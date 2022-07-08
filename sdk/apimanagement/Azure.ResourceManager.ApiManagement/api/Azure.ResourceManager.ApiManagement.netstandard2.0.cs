namespace Azure.ResourceManager.ApiManagement
{
    public partial class AccessInformationContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>, System.Collections.IEnumerable
    {
        protected AccessInformationContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, string ifMatch, Azure.ResourceManager.ApiManagement.Models.AccessInformationContractCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, string ifMatch, Azure.ResourceManager.ApiManagement.Models.AccessInformationContractCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> Get(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessInformationContractData : Azure.ResourceManager.Models.ResourceData
    {
        public AccessInformationContractData() { }
        public bool? Enabled { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
    }
    public partial class AccessInformationContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessInformationContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.AccessInformationContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.AccessInformationSecretsContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.AccessInformationSecretsContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegeneratePrimaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegeneratePrimaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegeneratePrimaryKeyTenantAccessGit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegeneratePrimaryKeyTenantAccessGitAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateSecondaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateSecondaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateSecondaryKeyTenantAccessGit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateSecondaryKeyTenantAccessGitAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.AccessInformationContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.AccessInformationContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiContractResource>, System.Collections.IEnumerable
    {
        protected ApiContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiId, Azure.ResourceManager.ApiManagement.Models.ApiContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiId, Azure.ResourceManager.ApiManagement.Models.ApiContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource> Get(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, bool? expandApiVersionSet = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, bool? expandApiVersionSet = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource>> GetAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiContractData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiContractData() { }
        public string ApiRevision { get { throw null; } set { } }
        public string ApiRevisionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public string ApiVersionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } set { } }
        public string ApiVersionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public bool? IsOnline { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.Protocol> Protocols { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public string SourceApiId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
    }
    public partial class ApiContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, bool? deleteRevisions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, bool? deleteRevisions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ProductContractResource> GetApiProductsByApis(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ProductContractResource> GetApiProductsByApisAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> GetApiReleaseContract(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>> GetApiReleaseContractAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiReleaseContractCollection GetApiReleaseContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiRevisionContract> GetApiRevisionsByService(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiRevisionContract> GetApiRevisionsByServiceAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OperationContractResource> GetOperationContract(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContractResource>> GetOperationContractAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.OperationContractCollection GetOperationContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetOperationsByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedOperations = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetOperationsByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedOperations = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContractResource> GetSchemaContract(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContractResource>> GetSchemaContractAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.SchemaContractCollection GetSchemaContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> GetServiceApiDiagnostic(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>> GetServiceApiDiagnosticAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticCollection GetServiceApiDiagnostics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> GetServiceApiIssue(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>> GetServiceApiIssueAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceApiIssueCollection GetServiceApiIssues() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceApiPolicyCollection GetServiceApiPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> GetServiceApiPolicy(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>> GetServiceApiPolicyAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> GetServiceApiTag(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>> GetServiceApiTagAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceApiTagCollection GetServiceApiTags() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> GetTagDescriptionContract(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>> GetTagDescriptionContractAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.TagDescriptionContractCollection GetTagDescriptionContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ApiManagementExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameAvailabilityResult> CheckNameAvailabilityApiManagementService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameAvailabilityResult>> CheckNameAvailabilityApiManagementServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.AccessInformationContractResource GetAccessInformationContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiContractResource GetApiContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource GetApiManagementPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource GetApiManagementPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementServiceResource GetApiManagementServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetApiManagementServiceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetApiManagementServiceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceCollection GetApiManagementServiceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetApiManagementServiceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetApiManagementServiceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementSku> GetApiManagementSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementSku> GetApiManagementSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiReleaseContractResource GetApiReleaseContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource GetApiVersionSetContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource GetAuthorizationServerContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.BackendContractResource GetBackendContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.CacheContractResource GetCacheContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.CertificateContractResource GetCertificateContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ContentItemContractResource GetContentItemContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ContentTypeContractResource GetContentTypeContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContractResource> GetDeletedServiceContract(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContractResource>> GetDeletedServiceContractAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.DeletedServiceContractResource GetDeletedServiceContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.DeletedServiceContractCollection GetDeletedServiceContracts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.DeletedServiceContractResource> GetDeletedServiceContracts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.DeletedServiceContractResource> GetDeletedServiceContractsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetDomainOwnershipIdentifierResult> GetDomainOwnershipIdentifierApiManagementService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetDomainOwnershipIdentifierResult>> GetDomainOwnershipIdentifierApiManagementServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.EmailTemplateContractResource GetEmailTemplateContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource GetGatewayCertificateAuthorityContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GatewayContractResource GetGatewayContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource GetGatewayHostnameConfigurationContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource GetGlobalSchemaContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GroupContractResource GetGroupContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.IdentityProviderContractResource GetIdentityProviderContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource GetIssueAttachmentContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.IssueCommentContractResource GetIssueCommentContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.LoggerContractResource GetLoggerContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.NamedValueContractResource GetNamedValueContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.NotificationContractResource GetNotificationContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource GetOpenIdConnectProviderContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.OperationContractResource GetOperationContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PortalDelegationSettingsResource GetPortalDelegationSettingsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PortalRevisionContractResource GetPortalRevisionContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PortalSigninSettingsResource GetPortalSigninSettingsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PortalSignupSettingsResource GetPortalSignupSettingsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ProductContractResource GetProductContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.SchemaContractResource GetSchemaContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource GetServiceApiDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiIssueResource GetServiceApiIssueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource GetServiceApiOperationPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource GetServiceApiOperationTagResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource GetServiceApiPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiTagResource GetServiceApiTagResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource GetServiceDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceIssueResource GetServiceIssueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServicePolicyResource GetServicePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource GetServiceProductPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceProductTagResource GetServiceProductTagResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource GetServiceSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceTagResource GetServiceTagResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource GetServiceUserSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.TagDescriptionContractResource GetTagDescriptionContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.TenantSettingsContractResource GetTenantSettingsContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.UserContractResource GetUserContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ApiManagementPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ApiManagementPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ApiManagementPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPrivateLinkResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string privateLinkSubResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected ApiManagementPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> Get(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>> GetAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class ApiManagementServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementServiceResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> ApplyNetworkConfigurationUpdates(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceApplyNetworkConfigurationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> ApplyNetworkConfigurationUpdatesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceApplyNetworkConfigurationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Backup(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreParameters apiManagementServiceBackupRestoreParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> BackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreParameters apiManagementServiceBackupRestoreParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract> DeployTenantConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.DeployConfigurationParameters deployConfigurationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> DeployTenantConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.DeployConfigurationParameters deployConfigurationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContractResource> GetAccessInformationContract(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContractResource>> GetAccessInformationContractAsync(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.AccessInformationContractCollection GetAccessInformationContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource> GetApiContract(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource>> GetApiContractAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiContractCollection GetApiContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> GetApiManagementPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> GetApiManagementPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionCollection GetApiManagementPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> GetApiManagementPrivateLinkResource(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>> GetApiManagementPrivateLinkResourceAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResourceCollection GetApiManagementPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetApisByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedApis = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetApisByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedApis = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> GetApiVersionSetContract(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>> GetApiVersionSetContractAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiVersionSetContractCollection GetApiVersionSetContracts() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> GetAuthorizationServerContract(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>> GetAuthorizationServerContractAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.AuthorizationServerContractCollection GetAuthorizationServerContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ResourceSkuResult> GetAvailableServiceSkusApiManagementServiceSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ResourceSkuResult> GetAvailableServiceSkusApiManagementServiceSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.BackendContractResource> GetBackendContract(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContractResource>> GetBackendContractAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.BackendContractCollection GetBackendContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CacheContractResource> GetCacheContract(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContractResource>> GetCacheContractAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.CacheContractCollection GetCacheContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContractResource> GetCertificateContract(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContractResource>> GetCertificateContractAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.CertificateContractCollection GetCertificateContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> GetContentTypeContract(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>> GetContentTypeContractAsync(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ContentTypeContractCollection GetContentTypeContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> GetEmailTemplateContract(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>> GetEmailTemplateContractAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.EmailTemplateContractCollection GetEmailTemplateContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContractResource> GetGatewayContract(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContractResource>> GetGatewayContractAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.GatewayContractCollection GetGatewayContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> GetGlobalSchemaContract(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>> GetGlobalSchemaContractAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.GlobalSchemaContractCollection GetGlobalSchemaContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource> GetGroupContract(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource>> GetGroupContractAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.GroupContractCollection GetGroupContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> GetIdentityProviderContract(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>> GetIdentityProviderContractAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.IdentityProviderContractCollection GetIdentityProviderContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContractResource> GetLoggerContract(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContractResource>> GetLoggerContractAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.LoggerContractCollection GetLoggerContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContractResource> GetNamedValueContract(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContractResource>> GetNamedValueContractAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.NamedValueContractCollection GetNamedValueContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract> GetNetworkStatusByLocation(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract>> GetNetworkStatusByLocationAsync(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContractByLocation> GetNetworkStatusesByService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContractByLocation> GetNetworkStatusesByServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContractResource> GetNotificationContract(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContractResource>> GetNotificationContractAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.NotificationContractCollection GetNotificationContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> GetOpenIdConnectProviderContract(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>> GetOpenIdConnectProviderContractAsync(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractCollection GetOpenIdConnectProviderContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsByService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsByServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.PolicyDescriptionContract> GetPolicyDescriptionsByService(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract? scope = default(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.PolicyDescriptionContract> GetPolicyDescriptionsByServiceAsync(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract? scope = default(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.PortalDelegationSettingsResource GetPortalDelegationSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> GetPortalRevisionContract(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>> GetPortalRevisionContractAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.PortalRevisionContractCollection GetPortalRevisionContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.PortalSettingsContract> GetPortalSettingsByService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.PortalSettingsContract> GetPortalSettingsByServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.PortalSigninSettingsResource GetPortalSigninSettings() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.PortalSignupSettingsResource GetPortalSignupSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ProductContractResource> GetProductContract(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContractResource>> GetProductContractAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ProductContractCollection GetProductContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetProductsByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedProducts = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetProductsByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedProducts = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> GetQuotaByCounterKeysByService(string quotaCounterKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> GetQuotaByCounterKeysByServiceAsync(string quotaCounterKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> GetQuotaByPeriodKey(string quotaCounterKey, string quotaPeriodKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>> GetQuotaByPeriodKeyAsync(string quotaCounterKey, string quotaPeriodKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.RegionContract> GetRegionsByService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.RegionContract> GetRegionsByServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByApi(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByApiAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByGeo(string filter, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByGeoAsync(string filter, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByOperation(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByOperationAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByProduct(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByProductAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.RequestReportRecordContract> GetReportsByRequest(string filter, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.RequestReportRecordContract> GetReportsByRequestAsync(string filter, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsBySubscription(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsBySubscriptionAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByTime(string filter, System.TimeSpan interval, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByTimeAsync(string filter, System.TimeSpan interval, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByUser(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByUserAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> GetServiceDiagnostic(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>> GetServiceDiagnosticAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceDiagnosticCollection GetServiceDiagnostics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssueResource> GetServiceIssue(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssueResource>> GetServiceIssueAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceIssueCollection GetServiceIssues() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServicePolicyCollection GetServicePolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicyResource> GetServicePolicy(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicyResource>> GetServicePolicyAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> GetServiceSubscription(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>> GetServiceSubscriptionAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceSubscriptionCollection GetServiceSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTagResource> GetServiceTag(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTagResource>> GetServiceTagAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceTagCollection GetServiceTags() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetSsoTokenResult> GetSsoToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetSsoTokenResult>> GetSsoTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationSyncStateContract> GetSyncStateTenantConfiguration(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationSyncStateContract>> GetSyncStateTenantConfigurationAsync(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetTagResourcesByService(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetTagResourcesByServiceAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource> GetTenantSettingsContract(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource>> GetTenantSettingsContractAsync(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.TenantSettingsContractCollection GetTenantSettingsContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource> GetUserContract(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource>> GetUserContractAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.UserContractCollection GetUserContracts() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckResponse> PerformConnectivityCheckAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckResponse>> PerformConnectivityCheckAsyncAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Restore(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreParameters apiManagementServiceBackupRestoreParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> RestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreParameters apiManagementServiceBackupRestoreParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract> SaveTenantConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.SaveConfigurationParameter saveConfigurationParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> SaveTenantConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.SaveConfigurationParameter saveConfigurationParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> UpdateQuotaByCounterKeys(string quotaCounterKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContract quotaCounterValueUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> UpdateQuotaByCounterKeysAsync(string quotaCounterKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContract quotaCounterValueUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> UpdateQuotaByPeriodKey(string quotaCounterKey, string quotaPeriodKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContract quotaCounterValueUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>> UpdateQuotaByPeriodKeyAsync(string quotaCounterKey, string quotaPeriodKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContract quotaCounterValueUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract> ValidateTenantConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.DeployConfigurationParameters deployConfigurationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> ValidateTenantConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.DeployConfigurationParameters deployConfigurationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>, System.Collections.IEnumerable
    {
        protected ApiManagementServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApiManagementServiceResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties sku, string publisherEmail, string publisherName) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AdditionalLocation> AdditionalLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.CertificateConfiguration> Certificates { get { throw null; } }
        public System.DateTimeOffset? CreatedAtUtc { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public System.Uri DeveloperPortalUri { get { throw null; } }
        public bool? DisableGateway { get { throw null; } set { } }
        public bool? EnableClientCertificate { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Uri GatewayRegionalUri { get { throw null; } }
        public System.Uri GatewayUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.HostnameConfiguration> HostnameConfigurations { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri ManagementApiUri { get { throw null; } }
        public string MinApiVersion { get { throw null; } set { } }
        public string NotificationSenderEmail { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public System.Uri PortalUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RemotePrivateEndpointConnectionWrapper> PrivateEndpointConnections { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PrivateIPAddresses { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PublicIPAddresses { get { throw null; } }
        public string PublicIPAddressId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PublisherEmail { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
        public bool? Restore { get { throw null; } set { } }
        public System.Uri ScmUri { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public string TargetProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ApiReleaseContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>, System.Collections.IEnumerable
    {
        protected ApiReleaseContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string releaseId, Azure.ResourceManager.ApiManagement.ApiReleaseContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string releaseId, Azure.ResourceManager.ApiManagement.ApiReleaseContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> Get(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>> GetAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiReleaseContractData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiReleaseContractData() { }
        public string ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class ApiReleaseContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiReleaseContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiReleaseContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string releaseId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionSetContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>, System.Collections.IEnumerable
    {
        protected ApiVersionSetContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionSetId, Azure.ResourceManager.ApiManagement.ApiVersionSetContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionSetId, Azure.ResourceManager.ApiManagement.ApiVersionSetContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> Get(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>> GetAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiVersionSetContractData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiVersionSetContractData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string VersionHeaderName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VersioningScheme? VersioningScheme { get { throw null; } set { } }
        public string VersionQueryName { get { throw null; } set { } }
    }
    public partial class ApiVersionSetContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiVersionSetContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiVersionSetContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string versionSetId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AuthorizationServerContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>, System.Collections.IEnumerable
    {
        protected AuthorizationServerContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authsid, Azure.ResourceManager.ApiManagement.AuthorizationServerContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authsid, Azure.ResourceManager.ApiManagement.AuthorizationServerContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> Get(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>> GetAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthorizationServerContractData : Azure.ResourceManager.Models.ResourceData
    {
        public AuthorizationServerContractData() { }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AuthorizationMethod> AuthorizationMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode> BearerTokenSendingMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod> ClientAuthenticationMethod { get { throw null; } }
        public string ClientId { get { throw null; } set { } }
        public string ClientRegistrationEndpoint { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string DefaultScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.GrantType> GrantTypes { get { throw null; } }
        public string ResourceOwnerPassword { get { throw null; } set { } }
        public string ResourceOwnerUsername { get { throw null; } set { } }
        public bool? SupportState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.TokenBodyParameterContract> TokenBodyParameters { get { throw null; } }
        public string TokenEndpoint { get { throw null; } set { } }
    }
    public partial class AuthorizationServerContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthorizationServerContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.AuthorizationServerContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string authsid) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.AuthorizationServerSecretsContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.AuthorizationServerSecretsContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.AuthorizationServerContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.AuthorizationServerContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackendContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.BackendContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.BackendContractResource>, System.Collections.IEnumerable
    {
        protected BackendContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.BackendContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backendId, Azure.ResourceManager.ApiManagement.BackendContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.BackendContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backendId, Azure.ResourceManager.ApiManagement.BackendContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.BackendContractResource> Get(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.BackendContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.BackendContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContractResource>> GetAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.BackendContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.BackendContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.BackendContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.BackendContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackendContractData : Azure.ResourceManager.Models.ResourceData
    {
        public BackendContractData() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendServiceFabricClusterProperties BackendServiceFabricCluster { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendCredentialsContract Credentials { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProxyContract Proxy { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendTlsProperties Tls { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class BackendContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackendContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.BackendContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string backendId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.BackendContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reconnect(Azure.ResourceManager.ApiManagement.Models.BackendReconnectContract backendReconnectContract = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReconnectAsync(Azure.ResourceManager.ApiManagement.Models.BackendReconnectContract backendReconnectContract = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.BackendContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.BackendContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.BackendContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CacheContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.CacheContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.CacheContractResource>, System.Collections.IEnumerable
    {
        protected CacheContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.CacheContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cacheId, Azure.ResourceManager.ApiManagement.CacheContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.CacheContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cacheId, Azure.ResourceManager.ApiManagement.CacheContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CacheContractResource> Get(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.CacheContractResource> GetAll(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.CacheContractResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContractResource>> GetAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.CacheContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.CacheContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.CacheContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.CacheContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CacheContractData : Azure.ResourceManager.Models.ResourceData
    {
        public CacheContractData() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string UseFromLocation { get { throw null; } set { } }
    }
    public partial class CacheContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CacheContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.CacheContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string cacheId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CacheContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CacheContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.CacheContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.CacheContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.CertificateContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.CertificateContractResource>, System.Collections.IEnumerable
    {
        protected CertificateContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.CertificateContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateId, Azure.ResourceManager.ApiManagement.Models.CertificateContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.CertificateContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateId, Azure.ResourceManager.ApiManagement.Models.CertificateContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContractResource> Get(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.CertificateContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.CertificateContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContractResource>> GetAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.CertificateContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.CertificateContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.CertificateContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.CertificateContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateContractData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateContractData() { }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractProperties KeyVault { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class CertificateContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.CertificateContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string certificateId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContractResource> RefreshSecret(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContractResource>> RefreshSecretAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.CertificateContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.CertificateContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.CertificateContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.CertificateContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentItemContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ContentItemContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ContentItemContractResource>, System.Collections.IEnumerable
    {
        protected ContentItemContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ContentItemContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contentItemId, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ContentItemContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contentItemId, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContractResource> Get(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ContentItemContractResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ContentItemContractResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContractResource>> GetAsync(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ContentItemContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ContentItemContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ContentItemContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ContentItemContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContentItemContractData : Azure.ResourceManager.Models.ResourceData
    {
        public ContentItemContractData() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
    }
    public partial class ContentItemContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContentItemContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ContentItemContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string contentTypeId, string contentItemId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ContentItemContractResource> Update(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ContentItemContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentTypeContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>, System.Collections.IEnumerable
    {
        protected ContentTypeContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contentTypeId, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contentTypeId, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> Get(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>> GetAsync(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContentTypeContractData : Azure.ResourceManager.Models.ResourceData
    {
        public ContentTypeContractData() { }
        public string Description { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ContentTypeContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContentTypeContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ContentTypeContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string contentTypeId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContractResource> GetContentItemContract(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContractResource>> GetContentItemContractAsync(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ContentItemContractCollection GetContentItemContracts() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ContentTypeContractResource> Update(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ContentTypeContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedServiceContractCollection : Azure.ResourceManager.ArmCollection
    {
        protected DeletedServiceContractCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContractResource> Get(Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContractResource>> GetAsync(Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedServiceContractData : Azure.ResourceManager.Models.ResourceData
    {
        public DeletedServiceContractData() { }
        public System.DateTimeOffset? DeletionOn { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } set { } }
        public string ServiceId { get { throw null; } set { } }
    }
    public partial class DeletedServiceContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedServiceContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.DeletedServiceContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticContractData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticContractData() { }
        public Azure.ResourceManager.ApiManagement.Models.AlwaysLog? AlwaysLog { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PipelineDiagnosticSettings Backend { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PipelineDiagnosticSettings Frontend { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol? HttpCorrelationProtocol { get { throw null; } set { } }
        public bool? LogClientIP { get { throw null; } set { } }
        public string LoggerId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.OperationNameFormat? OperationNameFormat { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SamplingSettings Sampling { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.Verbosity? Verbosity { get { throw null; } set { } }
    }
    public partial class EmailTemplateContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>, System.Collections.IEnumerable
    {
        protected EmailTemplateContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, Azure.ResourceManager.ApiManagement.Models.EmailTemplateUpdateParameters emailTemplateUpdateParameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, Azure.ResourceManager.ApiManagement.Models.EmailTemplateUpdateParameters emailTemplateUpdateParameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> Get(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EmailTemplateContractData : Azure.ResourceManager.Models.ResourceData
    {
        public EmailTemplateContractData() { }
        public string Body { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.EmailTemplateParametersContractProperties> Parameters { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class EmailTemplateContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EmailTemplateContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.EmailTemplateContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.TemplateName templateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.EmailTemplateUpdateParameters emailTemplateUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.EmailTemplateUpdateParameters emailTemplateUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayCertificateAuthorityContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>, System.Collections.IEnumerable
    {
        protected GatewayCertificateAuthorityContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateId, Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateId, Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> Get(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>> GetAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayCertificateAuthorityContractData : Azure.ResourceManager.Models.ResourceData
    {
        public GatewayCertificateAuthorityContractData() { }
        public bool? IsTrusted { get { throw null; } set { } }
    }
    public partial class GatewayCertificateAuthorityContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GatewayCertificateAuthorityContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId, string certificateId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayContractResource>, System.Collections.IEnumerable
    {
        protected GatewayContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayId, Azure.ResourceManager.ApiManagement.GatewayContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayId, Azure.ResourceManager.ApiManagement.GatewayContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContractResource> Get(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GatewayContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GatewayContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContractResource>> GetAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GatewayContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GatewayContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayContractData : Azure.ResourceManager.Models.ResourceData
    {
        public GatewayContractData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ResourceLocationDataContract LocationData { get { throw null; } set { } }
    }
    public partial class GatewayContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GatewayContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.GatewayContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource> CreateOrUpdateGatewayApi(string apiId, Azure.ResourceManager.ApiManagement.Models.AssociationContract associationContract = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource>> CreateOrUpdateGatewayApiAsync(string apiId, Azure.ResourceManager.ApiManagement.Models.AssociationContract associationContract = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGatewayApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGatewayApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayTokenContract> GenerateToken(Azure.ResourceManager.ApiManagement.Models.GatewayTokenRequestContract gatewayTokenRequestContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayTokenContract>> GenerateTokenAsync(Azure.ResourceManager.ApiManagement.Models.GatewayTokenRequestContract gatewayTokenRequestContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTagGatewayApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagGatewayApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiContractResource> GetGatewayApisByService(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiContractResource> GetGatewayApisByServiceAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource> GetGatewayCertificateAuthorityContract(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractResource>> GetGatewayCertificateAuthorityContractAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractCollection GetGatewayCertificateAuthorityContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> GetGatewayHostnameConfigurationContract(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>> GetGatewayHostnameConfigurationContractAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractCollection GetGatewayHostnameConfigurationContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayKeysContract> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayKeysContract>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateKey(Azure.ResourceManager.ApiManagement.Models.GatewayKeyRegenerationRequestContract gatewayKeyRegenerationRequestContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateKeyAsync(Azure.ResourceManager.ApiManagement.Models.GatewayKeyRegenerationRequestContract gatewayKeyRegenerationRequestContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.GatewayContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.GatewayContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayHostnameConfigurationContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>, System.Collections.IEnumerable
    {
        protected GatewayHostnameConfigurationContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hcId, Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hcId, Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> Get(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>> GetAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayHostnameConfigurationContractData : Azure.ResourceManager.Models.ResourceData
    {
        public GatewayHostnameConfigurationContractData() { }
        public string CertificateId { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public bool? Http2Enabled { get { throw null; } set { } }
        public bool? NegotiateClientCertificate { get { throw null; } set { } }
        public bool? Tls10Enabled { get { throw null; } set { } }
        public bool? Tls11Enabled { get { throw null; } set { } }
    }
    public partial class GatewayHostnameConfigurationContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GatewayHostnameConfigurationContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId, string hcId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalSchemaContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>, System.Collections.IEnumerable
    {
        protected GlobalSchemaContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaId, Azure.ResourceManager.ApiManagement.GlobalSchemaContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaId, Azure.ResourceManager.ApiManagement.GlobalSchemaContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> Get(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>> GetAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalSchemaContractData : Azure.ResourceManager.Models.ResourceData
    {
        public GlobalSchemaContractData() { }
        public string Description { get { throw null; } set { } }
        public System.BinaryData Document { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SchemaType? SchemaType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class GlobalSchemaContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GlobalSchemaContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.GlobalSchemaContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string schemaId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.GlobalSchemaContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GlobalSchemaContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.GlobalSchemaContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GroupContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GroupContractResource>, System.Collections.IEnumerable
    {
        protected GroupContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GroupContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupId, Azure.ResourceManager.ApiManagement.Models.GroupContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.GroupContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupId, Azure.ResourceManager.ApiManagement.Models.GroupContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GroupContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GroupContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GroupContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GroupContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GroupContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GroupContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupContractData : Azure.ResourceManager.Models.ResourceData
    {
        public GroupContractData() { }
        public bool? BuiltIn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.GroupType? TypePropertiesType { get { throw null; } set { } }
    }
    public partial class GroupContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.GroupContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<bool> CheckEntityExistsGroupUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsGroupUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource> CreateGroupUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource>> CreateGroupUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string groupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGroupUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGroupUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.UserContractResource> GetGroupUsers(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.UserContractResource> GetGroupUsersAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.GroupContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.GroupContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IdentityProviderContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>, System.Collections.IEnumerable
    {
        protected IdentityProviderContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, Azure.ResourceManager.ApiManagement.Models.IdentityProviderContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, Azure.ResourceManager.ApiManagement.Models.IdentityProviderContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> Get(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IdentityProviderContractData : Azure.ResourceManager.Models.ResourceData
    {
        public IdentityProviderContractData() { }
        public System.Collections.Generic.IList<string> AllowedTenants { get { throw null; } }
        public string Authority { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string PasswordResetPolicyName { get { throw null; } set { } }
        public string ProfileEditingPolicyName { get { throw null; } set { } }
        public string SigninPolicyName { get { throw null; } set { } }
        public string SigninTenant { get { throw null; } set { } }
        public string SignupPolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IdentityProviderType? TypePropertiesType { get { throw null; } set { } }
    }
    public partial class IdentityProviderContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IdentityProviderContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.IdentityProviderContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.IdentityProviderContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.IdentityProviderContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IssueAttachmentContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>, System.Collections.IEnumerable
    {
        protected IssueAttachmentContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachmentId, Azure.ResourceManager.ApiManagement.IssueAttachmentContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachmentId, Azure.ResourceManager.ApiManagement.IssueAttachmentContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> Get(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>> GetAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IssueAttachmentContractData : Azure.ResourceManager.Models.ResourceData
    {
        public IssueAttachmentContractData() { }
        public string Content { get { throw null; } set { } }
        public string ContentFormat { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class IssueAttachmentContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IssueAttachmentContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueAttachmentContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId, string attachmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.IssueAttachmentContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.IssueAttachmentContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IssueCommentContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>, System.Collections.IEnumerable
    {
        protected IssueCommentContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string commentId, Azure.ResourceManager.ApiManagement.IssueCommentContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string commentId, Azure.ResourceManager.ApiManagement.IssueCommentContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> Get(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>> GetAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IssueCommentContractData : Azure.ResourceManager.Models.ResourceData
    {
        public IssueCommentContractData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class IssueCommentContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IssueCommentContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueCommentContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId, string commentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.IssueCommentContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.IssueCommentContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IssueContractData : Azure.ResourceManager.Models.ResourceData
    {
        public IssueContractData() { }
        public string ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.State? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class LoggerContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.LoggerContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.LoggerContractResource>, System.Collections.IEnumerable
    {
        protected LoggerContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.LoggerContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loggerId, Azure.ResourceManager.ApiManagement.LoggerContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.LoggerContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loggerId, Azure.ResourceManager.ApiManagement.LoggerContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContractResource> Get(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.LoggerContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.LoggerContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContractResource>> GetAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.LoggerContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.LoggerContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.LoggerContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.LoggerContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoggerContractData : Azure.ResourceManager.Models.ResourceData
    {
        public LoggerContractData() { }
        public System.Collections.Generic.IDictionary<string, string> Credentials { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsBuffered { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.LoggerType? LoggerType { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class LoggerContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LoggerContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.LoggerContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string loggerId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.LoggerContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.LoggerContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamedValueContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.NamedValueContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.NamedValueContractResource>, System.Collections.IEnumerable
    {
        protected NamedValueContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NamedValueContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namedValueId, Azure.ResourceManager.ApiManagement.Models.NamedValueContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NamedValueContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namedValueId, Azure.ResourceManager.ApiManagement.Models.NamedValueContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContractResource> Get(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.NamedValueContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.NamedValueContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContractResource>> GetAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.NamedValueContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.NamedValueContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.NamedValueContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.NamedValueContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamedValueContractData : Azure.ResourceManager.Models.ResourceData
    {
        public NamedValueContractData() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractProperties KeyVault { get { throw null; } set { } }
        public bool? Secret { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class NamedValueContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamedValueContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.NamedValueContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string namedValueId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.NamedValueSecretContract> GetValue(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.NamedValueSecretContract>> GetValueAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NamedValueContractResource> RefreshSecret(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NamedValueContractResource>> RefreshSecretAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NamedValueContractResource> Update(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.ApiManagement.Models.NamedValueContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NamedValueContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.ApiManagement.Models.NamedValueContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.NotificationContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.NotificationContractResource>, System.Collections.IEnumerable
    {
        protected NotificationContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NotificationContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NotificationContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContractResource> Get(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.NotificationContractResource> GetAll(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.NotificationContractResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContractResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.NotificationContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.NotificationContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.NotificationContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.NotificationContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationContractData : Azure.ResourceManager.Models.ResourceData
    {
        public NotificationContractData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RecipientsContractProperties Recipients { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class NotificationContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.NotificationContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<bool> CheckEntityExistsNotificationRecipientEmail(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsNotificationRecipientEmailAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> CheckEntityExistsNotificationRecipientUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsNotificationRecipientUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract> CreateOrUpdateNotificationRecipientEmail(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract>> CreateOrUpdateNotificationRecipientEmailAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract> CreateOrUpdateNotificationRecipientUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract>> CreateOrUpdateNotificationRecipientUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName) { throw null; }
        public virtual Azure.Response DeleteNotificationRecipientEmail(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNotificationRecipientEmailAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteNotificationRecipientUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNotificationRecipientUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract> GetNotificationRecipientEmails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract> GetNotificationRecipientEmailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract> GetNotificationRecipientUsers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract> GetNotificationRecipientUsersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NotificationContractResource> Update(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.NotificationContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenIdConnectProviderContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>, System.Collections.IEnumerable
    {
        protected OpenIdConnectProviderContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string openId, Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string openId, Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> Get(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>> GetAsync(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OpenIdConnectProviderContractData : Azure.ResourceManager.Models.ResourceData
    {
        public OpenIdConnectProviderContractData() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string MetadataEndpoint { get { throw null; } set { } }
    }
    public partial class OpenIdConnectProviderContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OpenIdConnectProviderContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string openId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.OpenIdConnectProviderContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OpenIdConnectProviderContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.OpenIdConnectProviderContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.OperationContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.OperationContractResource>, System.Collections.IEnumerable
    {
        protected OperationContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.OperationContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ApiManagement.OperationContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.OperationContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ApiManagement.OperationContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OperationContractResource> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.OperationContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.OperationContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContractResource>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.OperationContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.OperationContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.OperationContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.OperationContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationContractData : Azure.ResourceManager.Models.ResourceData
    {
        public OperationContractData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public string Policies { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RequestContract Request { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ResponseContract> Responses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> TemplateParameters { get { throw null; } }
        public string UrlTemplate { get { throw null; } set { } }
    }
    public partial class OperationContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperationContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.OperationContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OperationContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyCollection GetServiceApiOperationPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> GetServiceApiOperationPolicy(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>> GetServiceApiOperationPolicyAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> GetServiceApiOperationTag(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>> GetServiceApiOperationTagAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceApiOperationTagCollection GetServiceApiOperationTags() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OperationContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.OperationContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.OperationContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyContractData : Azure.ResourceManager.Models.ResourceData
    {
        public PolicyContractData() { }
        public Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat? Format { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class PortalDelegationSettingsData : Azure.ResourceManager.Models.ResourceData
    {
        public PortalDelegationSettingsData() { }
        public bool? SubscriptionsEnabled { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UserRegistrationEnabled { get { throw null; } set { } }
        public string ValidationKey { get { throw null; } set { } }
    }
    public partial class PortalDelegationSettingsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PortalDelegationSettingsResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalDelegationSettingsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalDelegationSettingsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalDelegationSettingsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalDelegationSettingsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.PortalSettingValidationKeyContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.PortalSettingValidationKeyContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string ifMatch, Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PortalRevisionContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>, System.Collections.IEnumerable
    {
        protected PortalRevisionContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string portalRevisionId, Azure.ResourceManager.ApiManagement.PortalRevisionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string portalRevisionId, Azure.ResourceManager.ApiManagement.PortalRevisionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> Get(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>> GetAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PortalRevisionContractData : Azure.ResourceManager.Models.ResourceData
    {
        public PortalRevisionContractData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class PortalRevisionContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PortalRevisionContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PortalRevisionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string portalRevisionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource> Update(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.ApiManagement.PortalRevisionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalRevisionContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.ApiManagement.PortalRevisionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PortalSigninSettingsData : Azure.ResourceManager.Models.ResourceData
    {
        public PortalSigninSettingsData() { }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class PortalSigninSettingsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PortalSigninSettingsResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PortalSigninSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalSigninSettingsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PortalSigninSettingsData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalSigninSettingsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PortalSigninSettingsData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalSigninSettingsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalSigninSettingsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string ifMatch, Azure.ResourceManager.ApiManagement.PortalSigninSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.PortalSigninSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PortalSignupSettingsData : Azure.ResourceManager.Models.ResourceData
    {
        public PortalSignupSettingsData() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.TermsOfServiceProperties TermsOfService { get { throw null; } set { } }
    }
    public partial class PortalSignupSettingsResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PortalSignupSettingsResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PortalSignupSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalSignupSettingsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PortalSignupSettingsData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalSignupSettingsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PortalSignupSettingsData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalSignupSettingsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalSignupSettingsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string ifMatch, Azure.ResourceManager.ApiManagement.PortalSignupSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.PortalSignupSettingsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProductContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ProductContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ProductContractResource>, System.Collections.IEnumerable
    {
        protected ProductContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ProductContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string productId, Azure.ResourceManager.ApiManagement.ProductContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ProductContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string productId, Azure.ResourceManager.ApiManagement.ProductContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ProductContractResource> Get(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ProductContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ProductContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContractResource>> GetAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ProductContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ProductContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ProductContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ProductContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProductContractData : Azure.ResourceManager.Models.ResourceData
    {
        public ProductContractData() { }
        public bool? ApprovalRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ProductState? State { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public int? SubscriptionsLimit { get { throw null; } set { } }
        public string Terms { get { throw null; } set { } }
    }
    public partial class ProductContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProductContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ProductContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<bool> CheckEntityExistsProductApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsProductApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> CheckEntityExistsProductGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsProductGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource> CreateOrUpdateProductApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractResource>> CreateOrUpdateProductApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource> CreateOrUpdateProductGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractResource>> CreateOrUpdateProductGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, bool? deleteSubscriptions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, bool? deleteSubscriptions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteProductApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteProductApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteProductGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteProductGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ProductContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiContractResource> GetProductApis(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiContractResource> GetProductApisAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GroupContractResource> GetProductGroups(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GroupContractResource> GetProductGroupsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> GetProductSubscriptions(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> GetProductSubscriptionsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceProductPolicyCollection GetServiceProductPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> GetServiceProductPolicy(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>> GetServiceProductPolicyAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> GetServiceProductTag(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>> GetServiceProductTagAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceProductTagCollection GetServiceProductTags() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ProductContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ProductContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ProductContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchemaContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.SchemaContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.SchemaContractResource>, System.Collections.IEnumerable
    {
        protected SchemaContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.SchemaContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaId, Azure.ResourceManager.ApiManagement.SchemaContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.SchemaContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaId, Azure.ResourceManager.ApiManagement.SchemaContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContractResource> Get(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.SchemaContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.SchemaContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContractResource>> GetAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.SchemaContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.SchemaContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.SchemaContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.SchemaContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SchemaContractData : Azure.ResourceManager.Models.ResourceData
    {
        public SchemaContractData() { }
        public System.BinaryData Components { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public System.BinaryData Definitions { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SchemaContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SchemaContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.SchemaContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string schemaId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.SchemaContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.SchemaContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.SchemaContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.SchemaContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiDiagnosticCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>, System.Collections.IEnumerable
    {
        protected ServiceApiDiagnosticCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> Get(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>> GetAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceApiDiagnosticResource() { }
        public virtual Azure.ResourceManager.ApiManagement.DiagnosticContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string diagnosticId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiIssueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>, System.Collections.IEnumerable
    {
        protected ServiceApiIssueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string issueId, Azure.ResourceManager.ApiManagement.IssueContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string issueId, Azure.ResourceManager.ApiManagement.IssueContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> Get(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> GetAll(string filter = null, bool? expandCommentsAttachments = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> GetAllAsync(string filter = null, bool? expandCommentsAttachments = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>> GetAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiIssueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceApiIssueResource() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> Get(bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>> GetAsync(bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource> GetIssueAttachmentContract(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContractResource>> GetIssueAttachmentContractAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.IssueAttachmentContractCollection GetIssueAttachmentContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContractResource> GetIssueCommentContract(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContractResource>> GetIssueCommentContractAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.IssueCommentContractCollection GetIssueCommentContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ServiceApiIssuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssueResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ServiceApiIssuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiOperationPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>, System.Collections.IEnumerable
    {
        protected ServiceApiOperationPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiOperationPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceApiOperationPolicyResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiOperationTagCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>, System.Collections.IEnumerable
    {
        protected ServiceApiOperationTagCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiOperationTagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceApiOperationTagResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByOperation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByOperationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiOperationTagResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>, System.Collections.IEnumerable
    {
        protected ServiceApiPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceApiPolicyResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiTagCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>, System.Collections.IEnumerable
    {
        protected ServiceApiTagCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiTagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceApiTagResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByApi(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByApiAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiTagResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceApiTagResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceDiagnosticCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>, System.Collections.IEnumerable
    {
        protected ServiceDiagnosticCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> Get(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>> GetAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceDiagnosticResource() { }
        public virtual Azure.ResourceManager.ApiManagement.DiagnosticContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string diagnosticId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnosticResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceIssueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceIssueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceIssueResource>, System.Collections.IEnumerable
    {
        protected ServiceIssueCollection() { }
        public virtual Azure.Response<bool> Exists(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssueResource> Get(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceIssueResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceIssueResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssueResource>> GetAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceIssueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceIssueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceIssueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceIssueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceIssueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceIssueResource() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string issueId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServicePolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServicePolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServicePolicyResource>, System.Collections.IEnumerable
    {
        protected ServicePolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServicePolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServicePolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServicePolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServicePolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServicePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServicePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServicePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServicePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServicePolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServicePolicyResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServicePolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServicePolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceProductPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>, System.Collections.IEnumerable
    {
        protected ServiceProductPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceProductPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceProductPolicyResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId, Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceProductPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceProductTagCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>, System.Collections.IEnumerable
    {
        protected ServiceProductTagCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceProductTagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceProductTagResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByProduct(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByProductAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceProductTagResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceProductTagResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ServiceSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sid, Azure.ResourceManager.ApiManagement.Models.ServiceSubscriptionCreateOrUpdateContent content, bool? notify = default(bool?), string ifMatch = null, Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sid, Azure.ResourceManager.ApiManagement.Models.ServiceSubscriptionCreateOrUpdateContent content, bool? notify = default(bool?), string ifMatch = null, Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> Get(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>> GetAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceSubscriptionResource() { }
        public virtual Azure.ResourceManager.ApiManagement.SubscriptionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string sid) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.SubscriptionKeysContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.SubscriptionKeysContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegeneratePrimaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegeneratePrimaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateSecondaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateSecondaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ServiceSubscriptionPatch patch, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscriptionResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ServiceSubscriptionPatch patch, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceTagCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceTagResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceTagResource>, System.Collections.IEnumerable
    {
        protected ServiceTagCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceTagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagId, Azure.ResourceManager.ApiManagement.Models.TagCreateUpdateParameters tagCreateUpdateParameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceTagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagId, Azure.ResourceManager.ApiManagement.Models.TagCreateUpdateParameters tagCreateUpdateParameters, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTagResource> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceTagResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceTagResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTagResource>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceTagResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceTagResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceTagResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceTagResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceTagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceTagResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityState(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTagResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.TagCreateUpdateParameters tagCreateUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTagResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.TagCreateUpdateParameters tagCreateUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceUserSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ServiceUserSubscriptionCollection() { }
        public virtual Azure.Response<bool> Exists(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource> Get(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource>> GetAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceUserSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceUserSubscriptionResource() { }
        public virtual Azure.ResourceManager.ApiManagement.SubscriptionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string userId, string sid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionContractData : Azure.ResourceManager.Models.ResourceData
    {
        public SubscriptionContractData() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } set { } }
        public System.DateTimeOffset? NotificationOn { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
        public string StateComment { get { throw null; } set { } }
    }
    public partial class TagContractData : Azure.ResourceManager.Models.ResourceData
    {
        public TagContractData() { }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class TagDescriptionContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>, System.Collections.IEnumerable
    {
        protected TagDescriptionContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagDescriptionId, Azure.ResourceManager.ApiManagement.Models.TagDescriptionContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagDescriptionId, Azure.ResourceManager.ApiManagement.Models.TagDescriptionContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> Get(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>> GetAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TagDescriptionContractData : Azure.ResourceManager.Models.ResourceData
    {
        public TagDescriptionContractData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalDocsDescription { get { throw null; } set { } }
        public System.Uri ExternalDocsUri { get { throw null; } set { } }
        public string TagId { get { throw null; } set { } }
    }
    public partial class TagDescriptionContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TagDescriptionContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagDescriptionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string tagDescriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.TagDescriptionContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.TagDescriptionContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.TagDescriptionContractCreateOrUpdateContent content, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantSettingsContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource>, System.Collections.IEnumerable
    {
        protected TenantSettingsContractCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource> Get(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantSettingsContractData : Azure.ResourceManager.Models.ResourceData
    {
        public TenantSettingsContractData() { }
        public System.Collections.Generic.IDictionary<string, string> Settings { get { throw null; } }
    }
    public partial class TenantSettingsContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantSettingsContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TenantSettingsContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserContractCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.UserContractResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.UserContractResource>, System.Collections.IEnumerable
    {
        protected UserContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.UserContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string userId, Azure.ResourceManager.ApiManagement.Models.UserContractCreateOrUpdateContent content, bool? notify = default(bool?), string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.UserContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string userId, Azure.ResourceManager.ApiManagement.Models.UserContractCreateOrUpdateContent content, bool? notify = default(bool?), string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource> Get(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.UserContractResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.UserContractResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource>> GetAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.UserContractResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.UserContractResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.UserContractResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.UserContractResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserContractData : Azure.ResourceManager.Models.ResourceData
    {
        public UserContractData() { }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.GroupContractProperties> Groups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public System.DateTimeOffset? RegistrationOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.UserState? State { get { throw null; } set { } }
    }
    public partial class UserContractResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserContractResource() { }
        public virtual Azure.ResourceManager.ApiManagement.UserContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string userId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch, bool? deleteSubscriptions = default(bool?), bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch, bool? deleteSubscriptions = default(bool?), bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GenerateSsoUrlResult> GenerateSsoUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GenerateSsoUrlResult>> GenerateSsoUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource> GetServiceUserSubscription(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionResource>> GetServiceUserSubscriptionAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionCollection GetServiceUserSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.UserTokenResult> GetSharedAccessToken(Azure.ResourceManager.ApiManagement.Models.UserTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.UserTokenResult>> GetSharedAccessTokenAsync(Azure.ResourceManager.ApiManagement.Models.UserTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GroupContractResource> GetUserGroups(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GroupContractResource> GetUserGroupsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> GetUserIdentities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> GetUserIdentitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendUserConfirmationPassword(Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendUserConfirmationPasswordAsync(Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.UserContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContractResource>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.UserContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApiManagement.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessIdName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.AccessIdName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessIdName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.AccessIdName Access { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.AccessIdName GitAccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.AccessIdName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.AccessIdName left, Azure.ResourceManager.ApiManagement.Models.AccessIdName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.AccessIdName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.AccessIdName left, Azure.ResourceManager.ApiManagement.Models.AccessIdName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessInformationContractCreateOrUpdateContent
    {
        public AccessInformationContractCreateOrUpdateContent() { }
        public bool? Enabled { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    public partial class AccessInformationContractPatch
    {
        public AccessInformationContractPatch() { }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class AccessInformationSecretsContract
    {
        internal AccessInformationSecretsContract() { }
        public bool? Enabled { get { throw null; } }
        public string Id { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.AccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.AccessType AccessKey { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.AccessType SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.AccessType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.AccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.AccessType left, Azure.ResourceManager.ApiManagement.Models.AccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.AccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.AccessType left, Azure.ResourceManager.ApiManagement.Models.AccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdditionalLocation
    {
        public AdditionalLocation(Azure.Core.AzureLocation location, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties sku) { }
        public bool? DisableGateway { get { throw null; } set { } }
        public System.Uri GatewayRegionalUri { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PrivateIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PublicIPAddresses { get { throw null; } }
        public string PublicIPAddressId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlwaysLog : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.AlwaysLog>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlwaysLog(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.AlwaysLog AllErrors { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.AlwaysLog other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.AlwaysLog left, Azure.ResourceManager.ApiManagement.Models.AlwaysLog right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.AlwaysLog (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.AlwaysLog left, Azure.ResourceManager.ApiManagement.Models.AlwaysLog right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiContactInformation
    {
        public ApiContactInformation() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ApiContractCreateOrUpdateContent
    {
        public ApiContractCreateOrUpdateContent() { }
        public string ApiRevision { get { throw null; } set { } }
        public string ApiRevisionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public string ApiVersionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } set { } }
        public string ApiVersionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ContentFormat? Format { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public bool? IsOnline { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.Protocol> Protocols { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SoapApiType? SoapApiType { get { throw null; } set { } }
        public string SourceApiId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector { get { throw null; } set { } }
    }
    public partial class ApiContractPatch
    {
        public ApiContractPatch() { }
        public string ApiRevision { get { throw null; } set { } }
        public string ApiRevisionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public string ApiVersionDescription { get { throw null; } set { } }
        public string ApiVersionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public bool? IsOnline { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.Protocol> Protocols { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
    }
    public partial class ApiCreateOrUpdatePropertiesWsdlSelector
    {
        public ApiCreateOrUpdatePropertiesWsdlSelector() { }
        public string WsdlEndpointName { get { throw null; } set { } }
        public string WsdlServiceName { get { throw null; } set { } }
    }
    public partial class ApiEntityBaseContract
    {
        internal ApiEntityBaseContract() { }
        public string ApiRevision { get { throw null; } }
        public string ApiRevisionDescription { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } }
        public string ApiVersion { get { throw null; } }
        public string ApiVersionDescription { get { throw null; } }
        public string ApiVersionSetId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsCurrent { get { throw null; } }
        public bool? IsOnline { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } }
        public bool? SubscriptionRequired { get { throw null; } }
        public System.Uri TermsOfServiceUri { get { throw null; } }
    }
    public partial class ApiLicenseInformation
    {
        public ApiLicenseInformation() { }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ApiManagementPrivateEndpointConnectionCreateOrUpdateContent
    {
        public ApiManagementPrivateEndpointConnectionCreateOrUpdateContent() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiManagementPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiManagementPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiManagementPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiManagementPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiManagementPrivateLinkServiceConnectionState
    {
        public ApiManagementPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ApiManagementServiceApplyNetworkConfigurationContent
    {
        public ApiManagementServiceApplyNetworkConfigurationContent() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class ApiManagementServiceBackupRestoreParameters
    {
        public ApiManagementServiceBackupRestoreParameters(string storageAccount, string containerName, string backupName) { }
        public string AccessKey { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AccessType? AccessType { get { throw null; } set { } }
        public string BackupName { get { throw null; } }
        public string ClientId { get { throw null; } set { } }
        public string ContainerName { get { throw null; } }
        public string StorageAccount { get { throw null; } }
    }
    public partial class ApiManagementServiceCheckNameAvailabilityContent
    {
        public ApiManagementServiceCheckNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class ApiManagementServiceGetDomainOwnershipIdentifierResult
    {
        internal ApiManagementServiceGetDomainOwnershipIdentifierResult() { }
        public string DomainOwnershipIdentifier { get { throw null; } }
    }
    public partial class ApiManagementServiceGetSsoTokenResult
    {
        internal ApiManagementServiceGetSsoTokenResult() { }
        public System.Uri RedirectUri { get { throw null; } }
    }
    public partial class ApiManagementServiceNameAvailabilityResult
    {
        internal ApiManagementServiceNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.NameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class ApiManagementServiceResourcePatch : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementServiceResourcePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AdditionalLocation> AdditionalLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.CertificateConfiguration> Certificates { get { throw null; } }
        public System.DateTimeOffset? CreatedAtUtc { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public System.Uri DeveloperPortalUri { get { throw null; } }
        public bool? DisableGateway { get { throw null; } set { } }
        public bool? EnableClientCertificate { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Uri GatewayRegionalUri { get { throw null; } }
        public System.Uri GatewayUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.HostnameConfiguration> HostnameConfigurations { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri ManagementApiUri { get { throw null; } }
        public string MinApiVersion { get { throw null; } set { } }
        public string NotificationSenderEmail { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public System.Uri PortalUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RemotePrivateEndpointConnectionWrapper> PrivateEndpointConnections { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PrivateIPAddresses { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PublicIPAddresses { get { throw null; } }
        public string PublicIPAddressId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PublisherEmail { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
        public bool? Restore { get { throw null; } set { } }
        public System.Uri ScmUri { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ApiManagementServiceSkuProperties
    {
        public ApiManagementServiceSkuProperties(Azure.ResourceManager.ApiManagement.Models.SkuType name, int capacity) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SkuType Name { get { throw null; } set { } }
    }
    public partial class ApiManagementSku
    {
        internal ApiManagementSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ApiManagementSkuCapabilities
    {
        internal ApiManagementSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ApiManagementSkuCapacity
    {
        internal ApiManagementSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    public enum ApiManagementSkuCapacityScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public partial class ApiManagementSkuCosts
    {
        internal ApiManagementSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class ApiManagementSkuLocationInfo
    {
        internal ApiManagementSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ApiManagementSkuRestrictionInfo
    {
        internal ApiManagementSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ApiManagementSkuRestrictions
    {
        internal ApiManagementSkuRestrictions() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public enum ApiManagementSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum ApiManagementSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class ApiManagementSkuZoneDetails
    {
        internal ApiManagementSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    public partial class ApiRevisionContract
    {
        internal ApiRevisionContract() { }
        public string ApiId { get { throw null; } }
        public string ApiRevision { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsCurrent { get { throw null; } }
        public bool? IsOnline { get { throw null; } }
        public System.Uri PrivateUri { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class ApiTagResourceContractProperties : Azure.ResourceManager.ApiManagement.Models.ApiEntityBaseContract
    {
        internal ApiTagResourceContractProperties() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.Protocol> Protocols { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiType Graphql { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiType Http { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiType Soap { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiType Websocket { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiType left, Azure.ResourceManager.ApiManagement.Models.ApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiType left, Azure.ResourceManager.ApiManagement.Models.ApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiVersionSetContractDetails
    {
        public ApiVersionSetContractDetails() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string VersionHeaderName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme? VersioningScheme { get { throw null; } set { } }
        public string VersionQueryName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiVersionSetContractDetailsVersioningScheme : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiVersionSetContractDetailsVersioningScheme(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme Header { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme Query { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme Segment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme left, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme left, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetailsVersioningScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiVersionSetContractPatch
    {
        public ApiVersionSetContractPatch() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string VersionHeaderName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VersioningScheme? VersioningScheme { get { throw null; } set { } }
        public string VersionQueryName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.AppType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.AppType DeveloperPortal { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.AppType Portal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.AppType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.AppType left, Azure.ResourceManager.ApiManagement.Models.AppType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.AppType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.AppType left, Azure.ResourceManager.ApiManagement.Models.AppType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssociationContract : Azure.ResourceManager.Models.ResourceData
    {
        public AssociationContract() { }
        public Azure.ResourceManager.ApiManagement.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public enum AsyncOperationStatus
    {
        Started = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
    }
    public partial class AuthenticationSettingsContract
    {
        public AuthenticationSettingsContract() { }
        public Azure.ResourceManager.ApiManagement.Models.OAuth2AuthenticationSettingsContract OAuth2 { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.OpenIdAuthenticationSettingsContract Openid { get { throw null; } set { } }
    }
    public enum AuthorizationMethod
    {
        Head = 0,
        Options = 1,
        Trace = 2,
        GET = 3,
        Post = 4,
        PUT = 5,
        Patch = 6,
        Delete = 7,
    }
    public partial class AuthorizationServerContractPatch : Azure.ResourceManager.Models.ResourceData
    {
        public AuthorizationServerContractPatch() { }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AuthorizationMethod> AuthorizationMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode> BearerTokenSendingMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod> ClientAuthenticationMethod { get { throw null; } }
        public string ClientId { get { throw null; } set { } }
        public string ClientRegistrationEndpoint { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string DefaultScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.GrantType> GrantTypes { get { throw null; } }
        public string ResourceOwnerPassword { get { throw null; } set { } }
        public string ResourceOwnerUsername { get { throw null; } set { } }
        public bool? SupportState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.TokenBodyParameterContract> TokenBodyParameters { get { throw null; } }
        public string TokenEndpoint { get { throw null; } set { } }
    }
    public partial class AuthorizationServerSecretsContract
    {
        internal AuthorizationServerSecretsContract() { }
        public string ClientSecret { get { throw null; } }
        public string ResourceOwnerPassword { get { throw null; } }
        public string ResourceOwnerUsername { get { throw null; } }
    }
    public partial class BackendAuthorizationHeaderCredentials
    {
        public BackendAuthorizationHeaderCredentials(string scheme, string parameter) { }
        public string Parameter { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
    }
    public partial class BackendContractPatch
    {
        public BackendContractPatch() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendServiceFabricClusterProperties BackendServiceFabricCluster { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendCredentialsContract Credentials { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProxyContract Proxy { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendTlsProperties Tls { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class BackendCredentialsContract
    {
        public BackendCredentialsContract() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendAuthorizationHeaderCredentials Authorization { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Certificate { get { throw null; } }
        public System.Collections.Generic.IList<string> CertificateIds { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Header { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Query { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackendProtocol : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.BackendProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackendProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.BackendProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.BackendProtocol Soap { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.BackendProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.BackendProtocol left, Azure.ResourceManager.ApiManagement.Models.BackendProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.BackendProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.BackendProtocol left, Azure.ResourceManager.ApiManagement.Models.BackendProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackendProxyContract
    {
        public BackendProxyContract(System.Uri uri) { }
        public string Password { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class BackendReconnectContract : Azure.ResourceManager.Models.ResourceData
    {
        public BackendReconnectContract() { }
        public System.TimeSpan? After { get { throw null; } set { } }
    }
    public partial class BackendServiceFabricClusterProperties
    {
        public BackendServiceFabricClusterProperties(System.Collections.Generic.IEnumerable<string> managementEndpoints) { }
        public string ClientCertificateId { get { throw null; } set { } }
        public string ClientCertificatethumbprint { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagementEndpoints { get { throw null; } }
        public int? MaxPartitionResolutionRetries { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ServerCertificateThumbprints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.X509CertificateName> ServerX509Names { get { throw null; } }
    }
    public partial class BackendTlsProperties
    {
        public BackendTlsProperties() { }
        public bool? ValidateCertificateChain { get { throw null; } set { } }
        public bool? ValidateCertificateName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BearerTokenSendingMethodContract : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BearerTokenSendingMethodContract(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract AuthorizationHeader { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract Query { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BearerTokenSendingMethodMode : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BearerTokenSendingMethodMode(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode AuthorizationHeader { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode Query { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CacheContractPatch
    {
        public CacheContractPatch() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string UseFromLocation { get { throw null; } set { } }
    }
    public partial class CertificateConfiguration
    {
        public CertificateConfiguration(Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName storeName) { }
        public Azure.ResourceManager.ApiManagement.Models.CertificateInformation Certificate { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
        public string EncodedCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName StoreName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateConfigurationStoreName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateConfigurationStoreName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName CertificateAuthority { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName Root { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName left, Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName left, Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateContractCreateOrUpdateContent
    {
        public CertificateContractCreateOrUpdateContent() { }
        public string Data { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
    }
    public partial class CertificateInformation
    {
        public CertificateInformation(System.DateTimeOffset expiry, string thumbprint, string subject) { }
        public System.DateTimeOffset Expiry { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateSource : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.CertificateSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateSource(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateSource BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateSource Custom { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateSource KeyVault { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateSource Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.CertificateSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.CertificateSource left, Azure.ResourceManager.ApiManagement.Models.CertificateSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.CertificateSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.CertificateSource left, Azure.ResourceManager.ApiManagement.Models.CertificateSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.CertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.CertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.CertificateStatus left, Azure.ResourceManager.ApiManagement.Models.CertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.CertificateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.CertificateStatus left, Azure.ResourceManager.ApiManagement.Models.CertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientAuthenticationMethod : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientAuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod Basic { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod Body { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod left, Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod left, Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClientSecretContract
    {
        internal ClientSecretContract() { }
        public string ClientSecret { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationIdName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationIdName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName Configuration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName left, Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName left, Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Confirmation : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.Confirmation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Confirmation(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.Confirmation Invite { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Confirmation Signup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.Confirmation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.Confirmation left, Azure.ResourceManager.ApiManagement.Models.Confirmation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.Confirmation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.Confirmation left, Azure.ResourceManager.ApiManagement.Models.Confirmation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectionStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.ConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.ConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectivityCheckContent
    {
        public ConnectivityCheckContent(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestSource source, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestDestination destination) { }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestDestination Destination { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion? PreferredIPVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestProtocolConfigurationHttpConfiguration ProtocolHttpConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestSource Source { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityCheckProtocol : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityCheckProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol TCP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol left, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol left, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectivityCheckRequestDestination
    {
        public ConnectivityCheckRequestDestination(string address, long port) { }
        public string Address { get { throw null; } }
        public long Port { get { throw null; } }
    }
    public partial class ConnectivityCheckRequestProtocolConfigurationHttpConfiguration
    {
        public ConnectivityCheckRequestProtocolConfigurationHttpConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.HttpHeader> Headers { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.Method? Method { get { throw null; } set { } }
        public System.Collections.Generic.IList<long> ValidStatusCodes { get { throw null; } }
    }
    public partial class ConnectivityCheckRequestSource
    {
        public ConnectivityCheckRequestSource(string region) { }
        public long? Instance { get { throw null; } set { } }
        public string Region { get { throw null; } }
    }
    public partial class ConnectivityCheckResponse
    {
        internal ConnectivityCheckResponse() { }
        public long? AvgLatencyInMs { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectionStatus? ConnectionStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ConnectivityHop> Hops { get { throw null; } }
        public long? MaxLatencyInMs { get { throw null; } }
        public long? MinLatencyInMs { get { throw null; } }
        public long? ProbesFailed { get { throw null; } }
        public long? ProbesSent { get { throw null; } }
    }
    public partial class ConnectivityHop
    {
        internal ConnectivityHop() { }
        public string Address { get { throw null; } }
        public string ConnectivityHopType { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ConnectivityIssue> Issues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NextHopIds { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class ConnectivityIssue
    {
        internal ConnectivityIssue() { }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, string>> Context { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.IssueType? IssueType { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.Origin? Origin { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.Severity? Severity { get { throw null; } }
    }
    public partial class ConnectivityStatusContract
    {
        internal ConnectivityStatusContract() { }
        public string Error { get { throw null; } }
        public bool IsOptional { get { throw null; } }
        public System.DateTimeOffset LastStatusChange { get { throw null; } }
        public System.DateTimeOffset LastUpdated { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityStatusType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityStatusType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType Failure { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType Initializing { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType left, Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType left, Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ContentFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat GraphqlLink { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat Openapi { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat OpenapiJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat OpenapiJsonLink { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat OpenapiLink { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat SwaggerJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat SwaggerLinkJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat WadlLinkJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat WadlXml { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat Wsdl { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat WsdlLink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ContentFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ContentFormat left, Azure.ResourceManager.ApiManagement.Models.ContentFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ContentFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ContentFormat left, Azure.ResourceManager.ApiManagement.Models.ContentFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMasking
    {
        public DataMasking() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.DataMaskingEntity> Headers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.DataMaskingEntity> QueryParams { get { throw null; } }
    }
    public partial class DataMaskingEntity
    {
        public DataMaskingEntity() { }
        public Azure.ResourceManager.ApiManagement.Models.DataMaskingMode? Mode { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMaskingMode : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.DataMaskingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMaskingMode(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.DataMaskingMode Hide { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.DataMaskingMode Mask { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.DataMaskingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.DataMaskingMode left, Azure.ResourceManager.ApiManagement.Models.DataMaskingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.DataMaskingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.DataMaskingMode left, Azure.ResourceManager.ApiManagement.Models.DataMaskingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeployConfigurationParameters
    {
        public DeployConfigurationParameters() { }
        public string Branch { get { throw null; } set { } }
        public bool? Force { get { throw null; } set { } }
    }
    public partial class EmailTemplateParametersContractProperties
    {
        public EmailTemplateParametersContractProperties() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class EmailTemplateUpdateParameters
    {
        public EmailTemplateUpdateParameters() { }
        public string Body { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.EmailTemplateParametersContractProperties> Parameters { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class EndpointDependency
    {
        internal EndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.EndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class EndpointDetail
    {
        internal EndpointDetail() { }
        public int? Port { get { throw null; } }
        public string Region { get { throw null; } }
    }
    public partial class ErrorFieldContract
    {
        public ErrorFieldContract() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
    }
    public partial class ErrorResponseBody
    {
        public ErrorResponseBody() { }
        public string Code { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ErrorFieldContract> Details { get { throw null; } }
        public string Message { get { throw null; } set { } }
    }
    public partial class GatewayKeyRegenerationRequestContract
    {
        public GatewayKeyRegenerationRequestContract(Azure.ResourceManager.ApiManagement.Models.KeyType keyType) { }
        public Azure.ResourceManager.ApiManagement.Models.KeyType KeyType { get { throw null; } }
    }
    public partial class GatewayKeysContract
    {
        internal GatewayKeysContract() { }
        public string Primary { get { throw null; } }
        public string Secondary { get { throw null; } }
    }
    public partial class GatewayTokenContract
    {
        internal GatewayTokenContract() { }
        public string Value { get { throw null; } }
    }
    public partial class GatewayTokenRequestContract
    {
        public GatewayTokenRequestContract(Azure.ResourceManager.ApiManagement.Models.KeyType keyType, System.DateTimeOffset expiry) { }
        public System.DateTimeOffset Expiry { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.KeyType KeyType { get { throw null; } }
    }
    public partial class GenerateSsoUrlResult
    {
        internal GenerateSsoUrlResult() { }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrantType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.GrantType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrantType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.GrantType AuthorizationCode { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.GrantType ClientCredentials { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.GrantType Implicit { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.GrantType ResourceOwnerPassword { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.GrantType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.GrantType left, Azure.ResourceManager.ApiManagement.Models.GrantType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.GrantType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.GrantType left, Azure.ResourceManager.ApiManagement.Models.GrantType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GroupContractCreateOrUpdateContent
    {
        public GroupContractCreateOrUpdateContent() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.GroupType? GroupType { get { throw null; } set { } }
    }
    public partial class GroupContractPatch
    {
        public GroupContractPatch() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.GroupType? GroupType { get { throw null; } set { } }
    }
    public partial class GroupContractProperties
    {
        internal GroupContractProperties() { }
        public bool? BuiltIn { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ExternalId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.GroupType? GroupType { get { throw null; } }
    }
    public enum GroupType
    {
        Custom = 0,
        System = 1,
        External = 2,
    }
    public partial class HostnameConfiguration
    {
        public HostnameConfiguration(Azure.ResourceManager.ApiManagement.Models.HostnameType hostnameType, string hostName) { }
        public Azure.ResourceManager.ApiManagement.Models.CertificateInformation Certificate { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.CertificateSource? CertificateSource { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.CertificateStatus? CertificateStatus { get { throw null; } set { } }
        public bool? DefaultSslBinding { get { throw null; } set { } }
        public string EncodedCertificate { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.HostnameType HostnameType { get { throw null; } set { } }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } set { } }
        public bool? NegotiateClientCertificate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostnameType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.HostnameType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostnameType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType DeveloperPortal { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType Management { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType Portal { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType Proxy { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType Scm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.HostnameType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.HostnameType left, Azure.ResourceManager.ApiManagement.Models.HostnameType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.HostnameType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.HostnameType left, Azure.ResourceManager.ApiManagement.Models.HostnameType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpCorrelationProtocol : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpCorrelationProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol Legacy { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol None { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol W3C { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol left, Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol left, Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpHeader
    {
        public HttpHeader(string name, string value) { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class HttpMessageDiagnostic
    {
        public HttpMessageDiagnostic() { }
        public int? BodyBytes { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.DataMasking DataMasking { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
    }
    public partial class IdentityProviderContractCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public IdentityProviderContractCreateOrUpdateContent() { }
        public System.Collections.Generic.IList<string> AllowedTenants { get { throw null; } }
        public string Authority { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string PasswordResetPolicyName { get { throw null; } set { } }
        public string ProfileEditingPolicyName { get { throw null; } set { } }
        public string SigninPolicyName { get { throw null; } set { } }
        public string SigninTenant { get { throw null; } set { } }
        public string SignupPolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IdentityProviderType? TypePropertiesType { get { throw null; } set { } }
    }
    public partial class IdentityProviderContractPatch
    {
        public IdentityProviderContractPatch() { }
        public System.Collections.Generic.IList<string> AllowedTenants { get { throw null; } }
        public string Authority { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string PasswordResetPolicyName { get { throw null; } set { } }
        public string ProfileEditingPolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IdentityProviderType? ProviderType { get { throw null; } set { } }
        public string SigninPolicyName { get { throw null; } set { } }
        public string SigninTenant { get { throw null; } set { } }
        public string SignupPolicyName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityProviderType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.IdentityProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityProviderType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Aad { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType AadB2C { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Facebook { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Google { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Microsoft { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Twitter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType left, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.IdentityProviderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType left, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IssueType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.IssueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IssueType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType AgentStopped { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType DnsResolution { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType GuestFirewall { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType NetworkSecurityRule { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType Platform { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType PortThrottled { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType SocketBind { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType Unknown { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType UserDefinedRoute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.IssueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.IssueType left, Azure.ResourceManager.ApiManagement.Models.IssueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.IssueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.IssueType left, Azure.ResourceManager.ApiManagement.Models.IssueType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class KeyVaultContractCreateProperties
    {
        public KeyVaultContractCreateProperties() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string SecretIdentifier { get { throw null; } set { } }
    }
    public partial class KeyVaultContractProperties : Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties
    {
        public KeyVaultContractProperties() { }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultLastAccessStatusContractProperties LastStatus { get { throw null; } set { } }
    }
    public partial class KeyVaultLastAccessStatusContractProperties
    {
        public KeyVaultLastAccessStatusContractProperties() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? TimeStampUtc { get { throw null; } set { } }
    }
    public partial class LoggerContractPatch
    {
        public LoggerContractPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Credentials { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsBuffered { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.LoggerType? LoggerType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoggerType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.LoggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoggerType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.LoggerType ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.LoggerType AzureEventHub { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.LoggerType AzureMonitor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.LoggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.LoggerType left, Azure.ResourceManager.ApiManagement.Models.LoggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.LoggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.LoggerType left, Azure.ResourceManager.ApiManagement.Models.LoggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Method : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.Method>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Method(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.Method GET { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Method Post { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.Method other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.Method left, Azure.ResourceManager.ApiManagement.Models.Method right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.Method (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.Method left, Azure.ResourceManager.ApiManagement.Models.Method right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum NameAvailabilityReason
    {
        Valid = 0,
        Invalid = 1,
        AlreadyExists = 2,
    }
    public partial class NamedValueContractCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public NamedValueContractCreateOrUpdateContent() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public bool? Secret { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class NamedValueContractPatch
    {
        public NamedValueContractPatch() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public bool? Secret { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class NamedValueSecretContract
    {
        internal NamedValueSecretContract() { }
        public string Value { get { throw null; } }
    }
    public partial class NetworkStatusContract
    {
        internal NetworkStatusContract() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusContract> ConnectivityStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DnsServers { get { throw null; } }
    }
    public partial class NetworkStatusContractByLocation
    {
        internal NetworkStatusContractByLocation() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract NetworkStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.NotificationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName AccountClosedPublisher { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName BCC { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName NewApplicationNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName NewIssuePublisherNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName PurchasePublisherNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName QuotaLimitApproachingPublisherNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName RequestPublisherNotificationMessage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.NotificationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.NotificationName left, Azure.ResourceManager.ApiManagement.Models.NotificationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.NotificationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.NotificationName left, Azure.ResourceManager.ApiManagement.Models.NotificationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OAuth2AuthenticationSettingsContract
    {
        public OAuth2AuthenticationSettingsContract() { }
        public string AuthorizationServerId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class OpenIdAuthenticationSettingsContract
    {
        public OpenIdAuthenticationSettingsContract() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethodContract> BearerTokenSendingMethods { get { throw null; } }
        public string OpenidProviderId { get { throw null; } set { } }
    }
    public partial class OpenIdConnectProviderContractPatch
    {
        public OpenIdConnectProviderContractPatch() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string MetadataEndpoint { get { throw null; } set { } }
    }
    public partial class OperationContractPatch
    {
        public OperationContractPatch() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public string Policies { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RequestContract Request { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ResponseContract> Responses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> TemplateParameters { get { throw null; } }
        public string UrlTemplate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationNameFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.OperationNameFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationNameFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.OperationNameFormat Name { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.OperationNameFormat Url { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.OperationNameFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.OperationNameFormat left, Azure.ResourceManager.ApiManagement.Models.OperationNameFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.OperationNameFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.OperationNameFormat left, Azure.ResourceManager.ApiManagement.Models.OperationNameFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationResultContract : Azure.ResourceManager.Models.ResourceData
    {
        public OperationResultContract() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.OperationResultLogItemContract> ActionLog { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ErrorResponseBody Error { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } set { } }
        public string ResultInfo { get { throw null; } set { } }
        public System.DateTimeOffset? Started { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AsyncOperationStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? Updated { get { throw null; } set { } }
    }
    public partial class OperationResultLogItemContract
    {
        internal OperationResultLogItemContract() { }
        public string Action { get { throw null; } }
        public string ObjectKey { get { throw null; } }
        public string ObjectType { get { throw null; } }
    }
    public partial class OperationTagResourceContractProperties
    {
        internal OperationTagResourceContractProperties() { }
        public string ApiName { get { throw null; } }
        public string ApiRevision { get { throw null; } }
        public string ApiVersion { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Method { get { throw null; } }
        public string Name { get { throw null; } }
        public string UrlTemplate { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Origin : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.Origin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Origin(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.Origin Inbound { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Origin Local { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Origin Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.Origin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.Origin left, Azure.ResourceManager.ApiManagement.Models.Origin right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.Origin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.Origin left, Azure.ResourceManager.ApiManagement.Models.Origin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    public partial class ParameterContract
    {
        public ParameterContract(string name, string parameterContractType) { }
        public string DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ApiManagement.Models.ParameterExampleContract> Examples { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string ParameterContractType { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
        public string SchemaId { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class ParameterExampleContract
    {
        public ParameterExampleContract() { }
        public string Description { get { throw null; } set { } }
        public string ExternalValue { get { throw null; } set { } }
        public string Summary { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class PipelineDiagnosticSettings
    {
        public PipelineDiagnosticSettings() { }
        public Azure.ResourceManager.ApiManagement.Models.HttpMessageDiagnostic Request { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.HttpMessageDiagnostic Response { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlatformVersion : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PlatformVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlatformVersion(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PlatformVersion Mtv1 { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PlatformVersion Stv1 { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PlatformVersion Stv2 { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PlatformVersion Undetermined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PlatformVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PlatformVersion left, Azure.ResourceManager.ApiManagement.Models.PlatformVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PlatformVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PlatformVersion left, Azure.ResourceManager.ApiManagement.Models.PlatformVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyContentFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyContentFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat Rawxml { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat RawxmlLink { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat Xml { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat XmlLink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat left, Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat left, Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyDescriptionContract : Azure.ResourceManager.Models.ResourceData
    {
        public PolicyDescriptionContract() { }
        public string Description { get { throw null; } }
        public long? Scope { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyExportFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyExportFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat Rawxml { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat left, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat left, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyIdName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PolicyIdName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyIdName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyIdName Policy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PolicyIdName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PolicyIdName left, Azure.ResourceManager.ApiManagement.Models.PolicyIdName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PolicyIdName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PolicyIdName left, Azure.ResourceManager.ApiManagement.Models.PolicyIdName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PolicyScopeContract
    {
        Tenant = 0,
        Product = 1,
        Api = 2,
        Operation = 3,
        All = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortalRevisionStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortalRevisionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus Publishing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus left, Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus left, Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortalSettingsContract : Azure.ResourceManager.Models.ResourceData
    {
        public PortalSettingsContract() { }
        public bool? Enabled { get { throw null; } set { } }
        public bool? SubscriptionsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.TermsOfServiceProperties TermsOfService { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public bool? UserRegistrationEnabled { get { throw null; } set { } }
        public string ValidationKey { get { throw null; } set { } }
    }
    public partial class PortalSettingValidationKeyContract
    {
        internal PortalSettingValidationKeyContract() { }
        public string ValidationKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreferredIPVersion : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreferredIPVersion(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion IPv4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion left, Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion left, Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductContractPatch
    {
        public ProductContractPatch() { }
        public bool? ApprovalRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ProductState? State { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public int? SubscriptionsLimit { get { throw null; } set { } }
        public string Terms { get { throw null; } set { } }
    }
    public partial class ProductEntityBaseParameters
    {
        internal ProductEntityBaseParameters() { }
        public bool? ApprovalRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ProductState? State { get { throw null; } }
        public bool? SubscriptionRequired { get { throw null; } }
        public int? SubscriptionsLimit { get { throw null; } }
        public string Terms { get { throw null; } }
    }
    public enum ProductState
    {
        NotPublished = 0,
        Published = 1,
    }
    public partial class ProductTagResourceContractProperties : Azure.ResourceManager.ApiManagement.Models.ProductEntityBaseParameters
    {
        internal ProductTagResourceContractProperties() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Protocol : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Protocol(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.Protocol Http { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Protocol Https { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Protocol Ws { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Protocol Wss { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.Protocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.Protocol left, Azure.ResourceManager.ApiManagement.Models.Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.Protocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.Protocol left, Azure.ResourceManager.ApiManagement.Models.Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ProvisioningState Created { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ProvisioningState left, Azure.ResourceManager.ApiManagement.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ProvisioningState left, Azure.ResourceManager.ApiManagement.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess left, Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess left, Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaCounterContract
    {
        internal QuotaCounterContract() { }
        public string CounterKey { get { throw null; } }
        public System.DateTimeOffset PeriodEndOn { get { throw null; } }
        public string PeriodKey { get { throw null; } }
        public System.DateTimeOffset PeriodStartOn { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueContractProperties Value { get { throw null; } }
    }
    public partial class QuotaCounterValueContractProperties
    {
        internal QuotaCounterValueContractProperties() { }
        public int? CallsCount { get { throw null; } }
        public double? KbTransferred { get { throw null; } }
    }
    public partial class QuotaCounterValueUpdateContract
    {
        public QuotaCounterValueUpdateContract() { }
        public int? CallsCount { get { throw null; } set { } }
        public double? KbTransferred { get { throw null; } set { } }
    }
    public partial class RecipientEmailContract : Azure.ResourceManager.Models.ResourceData
    {
        public RecipientEmailContract() { }
        public string Email { get { throw null; } set { } }
    }
    public partial class RecipientsContractProperties
    {
        public RecipientsContractProperties() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> Users { get { throw null; } }
    }
    public partial class RecipientUserContract : Azure.ResourceManager.Models.ResourceData
    {
        public RecipientUserContract() { }
        public string UserId { get { throw null; } set { } }
    }
    public partial class RegionContract
    {
        internal RegionContract() { }
        public bool? IsDeleted { get { throw null; } }
        public bool? IsMasterRegion { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class RemotePrivateEndpointConnectionWrapper
    {
        public RemotePrivateEndpointConnectionWrapper() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class ReportRecordContract
    {
        internal ReportRecordContract() { }
        public string ApiId { get { throw null; } }
        public string ApiRegion { get { throw null; } }
        public double? ApiTimeAvg { get { throw null; } }
        public double? ApiTimeMax { get { throw null; } }
        public double? ApiTimeMin { get { throw null; } }
        public long? Bandwidth { get { throw null; } }
        public int? CacheHitCount { get { throw null; } }
        public int? CacheMissCount { get { throw null; } }
        public int? CallCountBlocked { get { throw null; } }
        public int? CallCountFailed { get { throw null; } }
        public int? CallCountOther { get { throw null; } }
        public int? CallCountSuccess { get { throw null; } }
        public int? CallCountTotal { get { throw null; } }
        public string Country { get { throw null; } }
        public string Interval { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string ProductId { get { throw null; } }
        public string Region { get { throw null; } }
        public double? ServiceTimeAvg { get { throw null; } }
        public double? ServiceTimeMax { get { throw null; } }
        public double? ServiceTimeMin { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string UserId { get { throw null; } }
        public string Zip { get { throw null; } }
    }
    public partial class RepresentationContract
    {
        public RepresentationContract(string contentType) { }
        public string ContentType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ApiManagement.Models.ParameterExampleContract> Examples { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> FormParameters { get { throw null; } }
        public string SchemaId { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
    }
    public partial class RequestContract
    {
        public RequestContract() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> Headers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> QueryParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RepresentationContract> Representations { get { throw null; } }
    }
    public partial class RequestReportRecordContract
    {
        internal RequestReportRecordContract() { }
        public string ApiId { get { throw null; } }
        public string ApiRegion { get { throw null; } }
        public double? ApiTime { get { throw null; } }
        public string BackendResponseCode { get { throw null; } }
        public string Cache { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string Method { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string ProductId { get { throw null; } }
        public string RequestId { get { throw null; } }
        public int? RequestSize { get { throw null; } }
        public int? ResponseCode { get { throw null; } }
        public int? ResponseSize { get { throw null; } }
        public double? ServiceTime { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    public partial class ResourceLocationDataContract
    {
        public ResourceLocationDataContract(string name) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } set { } }
        public string District { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ResourceSkuCapacity
    {
        internal ResourceSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuCapacityScaleType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuCapacityScaleType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType left, Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType left, Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacityScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSkuResult
    {
        internal ResourceSkuResult() { }
        public Azure.ResourceManager.ApiManagement.Models.ResourceSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.SkuType? SkuName { get { throw null; } }
    }
    public partial class ResponseContract
    {
        public ResponseContract(int statusCode) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> Headers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RepresentationContract> Representations { get { throw null; } }
        public int StatusCode { get { throw null; } set { } }
    }
    public partial class SamplingSettings
    {
        public SamplingSettings() { }
        public double? Percentage { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SamplingType? SamplingType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SamplingType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.SamplingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SamplingType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.SamplingType Fixed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.SamplingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.SamplingType left, Azure.ResourceManager.ApiManagement.Models.SamplingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.SamplingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.SamplingType left, Azure.ResourceManager.ApiManagement.Models.SamplingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SaveConfigurationParameter
    {
        public SaveConfigurationParameter() { }
        public string Branch { get { throw null; } set { } }
        public bool? Force { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchemaType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.SchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchemaType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.SchemaType Json { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SchemaType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.SchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.SchemaType left, Azure.ResourceManager.ApiManagement.Models.SchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.SchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.SchemaType left, Azure.ResourceManager.ApiManagement.Models.SchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceApiIssuePatch
    {
        public ServiceApiIssuePatch() { }
        public string ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.State? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class ServiceSubscriptionCreateOrUpdateContent
    {
        public ServiceSubscriptionCreateOrUpdateContent() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
    }
    public partial class ServiceSubscriptionPatch
    {
        public ServiceSubscriptionPatch() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
        public string StateComment { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SettingsTypeName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.SettingsTypeName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SettingsTypeName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.SettingsTypeName Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName left, Azure.ResourceManager.ApiManagement.Models.SettingsTypeName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.SettingsTypeName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName left, Azure.ResourceManager.ApiManagement.Models.SettingsTypeName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Severity : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.Severity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Severity(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.Severity Error { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Severity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.Severity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.Severity left, Azure.ResourceManager.ApiManagement.Models.Severity right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.Severity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.Severity left, Azure.ResourceManager.ApiManagement.Models.Severity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.SkuType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.SkuType Basic { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SkuType Consumption { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SkuType Developer { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SkuType Isolated { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SkuType Premium { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SkuType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.SkuType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.SkuType left, Azure.ResourceManager.ApiManagement.Models.SkuType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.SkuType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.SkuType left, Azure.ResourceManager.ApiManagement.Models.SkuType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoapApiType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.SoapApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoapApiType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.SoapApiType GraphQL { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SoapApiType SoapPassThrough { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SoapApiType SoapToRest { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SoapApiType WebSocket { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.SoapApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.SoapApiType left, Azure.ResourceManager.ApiManagement.Models.SoapApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.SoapApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.SoapApiType left, Azure.ResourceManager.ApiManagement.Models.SoapApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.State Closed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.State Open { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.State Proposed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.State Removed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.State Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.State left, Azure.ResourceManager.ApiManagement.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.State left, Azure.ResourceManager.ApiManagement.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionKeyParameterNamesContract
    {
        public SubscriptionKeyParameterNamesContract() { }
        public string Header { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public partial class SubscriptionKeysContract
    {
        internal SubscriptionKeysContract() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public enum SubscriptionState
    {
        Suspended = 0,
        Active = 1,
        Expired = 2,
        Submitted = 3,
        Rejected = 4,
        Cancelled = 5,
    }
    public partial class TagCreateUpdateParameters
    {
        public TagCreateUpdateParameters() { }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class TagDescriptionContractCreateOrUpdateContent
    {
        public TagDescriptionContractCreateOrUpdateContent() { }
        public string Description { get { throw null; } set { } }
        public string ExternalDocsDescription { get { throw null; } set { } }
        public System.Uri ExternalDocsUri { get { throw null; } set { } }
    }
    public partial class TagResourceContract
    {
        internal TagResourceContract() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiTagResourceContractProperties Api { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.OperationTagResourceContractProperties Operation { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ProductTagResourceContractProperties Product { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.TagResourceContractProperties Tag { get { throw null; } }
    }
    public partial class TagResourceContractProperties
    {
        internal TagResourceContractProperties() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.TemplateName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName AccountClosedDeveloper { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName ApplicationApprovedNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName ConfirmSignUpIdentityDefault { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName EmailChangeIdentityDefault { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName InviteUserNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName NewCommentNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName NewDeveloperNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName NewIssueNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName PasswordResetByAdminNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName PasswordResetIdentityDefault { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName PurchaseDeveloperNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName QuotaLimitApproachingDeveloperNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName RejectDeveloperNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName RequestDeveloperNotificationMessage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.TemplateName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.TemplateName left, Azure.ResourceManager.ApiManagement.Models.TemplateName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.TemplateName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.TemplateName left, Azure.ResourceManager.ApiManagement.Models.TemplateName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TenantConfigurationSyncStateContract : Azure.ResourceManager.Models.ResourceData
    {
        public TenantConfigurationSyncStateContract() { }
        public string Branch { get { throw null; } set { } }
        public string CommitId { get { throw null; } set { } }
        public System.DateTimeOffset? ConfigurationChangeOn { get { throw null; } set { } }
        public bool? IsExport { get { throw null; } set { } }
        public bool? IsGitEnabled { get { throw null; } set { } }
        public bool? IsSynced { get { throw null; } set { } }
        public string LastOperationId { get { throw null; } set { } }
        public System.DateTimeOffset? SyncOn { get { throw null; } set { } }
    }
    public partial class TermsOfServiceProperties
    {
        public TermsOfServiceProperties() { }
        public bool? ConsentRequired { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
    }
    public partial class TokenBodyParameterContract
    {
        public TokenBodyParameterContract(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class UserContractCreateOrUpdateContent
    {
        public UserContractCreateOrUpdateContent() { }
        public Azure.ResourceManager.ApiManagement.Models.AppType? AppType { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.Confirmation? Confirmation { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.UserState? State { get { throw null; } set { } }
    }
    public partial class UserContractPatch
    {
        public UserContractPatch() { }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.UserState? State { get { throw null; } set { } }
    }
    public partial class UserIdentityContract
    {
        public UserIdentityContract() { }
        public string Id { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserState : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.UserState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserState(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.UserState Active { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.UserState Blocked { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.UserState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.UserState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.UserState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.UserState left, Azure.ResourceManager.ApiManagement.Models.UserState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.UserState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.UserState left, Azure.ResourceManager.ApiManagement.Models.UserState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserTokenContent
    {
        public UserTokenContent() { }
        public System.DateTimeOffset? Expiry { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyType? KeyType { get { throw null; } set { } }
    }
    public partial class UserTokenResult
    {
        internal UserTokenResult() { }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Verbosity : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.Verbosity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Verbosity(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.Verbosity Error { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Verbosity Information { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.Verbosity Verbose { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.Verbosity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.Verbosity left, Azure.ResourceManager.ApiManagement.Models.Verbosity right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.Verbosity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.Verbosity left, Azure.ResourceManager.ApiManagement.Models.Verbosity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VersioningScheme : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.VersioningScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VersioningScheme(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.VersioningScheme Header { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.VersioningScheme Query { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.VersioningScheme Segment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.VersioningScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.VersioningScheme left, Azure.ResourceManager.ApiManagement.Models.VersioningScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.VersioningScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.VersioningScheme left, Azure.ResourceManager.ApiManagement.Models.VersioningScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkConfiguration
    {
        public VirtualNetworkConfiguration() { }
        public string Subnetname { get { throw null; } }
        public string SubnetResourceId { get { throw null; } set { } }
        public string VnetId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType External { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType Internal { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType left, Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType left, Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X509CertificateName
    {
        public X509CertificateName() { }
        public string IssuerCertificateThumbprint { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
}
