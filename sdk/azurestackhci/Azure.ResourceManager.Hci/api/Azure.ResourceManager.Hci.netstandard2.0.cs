namespace Azure.ResourceManager.Hci
{
    public partial class ArcExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>, System.Collections.IEnumerable
    {
        protected ArcExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ArcExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ArcExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ArcExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ArcExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcExtensionData : Azure.ResourceManager.Models.ResourceData
    {
        public ArcExtensionData() { }
        public Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? AggregateState { get { throw null; } }
        public string ArcExtensionType { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.ExtensionManagedBy? ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> PerNodeExtensionDetails { get { throw null; } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? ShouldAutoUpgradeMinorVersion { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class ArcExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcExtensionResource() { }
        public virtual Azure.ResourceManager.Hci.ArcExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.ArcExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.ExtensionUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArcSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>, System.Collections.IEnumerable
    {
        protected ArcSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.Hci.ArcSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.ArcSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string arcSettingName, Azure.ResourceManager.Hci.ArcSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.ArcSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.ArcSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.ArcSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.ArcSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.ArcSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArcSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public ArcSettingData() { }
        public Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? AggregateState { get { throw null; } }
        public System.Guid? ArcApplicationClientId { get { throw null; } set { } }
        public System.Guid? ArcApplicationObjectId { get { throw null; } set { } }
        public System.Guid? ArcApplicationTenantId { get { throw null; } set { } }
        public string ArcInstanceResourceGroup { get { throw null; } set { } }
        public System.Guid? ArcServicePrincipalObjectId { get { throw null; } set { } }
        public System.BinaryData ConnectivityProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails> DefaultExtensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.PerNodeArcState> PerNodeDetails { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ArcSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArcSettingResource() { }
        public virtual Azure.ResourceManager.Hci.ArcSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> ConsentAndInstallDefaultExtensions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> ConsentAndInstallDefaultExtensionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ArcIdentityResult> CreateIdentity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.ArcIdentityResult>> CreateIdentityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string arcSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.Models.ArcPasswordCredential> GeneratePassword(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.Models.ArcPasswordCredential>> GeneratePasswordAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource> GetArcExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcExtensionResource>> GetArcExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcExtensionCollection GetArcExtensions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitializeDisableProcess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitializeDisableProcessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> Update(Azure.ResourceManager.Hci.Models.ArcSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> UpdateAsync(Azure.ResourceManager.Hci.Models.ArcSettingPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterResource>, System.Collections.IEnumerable
    {
        protected HciClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.HciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Hci.HciClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Guid? AadApplicationObjectId { get { throw null; } set { } }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadServicePrincipalObjectId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string BillingModel { get { throw null; } }
        public System.Guid? CloudId { get { throw null; } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.DateTimeOffset? LastBillingTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastSyncTimestamp { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RegistrationTimestamp { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterReportedProperties ReportedProperties { get { throw null; } }
        public string ResourceProviderObjectId { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Guid? TenantId { get { throw null; } }
        public float? TrialDaysRemaining { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? TypeIdentityType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class HciClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciClusterResource() { }
        public virtual Azure.ResourceManager.Hci.HciClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult> CreateIdentity(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.Models.HciClusterIdentityResult>> CreateIdentityAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource> ExtendSoftwareAssuranceBenefit(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciClusterResource>> ExtendSoftwareAssuranceBenefitAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.SoftwareAssuranceChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource> GetArcSetting(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.ArcSettingResource>> GetArcSettingAsync(string arcSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.ArcSettingCollection GetArcSettings() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetOffers(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetOffersAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> GetPublisher(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetPublisherAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.PublisherCollection GetPublishers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> GetUpdate(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetUpdateAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateCollection GetUpdates() { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummary() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> Update(Azure.ResourceManager.Hci.Models.HciClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> UpdateAsync(Azure.ResourceManager.Hci.Models.HciClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UploadCertificate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciClusterCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UploadCertificateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciClusterCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HciExtensions
    {
        public static Azure.ResourceManager.Hci.ArcExtensionResource GetArcExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingResource GetArcSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciClusterResource> GetHciCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciClusterResource>> GetHciClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterResource GetHciClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterCollection GetHciClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciClusterResource> GetHciClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource> GetHciGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource>> GetHciGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciGalleryImageResource GetHciGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciGalleryImageCollection GetHciGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciGalleryImageResource> GetHciGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciGalleryImageResource> GetHciGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciGuestAgentResource GetHciGuestAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource GetHciHybridIdentityMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciMachineExtensionResource GetHciMachineExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> GetHciMarketplaceGalleryImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>> GetHciMarketplaceGalleryImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource GetHciMarketplaceGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciMarketplaceGalleryImageCollection GetHciMarketplaceGalleryImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> GetHciMarketplaceGalleryImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> GetHciMarketplaceGalleryImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> GetHciNetworkInterface(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>> GetHciNetworkInterfaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciNetworkInterfaceResource GetHciNetworkInterfaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciNetworkInterfaceCollection GetHciNetworkInterfaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> GetHciNetworkInterfaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> GetHciNetworkInterfacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciSkuResource GetHciSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource> GetHciStorageContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource>> GetHciStorageContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciStorageContainerResource GetHciStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciStorageContainerCollection GetHciStorageContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciStorageContainerResource> GetHciStorageContainers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciStorageContainerResource> GetHciStorageContainersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> GetHciVirtualHardDisk(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>> GetHciVirtualHardDiskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualHardDiskResource GetHciVirtualHardDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualHardDiskCollection GetHciVirtualHardDisks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> GetHciVirtualHardDisks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> GetHciVirtualHardDisksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource> GetHciVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource>> GetHciVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualMachineResource GetHciVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualMachineCollection GetHciVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciVirtualMachineResource> GetHciVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciVirtualMachineResource> GetHciVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource> GetHciVirtualNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource>> GetHciVirtualNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualNetworkResource GetHciVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualNetworkCollection GetHciVirtualNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Hci.HciVirtualNetworkResource> GetHciVirtualNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Hci.HciVirtualNetworkResource> GetHciVirtualNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Hci.OfferResource GetOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.PublisherResource GetPublisherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateResource GetUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateRunResource GetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateSummaryResource GetUpdateSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HciGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciGalleryImageResource>, System.Collections.IEnumerable
    {
        protected HciGalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciGalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Hci.HciGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciGalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Hci.HciGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciGalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciGalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciGalleryImageData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciGalleryImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Hci.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciHyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGalleryImageIdentifier Identifier { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OperatingSystemType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciGalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciGalleryImageVersion Version { get { throw null; } set { } }
    }
    public partial class HciGalleryImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciGalleryImageResource() { }
        public virtual Azure.ResourceManager.Hci.HciGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciGalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciGalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciGuestAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciGuestAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciGuestAgentResource>, System.Collections.IEnumerable
    {
        protected HciGuestAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciGuestAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Hci.HciGuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciGuestAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Hci.HciGuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciGuestAgentResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciGuestAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciGuestAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGuestAgentResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciGuestAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciGuestAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciGuestAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciGuestAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciGuestAgentData : Azure.ResourceManager.Models.ResourceData
    {
        public HciGuestAgentData() { }
        public Azure.ResourceManager.Hci.Models.HciGuestCredential Credentials { get { throw null; } set { } }
        public string HttpsProxy { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction? ProvisioningAction { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class HciGuestAgentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciGuestAgentResource() { }
        public virtual Azure.ResourceManager.Hci.HciGuestAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciGuestAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGuestAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciGuestAgentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciGuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciGuestAgentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciGuestAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciHybridIdentityMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>, System.Collections.IEnumerable
    {
        protected HciHybridIdentityMetadataCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metadataName, Azure.ResourceManager.Hci.HciHybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metadataName, Azure.ResourceManager.Hci.HciHybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> Get(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>> GetAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciHybridIdentityMetadataData : Azure.ResourceManager.Models.ResourceData
    {
        public HciHybridIdentityMetadataData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublicKey { get { throw null; } set { } }
        public string ResourceUid { get { throw null; } set { } }
    }
    public partial class HciHybridIdentityMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciHybridIdentityMetadataResource() { }
        public virtual Azure.ResourceManager.Hci.HciHybridIdentityMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string metadataName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciHybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.HciHybridIdentityMetadataData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciMachineExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciMachineExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciMachineExtensionResource>, System.Collections.IEnumerable
    {
        protected HciMachineExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciMachineExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.HciMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciMachineExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.Hci.HciMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciMachineExtensionResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciMachineExtensionResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciMachineExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciMachineExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciMachineExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciMachineExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciMachineExtensionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciMachineExtensionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class HciMachineExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciMachineExtensionResource() { }
        public virtual Azure.ResourceManager.Hci.HciMachineExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciMachineExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciMachineExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciMarketplaceGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>, System.Collections.IEnumerable
    {
        protected HciMarketplaceGalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string marketplaceGalleryImageName, Azure.ResourceManager.Hci.HciMarketplaceGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string marketplaceGalleryImageName, Azure.ResourceManager.Hci.HciMarketplaceGalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> Get(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>> GetAsync(string marketplaceGalleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciMarketplaceGalleryImageData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciMarketplaceGalleryImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Hci.Models.CloudInitDataSource? CloudInitDataSource { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciHyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.OperatingSystemType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciMarketplaceGalleryImageStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciGalleryImageVersion Version { get { throw null; } set { } }
    }
    public partial class HciMarketplaceGalleryImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciMarketplaceGalleryImageResource() { }
        public virtual Azure.ResourceManager.Hci.HciMarketplaceGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string marketplaceGalleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciMarketplaceGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciMarketplaceGalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciMarketplaceGalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciNetworkInterfaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>, System.Collections.IEnumerable
    {
        protected HciNetworkInterfaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.Hci.HciNetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.Hci.HciNetworkInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> Get(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>> GetAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciNetworkInterfaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciNetworkInterfaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciIPConfiguration> IPConfigurations { get { throw null; } }
        public string MacAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciNetworkInterfaceStatus Status { get { throw null; } }
    }
    public partial class HciNetworkInterfaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciNetworkInterfaceResource() { }
        public virtual Azure.ResourceManager.Hci.HciNetworkInterfaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkInterfaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciNetworkInterfaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciNetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciNetworkInterfaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciNetworkInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciSkuResource>, System.Collections.IEnumerable
    {
        protected HciSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> Get(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciSkuResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciSkuResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciSkuData : Azure.ResourceManager.Models.ResourceData
    {
        public HciSkuData() { }
        public string Content { get { throw null; } set { } }
        public string ContentVersion { get { throw null; } set { } }
        public string OfferId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSkuMappings> SkuMappings { get { throw null; } }
    }
    public partial class HciSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciSkuResource() { }
        public virtual Azure.ResourceManager.Hci.HciSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName, string skuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciStorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciStorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciStorageContainerResource>, System.Collections.IEnumerable
    {
        protected HciStorageContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciStorageContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Hci.HciStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciStorageContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Hci.HciStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciStorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciStorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciStorageContainerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciStorageContainerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Hci.Models.HciExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStorageContainerStatus Status { get { throw null; } }
    }
    public partial class HciStorageContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciStorageContainerResource() { }
        public virtual Azure.ResourceManager.Hci.HciStorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciStorageContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciStorageContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciStorageContainerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciStorageContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciStorageContainerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVirtualHardDiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>, System.Collections.IEnumerable
    {
        protected HciVirtualHardDiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualHardDiskName, Azure.ResourceManager.Hci.HciVirtualHardDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualHardDiskName, Azure.ResourceManager.Hci.HciVirtualHardDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> Get(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>> GetAsync(string virtualHardDiskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVirtualHardDiskData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciVirtualHardDiskData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? BlockSizeBytes { get { throw null; } set { } }
        public string ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciDiskFileFormat? DiskFileFormat { get { throw null; } set { } }
        public long? DiskSizeGB { get { throw null; } set { } }
        public bool? Dynamic { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciHyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public int? LogicalSectorBytes { get { throw null; } set { } }
        public int? PhysicalSectorBytes { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciVirtualHardDiskStatus Status { get { throw null; } }
    }
    public partial class HciVirtualHardDiskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVirtualHardDiskResource() { }
        public virtual Azure.ResourceManager.Hci.HciVirtualHardDiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualHardDiskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualHardDiskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciVirtualHardDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualHardDiskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciVirtualHardDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected HciVirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.Hci.HciVirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.Hci.HciVirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource>> GetAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciVirtualMachineData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Hci.Models.HciExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGuestAgentProfile GuestAgentProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciVirtualMachineStatus Status { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStorageProfile StorageProfile { get { throw null; } set { } }
        public string VmId { get { throw null; } }
    }
    public partial class HciVirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVirtualMachineResource() { }
        public virtual Azure.ResourceManager.Hci.HciVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciHybridIdentityMetadataCollection GetAllHciHybridIdentityMetadata() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciGuestAgentResource> GetHciGuestAgent(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciGuestAgentResource>> GetHciGuestAgentAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciGuestAgentCollection GetHciGuestAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource> GetHciHybridIdentityMetadata(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciHybridIdentityMetadataResource>> GetHciHybridIdentityMetadataAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource> GetHciMachineExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciMachineExtensionResource>> GetHciMachineExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciMachineExtensionCollection GetHciMachineExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HciVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected HciVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.Hci.HciVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkName, Azure.ResourceManager.Hci.HciVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource> Get(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.HciVirtualNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.HciVirtualNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource>> GetAsync(string virtualNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.HciVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.HciVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.HciVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.HciVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HciVirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HciVirtualNetworkData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> DhcpOptionsDnsServers { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciNetworkType? NetworkType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciVirtualNetworkStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSubnet> Subnets { get { throw null; } }
        public string VmSwitchName { get { throw null; } set { } }
    }
    public partial class HciVirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HciVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.Hci.HciVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciVirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.HciVirtualNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.Models.HciVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OfferCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OfferResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OfferResource>, System.Collections.IEnumerable
    {
        protected OfferCollection() { }
        public virtual Azure.Response<bool> Exists(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.OfferResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.OfferResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.OfferResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.OfferResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.OfferResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OfferData : Azure.ResourceManager.Models.ResourceData
    {
        public OfferData() { }
        public string Content { get { throw null; } set { } }
        public string ContentVersion { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string PublisherId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSkuMappings> SkuMappings { get { throw null; } }
    }
    public partial class OfferResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfferResource() { }
        public virtual Azure.ResourceManager.Hci.OfferData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName, string offerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.HciSkuResource> GetHciSku(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.HciSkuResource>> GetHciSkuAsync(string skuName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.HciSkuCollection GetHciSkus() { throw null; }
    }
    public partial class PublisherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PublisherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PublisherResource>, System.Collections.IEnumerable
    {
        protected PublisherCollection() { }
        public virtual Azure.Response<bool> Exists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> Get(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.PublisherResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.PublisherResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.PublisherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.PublisherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.PublisherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PublisherData : Azure.ResourceManager.Models.ResourceData
    {
        public PublisherData() { }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PublisherResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublisherResource() { }
        public virtual Azure.ResourceManager.Hci.PublisherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string publisherName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.PublisherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.PublisherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.OfferResource> GetOffer(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.OfferResource>> GetOfferAsync(string offerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.OfferCollection GetOffers() { throw null; }
    }
    public partial class UpdateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateResource>, System.Collections.IEnumerable
    {
        protected UpdateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> Get(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.UpdateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetAsync(string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UpdateData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateData() { }
        public string AdditionalProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciAvailabilityType? AvailabilityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> ComponentVersions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? InstalledOn { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string NotifyMessage { get { throw null; } set { } }
        public string PackagePath { get { throw null; } set { } }
        public float? PackageSizeInMb { get { throw null; } set { } }
        public string PackageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> Prerequisites { get { throw null; } }
        public float? ProgressPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? RebootRequired { get { throw null; } set { } }
        public string ReleaseLink { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciUpdateState? State { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class UpdateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string updateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> GetUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Hci.UpdateRunCollection GetUpdateRuns() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Post(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PostAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>, System.Collections.IEnumerable
    {
        protected UpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Hci.UpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Hci.UpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Hci.UpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Hci.UpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.UpdateRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UpdateRunData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateRunData() { }
        public string Description { get { throw null; } set { } }
        public string Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public string ExpectedExecutionTime { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string NamePropertiesProgressName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? State { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
        public System.DateTimeOffset? TimeStarted { get { throw null; } set { } }
    }
    public partial class UpdateRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateRunResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string updateName, string updateRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateSummaryData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateSummaryData() { }
        public string CurrentOemVersion { get { throw null; } set { } }
        public string CurrentVersion { get { throw null; } set { } }
        public string HardwareModel { get { throw null; } set { } }
        public System.DateTimeOffset? HealthCheckOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPrecheckResult> HealthCheckResult { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciHealthState? HealthState { get { throw null; } set { } }
        public System.DateTimeOffset? LastChecked { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string OemFamily { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> PackageVersions { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? State { get { throw null; } set { } }
    }
    public partial class UpdateSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateSummaryResource() { }
        public virtual Azure.ResourceManager.Hci.UpdateSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummaryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Hci.UpdateSummaryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Hci.UpdateSummaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Hci.UpdateSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Hci.UpdateSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Hci.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcExtensionAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcExtensionAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState Updating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState UpgradeFailedRollbackSucceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState left, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcIdentityResult
    {
        internal ArcIdentityResult() { }
        public System.Guid? ArcApplicationClientId { get { throw null; } }
        public System.Guid? ArcApplicationObjectId { get { throw null; } }
        public System.Guid? ArcApplicationTenantId { get { throw null; } }
        public System.Guid? ArcServicePrincipalObjectId { get { throw null; } }
    }
    public partial class ArcPasswordCredential
    {
        internal ArcPasswordCredential() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string KeyId { get { throw null; } }
        public string SecretText { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcSettingAggregateState : System.IEquatable<Azure.ResourceManager.Hci.Models.ArcSettingAggregateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcSettingAggregateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ArcSettingAggregateState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ArcSettingAggregateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState left, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcSettingPatch
    {
        public ArcSettingPatch() { }
        public System.BinaryData ConnectivityProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public static partial class ArmHciModelFactory
    {
        public static Azure.ResourceManager.Hci.ArcExtensionData ArcExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? aggregateState = default(Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> perNodeExtensionDetails = null, Azure.ResourceManager.Hci.Models.ExtensionManagedBy? managedBy = default(Azure.ResourceManager.Hci.Models.ExtensionManagedBy?), string forceUpdateTag = null, string publisher = null, string arcExtensionType = null, string typeHandlerVersion = null, bool? shouldAutoUpgradeMinorVersion = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, bool? enableAutomaticUpgrade = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Hci.ArcExtensionData ArcExtensionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, Azure.ResourceManager.Hci.Models.ArcExtensionAggregateState? aggregateState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeExtensionState> perNodeExtensionDetails, string forceUpdateTag, string publisher, string arcExtensionType, string typeHandlerVersion, bool? shouldAutoUpgradeMinorVersion, System.BinaryData settings, System.BinaryData protectedSettings, bool? enableAutomaticUpgrade) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcIdentityResult ArcIdentityResult(System.Guid? arcApplicationClientId = default(System.Guid?), System.Guid? arcApplicationTenantId = default(System.Guid?), System.Guid? arcServicePrincipalObjectId = default(System.Guid?), System.Guid? arcApplicationObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ArcPasswordCredential ArcPasswordCredential(string secretText = null, string keyId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, string arcInstanceResourceGroup, System.Guid? arcApplicationClientId, System.Guid? arcApplicationTenantId, System.Guid? arcServicePrincipalObjectId, System.Guid? arcApplicationObjectId, Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails, System.BinaryData connectivityProperties) { throw null; }
        public static Azure.ResourceManager.Hci.ArcSettingData ArcSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string arcInstanceResourceGroup = null, System.Guid? arcApplicationClientId = default(System.Guid?), System.Guid? arcApplicationTenantId = default(System.Guid?), System.Guid? arcServicePrincipalObjectId = default(System.Guid?), System.Guid? arcApplicationObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.ArcSettingAggregateState? aggregateState = default(Azure.ResourceManager.Hci.Models.ArcSettingAggregateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.PerNodeArcState> perNodeDetails = null, System.BinaryData connectivityProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.DefaultExtensionDetails> defaultExtensions = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.DefaultExtensionDetails DefaultExtensionDetails(string category = null, System.DateTimeOffset? consentOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus ExtensionInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.HciStatusLevelType? level = default(Azure.ResourceManager.Hci.Models.HciStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterData HciClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?), System.Guid? cloudId = default(System.Guid?), string cloudManagementEndpoint = null, System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), System.Guid? aadApplicationObjectId = default(System.Guid?), System.Guid? aadServicePrincipalObjectId = default(System.Guid?), Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties = null, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties = null, Azure.ResourceManager.Hci.Models.HciClusterReportedProperties reportedProperties = null, float? trialDaysRemaining = default(float?), string billingModel = null, System.DateTimeOffset? registrationTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastSyncTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastBillingTimestamp = default(System.DateTimeOffset?), string serviceEndpoint = null, string resourceProviderObjectId = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciClusterData HciClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, Azure.ResourceManager.Hci.Models.HciClusterStatus? status, System.Guid? cloudId, string cloudManagementEndpoint, System.Guid? aadClientId, System.Guid? aadTenantId, System.Guid? aadApplicationObjectId, System.Guid? aadServicePrincipalObjectId, Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties softwareAssuranceProperties, Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties desiredProperties, Azure.ResourceManager.Hci.Models.HciClusterReportedProperties reportedProperties, float? trialDaysRemaining, string billingModel, System.DateTimeOffset? registrationTimestamp, System.DateTimeOffset? lastSyncTimestamp, System.DateTimeOffset? lastBillingTimestamp, string serviceEndpoint, string resourceProviderObjectId, System.Guid? principalId, System.Guid? tenantId, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? typeIdentityType, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterIdentityResult HciClusterIdentityResult(System.Guid? aadClientId = default(System.Guid?), System.Guid? aadTenantId = default(System.Guid?), System.Guid? aadServicePrincipalObjectId = default(System.Guid?), System.Guid? aadApplicationObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterNode HciClusterNode(string name = null, float? id = default(float?), Azure.ResourceManager.Hci.Models.WindowsServerSubscription? windowsServerSubscription = default(Azure.ResourceManager.Hci.Models.WindowsServerSubscription?), Azure.ResourceManager.Hci.Models.ClusterNodeType? nodeType = default(Azure.ResourceManager.Hci.Models.ClusterNodeType?), string ehcResourceId = null, string manufacturer = null, string model = null, string osName = null, string osVersion = null, string osDisplayVersion = null, string serialNumber = null, float? coreCount = default(float?), float? memoryInGiB = default(float?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterNode HciClusterNode(string name, float? id, Azure.ResourceManager.Hci.Models.WindowsServerSubscription? windowsServerSubscription, Azure.ResourceManager.Hci.Models.ClusterNodeType? nodeType, string ehcResourceId, string manufacturer, string model, string osName, string osVersion, string osDisplayVersion, string serialNumber, float? coreCount, float? memoryInGiB, System.DateTimeOffset? lastLicensingTimestamp) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterReportedProperties HciClusterReportedProperties(string clusterName = null, System.Guid? clusterId = default(System.Guid?), string clusterVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciClusterNode> nodes = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.ImdsAttestationState? imdsAttestation = default(Azure.ResourceManager.Hci.Models.ImdsAttestationState?), Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? diagnosticLevel = default(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel?), System.Collections.Generic.IEnumerable<string> supportedCapabilities = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciExtensionInstanceView HciExtensionInstanceView(string name = null, string extensionInstanceViewType = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciGalleryImageData HciGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciExtendedLocation extendedLocation = null, string containerName = null, string imagePath = null, Azure.ResourceManager.Hci.Models.OperatingSystemType? osType = default(Azure.ResourceManager.Hci.Models.OperatingSystemType?), Azure.ResourceManager.Hci.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Models.HciHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Models.HciHyperVGeneration?), Azure.ResourceManager.Hci.Models.HciGalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Models.HciGalleryImageVersion version = null, Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState?), Azure.ResourceManager.Hci.Models.HciGalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciGalleryImageProvisioningStatus HciGalleryImageProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciGalleryImageStatus HciGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.HciGalleryImageProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciGuestAgentData HciGuestAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Hci.Models.HciGuestCredential credentials = null, string httpsProxy = null, Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction? provisioningAction = default(Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction?), string status = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciGuestAgentProfile HciGuestAgentProfile(string vmUuid = null, Azure.ResourceManager.Hci.Models.HciAgentStatusType? status = default(Azure.ResourceManager.Hci.Models.HciAgentStatusType?), System.DateTimeOffset? lastStatusChange = default(System.DateTimeOffset?), string agentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciHybridIdentityMetadataData HciHybridIdentityMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string resourceUid = null, string publicKey = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciInstanceViewStatus HciInstanceViewStatus(string code = null, Azure.ResourceManager.Hci.Models.HciStatusLevelType? level = default(Azure.ResourceManager.Hci.Models.HciStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciIPPoolInfo HciIPPoolInfo(string used = null, string available = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciMachineExtensionData HciMachineExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string forceUpdateTag = null, string publisher = null, string typePropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, Azure.ResourceManager.Hci.Models.HciMachineExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciMachineExtensionInstanceView HciMachineExtensionInstanceView(string name = null, string machineExtensionInstanceViewType = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.HciInstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciMarketplaceGalleryImageData HciMarketplaceGalleryImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciExtendedLocation extendedLocation = null, string containerName = null, Azure.ResourceManager.Hci.Models.OperatingSystemType? osType = default(Azure.ResourceManager.Hci.Models.OperatingSystemType?), Azure.ResourceManager.Hci.Models.CloudInitDataSource? cloudInitDataSource = default(Azure.ResourceManager.Hci.Models.CloudInitDataSource?), Azure.ResourceManager.Hci.Models.HciHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Models.HciHyperVGeneration?), Azure.ResourceManager.Hci.Models.HciGalleryImageIdentifier identifier = null, Azure.ResourceManager.Hci.Models.HciGalleryImageVersion version = null, Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState?), Azure.ResourceManager.Hci.Models.HciMarketplaceGalleryImageStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciMarketplaceGalleryImageProvisioningStatus HciMarketplaceGalleryImageProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciMarketplaceGalleryImageStatus HciMarketplaceGalleryImageStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.HciMarketplaceGalleryImageProvisioningStatus provisioningStatus = null, long? downloadSizeInMB = default(long?), long? progressPercentage = default(long?)) { throw null; }
        public static Azure.ResourceManager.Hci.HciNetworkInterfaceData HciNetworkInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciIPConfiguration> ipConfigurations = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> dnsServers = null, Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState?), Azure.ResourceManager.Hci.Models.HciNetworkInterfaceStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkInterfaceProvisioningStatus HciNetworkInterfaceProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkInterfaceStatus HciNetworkInterfaceStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.HciNetworkInterfaceProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciSkuData HciSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string offerId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciStorageContainerData HciStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciExtendedLocation extendedLocation = null, string path = null, Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState?), Azure.ResourceManager.Hci.Models.HciStorageContainerStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciStorageContainerProvisioningStatus HciStorageContainerProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciStorageContainerStatus HciStorageContainerStatus(string errorCode = null, string errorMessage = null, long? availableSizeMB = default(long?), long? containerSizeMB = default(long?), Azure.ResourceManager.Hci.Models.HciStorageContainerProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualHardDiskData HciVirtualHardDiskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciExtendedLocation extendedLocation = null, int? blockSizeBytes = default(int?), long? diskSizeGB = default(long?), bool? dynamic = default(bool?), int? logicalSectorBytes = default(int?), int? physicalSectorBytes = default(int?), Azure.ResourceManager.Hci.Models.HciHyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Hci.Models.HciHyperVGeneration?), Azure.ResourceManager.Hci.Models.HciDiskFileFormat? diskFileFormat = default(Azure.ResourceManager.Hci.Models.HciDiskFileFormat?), Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState?), string containerId = null, Azure.ResourceManager.Hci.Models.HciVirtualHardDiskStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciVirtualHardDiskProvisioningStatus HciVirtualHardDiskProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciVirtualHardDiskStatus HciVirtualHardDiskStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.HciVirtualHardDiskProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualMachineData HciVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Hci.Models.HciHardwareProfile hardwareProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> networkInterfaces = null, Azure.ResourceManager.Hci.Models.HciOSProfile osProfile = null, Azure.ResourceManager.Hci.Models.HciSecurityProfile securityProfile = null, Azure.ResourceManager.Hci.Models.HciStorageProfile storageProfile = null, Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState?), Azure.ResourceManager.Hci.Models.HciVirtualMachineStatus status = null, Azure.ResourceManager.Hci.Models.HciGuestAgentProfile guestAgentProfile = null, string vmId = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineProvisioningStatus HciVirtualMachineProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineStatus HciVirtualMachineStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.HciPowerState? powerState = default(Azure.ResourceManager.Hci.Models.HciPowerState?), Azure.ResourceManager.Hci.Models.HciVirtualMachineProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.HciVirtualNetworkData HciVirtualNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Hci.Models.HciExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> dhcpOptionsDnsServers = null, Azure.ResourceManager.Hci.Models.HciNetworkType? networkType = default(Azure.ResourceManager.Hci.Models.HciNetworkType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSubnet> subnets = null, Azure.ResourceManager.Hci.Models.HciGenericProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState?), string vmSwitchName = null, Azure.ResourceManager.Hci.Models.HciVirtualNetworkStatus status = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciVirtualNetworkProvisioningStatus HciVirtualNetworkProvisioningStatus(string operationId = null, Azure.ResourceManager.Hci.Models.HciClusterStatus? status = default(Azure.ResourceManager.Hci.Models.HciClusterStatus?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciVirtualNetworkStatus HciVirtualNetworkStatus(string errorCode = null, string errorMessage = null, Azure.ResourceManager.Hci.Models.HciVirtualNetworkProvisioningStatus provisioningStatus = null) { throw null; }
        public static Azure.ResourceManager.Hci.OfferData OfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string publisherId = null, string content = null, string contentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciSkuMappings> skuMappings = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeArcState PerNodeArcState(string name = null, string arcInstance = null, Azure.ResourceManager.Hci.Models.NodeArcState? state = default(Azure.ResourceManager.Hci.Models.NodeArcState?)) { throw null; }
        public static Azure.ResourceManager.Hci.Models.PerNodeExtensionState PerNodeExtensionState(string name = null, string extension = null, string typeHandlerVersion = null, Azure.ResourceManager.Hci.Models.NodeExtensionState? state = default(Azure.ResourceManager.Hci.Models.NodeExtensionState?), Azure.ResourceManager.Hci.Models.HciExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.Hci.PublisherData PublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceProperties SoftwareAssuranceProperties(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? softwareAssuranceStatus = default(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus?), Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? softwareAssuranceIntent = default(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent?), System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateData UpdateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? installedOn = default(System.DateTimeOffset?), string description = null, Azure.ResourceManager.Hci.Models.HciUpdateState? state = default(Azure.ResourceManager.Hci.Models.HciUpdateState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.UpdatePrerequisite> prerequisites = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> componentVersions = null, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement? rebootRequired = default(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), string packagePath = null, float? packageSizeInMb = default(float?), string displayName = null, string version = null, string publisher = null, string releaseLink = null, Azure.ResourceManager.Hci.Models.HciAvailabilityType? availabilityType = default(Azure.ResourceManager.Hci.Models.HciAvailabilityType?), string packageType = null, string additionalProperties = null, float? progressPercentage = default(float?), string notifyMessage = null) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, System.DateTimeOffset? timeStarted, System.DateTimeOffset? lastUpdatedOn, string duration, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state, string namePropertiesProgressName, string description, string errorMessage, string status, System.DateTimeOffset? startTimeUtc, System.DateTimeOffset? endTimeUtc, System.DateTimeOffset? lastUpdatedTimeUtc, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateRunData UpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), System.DateTimeOffset? timeStarted = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), string duration = null, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState?), string namePropertiesProgressName = null, string description = null, string errorMessage = null, string status = null, System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedTimeUtc = default(System.DateTimeOffset?), string expectedExecutionTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciUpdateStep> steps = null) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateSummaryData UpdateSummaryData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation? location, Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState, string oemFamily, string hardwareModel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> packageVersions, string currentVersion, System.DateTimeOffset? lastUpdated, System.DateTimeOffset? lastChecked, Azure.ResourceManager.Hci.Models.HciHealthState? healthState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult, System.DateTimeOffset? healthCheckOn, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? state) { throw null; }
        public static Azure.ResourceManager.Hci.UpdateSummaryData UpdateSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Hci.Models.HciProvisioningState? provisioningState = default(Azure.ResourceManager.Hci.Models.HciProvisioningState?), string oemFamily = null, string currentOemVersion = null, string hardwareModel = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPackageVersionInfo> packageVersions = null, string currentVersion = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.DateTimeOffset? lastChecked = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.HciHealthState? healthState = default(Azure.ResourceManager.Hci.Models.HciHealthState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Hci.Models.HciPrecheckResult> healthCheckResult = null, System.DateTimeOffset? healthCheckOn = default(System.DateTimeOffset?), Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState? state = default(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudInitDataSource : System.IEquatable<Azure.ResourceManager.Hci.Models.CloudInitDataSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudInitDataSource(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.CloudInitDataSource Azure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.CloudInitDataSource NoCloud { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.CloudInitDataSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.CloudInitDataSource left, Azure.ResourceManager.Hci.Models.CloudInitDataSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.CloudInitDataSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.CloudInitDataSource left, Azure.ResourceManager.Hci.Models.CloudInitDataSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterNodeType : System.IEquatable<Azure.ResourceManager.Hci.Models.ClusterNodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterNodeType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ClusterNodeType FirstParty { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ClusterNodeType ThirdParty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ClusterNodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ClusterNodeType left, Azure.ResourceManager.Hci.Models.ClusterNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ClusterNodeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ClusterNodeType left, Azure.ResourceManager.Hci.Models.ClusterNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DefaultExtensionDetails
    {
        internal DefaultExtensionDetails() { }
        public string Category { get { throw null; } }
        public System.DateTimeOffset? ConsentOn { get { throw null; } }
    }
    public partial class DynamicMemoryConfiguration
    {
        public DynamicMemoryConfiguration() { }
        public long? MaximumMemoryMB { get { throw null; } set { } }
        public long? MinimumMemoryMB { get { throw null; } set { } }
        public int? TargetMemoryBuffer { get { throw null; } set { } }
    }
    public partial class ExtensionInstanceViewStatus
    {
        internal ExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionManagedBy : System.IEquatable<Azure.ResourceManager.Hci.Models.ExtensionManagedBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionManagedBy(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ExtensionManagedBy Azure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ExtensionManagedBy User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ExtensionManagedBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ExtensionManagedBy left, Azure.ResourceManager.Hci.Models.ExtensionManagedBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ExtensionManagedBy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ExtensionManagedBy left, Azure.ResourceManager.Hci.Models.ExtensionManagedBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtensionUpgradeContent
    {
        public ExtensionUpgradeContent() { }
        public string TargetVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciAgentProvisioningAction : System.IEquatable<Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciAgentProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction Install { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction Repair { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction Uninstall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction left, Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction left, Azure.ResourceManager.Hci.Models.HciAgentProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciAgentStatusType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciAgentStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciAgentStatusType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciAgentStatusType Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAgentStatusType Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAgentStatusType Error { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciAgentStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciAgentStatusType left, Azure.ResourceManager.Hci.Models.HciAgentStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciAgentStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciAgentStatusType left, Azure.ResourceManager.Hci.Models.HciAgentStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciAvailabilityType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciAvailabilityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciAvailabilityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Local { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Notify { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciAvailabilityType Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciAvailabilityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciAvailabilityType left, Azure.ResourceManager.Hci.Models.HciAvailabilityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciAvailabilityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciAvailabilityType left, Azure.ResourceManager.Hci.Models.HciAvailabilityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterCertificateContent
    {
        public HciClusterCertificateContent() { }
        public System.Collections.Generic.IList<string> Certificates { get { throw null; } }
    }
    public partial class HciClusterDesiredProperties
    {
        public HciClusterDesiredProperties() { }
        public Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? DiagnosticLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterDiagnosticLevel : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterDiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Basic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Enhanced { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel Off { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel left, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel left, Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciClusterIdentityResult
    {
        internal HciClusterIdentityResult() { }
        public System.Guid? AadApplicationObjectId { get { throw null; } }
        public System.Guid? AadClientId { get { throw null; } }
        public System.Guid? AadServicePrincipalObjectId { get { throw null; } }
        public System.Guid? AadTenantId { get { throw null; } }
    }
    public partial class HciClusterNode
    {
        internal HciClusterNode() { }
        public float? CoreCount { get { throw null; } }
        public string EhcResourceId { get { throw null; } }
        public float? Id { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset? LastLicensingTimestamp { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public float? MemoryInGiB { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ClusterNodeType? NodeType { get { throw null; } }
        public string OSDisplayVersion { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.WindowsServerSubscription? WindowsServerSubscription { get { throw null; } }
    }
    public partial class HciClusterPatch
    {
        public HciClusterPatch() { }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string CloudManagementEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterDesiredProperties DesiredProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Guid? TenantId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public partial class HciClusterReportedProperties
    {
        internal HciClusterReportedProperties() { }
        public System.Guid? ClusterId { get { throw null; } }
        public string ClusterName { get { throw null; } }
        public string ClusterVersion { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterDiagnosticLevel? DiagnosticLevel { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ImdsAttestationState? ImdsAttestation { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Hci.Models.HciClusterNode> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedCapabilities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciClusterStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.HciClusterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciClusterStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus ConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotConnectedRecently { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus NotYetRegistered { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciClusterStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciClusterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciClusterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciClusterStatus left, Azure.ResourceManager.Hci.Models.HciClusterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciDiskFileFormat : System.IEquatable<Azure.ResourceManager.Hci.Models.HciDiskFileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciDiskFileFormat(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciDiskFileFormat Vhd { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciDiskFileFormat Vhdx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciDiskFileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciDiskFileFormat left, Azure.ResourceManager.Hci.Models.HciDiskFileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciDiskFileFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciDiskFileFormat left, Azure.ResourceManager.Hci.Models.HciDiskFileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciExtendedLocation
    {
        public HciExtendedLocation() { }
        public Azure.ResourceManager.Hci.Models.HciExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciExtendedLocationType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciExtendedLocationType CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciExtendedLocationType left, Azure.ResourceManager.Hci.Models.HciExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciExtendedLocationType left, Azure.ResourceManager.Hci.Models.HciExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciExtensionInstanceView
    {
        internal HciExtensionInstanceView() { }
        public string ExtensionInstanceViewType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.ExtensionInstanceViewStatus Status { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
    }
    public partial class HciGalleryImageIdentifier
    {
        public HciGalleryImageIdentifier(string publisher, string offer, string sku) { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
    }
    public partial class HciGalleryImagePatch
    {
        public HciGalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HciGalleryImageProvisioningStatus
    {
        internal HciGalleryImageProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
    }
    public partial class HciGalleryImageStatus
    {
        internal HciGalleryImageStatus() { }
        public long? DownloadSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciGalleryImageProvisioningStatus ProvisioningStatus { get { throw null; } }
    }
    public partial class HciGalleryImageVersion
    {
        public HciGalleryImageVersion() { }
        public string Name { get { throw null; } set { } }
        public long? OSDiskImageSizeInMB { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciGenericProvisioningState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciGenericProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciGenericProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciGenericProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciGenericProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciGenericProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciGenericProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciGenericProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciGenericProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState left, Azure.ResourceManager.Hci.Models.HciGenericProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciGenericProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciGenericProvisioningState left, Azure.ResourceManager.Hci.Models.HciGenericProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciGuestAgentProfile
    {
        public HciGuestAgentProfile() { }
        public string AgentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastStatusChange { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciAgentStatusType? Status { get { throw null; } }
        public string VmUuid { get { throw null; } }
    }
    public partial class HciGuestCredential
    {
        public HciGuestCredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class HciHardwareProfile
    {
        public HciHardwareProfile() { }
        public Azure.ResourceManager.Hci.Models.DynamicMemoryConfiguration DynamicMemoryConfig { get { throw null; } set { } }
        public long? MemoryMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciVirtualMachineSize? VmSize { get { throw null; } set { } }
    }
    public partial class HciHardwareProfilePatch
    {
        public HciHardwareProfilePatch() { }
        public long? MemoryMB { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciVirtualMachineSize? VmSize { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciHealthState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Failure { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Success { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHealthState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciHealthState left, Azure.ResourceManager.Hci.Models.HciHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciHealthState left, Azure.ResourceManager.Hci.Models.HciHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciHyperVGeneration : System.IEquatable<Azure.ResourceManager.Hci.Models.HciHyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciHyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciHyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciHyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciHyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciHyperVGeneration left, Azure.ResourceManager.Hci.Models.HciHyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciHyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciHyperVGeneration left, Azure.ResourceManager.Hci.Models.HciHyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciInstanceViewStatus
    {
        public HciInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciIPAllocationMethodType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciIPAllocationMethodType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType left, Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType left, Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciIPConfiguration
    {
        public HciIPConfiguration() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciIPConfigurationProperties Properties { get { throw null; } set { } }
    }
    public partial class HciIPConfigurationProperties
    {
        public HciIPConfigurationProperties() { }
        public string Gateway { get { throw null; } set { } }
        public string PrefixLength { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class HciIPPool
    {
        public HciIPPool() { }
        public string End { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciIPPoolInfo Info { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciIPPoolType? IPPoolType { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
    }
    public partial class HciIPPoolInfo
    {
        public HciIPPoolInfo() { }
        public string Available { get { throw null; } }
        public string Used { get { throw null; } }
    }
    public enum HciIPPoolType
    {
        Vm = 0,
        Vippool = 1,
    }
    public partial class HciLinuxConfiguration
    {
        public HciLinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciLinuxSshPublicKey> SshPublicKeys { get { throw null; } }
    }
    public partial class HciLinuxSshPublicKey
    {
        public HciLinuxSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class HciMachineExtensionInstanceView
    {
        public HciMachineExtensionInstanceView() { }
        public string MachineExtensionInstanceViewType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciInstanceViewStatus Status { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } }
    }
    public partial class HciMachineExtensionPatch : Azure.ResourceManager.Hci.Models.HciResourcePatch
    {
        public HciMachineExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string MachineExtensionUpdatePropertiesType { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType left, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType left, Azure.ResourceManager.Hci.Models.HciManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciMarketplaceGalleryImagePatch
    {
        public HciMarketplaceGalleryImagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HciMarketplaceGalleryImageProvisioningStatus
    {
        internal HciMarketplaceGalleryImageProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
    }
    public partial class HciMarketplaceGalleryImageStatus
    {
        internal HciMarketplaceGalleryImageStatus() { }
        public long? DownloadSizeInMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public long? ProgressPercentage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciMarketplaceGalleryImageProvisioningStatus ProvisioningStatus { get { throw null; } }
    }
    public partial class HciNetworkInterfacePatch
    {
        public HciNetworkInterfacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HciNetworkInterfaceProvisioningStatus
    {
        internal HciNetworkInterfaceProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
    }
    public partial class HciNetworkInterfaceStatus
    {
        internal HciNetworkInterfaceStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciNetworkInterfaceProvisioningStatus ProvisioningStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciNetworkType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType Ics { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType Internal { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType L2Bridge { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType L2Tunnel { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType Mirrored { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType Nat { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType Overlay { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType Private { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNetworkType Transparent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciNetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciNetworkType left, Azure.ResourceManager.Hci.Models.HciNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciNetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciNetworkType left, Azure.ResourceManager.Hci.Models.HciNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciNodeRebootRequirement : System.IEquatable<Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciNodeRebootRequirement(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement False { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement True { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement left, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement left, Azure.ResourceManager.Hci.Models.HciNodeRebootRequirement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciOSProfile
    {
        public HciOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciOSType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciOSType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciOSType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciOSType left, Azure.ResourceManager.Hci.Models.HciOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciOSType left, Azure.ResourceManager.Hci.Models.HciOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciPackageVersionInfo
    {
        public HciPackageVersionInfo() { }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public string PackageType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciPowerState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciPowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciPowerState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciPowerState Deallocated { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciPowerState Deallocating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciPowerState Running { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciPowerState Starting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciPowerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciPowerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciPowerState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciPowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciPowerState left, Azure.ResourceManager.Hci.Models.HciPowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciPowerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciPowerState left, Azure.ResourceManager.Hci.Models.HciPowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciPrecheckResult
    {
        public HciPrecheckResult() { }
        public string AdditionalData { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string HealthCheckSource { get { throw null; } set { } }
        public System.BinaryData HealthCheckTags { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Remediation { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.UpdateSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciPrecheckResultTags Tags { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceName { get { throw null; } set { } }
        public string TargetResourceType { get { throw null; } set { } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class HciPrecheckResultTags
    {
        public HciPrecheckResultTags() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciPrivateIPAllocationMethodType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciPrivateIPAllocationMethodType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType left, Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType left, Azure.ResourceManager.Hci.Models.HciPrivateIPAllocationMethodType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciProvisioningState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciProvisioningState left, Azure.ResourceManager.Hci.Models.HciProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciProvisioningState left, Azure.ResourceManager.Hci.Models.HciProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciResourcePatch
    {
        public HciResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HciSecurityProfile
    {
        public HciSecurityProfile() { }
        public bool? EnableTPM { get { throw null; } set { } }
        public bool? SecureBootEnabled { get { throw null; } set { } }
    }
    public partial class HciSkuMappings
    {
        public HciSkuMappings() { }
        public string CatalogPlanId { get { throw null; } set { } }
        public string MarketplaceSkuId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MarketplaceSkuVersions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciStatusLevelType : System.IEquatable<Azure.ResourceManager.Hci.Models.HciStatusLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciStatusLevelType(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Info { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciStatusLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciStatusLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciStatusLevelType left, Azure.ResourceManager.Hci.Models.HciStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciStatusLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciStatusLevelType left, Azure.ResourceManager.Hci.Models.HciStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciStorageContainerPatch
    {
        public HciStorageContainerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HciStorageContainerProvisioningStatus
    {
        internal HciStorageContainerProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
    }
    public partial class HciStorageContainerStatus
    {
        internal HciStorageContainerStatus() { }
        public long? AvailableSizeMB { get { throw null; } }
        public long? ContainerSizeMB { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciStorageContainerProvisioningStatus ProvisioningStatus { get { throw null; } }
    }
    public partial class HciStorageProfile
    {
        public HciStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> DataDisks { get { throw null; } }
        public Azure.Core.ResourceIdentifier ImageReferenceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OSDiskId { get { throw null; } set { } }
        public string VmConfigStoragePathId { get { throw null; } set { } }
    }
    public partial class HciSubnet
    {
        public HciSubnet() { }
        public string AddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciIPAllocationMethodType? IPAllocationMethod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> IPConfigurationReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciIPPool> IPPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.HciSubnetRouteTable RouteTable { get { throw null; } set { } }
        public int? Vlan { get { throw null; } set { } }
    }
    public partial class HciSubnetRoute
    {
        public HciSubnetRoute() { }
        public string AddressPrefix { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NextHopIPAddress { get { throw null; } set { } }
    }
    public partial class HciSubnetRouteTable
    {
        public HciSubnetRouteTable() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciSubnetRoute> Routes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciUpdateState : System.IEquatable<Azure.ResourceManager.Hci.Models.HciUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciUpdateState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState DownloadFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Downloading { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HasPrerequisite { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthCheckFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState HealthChecking { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState InstallationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Installed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Installing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState NotApplicableBecauseAnotherUpdateIsInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Obsolete { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState PreparationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Preparing { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Ready { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ReadyToInstall { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState Recalled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ScanFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciUpdateState ScanInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciUpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciUpdateState left, Azure.ResourceManager.Hci.Models.HciUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciUpdateState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciUpdateState left, Azure.ResourceManager.Hci.Models.HciUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciUpdateStep
    {
        public HciUpdateStep() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        public string ExpectedExecutionTime { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciUpdateStep> Steps { get { throw null; } }
    }
    public partial class HciVirtualHardDiskPatch
    {
        public HciVirtualHardDiskPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HciVirtualHardDiskProvisioningStatus
    {
        internal HciVirtualHardDiskProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
    }
    public partial class HciVirtualHardDiskStatus
    {
        internal HciVirtualHardDiskStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciVirtualHardDiskProvisioningStatus ProvisioningStatus { get { throw null; } }
    }
    public partial class HciVirtualMachinePatch
    {
        public HciVirtualMachinePatch() { }
        public Azure.ResourceManager.Hci.Models.HciVirtualMachinePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HciVirtualMachinePatchProperties
    {
        public HciVirtualMachinePatchProperties() { }
        public Azure.ResourceManager.Hci.Models.HciHardwareProfilePatch HardwareProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> StorageDataDisks { get { throw null; } }
    }
    public partial class HciVirtualMachineProvisioningStatus
    {
        internal HciVirtualMachineProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HciVirtualMachineSize : System.IEquatable<Azure.ResourceManager.Hci.Models.HciVirtualMachineSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HciVirtualMachineSize(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize Custom { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize Default { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardK8S2V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardK8S3V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardK8S4V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardK8S5V1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardK8SV1 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardNK12 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardNK6 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardNV12 { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.HciVirtualMachineSize StandardNV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.HciVirtualMachineSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.HciVirtualMachineSize left, Azure.ResourceManager.Hci.Models.HciVirtualMachineSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.HciVirtualMachineSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.HciVirtualMachineSize left, Azure.ResourceManager.Hci.Models.HciVirtualMachineSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HciVirtualMachineStatus
    {
        internal HciVirtualMachineStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciPowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciVirtualMachineProvisioningStatus ProvisioningStatus { get { throw null; } }
    }
    public partial class HciVirtualNetworkPatch
    {
        public HciVirtualNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HciVirtualNetworkProvisioningStatus
    {
        internal HciVirtualNetworkProvisioningStatus() { }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciClusterStatus? Status { get { throw null; } }
    }
    public partial class HciVirtualNetworkStatus
    {
        internal HciVirtualNetworkStatus() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciVirtualNetworkProvisioningStatus ProvisioningStatus { get { throw null; } }
    }
    public partial class HciWindowsConfiguration
    {
        public HciWindowsConfiguration() { }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Hci.Models.HciWindowsSshPublicKey> SshPublicKeys { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class HciWindowsSshPublicKey
    {
        public HciWindowsSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImdsAttestationState : System.IEquatable<Azure.ResourceManager.Hci.Models.ImdsAttestationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImdsAttestationState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestationState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.ImdsAttestationState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.ImdsAttestationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.ImdsAttestationState left, Azure.ResourceManager.Hci.Models.ImdsAttestationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.ImdsAttestationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.ImdsAttestationState left, Azure.ResourceManager.Hci.Models.ImdsAttestationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeArcState : System.IEquatable<Azure.ResourceManager.Hci.Models.NodeArcState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeArcState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState DisableInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeArcState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.NodeArcState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeArcState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.NodeArcState left, Azure.ResourceManager.Hci.Models.NodeArcState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeExtensionState : System.IEquatable<Azure.ResourceManager.Hci.Models.NodeExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Connected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Creating { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Error { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Moving { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState PartiallyConnected { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.NodeExtensionState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.NodeExtensionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.NodeExtensionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.NodeExtensionState left, Azure.ResourceManager.Hci.Models.NodeExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class PerNodeArcState
    {
        internal PerNodeArcState() { }
        public string ArcInstance { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeArcState? State { get { throw null; } }
    }
    public partial class PerNodeExtensionState
    {
        internal PerNodeExtensionState() { }
        public string Extension { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.HciExtensionInstanceView InstanceView { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.NodeExtensionState? State { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
    }
    public partial class SoftwareAssuranceChangeContent
    {
        public SoftwareAssuranceChangeContent() { }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftwareAssuranceIntent : System.IEquatable<Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftwareAssuranceIntent(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent Disable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SoftwareAssuranceProperties
    {
        public SoftwareAssuranceProperties() { }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceIntent? SoftwareAssuranceIntent { get { throw null; } set { } }
        public Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus? SoftwareAssuranceStatus { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftwareAssuranceStatus : System.IEquatable<Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftwareAssuranceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus left, Azure.ResourceManager.Hci.Models.SoftwareAssuranceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdatePrerequisite
    {
        public UpdatePrerequisite() { }
        public string PackageName { get { throw null; } set { } }
        public string UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateRunPropertiesState : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateRunPropertiesState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Failed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateRunPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateSeverity : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateSeverity(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Critical { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Hidden { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateSeverity left, Azure.ResourceManager.Hci.Models.UpdateSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSeverity left, Azure.ResourceManager.Hci.Models.UpdateSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateSummariesPropertiesState : System.IEquatable<Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateSummariesPropertiesState(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState AppliedSuccessfully { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState PreparationFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState PreparationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateAvailable { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState UpdateInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState left, Azure.ResourceManager.Hci.Models.UpdateSummariesPropertiesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsServerSubscription : System.IEquatable<Azure.ResourceManager.Hci.Models.WindowsServerSubscription>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsServerSubscription(string value) { throw null; }
        public static Azure.ResourceManager.Hci.Models.WindowsServerSubscription Disabled { get { throw null; } }
        public static Azure.ResourceManager.Hci.Models.WindowsServerSubscription Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Hci.Models.WindowsServerSubscription other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public static implicit operator Azure.ResourceManager.Hci.Models.WindowsServerSubscription (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Hci.Models.WindowsServerSubscription left, Azure.ResourceManager.Hci.Models.WindowsServerSubscription right) { throw null; }
        public override string ToString() { throw null; }
    }
}
