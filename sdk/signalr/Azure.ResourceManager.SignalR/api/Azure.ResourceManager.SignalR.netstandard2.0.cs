namespace Azure.ResourceManager.SignalR
{
    public partial class CustomCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.CustomCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.CustomCertificateResource>, System.Collections.IEnumerable
    {
        protected CustomCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.CustomCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.SignalR.CustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.CustomCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.SignalR.CustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.CustomCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.CustomCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.CustomCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.CustomCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.CustomCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.CustomCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.CustomCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.CustomCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomCertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public CustomCertificateData(System.Uri keyVaultBaseUri, string keyVaultSecretName) { }
        public System.Uri KeyVaultBaseUri { get { throw null; } set { } }
        public string KeyVaultSecretName { get { throw null; } set { } }
        public string KeyVaultSecretVersion { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class CustomCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomCertificateResource() { }
        public virtual Azure.ResourceManager.SignalR.CustomCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.CustomCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.CustomCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.CustomCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.CustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.CustomCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.CustomCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.CustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.CustomDomainResource>, System.Collections.IEnumerable
    {
        protected CustomDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.CustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.SignalR.CustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.CustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.SignalR.CustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.CustomDomainResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.CustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.CustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.CustomDomainResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.CustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.CustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.CustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.CustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomDomainData : Azure.ResourceManager.Models.ResourceData
    {
        public CustomDomainData(string domainName, Azure.ResourceManager.Resources.Models.WritableSubResource customCertificate) { }
        public Azure.Core.ResourceIdentifier CustomCertificateId { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class CustomDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomDomainResource() { }
        public virtual Azure.ResourceManager.SignalR.CustomDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.CustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.CustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.CustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.CustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.CustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.CustomDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.SignalR.SharedPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SharedPrivateLinkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.SignalR.SharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.SignalR.SharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SharedPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus? Status { get { throw null; } }
    }
    public partial class SignalRCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRResource>, System.Collections.IEnumerable
    {
        protected SignalRCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.SignalR.SignalRData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.SignalR.SignalRData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SignalRResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.SignalRResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.SignalRResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SignalRData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SignalRData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? ClientCertEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CorsAllowedOrigins { get { throw null; } }
        public bool? DisableAadAuth { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public string ExternalIP { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRFeature> Features { get { throw null; } }
        public string HostName { get { throw null; } }
        public string HostNamePrefix { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.ServiceKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.LiveTraceConfiguration LiveTraceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.SignalRNetworkACLs NetworkACLs { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public int? PublicPort { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.ResourceLogCategory> ResourceLogCategories { get { throw null; } }
        public int? ServerlessConnectionTimeoutInSeconds { get { throw null; } set { } }
        public int? ServerPort { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SignalR.SharedPrivateLinkResourceData> SharedPrivateLinkResources { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.ResourceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.UpstreamTemplate> UpstreamTemplates { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public static partial class SignalRExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SignalR.Models.NameAvailability> CheckNameAvailabilitySignalR(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.SignalR.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.Models.NameAvailability>> CheckNameAvailabilitySignalRAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.SignalR.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SignalR.CustomCertificateResource GetCustomCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SignalR.CustomDomainResource GetCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SignalR.SharedPrivateLinkResource GetSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> GetSignalR(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> GetSignalRAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource GetSignalRPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRResource GetSignalRResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SignalR.SignalRCollection GetSignalRs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SignalR.SignalRResource> GetSignalRs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRResource> GetSignalRsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SignalR.Models.SignalRUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SignalR.Models.SignalRUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalRPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SignalRPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SignalRPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public SignalRPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class SignalRPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SignalRPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SignalRResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SignalRResource() { }
        public virtual Azure.ResourceManager.SignalR.SignalRData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.CustomCertificateResource> GetCustomCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.CustomCertificateResource>> GetCustomCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.CustomCertificateCollection GetCustomCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.CustomDomainResource> GetCustomDomain(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.CustomDomainResource>> GetCustomDomainAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.CustomDomainCollection GetCustomDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.Models.SignalRKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.Models.SignalRKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SharedPrivateLinkResource> GetSharedPrivateLinkResource(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SharedPrivateLinkResource>> GetSharedPrivateLinkResourceAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SharedPrivateLinkResourceCollection GetSharedPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource> GetSignalRPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionResource>> GetSignalRPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SignalR.SignalRPrivateEndpointConnectionCollection GetSignalRPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource> GetSignalRPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.Models.SignalRPrivateLinkResource> GetSignalRPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SignalR.Models.SignalRSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SignalR.Models.SignalRSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.Models.SignalRKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.Models.SignalRKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SignalR.SignalRResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SignalR.SignalRResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SignalR.SignalRResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SignalR.SignalRData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SignalR.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ACLAction : System.IEquatable<Azure.ResourceManager.SignalR.Models.ACLAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ACLAction(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.ACLAction Allow { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ACLAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.ACLAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.ACLAction left, Azure.ResourceManager.SignalR.Models.ACLAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.ACLAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.ACLAction left, Azure.ResourceManager.SignalR.Models.ACLAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureFlag : System.IEquatable<Azure.ResourceManager.SignalR.Models.FeatureFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureFlag(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.FeatureFlag EnableConnectivityLogs { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.FeatureFlag EnableLiveTrace { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.FeatureFlag EnableMessagingLogs { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.FeatureFlag ServiceMode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.FeatureFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.FeatureFlag left, Azure.ResourceManager.SignalR.Models.FeatureFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.FeatureFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.FeatureFlag left, Azure.ResourceManager.SignalR.Models.FeatureFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.SignalR.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.KeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.KeyType Salt { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.KeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.KeyType left, Azure.ResourceManager.SignalR.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.KeyType left, Azure.ResourceManager.SignalR.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveTraceCategory
    {
        public LiveTraceCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class LiveTraceConfiguration
    {
        public LiveTraceConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.LiveTraceCategory> Categories { get { throw null; } }
        public string Enabled { get { throw null; } set { } }
    }
    public partial class NameAvailability
    {
        internal NameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class NameAvailabilityContent
    {
        public NameAvailabilityContent(string resourceType, string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class NetworkACL
    {
        public NetworkACL() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRRequestType> Allow { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.SignalRRequestType> Deny { get { throw null; } }
    }
    public partial class PrivateEndpointACL : Azure.ResourceManager.SignalR.Models.NetworkACL
    {
        public PrivateEndpointACL(string name) { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.SignalR.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.ProvisioningState left, Azure.ResourceManager.SignalR.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.ProvisioningState left, Azure.ResourceManager.SignalR.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateKeyContent
    {
        public RegenerateKeyContent() { }
        public Azure.ResourceManager.SignalR.Models.KeyType? KeyType { get { throw null; } set { } }
    }
    public partial class ResourceLogCategory
    {
        public ResourceLogCategory() { }
        public string Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ResourceSku
    {
        public ResourceSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleType : System.IEquatable<Azure.ResourceManager.SignalR.Models.ScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleType(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.ScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.ScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.ScaleType left, Azure.ResourceManager.SignalR.Models.ScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.ScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.ScaleType left, Azure.ResourceManager.SignalR.Models.ScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceKind : System.IEquatable<Azure.ResourceManager.SignalR.Models.ServiceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceKind(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.ServiceKind RawWebSockets { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.ServiceKind SignalR { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.ServiceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.ServiceKind left, Azure.ResourceManager.SignalR.Models.ServiceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.ServiceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.ServiceKind left, Azure.ResourceManager.SignalR.Models.ServiceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareablePrivateLinkResourceProperties
    {
        public ShareablePrivateLinkResourceProperties() { }
        public string Description { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public string ShareablePrivateLinkResourcePropertiesType { get { throw null; } set { } }
    }
    public partial class ShareablePrivateLinkResourceType
    {
        public ShareablePrivateLinkResourceType() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharedPrivateLinkResourceStatus : System.IEquatable<Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharedPrivateLinkResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus left, Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus left, Azure.ResourceManager.SignalR.Models.SharedPrivateLinkResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRFeature
    {
        public SignalRFeature(Azure.ResourceManager.SignalR.Models.FeatureFlag flag, string value) { }
        public Azure.ResourceManager.SignalR.Models.FeatureFlag Flag { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SignalRKeys
    {
        internal SignalRKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class SignalRNetworkACLs
    {
        public SignalRNetworkACLs() { }
        public Azure.ResourceManager.SignalR.Models.ACLAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.PrivateEndpointACL> PrivateEndpoints { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.NetworkACL PublicNetwork { get { throw null; } set { } }
    }
    public partial class SignalRPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public SignalRPrivateLinkResource() { }
        public string GroupId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SignalR.Models.ShareablePrivateLinkResourceType> ShareablePrivateLinkResourceTypes { get { throw null; } }
    }
    public partial class SignalRPrivateLinkServiceConnectionState
    {
        public SignalRPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.SignalR.Models.PrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRRequestType : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRRequestType(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRRequestType ClientConnection { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRRequestType Restapi { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRRequestType ServerConnection { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRRequestType Trace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRRequestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRRequestType left, Azure.ResourceManager.SignalR.Models.SignalRRequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRRequestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRRequestType left, Azure.ResourceManager.SignalR.Models.SignalRRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRSku
    {
        internal SignalRSku() { }
        public Azure.ResourceManager.SignalR.Models.SkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.ResourceSku Sku { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignalRSkuTier : System.IEquatable<Azure.ResourceManager.SignalR.Models.SignalRSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignalRSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.SignalRSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.SignalRSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.SignalRSkuTier left, Azure.ResourceManager.SignalR.Models.SignalRSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.SignalRSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.SignalRSkuTier left, Azure.ResourceManager.SignalR.Models.SignalRSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SignalRUsage
    {
        internal SignalRUsage() { }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.SignalRUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class SignalRUsageName
    {
        internal SignalRUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuCapacity
    {
        internal SkuCapacity() { }
        public System.Collections.Generic.IReadOnlyList<int> AllowedValues { get { throw null; } }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.SignalR.Models.ScaleType? ScaleType { get { throw null; } }
    }
    public partial class UpstreamAuthSettings
    {
        public UpstreamAuthSettings() { }
        public Azure.ResourceManager.SignalR.Models.UpstreamAuthType? AuthType { get { throw null; } set { } }
        public string ManagedIdentityResource { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpstreamAuthType : System.IEquatable<Azure.ResourceManager.SignalR.Models.UpstreamAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpstreamAuthType(string value) { throw null; }
        public static Azure.ResourceManager.SignalR.Models.UpstreamAuthType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.SignalR.Models.UpstreamAuthType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SignalR.Models.UpstreamAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SignalR.Models.UpstreamAuthType left, Azure.ResourceManager.SignalR.Models.UpstreamAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SignalR.Models.UpstreamAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SignalR.Models.UpstreamAuthType left, Azure.ResourceManager.SignalR.Models.UpstreamAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpstreamTemplate
    {
        public UpstreamTemplate(string urlTemplate) { }
        public Azure.ResourceManager.SignalR.Models.UpstreamAuthSettings Auth { get { throw null; } set { } }
        public string CategoryPattern { get { throw null; } set { } }
        public string EventPattern { get { throw null; } set { } }
        public string HubPattern { get { throw null; } set { } }
        public string UrlTemplate { get { throw null; } set { } }
    }
}
