namespace Azure.ResourceManager.HealthcareApis
{
    public partial class DicomServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.DicomServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.DicomServiceResource>, System.Collections.IEnumerable
    {
        protected DicomServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.DicomServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dicomServiceName, Azure.ResourceManager.HealthcareApis.DicomServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dicomServiceName, Azure.ResourceManager.HealthcareApis.DicomServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> Get(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.DicomServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.DicomServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> GetAsync(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.DicomServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.DicomServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.DicomServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.DicomServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DicomServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DicomServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.CorsConfiguration CorsConfiguration { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HealthcareApis.Models.ServicePrivateEndpointConnectionCreateOrUpdateContent> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } }
    }
    public partial class DicomServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DicomServiceResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.DicomServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dicomServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.DicomServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FhirServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.FhirServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.FhirServiceResource>, System.Collections.IEnumerable
    {
        protected FhirServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.FhirServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fhirServiceName, Azure.ResourceManager.HealthcareApis.FhirServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fhirServiceName, Azure.ResourceManager.HealthcareApis.FhirServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> Get(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.FhirServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.FhirServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> GetAsync(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.FhirServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.FhirServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.FhirServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.FhirServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FhirServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FhirServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration AcrConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration CorsConfiguration { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ServiceEventState? EventState { get { throw null; } }
        public string ExportStorageAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration ImportConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HealthcareApis.Models.ServicePrivateEndpointConnectionCreateOrUpdateContent> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ResourceVersionPolicyConfiguration ResourceVersionPolicyConfiguration { get { throw null; } set { } }
    }
    public partial class FhirServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FhirServiceResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.FhirServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string fhirServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.FhirServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HealthcareApisExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HealthcareApis.Models.ServicesNameAvailabilityInfo> CheckNameAvailabilityService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HealthcareApis.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.Models.ServicesNameAvailabilityInfo>> CheckNameAvailabilityServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HealthcareApis.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.DicomServiceResource GetDicomServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.FhirServiceResource GetFhirServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.IotConnectorResource GetIotConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource GetIotFhirDestinationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription> GetOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>> GetOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource GetServicePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource GetServicePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> GetServicesDescription(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>> GetServicesDescriptionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource GetServicesDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.ServicesDescriptionCollection GetServicesDescriptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> GetServicesDescriptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> GetServicesDescriptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource> GetWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource>> GetWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource GetWorkspacePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource GetWorkspacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.WorkspaceCollection GetWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HealthcareApis.WorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.WorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.IotConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.IotConnectorResource>, System.Collections.IEnumerable
    {
        protected IotConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.IotConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string iotConnectorName, Azure.ResourceManager.HealthcareApis.IotConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.IotConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string iotConnectorName, Azure.ResourceManager.HealthcareApis.IotConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource> Get(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.IotConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.IotConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource>> GetAsync(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.IotConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.IotConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.IotConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.IotConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotConnectorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IotConnectorData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.BinaryData DeviceMappingContent { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.IotEventHubIngestionEndpointConfiguration IngestionEndpointConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class IotConnectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotConnectorResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.IotConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string iotConnectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> GetIotFhirDestination(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>> GetIotFhirDestinationAsync(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.IotFhirDestinationCollection GetIotFhirDestinations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.IotConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.IotConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.IotConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.IotConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotFhirDestinationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>, System.Collections.IEnumerable
    {
        protected IotFhirDestinationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fhirDestinationName, Azure.ResourceManager.HealthcareApis.IotFhirDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fhirDestinationName, Azure.ResourceManager.HealthcareApis.IotFhirDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> Get(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>> GetAsync(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotFhirDestinationData : Azure.ResourceManager.Models.ResourceData
    {
        public IotFhirDestinationData(Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType resourceIdentityResolutionType, string fhirServiceResourceId, Azure.ResourceManager.HealthcareApis.Models.IotMappingProperties fhirMapping) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.BinaryData FhirMappingContent { get { throw null; } set { } }
        public string FhirServiceResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType ResourceIdentityResolutionType { get { throw null; } set { } }
    }
    public partial class IotFhirDestinationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotFhirDestinationResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.IotFhirDestinationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string iotConnectorName, string fhirDestinationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.IotFhirDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.IotFhirDestinationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.IotFhirDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDescriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateEndpointConnectionDescriptionData() { }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkResourceDescriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateLinkResourceDescriptionData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class ServicePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ServicePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthcareApis.Models.ServicePrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthcareApis.Models.ServicePrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServicePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServicePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.PrivateEndpointConnectionDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.ServicePrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.ServicePrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServicePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServicePrivateLinkResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.PrivateLinkResourceDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServicePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected ServicePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServicesDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>, System.Collections.IEnumerable
    {
        protected ServicesDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.HealthcareApis.ServicesDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.HealthcareApis.ServicesDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServicesDescriptionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServicesDescriptionData(Azure.Core.AzureLocation location, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisKind kind) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ServicesProperties Properties { get { throw null; } set { } }
    }
    public partial class ServicesDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServicesDescriptionResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.ServicesDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource> GetServicePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionResource>> GetServicePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.ServicePrivateEndpointConnectionCollection GetServicePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource> GetServicePrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResource>> GetServicePrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.ServicePrivateLinkResourceCollection GetServicePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.ServicesDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.ServicesDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.ServicesDescriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.HealthcareApis.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.HealthcareApis.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.WorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.WorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.WorkspaceProperties Properties { get { throw null; } set { } }
    }
    public partial class WorkspacePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected WorkspacePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthcareApis.PrivateEndpointConnectionDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthcareApis.PrivateEndpointConnectionDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspacePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspacePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.PrivateEndpointConnectionDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.PrivateEndpointConnectionDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.PrivateEndpointConnectionDescriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspacePrivateLinkResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.PrivateLinkResourceDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected WorkspacePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> GetDicomService(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> GetDicomServiceAsync(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.DicomServiceCollection GetDicomServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> GetFhirService(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> GetFhirServiceAsync(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.FhirServiceCollection GetFhirServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource> GetIotConnector(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.IotConnectorResource>> GetIotConnectorAsync(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.IotConnectorCollection GetIotConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource> GetWorkspacePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionResource>> GetWorkspacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.WorkspacePrivateEndpointConnectionCollection GetWorkspacePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource> GetWorkspacePrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResource>> GetWorkspacePrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.WorkspacePrivateLinkResourceCollection GetWorkspacePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.WorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.WorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.WorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HealthcareApis.Models
{
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name, string resourceType) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class CorsConfiguration
    {
        public CorsConfiguration() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public System.Collections.Generic.IList<string> Origins { get { throw null; } }
    }
    public partial class DicomServiceAuthenticationConfiguration
    {
        public DicomServiceAuthenticationConfiguration() { }
        public System.Collections.Generic.IReadOnlyList<string> Audiences { get { throw null; } }
        public string Authority { get { throw null; } }
    }
    public partial class DicomServicePatch : Azure.ResourceManager.HealthcareApis.Models.ResourceTags
    {
        public DicomServicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FhirResourceVersionPolicy : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FhirResourceVersionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy NoVersion { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy Versioned { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy VersionedUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy left, Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy left, Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirServiceAccessPolicyEntry
    {
        public FhirServiceAccessPolicyEntry(string objectId) { }
        public string ObjectId { get { throw null; } set { } }
    }
    public partial class FhirServiceAcrConfiguration
    {
        public FhirServiceAcrConfiguration() { }
        public System.Collections.Generic.IList<string> LoginServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.ServiceOciArtifactEntry> OciArtifacts { get { throw null; } }
    }
    public partial class FhirServiceAuthenticationConfiguration
    {
        public FhirServiceAuthenticationConfiguration() { }
        public string Audience { get { throw null; } set { } }
        public string Authority { get { throw null; } set { } }
        public bool? SmartProxyEnabled { get { throw null; } set { } }
    }
    public partial class FhirServiceCorsConfiguration
    {
        public FhirServiceCorsConfiguration() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public System.Collections.Generic.IList<string> Origins { get { throw null; } }
    }
    public partial class FhirServiceImportConfiguration
    {
        public FhirServiceImportConfiguration() { }
        public bool? Enabled { get { throw null; } set { } }
        public bool? InitialImportMode { get { throw null; } set { } }
        public string IntegrationDataStore { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FhirServiceKind : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FhirServiceKind(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind FhirR4 { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind FhirStu3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind left, Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind left, Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirServicePatch : Azure.ResourceManager.HealthcareApis.Models.ResourceTags
    {
        public FhirServicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
    }
    public enum HealthcareApisKind
    {
        Fhir = 0,
        FhirStu3 = 1,
        FhirR4 = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareApisPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareApisPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareApisPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareApisPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareApisPrivateLinkServiceConnectionState
    {
        public HealthcareApisPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class IotConnectorPatch : Azure.ResourceManager.HealthcareApis.Models.ResourceTags
    {
        public IotConnectorPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
    }
    public partial class IotEventHubIngestionEndpointConfiguration
    {
        public IotEventHubIngestionEndpointConfiguration() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string FullyQualifiedEventHubNamespace { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotIdentityResolutionType : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotIdentityResolutionType(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType Create { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType Lookup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType left, Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType left, Azure.ResourceManager.HealthcareApis.Models.IotIdentityResolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotMappingProperties
    {
        public IotMappingProperties() { }
        public System.BinaryData Content { get { throw null; } set { } }
    }
    public partial class OperationResultsDescription
    {
        internal OperationResultsDescription() { }
        public string EndTime { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationResultStatus : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Requested { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Running { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus left, Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus left, Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Deprovisioned { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Suspended { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState SystemMaintenance { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Verifying { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ProvisioningState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.ProvisioningState left, Azure.ResourceManager.HealthcareApis.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.ProvisioningState left, Azure.ResourceManager.HealthcareApis.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess left, Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess left, Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTags
    {
        public ResourceTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ResourceVersionPolicyConfiguration
    {
        public ResourceVersionPolicyConfiguration() { }
        public Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy? Default { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy> ResourceTypeOverrides { get { throw null; } }
    }
    public partial class ServiceAccessPolicyEntry
    {
        public ServiceAccessPolicyEntry(string objectId) { }
        public string ObjectId { get { throw null; } set { } }
    }
    public partial class ServiceAcrConfigurationInfo
    {
        public ServiceAcrConfigurationInfo() { }
        public System.Collections.Generic.IList<string> LoginServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.ServiceOciArtifactEntry> OciArtifacts { get { throw null; } }
    }
    public partial class ServiceAuthenticationConfigurationInfo
    {
        public ServiceAuthenticationConfigurationInfo() { }
        public string Audience { get { throw null; } set { } }
        public string Authority { get { throw null; } set { } }
        public bool? SmartProxyEnabled { get { throw null; } set { } }
    }
    public partial class ServiceCorsConfigurationInfo
    {
        public ServiceCorsConfigurationInfo() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public System.Collections.Generic.IList<string> Origins { get { throw null; } }
    }
    public partial class ServiceCosmosDbConfigurationInfo
    {
        public ServiceCosmosDbConfigurationInfo() { }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public int? OfferThroughput { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceEventState : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.ServiceEventState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceEventState(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.ServiceEventState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ServiceEventState Enabled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.ServiceEventState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.ServiceEventState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.ServiceEventState left, Azure.ResourceManager.HealthcareApis.Models.ServiceEventState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.ServiceEventState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.ServiceEventState left, Azure.ResourceManager.HealthcareApis.Models.ServiceEventState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceImportConfigurationInfo
    {
        public ServiceImportConfigurationInfo() { }
        public bool? Enabled { get { throw null; } set { } }
        public bool? InitialImportMode { get { throw null; } set { } }
        public string IntegrationDataStore { get { throw null; } set { } }
    }
    public enum ServiceNameUnavailabilityReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    public partial class ServiceOciArtifactEntry
    {
        public ServiceOciArtifactEntry() { }
        public string Digest { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public string LoginServer { get { throw null; } set { } }
    }
    public partial class ServicePrivateEndpointConnectionCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public ServicePrivateEndpointConnectionCreateOrUpdateContent() { }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ServicesDescriptionPatch
    {
        public ServicesDescriptionPatch() { }
        public Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ServicesNameAvailabilityInfo
    {
        internal ServicesNameAvailabilityInfo() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.ServiceNameUnavailabilityReason? Reason { get { throw null; } }
    }
    public partial class ServicesProperties
    {
        public ServicesProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.ServiceAccessPolicyEntry> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.ServiceAcrConfigurationInfo AcrConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ServiceAuthenticationConfigurationInfo AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ServiceCorsConfigurationInfo CorsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ServiceCosmosDbConfigurationInfo CosmosDbConfiguration { get { throw null; } set { } }
        public string ExportStorageAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.ServiceImportConfigurationInfo ImportConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.ServicePrivateEndpointConnectionCreateOrUpdateContent> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class WorkspacePatch : Azure.ResourceManager.HealthcareApis.Models.ResourceTags
    {
        public WorkspacePatch() { }
    }
    public partial class WorkspaceProperties
    {
        public WorkspaceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HealthcareApis.Models.ServicePrivateEndpointConnectionCreateOrUpdateContent> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
}
