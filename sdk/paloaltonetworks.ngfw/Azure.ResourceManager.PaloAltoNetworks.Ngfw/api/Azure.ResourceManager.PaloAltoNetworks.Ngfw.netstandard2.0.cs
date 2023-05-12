namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    public partial class CertificateObjectGlobalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateObjectGlobalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateObjectGlobalRulestackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>, System.Collections.IEnumerable
    {
        protected CertificateObjectGlobalRulestackResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateObjectGlobalRulestackResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateObjectGlobalRulestackResourceData(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum certificateSelfSigned) { }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum CertificateSelfSigned { get { throw null; } set { } }
        public string CertificateSignerResourceId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class CertificateObjectLocalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateObjectLocalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateObjectLocalRulestackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>, System.Collections.IEnumerable
    {
        protected CertificateObjectLocalRulestackResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateObjectLocalRulestackResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateObjectLocalRulestackResourceData(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum certificateSelfSigned) { }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum CertificateSelfSigned { get { throw null; } set { } }
        public string CertificateSignerResourceId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class FirewallResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string firewallName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackInfo> GetGlobalRulestack(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackInfo>> GetGlobalRulestackAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogSettings> GetLogProfile(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogSettings>> GetLogProfileAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SupportInfo> GetSupportInfo(string email = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SupportInfo>> GetSupportInfoAsync(string email = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SaveLogProfile(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogSettings logSettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SaveLogProfileAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogSettings logSettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> Update(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>> UpdateAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>, System.Collections.IEnumerable
    {
        protected FirewallResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> Get(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>> GetAsync(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FirewallResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkProfile networkProfile, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsSettings dnsSettings, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PlanData planData, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceDetails marketplaceDetails) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackDetails AssociatedRulestack { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsSettings DnsSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FrontendSetting> FrontEndSettings { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? IsPanoramaManaged { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public string PanETag { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanoramaConfig PanoramaConfig { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PlanData PlanData { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class FqdnListGlobalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FqdnListGlobalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FqdnListGlobalRulestackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>, System.Collections.IEnumerable
    {
        protected FqdnListGlobalRulestackResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FqdnListGlobalRulestackResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public FqdnListGlobalRulestackResourceData(System.Collections.Generic.IEnumerable<string> fqdnList) { }
        public string AuditComment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FqdnList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class FqdnListLocalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FqdnListLocalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FqdnListLocalRulestackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>, System.Collections.IEnumerable
    {
        protected FqdnListLocalRulestackResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FqdnListLocalRulestackResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public FqdnListLocalRulestackResourceData(System.Collections.Generic.IEnumerable<string> fqdnList) { }
        public string AuditComment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FqdnList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class GlobalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GlobalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Commit(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CommitAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectListResponse> GetAdvancedSecurityObjects(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectListResponse>> GetAdvancedSecurityObjectsAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAppIds(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAppIdsAsync(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource> GetCertificateObjectGlobalRulestackResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource>> GetCertificateObjectGlobalRulestackResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResourceCollection GetCertificateObjectGlobalRulestackResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Changelog> GetChangeLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Changelog>> GetChangeLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Country> GetCountries(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Country> GetCountriesAsync(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetFirewalls(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetFirewallsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource> GetFqdnListGlobalRulestackResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource>> GetFqdnListGlobalRulestackResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResourceCollection GetFqdnListGlobalRulestackResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> GetPostRulesResource(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>> GetPostRulesResourceAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResourceCollection GetPostRulesResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory> GetPredefinedUrlCategories(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory> GetPredefinedUrlCategoriesAsync(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> GetPrefixListGlobalRulestackResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>> GetPrefixListGlobalRulestackResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResourceCollection GetPrefixListGlobalRulestackResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> GetPreRulesResource(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>> GetPreRulesResourceAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResourceCollection GetPreRulesResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesResponse> GetSecurityServices(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesResponse>> GetSecurityServicesAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Revert(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevertAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> Update(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> UpdateAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalRulestackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>, System.Collections.IEnumerable
    {
        protected GlobalRulestackResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string globalRulestackName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string globalRulestackName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> Get(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> GetAsync(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalRulestackResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public GlobalRulestackResourceData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> AssociatedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode? DefaultMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string MinAppIdVersion { get { throw null; } set { } }
        public string PanETag { get { throw null; } set { } }
        public string PanLocation { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServices SecurityServices { get { throw null; } set { } }
    }
    public partial class LocalRulesResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocalRulesResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName, string priority) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounter> GetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounter>> GetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounterReset> ResetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounterReset>> ResetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalRulesResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>, System.Collections.IEnumerable
    {
        protected LocalRulesResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> Get(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>> GetAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocalRulesResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public LocalRulesResourceData(string ruleName) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum? ActionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Applications { get { throw null; } }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Category Category { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum? DecryptionRuleType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddr Destination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? EnableLogging { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string InboundInspectionCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? NegateDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? NegateSource { get { throw null; } set { } }
        public int? Priority { get { throw null; } }
        public string Protocol { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolPortList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RuleName { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? RuleState { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddr Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.TagInfo> Tags { get { throw null; } }
    }
    public partial class LocalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Commit(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CommitAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectListResponse> GetAdvancedSecurityObjects(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectListResponse>> GetAdvancedSecurityObjectsAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAppIds(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAppIdsAsync(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource> GetCertificateObjectLocalRulestackResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource>> GetCertificateObjectLocalRulestackResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResourceCollection GetCertificateObjectLocalRulestackResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Changelog> GetChangeLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Changelog>> GetChangeLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Country> GetCountries(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Country> GetCountriesAsync(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetFirewalls(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetFirewallsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource> GetFqdnListLocalRulestackResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource>> GetFqdnListLocalRulestackResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResourceCollection GetFqdnListLocalRulestackResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource> GetLocalRulesResource(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource>> GetLocalRulesResourceAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResourceCollection GetLocalRulesResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory> GetPredefinedUrlCategories(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory> GetPredefinedUrlCategoriesAsync(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> GetPrefixListResource(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>> GetPrefixListResourceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResourceCollection GetPrefixListResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesResponse> GetSecurityServices(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesResponse>> GetSecurityServicesAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SupportInfo> GetSupportInfo(string email = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SupportInfo>> GetSupportInfoAsync(string email = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Revert(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevertAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> Update(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LocalRulestackResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> UpdateAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LocalRulestackResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalRulestackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>, System.Collections.IEnumerable
    {
        protected LocalRulestackResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string localRulestackName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string localRulestackName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> Get(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> GetAsync(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocalRulestackResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LocalRulestackResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> AssociatedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode? DefaultMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties Identity { get { throw null; } set { } }
        public string MinAppIdVersion { get { throw null; } set { } }
        public string PanETag { get { throw null; } set { } }
        public string PanLocation { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServices SecurityServices { get { throw null; } set { } }
    }
    public static partial class NgfwExtensions
    {
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResource GetCertificateObjectGlobalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResource GetCertificateObjectLocalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource GetFirewallResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> GetFirewallResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource>> GetFirewallResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResourceCollection GetFirewallResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> GetFirewallResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResource> GetFirewallResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResource GetFqdnListGlobalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResource GetFqdnListLocalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource GetGlobalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> GetGlobalRulestackResource(this Azure.ResourceManager.Resources.TenantResource tenantResource, string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> GetGlobalRulestackResourceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResourceCollection GetGlobalRulestackResources(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResource GetLocalRulesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource GetLocalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestackResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> GetLocalRulestackResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResourceCollection GetLocalRulestackResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestackResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestackResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource GetPostRulesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource GetPrefixListGlobalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource GetPrefixListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource GetPreRulesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PostRulesResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostRulesResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string priority) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounter> GetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounter>> GetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounterReset> ResetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounterReset>> ResetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostRulesResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>, System.Collections.IEnumerable
    {
        protected PostRulesResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> Get(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>> GetAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostRulesResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public PostRulesResourceData(string ruleName) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum? ActionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Applications { get { throw null; } }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Category Category { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum? DecryptionRuleType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddr Destination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? EnableLogging { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string InboundInspectionCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? NegateDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? NegateSource { get { throw null; } set { } }
        public int? Priority { get { throw null; } }
        public string Protocol { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolPortList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RuleName { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? RuleState { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddr Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.TagInfo> Tags { get { throw null; } }
    }
    public partial class PrefixListGlobalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrefixListGlobalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrefixListGlobalRulestackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>, System.Collections.IEnumerable
    {
        protected PrefixListGlobalRulestackResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrefixListGlobalRulestackResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public PrefixListGlobalRulestackResourceData(System.Collections.Generic.IEnumerable<string> prefixList) { }
        public string AuditComment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrefixList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrefixListResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrefixListResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrefixListResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>, System.Collections.IEnumerable
    {
        protected PrefixListResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrefixListResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public PrefixListResourceData(System.Collections.Generic.IEnumerable<string> prefixList) { }
        public string AuditComment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrefixList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PreRulesResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PreRulesResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string priority) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounter> GetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounter>> GetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounterReset> ResetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounterReset>> ResetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PreRulesResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>, System.Collections.IEnumerable
    {
        protected PreRulesResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> Get(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>> GetAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PreRulesResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public PreRulesResourceData(string ruleName) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum? ActionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Applications { get { throw null; } }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Category Category { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum? DecryptionRuleType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddr Destination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? EnableLogging { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string InboundInspectionCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? NegateDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? NegateSource { get { throw null; } set { } }
        public int? Priority { get { throw null; } }
        public string Protocol { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolPortList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RuleName { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? RuleState { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddr Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.TagInfo> Tags { get { throw null; } }
    }
}
namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionEnum : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionEnum(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum Allow { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum DenyResetBoth { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum DenyResetServer { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum DenySilent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdvSecurityObjectListResponse
    {
        internal AdvSecurityObjectListResponse() { }
        public string NextLink { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectModel Value { get { throw null; } }
    }
    public partial class AdvSecurityObjectModel
    {
        internal AdvSecurityObjectModel() { }
        public string AdvSecurityObjectModelType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject> Entry { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvSecurityObjectTypeEnum : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvSecurityObjectTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum Feeds { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum UrlCustom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationInsights
    {
        public ApplicationInsights() { }
        public string Id { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
    }
    public partial class AppSeenData
    {
        internal AppSeenData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfo> AppSeenList { get { throw null; } }
        public int Count { get { throw null; } }
    }
    public partial class AppSeenInfo
    {
        internal AppSeenInfo() { }
        public string Category { get { throw null; } }
        public string Risk { get { throw null; } }
        public string StandardPorts { get { throw null; } }
        public string SubCategory { get { throw null; } }
        public string Tag { get { throw null; } }
        public string Technology { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public static partial class ArmNgfwModelFactory
    {
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectListResponse AdvSecurityObjectListResponse(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectModel value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvSecurityObjectModel AdvSecurityObjectModel(string advSecurityObjectModelType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject> entry = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenData AppSeenData(int count = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfo> appSeenList = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfo AppSeenInfo(string title = null, string category = null, string subCategory = null, string risk = null, string tag = null, string technology = null, string standardPorts = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties AzureResourceManagerManagedIdentityProperties(System.Guid? tenantId = default(System.Guid?), string principalId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType managedIdentityType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectGlobalRulestackResourceData CertificateObjectGlobalRulestackResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string certificateSignerResourceId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum certificateSelfSigned = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum), string auditComment = null, string description = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.CertificateObjectLocalRulestackResourceData CertificateObjectLocalRulestackResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string certificateSignerResourceId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum certificateSelfSigned = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum), string auditComment = null, string description = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Changelog Changelog(System.Collections.Generic.IEnumerable<string> changes = null, System.DateTimeOffset? lastCommitted = default(System.DateTimeOffset?), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Country Country(string code = null, string description = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.FirewallResourceData FirewallResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties identity = null, string panETag = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkProfile networkProfile = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? isPanoramaManaged = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanoramaConfig panoramaConfig = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackDetails associatedRulestack = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsSettings dnsSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FrontendSetting> frontEndSettings = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PlanData planData = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceDetails marketplaceDetails = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListGlobalRulestackResourceData FqdnListGlobalRulestackResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> fqdnList = null, Azure.ETag? etag = default(Azure.ETag?), string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.FqdnListLocalRulestackResourceData FqdnListLocalRulestackResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> fqdnList = null, Azure.ETag? etag = default(Azure.ETag?), string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackInfo GlobalRulestackInfo(string azureId = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResourceData GlobalRulestackResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties identity = null, string panETag = null, string panLocation = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType? scope = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType?), System.Collections.Generic.IEnumerable<string> associatedSubscriptions = null, string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode? defaultMode = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode?), string minAppIdVersion = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServices securityServices = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulesResourceData LocalRulesResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string ruleName = null, int? priority = default(int?), string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? ruleState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddr source = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? negateSource = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddr destination = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? negateDestination = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), System.Collections.Generic.IEnumerable<string> applications = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Category category = null, string protocol = null, System.Collections.Generic.IEnumerable<string> protocolPortList = null, string inboundInspectionCertificate = null, string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum? actionType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? enableLogging = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum? decryptionRuleType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.TagInfo> tags = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResourceData LocalRulestackResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties identity = null, string panETag = null, string panLocation = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType? scope = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType?), System.Collections.Generic.IEnumerable<string> associatedSubscriptions = null, string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode? defaultMode = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode?), string minAppIdVersion = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServices securityServices = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceDetails MarketplaceDetails(string marketplaceSubscriptionId = null, string offerId = null, string publisherId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject NameDescriptionObject(string name = null, string description = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanoramaConfig PanoramaConfig(string configString = null, string vmAuthKey = null, string panoramaServer = null, string panoramaServer2 = null, string dgName = null, string tplName = null, string cgName = null, string hostName = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PlanData PlanData(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType? usageType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle billingCycle = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle), string planId = null, System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulesResourceData PostRulesResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string ruleName = null, int? priority = default(int?), string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? ruleState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddr source = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? negateSource = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddr destination = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? negateDestination = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), System.Collections.Generic.IEnumerable<string> applications = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Category category = null, string protocol = null, System.Collections.Generic.IEnumerable<string> protocolPortList = null, string inboundInspectionCertificate = null, string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum? actionType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? enableLogging = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum? decryptionRuleType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.TagInfo> tags = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory PredefinedUrlCategory(string action = null, string name = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListGlobalRulestackResourceData PrefixListGlobalRulestackResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> prefixList = null, Azure.ETag? etag = default(Azure.ETag?), string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PrefixListResourceData PrefixListResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> prefixList = null, Azure.ETag? etag = default(Azure.ETag?), string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulesResourceData PreRulesResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string ruleName = null, int? priority = default(int?), string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? ruleState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddr source = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? negateSource = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddr destination = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? negateDestination = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), System.Collections.Generic.IEnumerable<string> applications = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.Category category = null, string protocol = null, System.Collections.Generic.IEnumerable<string> protocolPortList = null, string inboundInspectionCertificate = null, string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum? actionType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ActionEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum? enableLogging = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum? decryptionRuleType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.TagInfo> tags = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounter RuleCounter(string priority = null, string ruleStackName = null, string ruleListName = null, string firewallName = null, string ruleName = null, int? hitCount = default(int?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenData appSeen = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.DateTimeOffset? requestTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCounterReset RuleCounterReset(string priority = null, string ruleStackName = null, string ruleListName = null, string firewallName = null, string ruleName = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesResponse SecurityServicesResponse(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeList value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeList SecurityServicesTypeList(string securityServicesTypeListType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject> entry = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SupportInfo SupportInfo(string productSku = null, string productSerial = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? accountRegistered = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), string accountId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? userDomainSupported = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? userRegistered = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? freeTrial = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum?), int? freeTrialDaysLeft = default(int?), int? freeTrialCreditLeft = default(int?), string helpURL = null, string supportURL = null, string registerURL = null) { throw null; }
    }
    public partial class AzureResourceManagerManagedIdentityProperties
    {
        public AzureResourceManagerManagedIdentityProperties(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType managedIdentityType) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType ManagedIdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingCycle : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingCycle(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle Monthly { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BooleanEnum : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BooleanEnum(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum False { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Category
    {
        public Category(System.Collections.Generic.IEnumerable<string> urlCustom, System.Collections.Generic.IEnumerable<string> feeds) { }
        public System.Collections.Generic.IList<string> Feeds { get { throw null; } }
        public System.Collections.Generic.IList<string> UrlCustom { get { throw null; } }
    }
    public partial class Changelog
    {
        internal Changelog() { }
        public System.Collections.Generic.IReadOnlyList<string> Changes { get { throw null; } }
        public System.DateTimeOffset? LastCommitted { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
    }
    public partial class Country
    {
        internal Country() { }
        public string Code { get { throw null; } }
        public string Description { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DecryptionRuleTypeEnum : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DecryptionRuleTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum None { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum SSLInboundInspection { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum SSLOutboundInspection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultMode : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultMode(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode Firewall { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode IPS { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DestinationAddr
    {
        public DestinationAddr() { }
        public System.Collections.Generic.IList<string> Cidrs { get { throw null; } }
        public System.Collections.Generic.IList<string> Countries { get { throw null; } }
        public System.Collections.Generic.IList<string> Feeds { get { throw null; } }
        public System.Collections.Generic.IList<string> FqdnLists { get { throw null; } }
        public System.Collections.Generic.IList<string> PrefixLists { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsProxy : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsProxy(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy Disabled { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsSettings
    {
        public DnsSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddress> DnsServers { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType? EnabledDnsType { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsProxy? EnableDnsProxy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressNat : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressNat(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat Disabled { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnabledDnsType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnabledDnsType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType Azure { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType Custom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointConfiguration
    {
        public EndpointConfiguration(string port, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddress address) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddress Address { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
    }
    public partial class EventHub
    {
        public EventHub() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NameSpace { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class FirewallResourcePatch
    {
        public FirewallResourcePatch() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class FirewallResourceUpdateProperties
    {
        public FirewallResourceUpdateProperties() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackDetails AssociatedRulestack { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DnsSettings DnsSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FrontendSetting> FrontEndSettings { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? IsPanoramaManaged { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public string PanETag { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanoramaConfig PanoramaConfig { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PlanData PlanData { get { throw null; } set { } }
    }
    public partial class FrontendSetting
    {
        public FrontendSetting(string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType protocol, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EndpointConfiguration frontendConfiguration, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EndpointConfiguration backendConfiguration) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EndpointConfiguration BackendConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EndpointConfiguration FrontendConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType Protocol { get { throw null; } set { } }
    }
    public partial class GlobalRulestackInfo
    {
        internal GlobalRulestackInfo() { }
        public string AzureId { get { throw null; } }
    }
    public partial class GlobalRulestackResourcePatch
    {
        public GlobalRulestackResourcePatch() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackResourceUpdateProperties Properties { get { throw null; } set { } }
    }
    public partial class GlobalRulestackResourceUpdateProperties
    {
        public GlobalRulestackResourceUpdateProperties() { }
        public System.Collections.Generic.IList<string> AssociatedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode? DefaultMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string MinAppIdVersion { get { throw null; } set { } }
        public string PanETag { get { throw null; } set { } }
        public string PanLocation { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServices SecurityServices { get { throw null; } set { } }
    }
    public partial class IPAddress
    {
        public IPAddress() { }
        public string Address { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class IPAddressSpace
    {
        public IPAddressSpace() { }
        public string AddressSpace { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class LocalRulestackResourcePatch
    {
        public LocalRulestackResourcePatch() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AzureResourceManagerManagedIdentityProperties Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LocalRulestackResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LocalRulestackResourceUpdateProperties
    {
        public LocalRulestackResourceUpdateProperties() { }
        public System.Collections.Generic.IList<string> AssociatedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DefaultMode? DefaultMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string MinAppIdVersion { get { throw null; } set { } }
        public string PanETag { get { throw null; } set { } }
        public string PanLocation { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServices SecurityServices { get { throw null; } set { } }
    }
    public partial class LogDestination
    {
        public LogDestination() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EventHub EventHubConfigurations { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MonitorLog MonitorConfigurations { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StorageAccount StorageConfigurations { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogOption : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogOption(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption IndividualDestination { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption SameDestination { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogSettings
    {
        public LogSettings() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ApplicationInsights ApplicationInsights { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogDestination CommonDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogDestination DecryptLogDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogOption? LogOption { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType? LogType { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogDestination ThreatLogDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogDestination TrafficLogDestination { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType Audit { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType Decryption { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType DLP { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType Threat { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType Traffic { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType Wildfire { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LogType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType SystemAndUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MarketplaceDetails
    {
        public MarketplaceDetails(string offerId, string publisherId) { }
        public string MarketplaceSubscriptionId { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } set { } }
        public string OfferId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus FulfillmentRequested { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorLog
    {
        public MonitorLog() { }
        public string Id { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string Workspace { get { throw null; } set { } }
    }
    public partial class NameDescriptionObject
    {
        internal NameDescriptionObject() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType networkType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddress> publicIPs, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat enableEgressNat) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddress> EgressNatIP { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EgressNat EnableEgressNat { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType NetworkType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddress> PublicIPs { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.VnetConfiguration VnetConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.VwanConfiguration VwanConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType Vnet { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType Vwan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PanoramaConfig
    {
        public PanoramaConfig(string configString) { }
        public string CgName { get { throw null; } }
        public string ConfigString { get { throw null; } set { } }
        public string DgName { get { throw null; } }
        public string HostName { get { throw null; } }
        public string PanoramaServer { get { throw null; } }
        public string PanoramaServer2 { get { throw null; } }
        public string TplName { get { throw null; } }
        public string VmAuthKey { get { throw null; } }
    }
    public partial class PlanData
    {
        public PlanData(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle billingCycle, string planId) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BillingCycle BillingCycle { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public string PlanId { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType? UsageType { get { throw null; } set { } }
    }
    public partial class PredefinedUrlCategory
    {
        internal PredefinedUrlCategory() { }
        public string Action { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtocolType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType TCP { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType UDP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RuleCounter
    {
        internal RuleCounter() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenData AppSeen { get { throw null; } }
        public string FirewallName { get { throw null; } }
        public int? HitCount { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimestamp { get { throw null; } }
        public string Priority { get { throw null; } }
        public System.DateTimeOffset? RequestTimestamp { get { throw null; } }
        public string RuleListName { get { throw null; } }
        public string RuleName { get { throw null; } }
        public string RuleStackName { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class RuleCounterReset
    {
        internal RuleCounterReset() { }
        public string FirewallName { get { throw null; } }
        public string Priority { get { throw null; } }
        public string RuleListName { get { throw null; } }
        public string RuleName { get { throw null; } }
        public string RuleStackName { get { throw null; } }
    }
    public partial class RulestackDetails
    {
        public RulestackDetails() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string RulestackId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScopeType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScopeType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType Global { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.ScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityServices
    {
        public SecurityServices() { }
        public string AntiSpywareProfile { get { throw null; } set { } }
        public string AntiVirusProfile { get { throw null; } set { } }
        public string DnsSubscription { get { throw null; } set { } }
        public string FileBlockingProfile { get { throw null; } set { } }
        public string OutboundTrustCertificate { get { throw null; } set { } }
        public string OutboundUnTrustCertificate { get { throw null; } set { } }
        public string UrlFilteringProfile { get { throw null; } set { } }
        public string VulnerabilityProfile { get { throw null; } set { } }
    }
    public partial class SecurityServicesResponse
    {
        internal SecurityServicesResponse() { }
        public string NextLink { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeList Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityServicesTypeEnum : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityServicesTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum AntiSpyware { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum AntiVirus { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum DnsSubscription { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum FileBlocking { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum IPsVulnerability { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum UrlFiltering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SecurityServicesTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityServicesTypeList
    {
        internal SecurityServicesTypeList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject> Entry { get { throw null; } }
        public string SecurityServicesTypeListType { get { throw null; } }
    }
    public partial class SourceAddr
    {
        public SourceAddr() { }
        public System.Collections.Generic.IList<string> Cidrs { get { throw null; } }
        public System.Collections.Generic.IList<string> Countries { get { throw null; } }
        public System.Collections.Generic.IList<string> Feeds { get { throw null; } }
        public System.Collections.Generic.IList<string> PrefixLists { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StateEnum : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StateEnum(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccount
    {
        public StorageAccount() { }
        public string AccountName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class SupportInfo
    {
        internal SupportInfo() { }
        public string AccountId { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? AccountRegistered { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? FreeTrial { get { throw null; } }
        public int? FreeTrialCreditLeft { get { throw null; } }
        public int? FreeTrialDaysLeft { get { throw null; } }
        public string HelpURL { get { throw null; } }
        public string ProductSerial { get { throw null; } }
        public string ProductSku { get { throw null; } }
        public string RegisterURL { get { throw null; } }
        public string SupportURL { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? UserDomainSupported { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.BooleanEnum? UserRegistered { get { throw null; } }
    }
    public partial class TagInfo
    {
        public TagInfo(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType Committed { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.UsageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VnetConfiguration
    {
        public VnetConfiguration(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace vnet, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace trustSubnet, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace unTrustSubnet) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddress IPOfTrustSubnetForUdr { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace TrustSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace UnTrustSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace Vnet { get { throw null; } set { } }
    }
    public partial class VwanConfiguration
    {
        public VwanConfiguration(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace vHub) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddress IPOfTrustSubnetForUdr { get { throw null; } set { } }
        public string NetworkVirtualApplianceId { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace TrustSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace UnTrustSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpace VHub { get { throw null; } set { } }
    }
}
