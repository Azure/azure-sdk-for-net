namespace Azure.ResourceManager.ApiManagement
{
    public partial class AccessInformationContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected AccessInformationContract() { }
        public virtual Azure.ResourceManager.ApiManagement.AccessInformationContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string accessName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.AccessInformationUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.AccessInformationUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AccessInformationContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.AccessInformationContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.AccessInformationContract>, System.Collections.IEnumerable
    {
        protected AccessInformationContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.TenantAccesCreateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, string ifMatch, Azure.ResourceManager.ApiManagement.Models.AccessInformationCreateParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TenantAccesCreateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, string ifMatch, Azure.ResourceManager.ApiManagement.Models.AccessInformationCreateParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract> Get(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.AccessInformationContract> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.AccessInformationContract> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract>> GetAsync(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract> GetIfExists(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.AccessIdName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.AccessInformationContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.AccessInformationContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.AccessInformationContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.AccessInformationContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessInformationContractData : Azure.ResourceManager.Models.Resource
    {
        public AccessInformationContractData() { }
        public bool? Enabled { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
    }
    public partial class ApiContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ApiContract() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiDeleteOperation Delete(string ifMatch, bool? deleteRevisions = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiDeleteOperation> DeleteAsync(string ifMatch, bool? deleteRevisions = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ProductContractData> GetApiProductsByApis(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ProductContractData> GetApiProductsByApisAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.ApiReleaseContractCollection GetApiReleaseContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiRevisionContract> GetApiRevisionsByService(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiRevisionContract> GetApiRevisionsByServiceAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.OperationContractCollection GetOperationContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetOperationsByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedOperations = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetOperationsByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedOperations = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.SchemaContractCollection GetSchemaContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceApiDiagnosticCollection GetServiceApiDiagnostics() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceApiIssueCollection GetServiceApiIssues() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceApiPolicyCollection GetServiceApiPolicies() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceApiTagCollection GetServiceApiTags() { throw null; }
        public Azure.ResourceManager.ApiManagement.TagDescriptionContractCollection GetTagDescriptionContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiContract>, System.Collections.IEnumerable
    {
        protected ApiContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdateOperation CreateOrUpdate(string apiId, Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdateParameter parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdateOperation> CreateOrUpdateAsync(string apiId, Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdateParameter parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract> Get(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, bool? expandApiVersionSet = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, bool? expandApiVersionSet = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract>> GetAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract> GetIfExists(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract>> GetIfExistsAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiContractData : Azure.ResourceManager.Models.Resource
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
        public string ServiceUrl { get { throw null; } set { } }
        public string SourceApiId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public string TermsOfServiceUrl { get { throw null; } set { } }
    }
    public partial class ApiManagementServiceResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ApiManagementServiceResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceApplyNetworkConfigurationUpdatesOperation ApplyNetworkConfigurationUpdates(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceApplyNetworkConfigurationParameters parameters = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceApplyNetworkConfigurationUpdatesOperation> ApplyNetworkConfigurationUpdatesAsync(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceApplyNetworkConfigurationParameters parameters = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupOperation Backup(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupOperation> BackupAsync(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.TenantConfigurationDeployOperation DeployTenantConfiguration(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.DeployConfigurationParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationDeployOperation> DeployTenantConfigurationAsync(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.DeployConfigurationParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.AccessInformationContractCollection GetAccessInformationContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.ApiContractCollection GetApiContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetApisByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedApis = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetApisByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedApis = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.ApiVersionSetContractCollection GetApiVersionSetContracts() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.AuthorizationServerContractCollection GetAuthorizationServerContracts() { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ResourceSkuResult> GetAvailableServiceSkusApiManagementServiceSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ResourceSkuResult> GetAvailableServiceSkusApiManagementServiceSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.BackendContractCollection GetBackendContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract> GetByLocationNetworkStatu(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract>> GetByLocationNetworkStatuAsync(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.CacheContractCollection GetCacheContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.CertificateContractCollection GetCertificateContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.ContentTypeContractCollection GetContentTypeContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.EmailTemplateContractCollection GetEmailTemplateContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.GatewayContractCollection GetGatewayContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.GlobalSchemaContractCollection GetGlobalSchemaContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.GroupContractCollection GetGroupContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.IdentityProviderContractCollection GetIdentityProviderContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.LoggerContractCollection GetLoggerContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.NamedValueContractCollection GetNamedValueContracts() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContractByLocation>> GetNetworkStatusesByService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContractByLocation>>> GetNetworkStatusesByServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.NotificationContractCollection GetNotificationContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.OpenidConnectProviderContractCollection GetOpenidConnectProviderContracts() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.OutboundEnvironmentEndpoint>> GetOutboundNetworkDependenciesEndpointsByService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.OutboundEnvironmentEndpoint>>> GetOutboundNetworkDependenciesEndpointsByServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.PolicyDescriptionContract>> GetPolicyDescriptionsByService(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract? scope = default(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.PolicyDescriptionContract>>> GetPolicyDescriptionsByServiceAsync(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract? scope = default(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.PortalDelegationSettings GetPortalDelegationSettings() { throw null; }
        public Azure.ResourceManager.ApiManagement.PortalRevisionContractCollection GetPortalRevisionContracts() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.PortalSettingsContract>> GetPortalSettingsByService(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.PortalSettingsContract>>> GetPortalSettingsByServiceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.PortalSigninSettings GetPortalSigninSettings() { throw null; }
        public Azure.ResourceManager.ApiManagement.PortalSignupSettings GetPortalSignupSettings() { throw null; }
        public Azure.ResourceManager.ApiManagement.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public Azure.ResourceManager.ApiManagement.PrivateLinkResourceCollection GetPrivateLinkResources() { throw null; }
        public Azure.ResourceManager.ApiManagement.ProductContractCollection GetProductContracts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetProductsByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedProducts = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetProductsByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedProducts = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>> GetQuotaByCounterKeysByService(string quotaCounterKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>>> GetQuotaByCounterKeysByServiceAsync(string quotaCounterKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ApiManagement.ServiceDiagnosticCollection GetServiceDiagnostics() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceIssueCollection GetServiceIssues() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServicePolicyCollection GetServicePolicies() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceSubscriptionCollection GetServiceSubscriptions() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceTagCollection GetServiceTags() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetSsoTokenResult> GetSsoToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetSsoTokenResult>> GetSsoTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationSyncStateContract> GetSyncStateTenantConfiguration(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationSyncStateContract>> GetSyncStateTenantConfigurationAsync(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetTagResourcesByService(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContract> GetTagResourcesByServiceAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.TenantSettingsContractCollection GetTenantSettingsContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.UserContractCollection GetUserContracts() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiManagementPerformConnectivityCheckAsyncOperation PerformConnectivityCheckAsync(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequest connectivityCheckRequestParams, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiManagementPerformConnectivityCheckAsyncOperation> PerformConnectivityCheckAsyncAsync(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequest connectivityCheckRequestParams, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceRestoreOperation Restore(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceRestoreOperation> RestoreAsync(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.TenantConfigurationSaveOperation SaveTenantConfiguration(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.SaveConfigurationParameter parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationSaveOperation> SaveTenantConfigurationAsync(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.SaveConfigurationParameter parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceUpdateOperation Update(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceUpdateParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceUpdateOperation> UpdateAsync(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceUpdateParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>> UpdateQuotaByCounterKeys(string quotaCounterKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>>> UpdateQuotaByCounterKeysAsync(string quotaCounterKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> UpdateQuotaByPeriodKey(string quotaCounterKey, string quotaPeriodKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>> UpdateQuotaByPeriodKeyAsync(string quotaCounterKey, string quotaPeriodKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.TenantConfigurationValidateOperation ValidateTenantConfiguration(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.DeployConfigurationParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationValidateOperation> ValidateTenantConfigurationAsync(Azure.ResourceManager.ApiManagement.Models.ConfigurationIdName configurationName, Azure.ResourceManager.ApiManagement.Models.DeployConfigurationParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>, System.Collections.IEnumerable
    {
        protected ApiManagementServiceResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceCreateOrUpdateOperation CreateOrUpdate(string serviceName, Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceCreateOrUpdateOperation> CreateOrUpdateAsync(string serviceName, Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetIfExists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetIfExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementServiceResourceData : Azure.ResourceManager.ApiManagement.Models.ApimResource
    {
        public ApiManagementServiceResourceData(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties sku, string location, string publisherEmail, string publisherName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AdditionalLocation> AdditionalLocations { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionConstraint ApiVersionConstraint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.CertificateConfiguration> Certificates { get { throw null; } }
        public System.DateTimeOffset? CreatedAtUtc { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public string DeveloperPortalUrl { get { throw null; } }
        public bool? DisableGateway { get { throw null; } set { } }
        public bool? EnableClientCertificate { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public string GatewayRegionalUrl { get { throw null; } }
        public string GatewayUrl { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.HostnameConfiguration> HostnameConfigurations { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public string ManagementApiUrl { get { throw null; } }
        public string NotificationSenderEmail { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public string PortalUrl { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RemotePrivateEndpointConnectionWrapper> PrivateEndpointConnections { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PrivateIPAddresses { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PublicIPAddresses { get { throw null; } }
        public string PublicIpAddressId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PublisherEmail { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
        public bool? Restore { get { throw null; } set { } }
        public string ScmUrl { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string TargetProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ApiReleaseContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ApiReleaseContract() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiReleaseContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string releaseId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiReleaseDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiReleaseDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseContractData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseContractData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiReleaseContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseContract>, System.Collections.IEnumerable
    {
        protected ApiReleaseContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiReleaseCreateOrUpdateOperation CreateOrUpdate(string releaseId, Azure.ResourceManager.ApiManagement.ApiReleaseContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiReleaseCreateOrUpdateOperation> CreateOrUpdateAsync(string releaseId, Azure.ResourceManager.ApiManagement.ApiReleaseContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract> Get(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiReleaseContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiReleaseContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract>> GetAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract> GetIfExists(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract>> GetIfExistsAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiReleaseContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiReleaseContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiReleaseContractData : Azure.ResourceManager.Models.Resource
    {
        public ApiReleaseContractData() { }
        public string ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedDateTime { get { throw null; } }
    }
    public partial class ApiVersionSetContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ApiVersionSetContract() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiVersionSetContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string versionSetId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiVersionSetDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiVersionSetDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionSetContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>, System.Collections.IEnumerable
    {
        protected ApiVersionSetContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiVersionSetCreateOrUpdateOperation CreateOrUpdate(string versionSetId, Azure.ResourceManager.ApiManagement.ApiVersionSetContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiVersionSetCreateOrUpdateOperation> CreateOrUpdateAsync(string versionSetId, Azure.ResourceManager.ApiManagement.ApiVersionSetContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract> Get(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiVersionSetContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiVersionSetContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>> GetAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract> GetIfExists(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>> GetIfExistsAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiVersionSetContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiVersionSetContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiVersionSetContractData : Azure.ResourceManager.Models.Resource
    {
        public ApiVersionSetContractData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string VersionHeaderName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VersioningScheme? VersioningScheme { get { throw null; } set { } }
        public string VersionQueryName { get { throw null; } set { } }
    }
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.ApiManagement.AccessInformationContract GetAccessInformationContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiContract GetApiContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementServiceResource GetApiManagementServiceResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiReleaseContract GetApiReleaseContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiVersionSetContract GetApiVersionSetContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.AuthorizationServerContract GetAuthorizationServerContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.BackendContract GetBackendContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.CacheContract GetCacheContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.CertificateContract GetCertificateContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ContentItemContract GetContentItemContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ContentTypeContract GetContentTypeContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.DeletedServiceContract GetDeletedServiceContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.EmailTemplateContract GetEmailTemplateContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract GetGatewayCertificateAuthorityContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GatewayContract GetGatewayContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract GetGatewayHostnameConfigurationContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GlobalSchemaContract GetGlobalSchemaContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.GroupContract GetGroupContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.IdentityProviderContract GetIdentityProviderContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.IssueAttachmentContract GetIssueAttachmentContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.IssueCommentContract GetIssueCommentContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.LoggerContract GetLoggerContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.NamedValueContract GetNamedValueContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.NotificationContract GetNotificationContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract GetOpenidConnectProviderContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.OperationContract GetOperationContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PortalDelegationSettings GetPortalDelegationSettings(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PortalRevisionContract GetPortalRevisionContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PortalSigninSettings GetPortalSigninSettings(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PortalSignupSettings GetPortalSignupSettings(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ProductContract GetProductContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.SchemaContract GetSchemaContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic GetServiceApiDiagnostic(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiIssue GetServiceApiIssue(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy GetServiceApiOperationPolicy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiOperationTag GetServiceApiOperationTag(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiPolicy GetServiceApiPolicy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceApiTag GetServiceApiTag(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceDiagnostic GetServiceDiagnostic(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceIssue GetServiceIssue(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServicePolicy GetServicePolicy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceProductPolicy GetServiceProductPolicy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceProductTag GetServiceProductTag(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceSubscription GetServiceSubscription(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceTag GetServiceTag(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ServiceUserSubscription GetServiceUserSubscription(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.TagDescriptionContract GetTagDescriptionContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.TenantSettingsContract GetTenantSettingsContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.UserContract GetUserContract(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class AuthorizationServerContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected AuthorizationServerContract() { }
        public virtual Azure.ResourceManager.ApiManagement.AuthorizationServerContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string authsid) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.AuthorizationServerDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.AuthorizationServerDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.AuthorizationServerSecretsContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.AuthorizationServerSecretsContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.AuthorizationServerUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.AuthorizationServerUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AuthorizationServerContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>, System.Collections.IEnumerable
    {
        protected AuthorizationServerContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.AuthorizationServerCreateOrUpdateOperation CreateOrUpdate(string authsid, Azure.ResourceManager.ApiManagement.AuthorizationServerContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.AuthorizationServerCreateOrUpdateOperation> CreateOrUpdateAsync(string authsid, Azure.ResourceManager.ApiManagement.AuthorizationServerContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract> Get(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.AuthorizationServerContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.AuthorizationServerContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>> GetAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract> GetIfExists(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>> GetIfExistsAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.AuthorizationServerContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.AuthorizationServerContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthorizationServerContractData : Azure.ResourceManager.Models.Resource
    {
        public AuthorizationServerContractData() { }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AuthorizationMethod> AuthorizationMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod> BearerTokenSendingMethods { get { throw null; } }
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
    public partial class BackendContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected BackendContract() { }
        public virtual Azure.ResourceManager.ApiManagement.BackendContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string backendId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.BackendDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.BackendDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reconnect(Azure.ResourceManager.ApiManagement.Models.BackendReconnectContract parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReconnectAsync(Azure.ResourceManager.ApiManagement.Models.BackendReconnectContract parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.BackendUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.BackendUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackendContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.BackendContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.BackendContract>, System.Collections.IEnumerable
    {
        protected BackendContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.BackendCreateOrUpdateOperation CreateOrUpdate(string backendId, Azure.ResourceManager.ApiManagement.BackendContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.BackendCreateOrUpdateOperation> CreateOrUpdateAsync(string backendId, Azure.ResourceManager.ApiManagement.BackendContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract> Get(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.BackendContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.BackendContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract>> GetAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract> GetIfExists(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract>> GetIfExistsAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.BackendContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.BackendContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.BackendContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.BackendContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackendContractData : Azure.ResourceManager.Models.Resource
    {
        public BackendContractData() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendCredentialsContract Credentials { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProxyContract Proxy { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendTlsProperties Tls { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
    }
    public partial class CacheContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected CacheContract() { }
        public virtual Azure.ResourceManager.ApiManagement.CacheContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string cacheId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.CacheDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.CacheDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.CacheUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.CacheUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CacheContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.CacheContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.CacheContract>, System.Collections.IEnumerable
    {
        protected CacheContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.CacheCreateOrUpdateOperation CreateOrUpdate(string cacheId, Azure.ResourceManager.ApiManagement.CacheContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.CacheCreateOrUpdateOperation> CreateOrUpdateAsync(string cacheId, Azure.ResourceManager.ApiManagement.CacheContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract> Get(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.CacheContract> GetAll(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.CacheContract> GetAllAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract>> GetAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract> GetIfExists(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract>> GetIfExistsAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.CacheContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.CacheContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.CacheContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.CacheContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CacheContractData : Azure.ResourceManager.Models.Resource
    {
        public CacheContractData() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string UseFromLocation { get { throw null; } set { } }
    }
    public partial class CertificateContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected CertificateContract() { }
        public virtual Azure.ResourceManager.ApiManagement.CertificateContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string certificateId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.CertificateDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.CertificateDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract> RefreshSecret(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract>> RefreshSecretAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.CertificateContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.CertificateContract>, System.Collections.IEnumerable
    {
        protected CertificateContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.CertificateCreateOrUpdateOperation CreateOrUpdate(string certificateId, Azure.ResourceManager.ApiManagement.Models.CertificateCreateOrUpdateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.CertificateCreateOrUpdateOperation> CreateOrUpdateAsync(string certificateId, Azure.ResourceManager.ApiManagement.Models.CertificateCreateOrUpdateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract> Get(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.CertificateContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.CertificateContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract>> GetAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract> GetIfExists(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract>> GetIfExistsAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.CertificateContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.CertificateContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.CertificateContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.CertificateContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateContractData : Azure.ResourceManager.Models.Resource
    {
        public CertificateContractData() { }
        public System.DateTimeOffset? ExpirationDate { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractProperties KeyVault { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class ContentItemContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ContentItemContract() { }
        public virtual Azure.ResourceManager.ApiManagement.ContentItemContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string contentTypeId, string contentItemId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ContentItemDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ContentItemDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentItemContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ContentItemContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ContentItemContract>, System.Collections.IEnumerable
    {
        protected ContentItemContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ContentItemCreateOrUpdateOperation CreateOrUpdate(string contentItemId, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ContentItemCreateOrUpdateOperation> CreateOrUpdateAsync(string contentItemId, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContract> Get(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ContentItemContract> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ContentItemContract> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContract>> GetAsync(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContract> GetIfExists(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContract>> GetIfExistsAsync(string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ContentItemContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ContentItemContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ContentItemContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ContentItemContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContentItemContractData : Azure.ResourceManager.Models.Resource
    {
        public ContentItemContractData() { }
        public System.Collections.Generic.IDictionary<string, object> Properties { get { throw null; } }
    }
    public partial class ContentTypeContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ContentTypeContract() { }
        public virtual Azure.ResourceManager.ApiManagement.ContentTypeContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string contentTypeId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ContentTypeDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ContentTypeDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.ContentItemContractCollection GetContentItemContracts() { throw null; }
    }
    public partial class ContentTypeContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ContentTypeContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ContentTypeContract>, System.Collections.IEnumerable
    {
        protected ContentTypeContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ContentTypeCreateOrUpdateOperation CreateOrUpdate(string contentTypeId, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ContentTypeCreateOrUpdateOperation> CreateOrUpdateAsync(string contentTypeId, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContract> Get(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ContentTypeContract> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ContentTypeContract> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContract>> GetAsync(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContract> GetIfExists(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContract>> GetIfExistsAsync(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ContentTypeContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ContentTypeContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ContentTypeContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ContentTypeContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContentTypeContractData : Azure.ResourceManager.Models.Resource
    {
        public ContentTypeContractData() { }
        public string Description { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public object Schema { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class DeletedServiceContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DeletedServiceContract() { }
        public virtual Azure.ResourceManager.ApiManagement.DeletedServiceContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.DeletedServicePurgeOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.DeletedServicePurgeOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedServiceContractCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected DeletedServiceContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> Exists(string location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContract> Get(string location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContract>> GetAsync(string location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContract> GetIfExists(string location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.DeletedServiceContract>> GetIfExistsAsync(string location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedServiceContractData : Azure.ResourceManager.Models.Resource
    {
        public DeletedServiceContractData() { }
        public System.DateTimeOffset? DeletionDate { get { throw null; } set { } }
        public string Location { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeDate { get { throw null; } set { } }
        public string ServiceId { get { throw null; } set { } }
    }
    public partial class DiagnosticContractData : Azure.ResourceManager.Models.Resource
    {
        public DiagnosticContractData() { }
        public Azure.ResourceManager.ApiManagement.Models.AlwaysLog? AlwaysLog { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PipelineDiagnosticSettings Backend { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PipelineDiagnosticSettings Frontend { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol? HttpCorrelationProtocol { get { throw null; } set { } }
        public bool? LogClientIp { get { throw null; } set { } }
        public string LoggerId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.OperationNameFormat? OperationNameFormat { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SamplingSettings Sampling { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.Verbosity? Verbosity { get { throw null; } set { } }
    }
    public partial class EmailTemplateContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected EmailTemplateContract() { }
        public virtual Azure.ResourceManager.ApiManagement.EmailTemplateContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string templateName) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.EmailTemplateDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.EmailTemplateDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.EmailTemplateUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.EmailTemplateUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmailTemplateContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.EmailTemplateContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.EmailTemplateContract>, System.Collections.IEnumerable
    {
        protected EmailTemplateContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.EmailTemplateCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, Azure.ResourceManager.ApiManagement.Models.EmailTemplateUpdateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.EmailTemplateCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, Azure.ResourceManager.ApiManagement.Models.EmailTemplateUpdateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract> Get(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.EmailTemplateContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.EmailTemplateContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract>> GetAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract> GetIfExists(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.EmailTemplateContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.EmailTemplateContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.EmailTemplateContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.EmailTemplateContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EmailTemplateContractData : Azure.ResourceManager.Models.Resource
    {
        public EmailTemplateContractData() { }
        public string Body { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.EmailTemplateParametersContractProperties> Parameters { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class GatewayCertificateAuthorityContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected GatewayCertificateAuthorityContract() { }
        public virtual Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId, string certificateId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.GatewayCertificateAuthorityDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GatewayCertificateAuthorityDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayCertificateAuthorityContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>, System.Collections.IEnumerable
    {
        protected GatewayCertificateAuthorityContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.GatewayCertificateAuthorityCreateOrUpdateOperation CreateOrUpdate(string certificateId, Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GatewayCertificateAuthorityCreateOrUpdateOperation> CreateOrUpdateAsync(string certificateId, Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract> Get(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>> GetAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract> GetIfExists(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>> GetIfExistsAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayCertificateAuthorityContractData : Azure.ResourceManager.Models.Resource
    {
        public GatewayCertificateAuthorityContractData() { }
        public bool? IsTrusted { get { throw null; } set { } }
    }
    public partial class GatewayContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected GatewayContract() { }
        public virtual Azure.ResourceManager.ApiManagement.GatewayContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractData> CreateOrUpdateGatewayApi(string apiId, Azure.ResourceManager.ApiManagement.Models.AssociationContract parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractData>> CreateOrUpdateGatewayApiAsync(string apiId, Azure.ResourceManager.ApiManagement.Models.AssociationContract parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.GatewayDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GatewayDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGatewayApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGatewayApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayTokenContract> GenerateToken(Azure.ResourceManager.ApiManagement.Models.GatewayTokenRequestContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayTokenContract>> GenerateTokenAsync(Azure.ResourceManager.ApiManagement.Models.GatewayTokenRequestContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTagGatewayApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagGatewayApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiContractData> GetGatewayApisByService(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiContractData> GetGatewayApisByServiceAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContractCollection GetGatewayCertificateAuthorityContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractCollection GetGatewayHostnameConfigurationContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayKeysContract> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayKeysContract>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateKey(Azure.ResourceManager.ApiManagement.Models.GatewayKeyRegenerationRequestContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateKeyAsync(Azure.ResourceManager.ApiManagement.Models.GatewayKeyRegenerationRequestContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.GatewayContractData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.GatewayContractData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayContract>, System.Collections.IEnumerable
    {
        protected GatewayContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.GatewayCreateOrUpdateOperation CreateOrUpdate(string gatewayId, Azure.ResourceManager.ApiManagement.GatewayContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GatewayCreateOrUpdateOperation> CreateOrUpdateAsync(string gatewayId, Azure.ResourceManager.ApiManagement.GatewayContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract> Get(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GatewayContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GatewayContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract>> GetAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract> GetIfExists(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract>> GetIfExistsAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GatewayContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GatewayContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayContractData : Azure.ResourceManager.Models.Resource
    {
        public GatewayContractData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ResourceLocationDataContract LocationData { get { throw null; } set { } }
    }
    public partial class GatewayHostnameConfigurationContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected GatewayHostnameConfigurationContract() { }
        public virtual Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId, string hcId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.GatewayHostnameConfigurationDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GatewayHostnameConfigurationDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayHostnameConfigurationContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>, System.Collections.IEnumerable
    {
        protected GatewayHostnameConfigurationContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.GatewayHostnameConfigurationCreateOrUpdateOperation CreateOrUpdate(string hcId, Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GatewayHostnameConfigurationCreateOrUpdateOperation> CreateOrUpdateAsync(string hcId, Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract> Get(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>> GetAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract> GetIfExists(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>> GetIfExistsAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayHostnameConfigurationContractData : Azure.ResourceManager.Models.Resource
    {
        public GatewayHostnameConfigurationContractData() { }
        public string CertificateId { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public bool? Http2Enabled { get { throw null; } set { } }
        public bool? NegotiateClientCertificate { get { throw null; } set { } }
        public bool? Tls10Enabled { get { throw null; } set { } }
        public bool? Tls11Enabled { get { throw null; } set { } }
    }
    public partial class GlobalSchemaContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected GlobalSchemaContract() { }
        public virtual Azure.ResourceManager.ApiManagement.GlobalSchemaContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string schemaId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.GlobalSchemaDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GlobalSchemaDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalSchemaContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>, System.Collections.IEnumerable
    {
        protected GlobalSchemaContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.GlobalSchemaCreateOrUpdateOperation CreateOrUpdate(string schemaId, Azure.ResourceManager.ApiManagement.GlobalSchemaContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GlobalSchemaCreateOrUpdateOperation> CreateOrUpdateAsync(string schemaId, Azure.ResourceManager.ApiManagement.GlobalSchemaContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContract> Get(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GlobalSchemaContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GlobalSchemaContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>> GetAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContract> GetIfExists(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>> GetIfExistsAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GlobalSchemaContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GlobalSchemaContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalSchemaContractData : Azure.ResourceManager.Models.Resource
    {
        public GlobalSchemaContractData() { }
        public string Description { get { throw null; } set { } }
        public object Document { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SchemaType? SchemaType { get { throw null; } set { } }
        public object Value { get { throw null; } set { } }
    }
    public partial class GroupContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected GroupContract() { }
        public virtual Azure.ResourceManager.ApiManagement.GroupContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckEntityExistsGroupUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsGroupUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContractData> CreateGroupUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContractData>> CreateGroupUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string groupId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.GroupDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GroupDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGroupUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGroupUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.UserContractData> GetGroupUsers(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.UserContractData> GetGroupUsersAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.GroupUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.GroupUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GroupContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GroupContract>, System.Collections.IEnumerable
    {
        protected GroupContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.GroupCreateOrUpdateOperation CreateOrUpdate(string groupId, Azure.ResourceManager.ApiManagement.Models.GroupCreateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.GroupCreateOrUpdateOperation> CreateOrUpdateAsync(string groupId, Azure.ResourceManager.ApiManagement.Models.GroupCreateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GroupContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GroupContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.GroupContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.GroupContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.GroupContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.GroupContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupContractData : Azure.ResourceManager.Models.Resource
    {
        public GroupContractData() { }
        public bool? BuiltIn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.GroupType? TypePropertiesType { get { throw null; } set { } }
    }
    public partial class IdentityProviderContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected IdentityProviderContract() { }
        public virtual Azure.ResourceManager.ApiManagement.IdentityProviderContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string identityProviderName) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.IdentityProviderDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.IdentityProviderDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.IdentityProviderUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.IdentityProviderUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IdentityProviderContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IdentityProviderContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IdentityProviderContract>, System.Collections.IEnumerable
    {
        protected IdentityProviderContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.IdentityProviderCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, Azure.ResourceManager.ApiManagement.Models.IdentityProviderCreateContract parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.IdentityProviderCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, Azure.ResourceManager.ApiManagement.Models.IdentityProviderCreateContract parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract> Get(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.IdentityProviderContract> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.IdentityProviderContract> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract>> GetAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract> GetIfExists(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.IdentityProviderContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IdentityProviderContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.IdentityProviderContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IdentityProviderContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IdentityProviderContractData : Azure.ResourceManager.Models.Resource
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
    public partial class IssueAttachmentContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected IssueAttachmentContract() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueAttachmentContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId, string attachmentId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiIssueAttachmentDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiIssueAttachmentDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IssueAttachmentContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>, System.Collections.IEnumerable
    {
        protected IssueAttachmentContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiIssueAttachmentCreateOrUpdateOperation CreateOrUpdate(string attachmentId, Azure.ResourceManager.ApiManagement.IssueAttachmentContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiIssueAttachmentCreateOrUpdateOperation> CreateOrUpdateAsync(string attachmentId, Azure.ResourceManager.ApiManagement.IssueAttachmentContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContract> Get(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.IssueAttachmentContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.IssueAttachmentContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>> GetAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContract> GetIfExists(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>> GetIfExistsAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.IssueAttachmentContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.IssueAttachmentContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IssueAttachmentContractData : Azure.ResourceManager.Models.Resource
    {
        public IssueAttachmentContractData() { }
        public string Content { get { throw null; } set { } }
        public string ContentFormat { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class IssueCommentContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected IssueCommentContract() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueCommentContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId, string commentId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiIssueCommentDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiIssueCommentDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IssueCommentContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IssueCommentContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IssueCommentContract>, System.Collections.IEnumerable
    {
        protected IssueCommentContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiIssueCommentCreateOrUpdateOperation CreateOrUpdate(string commentId, Azure.ResourceManager.ApiManagement.IssueCommentContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiIssueCommentCreateOrUpdateOperation> CreateOrUpdateAsync(string commentId, Azure.ResourceManager.ApiManagement.IssueCommentContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContract> Get(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.IssueCommentContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.IssueCommentContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContract>> GetAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContract> GetIfExists(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContract>> GetIfExistsAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.IssueCommentContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.IssueCommentContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.IssueCommentContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.IssueCommentContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IssueCommentContractData : Azure.ResourceManager.Models.Resource
    {
        public IssueCommentContractData() { }
        public System.DateTimeOffset? CreatedDate { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class IssueContractData : Azure.ResourceManager.Models.Resource
    {
        public IssueContractData() { }
        public string ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDate { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.State? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class LoggerContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected LoggerContract() { }
        public virtual Azure.ResourceManager.ApiManagement.LoggerContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string loggerId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.LoggerDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.LoggerDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.LoggerUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.LoggerUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoggerContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.LoggerContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.LoggerContract>, System.Collections.IEnumerable
    {
        protected LoggerContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.LoggerCreateOrUpdateOperation CreateOrUpdate(string loggerId, Azure.ResourceManager.ApiManagement.LoggerContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.LoggerCreateOrUpdateOperation> CreateOrUpdateAsync(string loggerId, Azure.ResourceManager.ApiManagement.LoggerContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract> Get(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.LoggerContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.LoggerContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract>> GetAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract> GetIfExists(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract>> GetIfExistsAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.LoggerContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.LoggerContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.LoggerContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.LoggerContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LoggerContractData : Azure.ResourceManager.Models.Resource
    {
        public LoggerContractData() { }
        public System.Collections.Generic.IDictionary<string, string> Credentials { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsBuffered { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.LoggerType? LoggerType { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class NamedValueContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected NamedValueContract() { }
        public virtual Azure.ResourceManager.ApiManagement.NamedValueContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string namedValueId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.NamedValueDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.NamedValueDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.NamedValueSecretContract> GetValue(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.NamedValueSecretContract>> GetValueAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.NamedValueRefreshSecretOperation RefreshSecret(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.NamedValueRefreshSecretOperation> RefreshSecretAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.NamedValueUpdateOperation Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.NamedValueUpdateParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.NamedValueUpdateOperation> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.NamedValueUpdateParameters parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamedValueContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.NamedValueContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.NamedValueContract>, System.Collections.IEnumerable
    {
        protected NamedValueContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.NamedValueCreateOrUpdateOperation CreateOrUpdate(string namedValueId, Azure.ResourceManager.ApiManagement.Models.NamedValueCreateContract parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.NamedValueCreateOrUpdateOperation> CreateOrUpdateAsync(string namedValueId, Azure.ResourceManager.ApiManagement.Models.NamedValueCreateContract parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract> Get(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.NamedValueContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.NamedValueContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract>> GetAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract> GetIfExists(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract>> GetIfExistsAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.NamedValueContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.NamedValueContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.NamedValueContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.NamedValueContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamedValueContractData : Azure.ResourceManager.Models.Resource
    {
        public NamedValueContractData() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractProperties KeyVault { get { throw null; } set { } }
        public bool? Secret { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class NotificationContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected NotificationContract() { }
        public virtual Azure.ResourceManager.ApiManagement.NotificationContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckEntityExistsNotificationRecipientEmail(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsNotificationRecipientEmailAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> CheckEntityExistsNotificationRecipientUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsNotificationRecipientUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract> CreateOrUpdateNotificationRecipientEmail(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract>> CreateOrUpdateNotificationRecipientEmailAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract> CreateOrUpdateNotificationRecipientUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract>> CreateOrUpdateNotificationRecipientUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string notificationName) { throw null; }
        public virtual Azure.Response DeleteNotificationRecipientEmail(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNotificationRecipientEmailAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteNotificationRecipientUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNotificationRecipientUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract>> GetNotificationRecipientEmails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract>>> GetNotificationRecipientEmailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract>> GetNotificationRecipientUsers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract>>> GetNotificationRecipientUsersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.NotificationContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.NotificationContract>, System.Collections.IEnumerable
    {
        protected NotificationContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.NotificationCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.NotificationCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContract> Get(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.NotificationContract> GetAll(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.NotificationContract> GetAllAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContract>> GetAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContract> GetIfExists(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContract>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.NotificationContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.NotificationContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.NotificationContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.NotificationContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationContractData : Azure.ResourceManager.Models.Resource
    {
        public NotificationContractData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RecipientsContractProperties Recipients { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class OpenidConnectProviderContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected OpenidConnectProviderContract() { }
        public virtual Azure.ResourceManager.ApiManagement.OpenidConnectProviderContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string opid) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.OpenIdConnectProviderDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.OpenIdConnectProviderDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.OpenidConnectProviderUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.OpenidConnectProviderUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenidConnectProviderContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>, System.Collections.IEnumerable
    {
        protected OpenidConnectProviderContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.OpenIdConnectProviderCreateOrUpdateOperation CreateOrUpdate(string opid, Azure.ResourceManager.ApiManagement.OpenidConnectProviderContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.OpenIdConnectProviderCreateOrUpdateOperation> CreateOrUpdateAsync(string opid, Azure.ResourceManager.ApiManagement.OpenidConnectProviderContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string opid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string opid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract> Get(string opid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>> GetAsync(string opid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract> GetIfExists(string opid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>> GetIfExistsAsync(string opid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OpenidConnectProviderContractData : Azure.ResourceManager.Models.Resource
    {
        public OpenidConnectProviderContractData() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string MetadataEndpoint { get { throw null; } set { } }
    }
    public partial class OperationContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected OperationContract() { }
        public virtual Azure.ResourceManager.ApiManagement.OperationContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiOperationDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiOperationDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicyCollection GetServiceApiOperationPolicies() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceApiOperationTagCollection GetServiceApiOperationTags() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.OperationUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.OperationUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.OperationContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.OperationContract>, System.Collections.IEnumerable
    {
        protected OperationContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiOperationCreateOrUpdateOperation CreateOrUpdate(string operationId, Azure.ResourceManager.ApiManagement.OperationContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiOperationCreateOrUpdateOperation> CreateOrUpdateAsync(string operationId, Azure.ResourceManager.ApiManagement.OperationContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.OperationContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.OperationContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract> GetIfExists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract>> GetIfExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.OperationContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.OperationContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.OperationContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.OperationContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperationContractData : Azure.ResourceManager.Models.Resource
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
    public partial class PolicyContractData : Azure.ResourceManager.Models.Resource
    {
        public PolicyContractData() { }
        public Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat? Format { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class PortalDelegationSettings : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PortalDelegationSettings() { }
        public virtual Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.DelegationSettingCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.DelegationSettingCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalDelegationSettings> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalDelegationSettings>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.PortalSettingValidationKeyContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.PortalSettingValidationKeyContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string ifMatch, Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.PortalDelegationSettingsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PortalDelegationSettingsData : Azure.ResourceManager.Models.Resource
    {
        public PortalDelegationSettingsData() { }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionsDelegationSettingsProperties Subscriptions { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RegistrationDelegationSettingsProperties UserRegistration { get { throw null; } set { } }
        public string ValidationKey { get { throw null; } set { } }
    }
    public partial class PortalRevisionContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PortalRevisionContract() { }
        public virtual Azure.ResourceManager.ApiManagement.PortalRevisionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string portalRevisionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.PortalRevisionUpdateOperation Update(string ifMatch, Azure.ResourceManager.ApiManagement.PortalRevisionContractData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.PortalRevisionUpdateOperation> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.PortalRevisionContractData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PortalRevisionContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.PortalRevisionContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.PortalRevisionContract>, System.Collections.IEnumerable
    {
        protected PortalRevisionContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.PortalRevisionCreateOrUpdateOperation CreateOrUpdate(string portalRevisionId, Azure.ResourceManager.ApiManagement.PortalRevisionContractData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.PortalRevisionCreateOrUpdateOperation> CreateOrUpdateAsync(string portalRevisionId, Azure.ResourceManager.ApiManagement.PortalRevisionContractData parameters, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract> Get(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.PortalRevisionContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.PortalRevisionContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract>> GetAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract> GetIfExists(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract>> GetIfExistsAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.PortalRevisionContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.PortalRevisionContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.PortalRevisionContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.PortalRevisionContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PortalRevisionContractData : Azure.ResourceManager.Models.Resource
    {
        public PortalRevisionContractData() { }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public System.DateTimeOffset? UpdatedDateTime { get { throw null; } }
    }
    public partial class PortalSigninSettings : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PortalSigninSettings() { }
        public virtual Azure.ResourceManager.ApiManagement.PortalSigninSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.SignInSettingCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.PortalSigninSettingsData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.SignInSettingCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.PortalSigninSettingsData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalSigninSettings> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalSigninSettings>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string ifMatch, Azure.ResourceManager.ApiManagement.PortalSigninSettingsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.PortalSigninSettingsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PortalSigninSettingsData : Azure.ResourceManager.Models.Resource
    {
        public PortalSigninSettingsData() { }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class PortalSignupSettings : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PortalSignupSettings() { }
        public virtual Azure.ResourceManager.ApiManagement.PortalSignupSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public Azure.ResourceManager.Core.ArmResource Parent { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.SignUpSettingCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.PortalSignupSettingsData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.SignUpSettingCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.PortalSignupSettingsData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalSignupSettings> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalSignupSettings>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string ifMatch, Azure.ResourceManager.ApiManagement.PortalSignupSettingsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.PortalSignupSettingsData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PortalSignupSettingsData : Azure.ResourceManager.Models.Resource
    {
        public PortalSignupSettingsData() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.TermsOfServiceProperties TermsOfService { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.ApiManagement.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(string privateEndpointConnectionName, Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionRequest privateEndpointConnectionRequest, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(string privateEndpointConnectionName, Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionRequest privateEndpointConnectionRequest, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.ApiManagement.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string privateLinkSubResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkResourceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> Exists(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PrivateLinkResource> Get(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.PrivateLinkResource>> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.PrivateLinkResource>>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PrivateLinkResource>> GetAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PrivateLinkResource> GetIfExists(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PrivateLinkResource>> GetIfExistsAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkResourceData : Azure.ResourceManager.Models.Resource
    {
        public PrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class ProductContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ProductContract() { }
        public virtual Azure.ResourceManager.ApiManagement.ProductContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckEntityExistsProductApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsProductApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> CheckEntityExistsProductGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckEntityExistsProductGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractData> CreateOrUpdateProductApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContractData>> CreateOrUpdateProductApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractData> CreateOrUpdateProductGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContractData>> CreateOrUpdateProductGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ProductDeleteOperation Delete(string ifMatch, bool? deleteSubscriptions = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ProductDeleteOperation> DeleteAsync(string ifMatch, bool? deleteSubscriptions = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteProductApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteProductApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteProductGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteProductGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiContractData> GetProductApis(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiContractData> GetProductApisAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GroupContractData> GetProductGroups(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GroupContractData> GetProductGroupsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.SubscriptionContractData> GetProductSubscriptions(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.SubscriptionContractData> GetProductSubscriptionsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceProductPolicyCollection GetServiceProductPolicies() { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceProductTagCollection GetServiceProductTags() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ProductUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.ProductUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProductContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ProductContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ProductContract>, System.Collections.IEnumerable
    {
        protected ProductContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ProductCreateOrUpdateOperation CreateOrUpdate(string productId, Azure.ResourceManager.ApiManagement.ProductContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ProductCreateOrUpdateOperation> CreateOrUpdateAsync(string productId, Azure.ResourceManager.ApiManagement.ProductContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract> Get(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ProductContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ProductContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract>> GetAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract> GetIfExists(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract>> GetIfExistsAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ProductContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ProductContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ProductContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ProductContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProductContractData : Azure.ResourceManager.Models.Resource
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
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceCollection GetApiManagementServiceResources(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class SchemaContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected SchemaContract() { }
        public virtual Azure.ResourceManager.ApiManagement.SchemaContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string schemaId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiSchemaDeleteOperation Delete(string ifMatch, bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiSchemaDeleteOperation> DeleteAsync(string ifMatch, bool? force = default(bool?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchemaContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.SchemaContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.SchemaContract>, System.Collections.IEnumerable
    {
        protected SchemaContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiSchemaCreateOrUpdateOperation CreateOrUpdate(string schemaId, Azure.ResourceManager.ApiManagement.SchemaContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiSchemaCreateOrUpdateOperation> CreateOrUpdateAsync(string schemaId, Azure.ResourceManager.ApiManagement.SchemaContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContract> Get(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.SchemaContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.SchemaContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContract>> GetAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContract> GetIfExists(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContract>> GetIfExistsAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.SchemaContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.SchemaContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.SchemaContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.SchemaContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SchemaContractData : Azure.ResourceManager.Models.Resource
    {
        public SchemaContractData() { }
        public object Components { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public object Definitions { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ServiceApiDiagnostic : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceApiDiagnostic() { }
        public virtual Azure.ResourceManager.ApiManagement.DiagnosticContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string diagnosticId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiDiagnosticDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiDiagnosticDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic> Update(string ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiDiagnosticCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>, System.Collections.IEnumerable
    {
        protected ServiceApiDiagnosticCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiDiagnosticCreateOrUpdateOperation CreateOrUpdate(string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiDiagnosticCreateOrUpdateOperation> CreateOrUpdateAsync(string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic> Get(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>> GetAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic> GetIfExists(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>> GetIfExistsAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiIssue : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceApiIssue() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiIssueDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiIssueDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue> Get(bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue>> GetAsync(bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.IssueAttachmentContractCollection GetIssueAttachmentContracts() { throw null; }
        public Azure.ResourceManager.ApiManagement.IssueCommentContractCollection GetIssueCommentContracts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.IssueUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.IssueUpdateContract parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiIssueCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiIssue>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiIssue>, System.Collections.IEnumerable
    {
        protected ServiceApiIssueCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiIssueCreateOrUpdateOperation CreateOrUpdate(string issueId, Azure.ResourceManager.ApiManagement.IssueContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiIssueCreateOrUpdateOperation> CreateOrUpdateAsync(string issueId, Azure.ResourceManager.ApiManagement.IssueContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue> Get(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiIssue> GetAll(string filter = null, bool? expandCommentsAttachments = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiIssue> GetAllAsync(string filter = null, bool? expandCommentsAttachments = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue>> GetAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue> GetIfExists(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue>> GetIfExistsAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiIssue> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiIssue>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiIssue> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiIssue>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiOperationPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceApiOperationPolicy() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId, string policyId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiOperationPolicyDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiOperationPolicyDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiOperationPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>, System.Collections.IEnumerable
    {
        protected ServiceApiOperationPolicyCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiOperationPolicyCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiOperationPolicyCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy> Get(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy> GetIfExists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiOperationTag : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceApiOperationTag() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.TagDetachFromOperationOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TagDetachFromOperationOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByOperation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByOperationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiOperationTagCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>, System.Collections.IEnumerable
    {
        protected ServiceApiOperationTagCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.TagAssignToOperationOperation CreateOrUpdate(string tagId, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TagAssignToOperationOperation> CreateOrUpdateAsync(string tagId, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag> GetIfExists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>> GetIfExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceApiPolicy() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string policyId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiPolicyDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiPolicyDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicy> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>, System.Collections.IEnumerable
    {
        protected ServiceApiPolicyCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiPolicyCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiPolicyCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicy> Get(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicy> GetIfExists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceApiTag : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceApiTag() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.TagDetachFromApiOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TagDetachFromApiOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTag> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTag>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByApi(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByApiAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceApiTagCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiTag>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiTag>, System.Collections.IEnumerable
    {
        protected ServiceApiTagCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.TagAssignToApiOperation CreateOrUpdate(string tagId, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TagAssignToApiOperation> CreateOrUpdateAsync(string tagId, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTag> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceApiTag> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceApiTag> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTag>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTag> GetIfExists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTag>> GetIfExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiTag> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiTag>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceApiTag> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceApiTag>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceDiagnostic : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceDiagnostic() { }
        public virtual Azure.ResourceManager.ApiManagement.DiagnosticContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string diagnosticId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.DiagnosticDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.DiagnosticDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic> Update(string ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceDiagnosticCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>, System.Collections.IEnumerable
    {
        protected ServiceDiagnosticCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.DiagnosticCreateOrUpdateOperation CreateOrUpdate(string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.DiagnosticCreateOrUpdateOperation> CreateOrUpdateAsync(string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic> Get(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceDiagnostic> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceDiagnostic> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>> GetAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic> GetIfExists(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>> GetIfExistsAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceDiagnostic> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceDiagnostic> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceIssue : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceIssue() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string issueId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssue> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssue>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceIssueCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceIssue>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceIssue>, System.Collections.IEnumerable
    {
        protected ServiceIssueCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> Exists(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssue> Get(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceIssue> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceIssue> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssue>> GetAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssue> GetIfExists(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceIssue>> GetIfExistsAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceIssue> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceIssue>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceIssue> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceIssue>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServicePolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServicePolicy() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string policyId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.PolicyDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.PolicyDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicy> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicy>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServicePolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServicePolicy>, System.Collections.IEnumerable
    {
        protected ServicePolicyCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.PolicyCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.PolicyCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicy> Get(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.ServicePolicy>> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.ServicePolicy>>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicy>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicy> GetIfExists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicy>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServicePolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServicePolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceProductPolicy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceProductPolicy() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId, string policyId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ProductPolicyDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ProductPolicyDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicy> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceProductPolicyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>, System.Collections.IEnumerable
    {
        protected ServiceProductPolicyCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ProductPolicyCreateOrUpdateOperation CreateOrUpdate(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ProductPolicyCreateOrUpdateOperation> CreateOrUpdateAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicy> Get(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicy> GetIfExists(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyIdName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceProductPolicy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceProductTag : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceProductTag() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.TagDetachFromProductOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TagDetachFromProductOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTag> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTag>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByProduct(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByProductAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceProductTagCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductTag>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductTag>, System.Collections.IEnumerable
    {
        protected ServiceProductTagCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.TagAssignToProductOperation CreateOrUpdate(string tagId, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TagAssignToProductOperation> CreateOrUpdateAsync(string tagId, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTag> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceProductTag> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceProductTag> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTag>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTag> GetIfExists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTag>> GetIfExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceProductTag> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductTag>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceProductTag> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceProductTag>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceSubscription : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceSubscription() { }
        public virtual Azure.ResourceManager.ApiManagement.SubscriptionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string sid) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.SubscriptionDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.SubscriptionDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.SubscriptionKeysContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.SubscriptionKeysContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegeneratePrimaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegeneratePrimaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateSecondaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateSecondaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.SubscriptionUpdateParameters parameters, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.SubscriptionUpdateParameters parameters, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceSubscriptionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceSubscription>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceSubscription>, System.Collections.IEnumerable
    {
        protected ServiceSubscriptionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.SubscriptionCreateOrUpdateOperation CreateOrUpdate(string sid, Azure.ResourceManager.ApiManagement.Models.SubscriptionCreateParameters parameters, bool? notify = default(bool?), string ifMatch = null, Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.SubscriptionCreateOrUpdateOperation> CreateOrUpdateAsync(string sid, Azure.ResourceManager.ApiManagement.Models.SubscriptionCreateParameters parameters, bool? notify = default(bool?), string ifMatch = null, Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription> Get(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceSubscription> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceSubscription> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription>> GetAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription> GetIfExists(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription>> GetIfExistsAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceSubscription> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceSubscription>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceSubscription> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceSubscription>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceTag : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceTag() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.TagDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TagDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityState(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.TagCreateUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.TagCreateUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceTagCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceTag>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceTag>, System.Collections.IEnumerable
    {
        protected ServiceTagCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.TagCreateOrUpdateOperation CreateOrUpdate(string tagId, Azure.ResourceManager.ApiManagement.Models.TagCreateUpdateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.TagCreateOrUpdateOperation> CreateOrUpdateAsync(string tagId, Azure.ResourceManager.ApiManagement.Models.TagCreateUpdateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceTag> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceTag> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag> GetIfExists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag>> GetIfExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceTag> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceTag>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceTag> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceTag>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceUserSubscription : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected ServiceUserSubscription() { }
        public virtual Azure.ResourceManager.ApiManagement.SubscriptionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string userId, string sid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscription> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscription>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceUserSubscriptionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceUserSubscription>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceUserSubscription>, System.Collections.IEnumerable
    {
        protected ServiceUserSubscriptionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> Exists(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscription> Get(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ServiceUserSubscription> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ServiceUserSubscription> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscription>> GetAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscription> GetIfExists(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceUserSubscription>> GetIfExistsAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ServiceUserSubscription> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ServiceUserSubscription>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ServiceUserSubscription> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ServiceUserSubscription>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionContractData : Azure.ResourceManager.Models.Resource
    {
        public SubscriptionContractData() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDate { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndDate { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationDate { get { throw null; } set { } }
        public System.DateTimeOffset? NotificationDate { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public System.DateTimeOffset? StartDate { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
        public string StateComment { get { throw null; } set { } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameAvailabilityResult> CheckNameAvailabilityApiManagementService(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceCheckNameAvailabilityParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameAvailabilityResult>> CheckNameAvailabilityApiManagementServiceAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceCheckNameAvailabilityParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetApiManagementServiceResourcesAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetApiManagementServiceResourcesAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetApiManagementServices(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetApiManagementServicesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementSku> GetApiManagementSkus(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementSku> GetApiManagementSkusAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.DeletedServiceContractCollection GetDeletedServiceContracts(this Azure.ResourceManager.Resources.Subscription subscription) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetDeletedServiceContractsAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetDeletedServiceContractsAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.DeletedServiceContractData> GetDeletedServices(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.DeletedServiceContractData> GetDeletedServicesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetDomainOwnershipIdentifierResult> GetDomainOwnershipIdentifierApiManagementService(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetDomainOwnershipIdentifierResult>> GetDomainOwnershipIdentifierApiManagementServiceAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagContractData : Azure.ResourceManager.Models.Resource
    {
        public TagContractData() { }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class TagDescriptionContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected TagDescriptionContract() { }
        public virtual Azure.ResourceManager.ApiManagement.TagDescriptionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string tagDescriptionId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiTagDescriptionDeleteOperation Delete(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiTagDescriptionDeleteOperation> DeleteAsync(string ifMatch, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagDescriptionContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TagDescriptionContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TagDescriptionContract>, System.Collections.IEnumerable
    {
        protected TagDescriptionContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.ApiTagDescriptionCreateOrUpdateOperation CreateOrUpdate(string tagDescriptionId, Azure.ResourceManager.ApiManagement.Models.TagDescriptionCreateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.ApiTagDescriptionCreateOrUpdateOperation> CreateOrUpdateAsync(string tagDescriptionId, Azure.ResourceManager.ApiManagement.Models.TagDescriptionCreateParameters parameters, string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContract> Get(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.TagDescriptionContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.TagDescriptionContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContract>> GetAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContract> GetIfExists(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContract>> GetIfExistsAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.TagDescriptionContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TagDescriptionContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.TagDescriptionContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TagDescriptionContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TagDescriptionContractData : Azure.ResourceManager.Models.Resource
    {
        public TagDescriptionContractData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalDocsDescription { get { throw null; } set { } }
        public string ExternalDocsUrl { get { throw null; } set { } }
        public string TagId { get { throw null; } set { } }
    }
    public partial class TenantSettingsContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected TenantSettingsContract() { }
        public virtual Azure.ResourceManager.ApiManagement.TenantSettingsContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string settingsType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantSettingsContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TenantSettingsContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TenantSettingsContract>, System.Collections.IEnumerable
    {
        protected TenantSettingsContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContract> Get(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.TenantSettingsContract> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.TenantSettingsContract> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContract>> GetAsync(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContract> GetIfExists(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantSettingsContract>> GetIfExistsAsync(Azure.ResourceManager.ApiManagement.Models.SettingsTypeName settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.TenantSettingsContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TenantSettingsContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.TenantSettingsContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TenantSettingsContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantSettingsContractData : Azure.ResourceManager.Models.Resource
    {
        public TenantSettingsContractData() { }
        public System.Collections.Generic.IDictionary<string, string> Settings { get { throw null; } }
    }
    public partial class UserContract : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected UserContract() { }
        public virtual Azure.ResourceManager.ApiManagement.UserContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public static Azure.ResourceManager.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string userId) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.Models.UserDeleteOperation Delete(string ifMatch, bool? deleteSubscriptions = default(bool?), bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.UserDeleteOperation> DeleteAsync(string ifMatch, bool? deleteSubscriptions = default(bool?), bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GenerateSsoUrlResult> GenerateSsoUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GenerateSsoUrlResult>> GenerateSsoUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.ApiManagement.ServiceUserSubscriptionCollection GetServiceUserSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.UserTokenResult> GetSharedAccessToken(Azure.ResourceManager.ApiManagement.Models.UserTokenParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.UserTokenResult>> GetSharedAccessTokenAsync(Azure.ResourceManager.ApiManagement.Models.UserTokenParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.GroupContractData> GetUserGroups(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.GroupContractData> GetUserGroupsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> GetUserIdentities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> GetUserIdentitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendUserConfirmationPassword(Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendUserConfirmationPasswordAsync(Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContract> Update(string ifMatch, Azure.ResourceManager.ApiManagement.Models.UserUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContract>> UpdateAsync(string ifMatch, Azure.ResourceManager.ApiManagement.Models.UserUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserContractCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.UserContract>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.UserContract>, System.Collections.IEnumerable
    {
        protected UserContractCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.ApiManagement.Models.UserCreateOrUpdateOperation CreateOrUpdate(string userId, Azure.ResourceManager.ApiManagement.Models.UserCreateParameters parameters, bool? notify = default(bool?), string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ApiManagement.Models.UserCreateOrUpdateOperation> CreateOrUpdateAsync(string userId, Azure.ResourceManager.ApiManagement.Models.UserCreateParameters parameters, bool? notify = default(bool?), string ifMatch = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContract> Get(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.UserContract> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.UserContract> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContract>> GetAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.UserContract> GetIfExists(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.UserContract>> GetIfExistsAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.UserContract> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.UserContract>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.UserContract> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.UserContract>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserContractData : Azure.ResourceManager.Models.Resource
    {
        public UserContractData() { }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.GroupContractProperties> Groups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public System.DateTimeOffset? RegistrationDate { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.UserState? State { get { throw null; } set { } }
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
    public partial class AccessInformationCreateParameters
    {
        public AccessInformationCreateParameters() { }
        public bool? Enabled { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
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
    public partial class AccessInformationUpdateParameters
    {
        public AccessInformationUpdateParameters() { }
        public bool? Enabled { get { throw null; } set { } }
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
        public AdditionalLocation(string location, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties sku) { }
        public bool? DisableGateway { get { throw null; } set { } }
        public string GatewayRegionalUrl { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PrivateIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PublicIPAddresses { get { throw null; } }
        public string PublicIpAddressId { get { throw null; } set { } }
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
        public string Url { get { throw null; } set { } }
    }
    public partial class ApiContractProperties : Azure.ResourceManager.ApiManagement.Models.ApiEntityBaseContract
    {
        internal ApiContractProperties() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Path { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.Protocol> Protocols { get { throw null; } }
        public string ServiceUrl { get { throw null; } }
        public string SourceApiId { get { throw null; } }
    }
    public partial class ApiContractUpdateProperties : Azure.ResourceManager.ApiManagement.Models.ApiEntityBaseContract
    {
        internal ApiContractUpdateProperties() { }
        public string DisplayName { get { throw null; } }
        public string Path { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.Protocol> Protocols { get { throw null; } }
        public string ServiceUrl { get { throw null; } }
    }
    public partial class ApiCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiContract>
    {
        protected ApiCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiCreateOrUpdateParameter
    {
        public ApiCreateOrUpdateParameter() { }
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
        public string ServiceUrl { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SoapApiType? SoapApiType { get { throw null; } set { } }
        public string SourceApiId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public string TermsOfServiceUrl { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector { get { throw null; } set { } }
    }
    public partial class ApiCreateOrUpdateProperties : Azure.ResourceManager.ApiManagement.Models.ApiContractProperties
    {
        internal ApiCreateOrUpdateProperties() { }
        public Azure.ResourceManager.ApiManagement.Models.ContentFormat? Format { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.SoapApiType? SoapApiType { get { throw null; } }
        public string Value { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector { get { throw null; } }
    }
    public partial class ApiCreateOrUpdatePropertiesWsdlSelector
    {
        public ApiCreateOrUpdatePropertiesWsdlSelector() { }
        public string WsdlEndpointName { get { throw null; } set { } }
        public string WsdlServiceName { get { throw null; } set { } }
    }
    public partial class ApiDeleteOperation : Azure.Operation
    {
        protected ApiDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiDiagnosticCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>
    {
        protected ApiDiagnosticCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiDiagnosticDeleteOperation : Azure.Operation
    {
        protected ApiDiagnosticDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiDiagnosticUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>
    {
        protected ApiDiagnosticUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiDiagnostic>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string TermsOfServiceUrl { get { throw null; } }
    }
    public partial class ApiExportResult
    {
        internal ApiExportResult() { }
        public Azure.ResourceManager.ApiManagement.Models.ExportResultFormat? ExportResultFormat { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiExportResultValue Value { get { throw null; } }
    }
    public partial class ApiExportResultValue
    {
        internal ApiExportResultValue() { }
        public string Link { get { throw null; } }
    }
    public partial class ApiIssueAttachmentCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>
    {
        protected ApiIssueAttachmentCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.IssueAttachmentContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.IssueAttachmentContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueAttachmentDeleteOperation : Azure.Operation
    {
        protected ApiIssueAttachmentDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueCommentCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.IssueCommentContract>
    {
        protected ApiIssueCommentCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.IssueCommentContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.IssueCommentContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueCommentDeleteOperation : Azure.Operation
    {
        protected ApiIssueCommentDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceApiIssue>
    {
        protected ApiIssueCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceApiIssue Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueDeleteOperation : Azure.Operation
    {
        protected ApiIssueDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceApiIssue>
    {
        protected ApiIssueUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceApiIssue Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiIssue>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiLicenseInformation
    {
        public ApiLicenseInformation() { }
        public string Name { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
    }
    public partial class ApiManagementPerformConnectivityCheckAsyncOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckResponse>
    {
        protected ApiManagementPerformConnectivityCheckAsyncOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckResponse Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckResponse>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckResponse>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceApplyNetworkConfigurationParameters
    {
        public ApiManagementServiceApplyNetworkConfigurationParameters() { }
        public string Location { get { throw null; } set { } }
    }
    public partial class ApiManagementServiceApplyNetworkConfigurationUpdatesOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>
    {
        protected ApiManagementServiceApplyNetworkConfigurationUpdatesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceBackupOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>
    {
        protected ApiManagementServiceBackupOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ApiManagementServiceCheckNameAvailabilityParameters
    {
        public ApiManagementServiceCheckNameAvailabilityParameters(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class ApiManagementServiceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>
    {
        protected ApiManagementServiceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiManagementServiceResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceDeleteOperation : Azure.Operation
    {
        protected ApiManagementServiceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceGetDomainOwnershipIdentifierResult
    {
        internal ApiManagementServiceGetDomainOwnershipIdentifierResult() { }
        public string DomainOwnershipIdentifier { get { throw null; } }
    }
    public partial class ApiManagementServiceGetSsoTokenResult
    {
        internal ApiManagementServiceGetSsoTokenResult() { }
        public string RedirectUri { get { throw null; } }
    }
    public partial class ApiManagementServiceIdentity
    {
        public ApiManagementServiceIdentity(Azure.ResourceManager.ApiManagement.Models.ApimIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApimIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class ApiManagementServiceNameAvailabilityResult
    {
        internal ApiManagementServiceNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.NameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class ApiManagementServiceRestoreOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>
    {
        protected ApiManagementServiceRestoreOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResourceData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceSkuProperties
    {
        public ApiManagementServiceSkuProperties(Azure.ResourceManager.ApiManagement.Models.SkuType name, int capacity) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SkuType Name { get { throw null; } set { } }
    }
    public partial class ApiManagementServiceUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>
    {
        protected ApiManagementServiceUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiManagementServiceResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceUpdateParameters : Azure.ResourceManager.ApiManagement.Models.ApimResource
    {
        public ApiManagementServiceUpdateParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AdditionalLocation> AdditionalLocations { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionConstraint ApiVersionConstraint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.CertificateConfiguration> Certificates { get { throw null; } }
        public System.DateTimeOffset? CreatedAtUtc { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public string DeveloperPortalUrl { get { throw null; } }
        public bool? DisableGateway { get { throw null; } set { } }
        public bool? EnableClientCertificate { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public string GatewayRegionalUrl { get { throw null; } }
        public string GatewayUrl { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.HostnameConfiguration> HostnameConfigurations { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceIdentity Identity { get { throw null; } set { } }
        public string ManagementApiUrl { get { throw null; } }
        public string NotificationSenderEmail { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public string PortalUrl { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RemotePrivateEndpointConnectionWrapper> PrivateEndpointConnections { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PrivateIPAddresses { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PublicIPAddresses { get { throw null; } }
        public string PublicIpAddressId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PublisherEmail { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
        public bool? Restore { get { throw null; } set { } }
        public string ScmUrl { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public string TargetProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
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
        Automatic = 0,
        Manual = 1,
        None = 2,
    }
    public partial class ApiManagementSkuCosts
    {
        internal ApiManagementSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterID { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class ApiManagementSkuLocationInfo
    {
        internal ApiManagementSkuLocationInfo() { }
        public string Location { get { throw null; } }
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
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictionsType? Type { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApimIdentityType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApimIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApimIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApimIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApimIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApimIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApimIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApimIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApimIdentityType left, Azure.ResourceManager.ApiManagement.Models.ApimIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApimIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApimIdentityType left, Azure.ResourceManager.ApiManagement.Models.ApimIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApimResource : Azure.ResourceManager.Models.Resource
    {
        public ApimResource() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ApiOperationCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.OperationContract>
    {
        protected ApiOperationCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.OperationContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiOperationDeleteOperation : Azure.Operation
    {
        protected ApiOperationDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiOperationPolicyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>
    {
        protected ApiOperationPolicyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiOperationPolicyDeleteOperation : Azure.Operation
    {
        protected ApiOperationPolicyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiOperationUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.OperationContract>
    {
        protected ApiOperationUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.OperationContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.OperationContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiPolicyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>
    {
        protected ApiPolicyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceApiPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiPolicyDeleteOperation : Azure.Operation
    {
        protected ApiPolicyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiReleaseCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiReleaseContract>
    {
        protected ApiReleaseCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiReleaseContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiReleaseDeleteOperation : Azure.Operation
    {
        protected ApiReleaseDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiReleaseUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiReleaseContract>
    {
        protected ApiReleaseUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiReleaseContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiRevisionContract
    {
        internal ApiRevisionContract() { }
        public string ApiId { get { throw null; } }
        public string ApiRevision { get { throw null; } }
        public System.DateTimeOffset? CreatedDateTime { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsCurrent { get { throw null; } }
        public bool? IsOnline { get { throw null; } }
        public string PrivateUrl { get { throw null; } }
        public System.DateTimeOffset? UpdatedDateTime { get { throw null; } }
    }
    public partial class ApiSchemaCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.SchemaContract>
    {
        protected ApiSchemaCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.SchemaContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.SchemaContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiSchemaDeleteOperation : Azure.Operation
    {
        protected ApiSchemaDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiTagDescriptionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.TagDescriptionContract>
    {
        protected ApiTagDescriptionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.TagDescriptionContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.TagDescriptionContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiTagDescriptionDeleteOperation : Azure.Operation
    {
        protected ApiTagDescriptionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiTagResourceContractProperties : Azure.ResourceManager.ApiManagement.Models.ApiEntityBaseContract
    {
        internal ApiTagResourceContractProperties() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.Protocol> Protocols { get { throw null; } }
        public string ServiceUrl { get { throw null; } }
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
    public partial class ApiUpdateContract
    {
        public ApiUpdateContract() { }
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
        public string ServiceUrl { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public string TermsOfServiceUrl { get { throw null; } set { } }
    }
    public partial class ApiUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiContract>
    {
        protected ApiUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionConstraint
    {
        public ApiVersionConstraint() { }
        public string MinApiVersion { get { throw null; } set { } }
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
    public partial class ApiVersionSetCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>
    {
        protected ApiVersionSetCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiVersionSetContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionSetDeleteOperation : Azure.Operation
    {
        protected ApiVersionSetDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionSetUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>
    {
        protected ApiVersionSetUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ApiVersionSetContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionSetUpdateParameters
    {
        public ApiVersionSetUpdateParameters() { }
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
    public partial class AssociationContract : Azure.ResourceManager.Models.Resource
    {
        public AssociationContract() { }
        public string ProvisioningState { get { throw null; } set { } }
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
    public partial class AuthorizationServerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>
    {
        protected AuthorizationServerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.AuthorizationServerContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AuthorizationServerDeleteOperation : Azure.Operation
    {
        protected AuthorizationServerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AuthorizationServerSecretsContract
    {
        internal AuthorizationServerSecretsContract() { }
        public string ClientSecret { get { throw null; } }
        public string ResourceOwnerPassword { get { throw null; } }
        public string ResourceOwnerUsername { get { throw null; } }
    }
    public partial class AuthorizationServerUpdateContract : Azure.ResourceManager.Models.Resource
    {
        public AuthorizationServerUpdateContract() { }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AuthorizationMethod> AuthorizationMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod> BearerTokenSendingMethods { get { throw null; } }
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
    public partial class AuthorizationServerUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>
    {
        protected AuthorizationServerUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.AuthorizationServerContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.AuthorizationServerContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackendAuthorizationHeaderCredentials
    {
        public BackendAuthorizationHeaderCredentials(string scheme, string parameter) { }
        public string Parameter { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
    }
    public partial class BackendCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.BackendContract>
    {
        protected BackendCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.BackendContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class BackendDeleteOperation : Azure.Operation
    {
        protected BackendDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackendProperties
    {
        public BackendProperties() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendServiceFabricClusterProperties ServiceFabricCluster { get { throw null; } set { } }
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
        public BackendProxyContract(string url) { }
        public string Password { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class BackendReconnectContract : Azure.ResourceManager.Models.Resource
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
    public partial class BackendUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.BackendContract>
    {
        protected BackendUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.BackendContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.BackendContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackendUpdateParameters
    {
        public BackendUpdateParameters() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendCredentialsContract Credentials { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProxyContract Proxy { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendTlsProperties Tls { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BearerTokenSendingMethod : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BearerTokenSendingMethod(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod AuthorizationHeader { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod Query { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BearerTokenSendingMethods : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BearerTokenSendingMethods(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods AuthorizationHeader { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods Query { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BodyDiagnosticSettings
    {
        public BodyDiagnosticSettings() { }
        public int? Bytes { get { throw null; } set { } }
    }
    public partial class CacheCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.CacheContract>
    {
        protected CacheCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.CacheContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CacheDeleteOperation : Azure.Operation
    {
        protected CacheDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CacheUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.CacheContract>
    {
        protected CacheUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.CacheContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.CacheContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CacheUpdateParameters
    {
        public CacheUpdateParameters() { }
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
    public partial class CertificateCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.CertificateContract>
    {
        protected CertificateCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.CertificateContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.CertificateContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateCreateOrUpdateParameters
    {
        public CertificateCreateOrUpdateParameters() { }
        public string Data { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
    }
    public partial class CertificateDeleteOperation : Azure.Operation
    {
        protected CertificateDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ConnectivityCheckRequest
    {
        public ConnectivityCheckRequest(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestSource source, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestDestination destination) { }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestDestination Destination { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion? PreferredIPVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestProtocolConfiguration ProtocolConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestSource Source { get { throw null; } }
    }
    public partial class ConnectivityCheckRequestDestination
    {
        public ConnectivityCheckRequestDestination(string address, long port) { }
        public string Address { get { throw null; } }
        public long Port { get { throw null; } }
    }
    public partial class ConnectivityCheckRequestProtocolConfiguration
    {
        public ConnectivityCheckRequestProtocolConfiguration() { }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestProtocolConfigurationHttpConfiguration HttpConfiguration { get { throw null; } set { } }
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
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ConnectivityIssue> Issues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NextHopIds { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ConnectivityIssue
    {
        internal ConnectivityIssue() { }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, string>> Context { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.Origin? Origin { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.Severity? Severity { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.IssueType? Type { get { throw null; } }
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
    public partial class ContentItemCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ContentItemContract>
    {
        protected ContentItemCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ContentItemContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ContentItemContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentItemDeleteOperation : Azure.Operation
    {
        protected ContentItemDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentTypeCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ContentTypeContract>
    {
        protected ContentTypeCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ContentTypeContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ContentTypeContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContentTypeDeleteOperation : Azure.Operation
    {
        protected ContentTypeDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.CreatedByType left, Azure.ResourceManager.ApiManagement.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.CreatedByType left, Azure.ResourceManager.ApiManagement.Models.CreatedByType right) { throw null; }
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
    public partial class DelegationSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.PortalDelegationSettings>
    {
        protected DelegationSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.PortalDelegationSettings Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalDelegationSettings>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalDelegationSettings>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DelegationSettingUpdateOperation : Azure.Operation
    {
        protected DelegationSettingUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedServicePurgeOperation : Azure.Operation
    {
        protected DeletedServicePurgeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeployConfigurationParameters
    {
        public DeployConfigurationParameters() { }
        public string Branch { get { throw null; } set { } }
        public bool? Force { get { throw null; } set { } }
    }
    public partial class DiagnosticCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>
    {
        protected DiagnosticCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceDiagnostic Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticDeleteOperation : Azure.Operation
    {
        protected DiagnosticDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>
    {
        protected DiagnosticUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceDiagnostic Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceDiagnostic>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmailTemplateCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.EmailTemplateContract>
    {
        protected EmailTemplateCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.EmailTemplateContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmailTemplateDeleteOperation : Azure.Operation
    {
        protected EmailTemplateDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmailTemplateParametersContractProperties
    {
        public EmailTemplateParametersContractProperties() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class EmailTemplateUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.EmailTemplateContract>
    {
        protected EmailTemplateUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.EmailTemplateContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.EmailTemplateContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportApi : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ExportApi>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportApi(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ExportApi True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ExportApi other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ExportApi left, Azure.ResourceManager.ApiManagement.Models.ExportApi right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ExportApi (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ExportApi left, Azure.ResourceManager.ApiManagement.Models.ExportApi right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ExportFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ExportFormat Openapi { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ExportFormat OpenapiJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ExportFormat Swagger { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ExportFormat Wadl { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ExportFormat Wsdl { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ExportFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ExportFormat left, Azure.ResourceManager.ApiManagement.Models.ExportFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ExportFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ExportFormat left, Azure.ResourceManager.ApiManagement.Models.ExportFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportResultFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ExportResultFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportResultFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ExportResultFormat OpenApi { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ExportResultFormat Swagger { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ExportResultFormat Wadl { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ExportResultFormat Wsdl { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ExportResultFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ExportResultFormat left, Azure.ResourceManager.ApiManagement.Models.ExportResultFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ExportResultFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ExportResultFormat left, Azure.ResourceManager.ApiManagement.Models.ExportResultFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayCertificateAuthorityCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>
    {
        protected GatewayCertificateAuthorityCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayCertificateAuthorityContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayCertificateAuthorityDeleteOperation : Azure.Operation
    {
        protected GatewayCertificateAuthorityDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.GatewayContract>
    {
        protected GatewayCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.GatewayContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayDeleteOperation : Azure.Operation
    {
        protected GatewayDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayHostnameConfigurationCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>
    {
        protected GatewayHostnameConfigurationCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayHostnameConfigurationContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayHostnameConfigurationDeleteOperation : Azure.Operation
    {
        protected GatewayHostnameConfigurationDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class GatewayUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.GatewayContract>
    {
        protected GatewayUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.GatewayContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GatewayContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenerateSsoUrlResult
    {
        internal GenerateSsoUrlResult() { }
        public string Value { get { throw null; } }
    }
    public partial class GlobalSchemaCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>
    {
        protected GlobalSchemaCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.GlobalSchemaContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GlobalSchemaContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalSchemaDeleteOperation : Azure.Operation
    {
        protected GlobalSchemaDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class GroupContractProperties
    {
        internal GroupContractProperties() { }
        public bool? BuiltIn { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ExternalId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.GroupType? Type { get { throw null; } }
    }
    public partial class GroupCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.GroupContract>
    {
        protected GroupCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.GroupContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupCreateParameters
    {
        public GroupCreateParameters() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.GroupType? Type { get { throw null; } set { } }
    }
    public partial class GroupDeleteOperation : Azure.Operation
    {
        protected GroupDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum GroupType
    {
        Custom = 0,
        System = 1,
        External = 2,
    }
    public partial class GroupUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.GroupContract>
    {
        protected GroupUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.GroupContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.GroupContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupUpdateParameters
    {
        public GroupUpdateParameters() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.GroupType? Type { get { throw null; } set { } }
    }
    public partial class HostnameConfiguration
    {
        public HostnameConfiguration(Azure.ResourceManager.ApiManagement.Models.HostnameType type, string hostName) { }
        public Azure.ResourceManager.ApiManagement.Models.CertificateInformation Certificate { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.CertificateSource? CertificateSource { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.CertificateStatus? CertificateStatus { get { throw null; } set { } }
        public bool? DefaultSslBinding { get { throw null; } set { } }
        public string EncodedCertificate { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } set { } }
        public bool? NegotiateClientCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.HostnameType Type { get { throw null; } set { } }
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
        public Azure.ResourceManager.ApiManagement.Models.BodyDiagnosticSettings Body { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.DataMasking DataMasking { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
    }
    public partial class IdentityProviderCreateContract : Azure.ResourceManager.Models.Resource
    {
        public IdentityProviderCreateContract() { }
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
    public partial class IdentityProviderCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.IdentityProviderContract>
    {
        protected IdentityProviderCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.IdentityProviderContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IdentityProviderDeleteOperation : Azure.Operation
    {
        protected IdentityProviderDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class IdentityProviderUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.IdentityProviderContract>
    {
        protected IdentityProviderUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.IdentityProviderContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.IdentityProviderContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IdentityProviderUpdateParameters
    {
        public IdentityProviderUpdateParameters() { }
        public System.Collections.Generic.IList<string> AllowedTenants { get { throw null; } }
        public string Authority { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string PasswordResetPolicyName { get { throw null; } set { } }
        public string ProfileEditingPolicyName { get { throw null; } set { } }
        public string SigninPolicyName { get { throw null; } set { } }
        public string SigninTenant { get { throw null; } set { } }
        public string SignupPolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IdentityProviderType? Type { get { throw null; } set { } }
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
    public partial class IssueUpdateContract
    {
        public IssueUpdateContract() { }
        public string ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDate { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.State? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
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
    public partial class LoggerCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.LoggerContract>
    {
        protected LoggerCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.LoggerContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LoggerDeleteOperation : Azure.Operation
    {
        protected LoggerDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class LoggerUpdateContract
    {
        public LoggerUpdateContract() { }
        public System.Collections.Generic.IDictionary<string, string> Credentials { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsBuffered { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.LoggerType? LoggerType { get { throw null; } set { } }
    }
    public partial class LoggerUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.LoggerContract>
    {
        protected LoggerUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.LoggerContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.LoggerContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class NamedValueCreateContract : Azure.ResourceManager.Models.Resource
    {
        public NamedValueCreateContract() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public bool? Secret { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class NamedValueCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.NamedValueContract>
    {
        protected NamedValueCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.NamedValueContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamedValueDeleteOperation : Azure.Operation
    {
        protected NamedValueDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamedValueRefreshSecretOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.NamedValueContractData>
    {
        protected NamedValueRefreshSecretOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.NamedValueContractData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContractData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContractData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamedValueSecretContract
    {
        internal NamedValueSecretContract() { }
        public string Value { get { throw null; } }
    }
    public partial class NamedValueUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.NamedValueContract>
    {
        protected NamedValueUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.NamedValueContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.NamedValueContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamedValueUpdateParameters
    {
        public NamedValueUpdateParameters() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public bool? Secret { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
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
        public string Location { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract NetworkStatus { get { throw null; } }
    }
    public partial class NotificationCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.NotificationContract>
    {
        protected NotificationCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.NotificationContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.NotificationContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethods> BearerTokenSendingMethods { get { throw null; } }
        public string OpenidProviderId { get { throw null; } set { } }
    }
    public partial class OpenIdConnectProviderCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>
    {
        protected OpenIdConnectProviderCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenIdConnectProviderDeleteOperation : Azure.Operation
    {
        protected OpenIdConnectProviderDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenidConnectProviderUpdateContract
    {
        public OpenidConnectProviderUpdateContract() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string MetadataEndpoint { get { throw null; } set { } }
    }
    public partial class OpenIdConnectProviderUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>
    {
        protected OpenIdConnectProviderUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.OpenidConnectProviderContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class OperationResultContract : Azure.ResourceManager.Models.Resource
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
    public partial class OperationUpdateContract
    {
        public OperationUpdateContract() { }
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
    public partial class OutboundEnvironmentEndpointList
    {
        internal OutboundEnvironmentEndpointList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.OutboundEnvironmentEndpoint> Value { get { throw null; } }
    }
    public partial class ParameterContract
    {
        public ParameterContract(string name, string type) { }
        public string DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ApiManagement.Models.ParameterExampleContract> Examples { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
        public string SchemaId { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class ParameterExampleContract
    {
        public ParameterExampleContract() { }
        public string Description { get { throw null; } set { } }
        public string ExternalValue { get { throw null; } set { } }
        public string Summary { get { throw null; } set { } }
        public object Value { get { throw null; } set { } }
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
    public partial class PolicyCollection
    {
        internal PolicyCollection() { }
        public long? Count { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.PolicyContractData> Value { get { throw null; } }
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
    public partial class PolicyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServicePolicy>
    {
        protected PolicyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServicePolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServicePolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyDeleteOperation : Azure.Operation
    {
        protected PolicyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyDescriptionCollection
    {
        internal PolicyDescriptionCollection() { }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.PolicyDescriptionContract> Value { get { throw null; } }
    }
    public partial class PolicyDescriptionContract : Azure.ResourceManager.Models.Resource
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
    public partial class PortalRevisionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.PortalRevisionContract>
    {
        protected PortalRevisionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.PortalRevisionContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PortalRevisionUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.PortalRevisionContract>
    {
        protected PortalRevisionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.PortalRevisionContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalRevisionContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PortalSettingsCollection
    {
        internal PortalSettingsCollection() { }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.PortalSettingsContract> Value { get { throw null; } }
    }
    public partial class PortalSettingsContract : Azure.ResourceManager.Models.Resource
    {
        public PortalSettingsContract() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionsDelegationSettingsProperties Subscriptions { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.TermsOfServiceProperties TermsOfService { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RegistrationDelegationSettingsProperties UserRegistration { get { throw null; } set { } }
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
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionRequest
    {
        public PrivateEndpointConnectionRequest() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PrivateEndpointConnectionRequestProperties Properties { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnectionRequestProperties
    {
        public PrivateEndpointConnectionRequestProperties() { }
        public Azure.ResourceManager.ApiManagement.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.PrivateLinkResourceData> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ProductContractProperties : Azure.ResourceManager.ApiManagement.Models.ProductEntityBaseParameters
    {
        internal ProductContractProperties() { }
        public string DisplayName { get { throw null; } }
    }
    public partial class ProductCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ProductContract>
    {
        protected ProductCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ProductContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProductDeleteOperation : Azure.Operation
    {
        protected ProductDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ProductPolicyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>
    {
        protected ProductPolicyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceProductPolicy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductPolicy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProductPolicyDeleteOperation : Azure.Operation
    {
        protected ProductPolicyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ProductUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ProductContract>
    {
        protected ProductUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ProductContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ProductContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProductUpdateParameters
    {
        public ProductUpdateParameters() { }
        public bool? ApprovalRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ProductState? State { get { throw null; } set { } }
        public bool? SubscriptionRequired { get { throw null; } set { } }
        public int? SubscriptionsLimit { get { throw null; } set { } }
        public string Terms { get { throw null; } set { } }
    }
    public partial class ProductUpdateProperties : Azure.ResourceManager.ApiManagement.Models.ProductEntityBaseParameters
    {
        internal ProductUpdateProperties() { }
        public string DisplayName { get { throw null; } }
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
    public partial class QuotaCounterCollection
    {
        internal QuotaCounterCollection() { }
        public long? Count { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> Value { get { throw null; } }
    }
    public partial class QuotaCounterContract
    {
        internal QuotaCounterContract() { }
        public string CounterKey { get { throw null; } }
        public System.DateTimeOffset PeriodEndTime { get { throw null; } }
        public string PeriodKey { get { throw null; } }
        public System.DateTimeOffset PeriodStartTime { get { throw null; } }
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
    public partial class RecipientEmailCollection
    {
        internal RecipientEmailCollection() { }
        public long? Count { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract> Value { get { throw null; } }
    }
    public partial class RecipientEmailContract : Azure.ResourceManager.Models.Resource
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
    public partial class RecipientUserCollection
    {
        internal RecipientUserCollection() { }
        public long? Count { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract> Value { get { throw null; } }
    }
    public partial class RecipientUserContract : Azure.ResourceManager.Models.Resource
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
    public partial class RegistrationDelegationSettingsProperties
    {
        public RegistrationDelegationSettingsProperties() { }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class RemotePrivateEndpointConnectionWrapper
    {
        public RemotePrivateEndpointConnectionWrapper() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Type { get { throw null; } set { } }
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
        public string IpAddress { get { throw null; } }
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
        public string Url { get { throw null; } }
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
    public partial class ResourceSku
    {
        internal ResourceSku() { }
        public Azure.ResourceManager.ApiManagement.Models.SkuType? Name { get { throw null; } }
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
        public Azure.ResourceManager.ApiManagement.Models.ResourceSku Sku { get { throw null; } }
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
    public partial class SignInSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.PortalSigninSettings>
    {
        protected SignInSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.PortalSigninSettings Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalSigninSettings>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalSigninSettings>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignInSettingUpdateOperation : Azure.Operation
    {
        protected SignInSettingUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignUpSettingCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.PortalSignupSettings>
    {
        protected SignUpSettingCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.PortalSignupSettings Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalSignupSettings>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.PortalSignupSettings>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignUpSettingUpdateOperation : Azure.Operation
    {
        protected SignUpSettingUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SubscriptionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceSubscription>
    {
        protected SubscriptionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceSubscription Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionCreateParameters
    {
        public SubscriptionCreateParameters() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
    }
    public partial class SubscriptionDeleteOperation : Azure.Operation
    {
        protected SubscriptionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SubscriptionsDelegationSettingsProperties
    {
        public SubscriptionsDelegationSettingsProperties() { }
        public bool? Enabled { get { throw null; } set { } }
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
    public partial class SubscriptionUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceSubscription>
    {
        protected SubscriptionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceSubscription Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceSubscription>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SubscriptionUpdateParameters
    {
        public SubscriptionUpdateParameters() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationDate { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
        public string StateComment { get { throw null; } set { } }
    }
    public partial class TagAssignToApiOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceApiTag>
    {
        protected TagAssignToApiOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceApiTag Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTag>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiTag>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagAssignToOperationOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>
    {
        protected TagAssignToOperationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceApiOperationTag Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiOperationTag>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagAssignToProductOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceProductTag>
    {
        protected TagAssignToProductOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceProductTag Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTag>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductTag>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceTag>
    {
        protected TagCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceTag Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagCreateUpdateParameters
    {
        public TagCreateUpdateParameters() { }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class TagDeleteOperation : Azure.Operation
    {
        protected TagDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagDescriptionCreateParameters
    {
        public TagDescriptionCreateParameters() { }
        public string Description { get { throw null; } set { } }
        public string ExternalDocsDescription { get { throw null; } set { } }
        public string ExternalDocsUrl { get { throw null; } set { } }
    }
    public partial class TagDetachFromApiOperation : Azure.Operation
    {
        protected TagDetachFromApiOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagDetachFromOperationOperation : Azure.Operation
    {
        protected TagDetachFromOperationOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TagDetachFromProductOperation : Azure.Operation
    {
        protected TagDetachFromProductOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class TagUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.ServiceTag>
    {
        protected TagUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.ServiceTag Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceTag>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class TenantAccesCreateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.AccessInformationContract>
    {
        protected TenantAccesCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.AccessInformationContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantAccesUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.AccessInformationContract>
    {
        protected TenantAccesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.AccessInformationContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.AccessInformationContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantConfigurationDeployOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>
    {
        protected TenantConfigurationDeployOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.Models.OperationResultContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantConfigurationSaveOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>
    {
        protected TenantConfigurationSaveOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.Models.OperationResultContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantConfigurationSyncStateContract : Azure.ResourceManager.Models.Resource
    {
        public TenantConfigurationSyncStateContract() { }
        public string Branch { get { throw null; } set { } }
        public string CommitId { get { throw null; } set { } }
        public System.DateTimeOffset? ConfigurationChangeDate { get { throw null; } set { } }
        public bool? IsExport { get { throw null; } set { } }
        public bool? IsGitEnabled { get { throw null; } set { } }
        public bool? IsSynced { get { throw null; } set { } }
        public string LastOperationId { get { throw null; } set { } }
        public System.DateTimeOffset? SyncDate { get { throw null; } set { } }
    }
    public partial class TenantConfigurationValidateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>
    {
        protected TenantConfigurationValidateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.Models.OperationResultContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.Models.OperationResultContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class UserCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.UserContract>
    {
        protected UserCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.UserContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.UserContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.UserContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserCreateParameters
    {
        public UserCreateParameters() { }
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
    public partial class UserDeleteOperation : Azure.Operation
    {
        protected UserDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class UserTokenParameters
    {
        public UserTokenParameters() { }
        public System.DateTimeOffset? Expiry { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyType? KeyType { get { throw null; } set { } }
    }
    public partial class UserTokenResult
    {
        internal UserTokenResult() { }
        public string Value { get { throw null; } }
    }
    public partial class UserUpdateOperation : Azure.Operation<Azure.ResourceManager.ApiManagement.UserContract>
    {
        protected UserUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ApiManagement.UserContract Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.UserContract>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ApiManagement.UserContract>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserUpdateParameters
    {
        public UserUpdateParameters() { }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.UserState? State { get { throw null; } set { } }
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
        public string Vnetid { get { throw null; } }
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
