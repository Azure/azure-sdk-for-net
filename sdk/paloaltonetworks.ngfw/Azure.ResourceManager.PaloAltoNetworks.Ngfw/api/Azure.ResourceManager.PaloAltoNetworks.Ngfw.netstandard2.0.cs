namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    public partial class GlobalRulestackCertificateObjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>, System.Collections.IEnumerable
    {
        protected GlobalRulestackCertificateObjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalRulestackCertificateObjectData : Azure.ResourceManager.Models.ResourceData
    {
        public GlobalRulestackCertificateObjectData(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType certificateSelfSigned) { }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType CertificateSelfSigned { get { throw null; } set { } }
        public string CertificateSignerResourceId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class GlobalRulestackCertificateObjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GlobalRulestackCertificateObjectResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalRulestackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>, System.Collections.IEnumerable
    {
        protected GlobalRulestackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string globalRulestackName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string globalRulestackName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> Get(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> GetAsync(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> GetIfExists(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> GetIfExistsAsync(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalRulestackData : Azure.ResourceManager.Models.ResourceData
    {
        public GlobalRulestackData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> AssociatedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode? DefaultMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string MinAppIdVersion { get { throw null; } set { } }
        public Azure.ETag? PanETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? PanLocation { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServices SecurityServices { get { throw null; } set { } }
    }
    public partial class GlobalRulestackFqdnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>, System.Collections.IEnumerable
    {
        protected GlobalRulestackFqdnCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalRulestackFqdnData : Azure.ResourceManager.Models.ResourceData
    {
        public GlobalRulestackFqdnData(System.Collections.Generic.IEnumerable<string> fqdnList) { }
        public string AuditComment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FqdnList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class GlobalRulestackFqdnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GlobalRulestackFqdnResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalRulestackPrefixCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>, System.Collections.IEnumerable
    {
        protected GlobalRulestackPrefixCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalRulestackPrefixData : Azure.ResourceManager.Models.ResourceData
    {
        public GlobalRulestackPrefixData(System.Collections.Generic.IEnumerable<string> prefixList) { }
        public string AuditComment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrefixList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class GlobalRulestackPrefixResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GlobalRulestackPrefixResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GlobalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Commit(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CommitAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectListResult> GetAdvancedSecurityObjects(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectListResult>> GetAdvancedSecurityObjectsAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAppIds(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAppIdsAsync(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackChangelog> GetChangeLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackChangelog>> GetChangeLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackCountry> GetCountries(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackCountry> GetCountriesAsync(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetFirewalls(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetFirewallsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource> GetGlobalRulestackCertificateObject(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource>> GetGlobalRulestackCertificateObjectAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectCollection GetGlobalRulestackCertificateObjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource> GetGlobalRulestackFqdn(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource>> GetGlobalRulestackFqdnAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnCollection GetGlobalRulestackFqdns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource> GetGlobalRulestackPrefix(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource>> GetGlobalRulestackPrefixAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixCollection GetGlobalRulestackPrefixes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> GetPostRulestackRule(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>> GetPostRulestackRuleAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleCollection GetPostRulestackRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory> GetPredefinedUrlCategories(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory> GetPredefinedUrlCategoriesAsync(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> GetPreRulestackRule(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>> GetPreRulestackRuleAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleCollection GetPreRulestackRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceListResult> GetSecurityServices(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceListResult>> GetSecurityServicesAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Revert(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevertAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> Update(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> UpdateAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalRulestackCertificateObjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>, System.Collections.IEnumerable
    {
        protected LocalRulestackCertificateObjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocalRulestackCertificateObjectData : Azure.ResourceManager.Models.ResourceData
    {
        public LocalRulestackCertificateObjectData(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType certificateSelfSigned) { }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType CertificateSelfSigned { get { throw null; } set { } }
        public string CertificateSignerResourceId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class LocalRulestackCertificateObjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocalRulestackCertificateObjectResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalRulestackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>, System.Collections.IEnumerable
    {
        protected LocalRulestackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string localRulestackName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string localRulestackName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> Get(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> GetAsync(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetIfExists(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> GetIfExistsAsync(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocalRulestackData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LocalRulestackData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> AssociatedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode? DefaultMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string MinAppIdVersion { get { throw null; } set { } }
        public Azure.ETag? PanETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? PanLocation { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServices SecurityServices { get { throw null; } set { } }
    }
    public partial class LocalRulestackFqdnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>, System.Collections.IEnumerable
    {
        protected LocalRulestackFqdnCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocalRulestackFqdnData : Azure.ResourceManager.Models.ResourceData
    {
        public LocalRulestackFqdnData(System.Collections.Generic.IEnumerable<string> fqdnList) { }
        public string AuditComment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FqdnList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class LocalRulestackFqdnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocalRulestackFqdnResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalRulestackPrefixCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>, System.Collections.IEnumerable
    {
        protected LocalRulestackPrefixCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocalRulestackPrefixData : Azure.ResourceManager.Models.ResourceData
    {
        public LocalRulestackPrefixData(System.Collections.Generic.IEnumerable<string> prefixList) { }
        public string AuditComment { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrefixList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class LocalRulestackPrefixResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocalRulestackPrefixResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalRulestackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocalRulestackResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Commit(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CommitAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectListResult> GetAdvancedSecurityObjects(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectListResult>> GetAdvancedSecurityObjectsAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAppIds(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAppIdsAsync(string appIdVersion = null, string appPrefix = null, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackChangelog> GetChangeLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackChangelog>> GetChangeLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackCountry> GetCountries(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackCountry> GetCountriesAsync(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetFirewalls(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetFirewallsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource> GetLocalRulestackCertificateObject(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource>> GetLocalRulestackCertificateObjectAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectCollection GetLocalRulestackCertificateObjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource> GetLocalRulestackFqdn(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource>> GetLocalRulestackFqdnAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnCollection GetLocalRulestackFqdns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource> GetLocalRulestackPrefix(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource>> GetLocalRulestackPrefixAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixCollection GetLocalRulestackPrefixes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> GetLocalRulestackRule(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>> GetLocalRulestackRuleAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleCollection GetLocalRulestackRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory> GetPredefinedUrlCategories(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory> GetPredefinedUrlCategoriesAsync(string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceListResult> GetSecurityServices(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceListResult>> GetSecurityServicesAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType type, string skip = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallSupportInfo> GetSupportInfo(string email = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallSupportInfo>> GetSupportInfoAsync(string email = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Revert(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevertAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> Update(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LocalRulestackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> UpdateAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LocalRulestackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocalRulestackRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>, System.Collections.IEnumerable
    {
        protected LocalRulestackRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> Get(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>> GetAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> GetIfExists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>> GetIfExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LocalRulestackRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public LocalRulestackRuleData(string ruleName) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType? ActionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Applications { get { throw null; } }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EdlMatchCategory Category { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType? DecryptionRuleType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddressInfo Destination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? EnableLogging { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string InboundInspectionCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? NegateDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? NegateSource { get { throw null; } set { } }
        public int? Priority { get { throw null; } }
        public string Protocol { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolPortList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
        public string RuleName { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? RuleState { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddressInfo Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackTagInfo> Tags { get { throw null; } }
    }
    public partial class LocalRulestackRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocalRulestackRuleResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string localRulestackName, string priority) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleCounter> GetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleCounter>> GetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleResetConter> ResetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleResetConter>> ResetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NgfwExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> GetGlobalRulestack(this Azure.ResourceManager.Resources.TenantResource tenantResource, string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> GetGlobalRulestackAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource GetGlobalRulestackCertificateObjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource GetGlobalRulestackFqdnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource GetGlobalRulestackPrefixResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource GetGlobalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCollection GetGlobalRulestacks(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> GetLocalRulestackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource GetLocalRulestackCertificateObjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource GetLocalRulestackFqdnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource GetLocalRulestackPrefixResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource GetLocalRulestackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource GetLocalRulestackRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCollection GetLocalRulestacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetPaloAltoNetworksFirewall(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> GetPaloAltoNetworksFirewallAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource GetPaloAltoNetworksFirewallResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallCollection GetPaloAltoNetworksFirewalls(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetPaloAltoNetworksFirewalls(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetPaloAltoNetworksFirewallsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallStatusResource GetPaloAltoNetworksFirewallStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource GetPostRulestackRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource GetPreRulestackRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PaloAltoNetworksFirewallCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>, System.Collections.IEnumerable
    {
        protected PaloAltoNetworksFirewallCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallName, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> Get(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> GetAsync(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetIfExists(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> GetIfExistsAsync(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PaloAltoNetworksFirewallData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PaloAltoNetworksFirewallData(Azure.Core.AzureLocation location, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkProfile networkProfile, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallDnsSettings dnsSettings, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanInfo planData, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanFirewallMarketplaceDetails marketplaceDetails) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackDetails AssociatedRulestack { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallDnsSettings DnsSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallFrontendSetting> FrontEndSettings { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? IsPanoramaManaged { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanFirewallMarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ETag? PanETag { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaConfiguration PanoramaConfig { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanInfo PlanData { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PaloAltoNetworksFirewallResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PaloAltoNetworksFirewallResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string firewallName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackInfo> GetGlobalRulestack(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackInfo>> GetGlobalRulestackAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogSettings> GetLogProfile(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogSettings>> GetLogProfileAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallStatusResource GetPaloAltoNetworksFirewallStatus() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallSupportInfo> GetSupportInfo(string email = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallSupportInfo>> GetSupportInfoAsync(string email = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SaveLogProfile(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogSettings logSettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SaveLogProfileAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogSettings logSettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> Update(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PaloAltoNetworksFirewallPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> UpdateAsync(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PaloAltoNetworksFirewallPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PaloAltoNetworksFirewallStatusData : Azure.ResourceManager.Models.ResourceData
    {
        public PaloAltoNetworksFirewallStatusData() { }
        public string HealthReason { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus? HealthStatus { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? IsPanoramaManaged { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaStatus PanoramaStatus { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType? ProvisioningState { get { throw null; } }
    }
    public partial class PaloAltoNetworksFirewallStatusResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PaloAltoNetworksFirewallStatusResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string firewallName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostRulestackRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>, System.Collections.IEnumerable
    {
        protected PostRulestackRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> Get(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>> GetAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> GetIfExists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>> GetIfExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostRulestackRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public PostRulestackRuleData(string ruleName) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType? ActionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Applications { get { throw null; } }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EdlMatchCategory Category { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType? DecryptionRuleType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddressInfo Destination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? EnableLogging { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string InboundInspectionCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? NegateDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? NegateSource { get { throw null; } set { } }
        public int? Priority { get { throw null; } }
        public string Protocol { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolPortList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
        public string RuleName { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? RuleState { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddressInfo Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackTagInfo> Tags { get { throw null; } }
    }
    public partial class PostRulestackRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostRulestackRuleResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string priority) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleCounter> GetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleCounter>> GetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleResetConter> ResetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleResetConter>> ResetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PreRulestackRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>, System.Collections.IEnumerable
    {
        protected PreRulestackRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string priority, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> Get(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>> GetAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> GetIfExists(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>> GetIfExistsAsync(string priority, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PreRulestackRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public PreRulestackRuleData(string ruleName) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType? ActionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Applications { get { throw null; } }
        public string AuditComment { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EdlMatchCategory Category { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType? DecryptionRuleType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddressInfo Destination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? EnableLogging { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string InboundInspectionCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? NegateDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? NegateSource { get { throw null; } set { } }
        public int? Priority { get { throw null; } }
        public string Protocol { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolPortList { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? ProvisioningState { get { throw null; } }
        public string RuleName { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? RuleState { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddressInfo Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackTagInfo> Tags { get { throw null; } }
    }
    public partial class PreRulestackRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PreRulestackRuleResource() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string globalRulestackName, string priority) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleCounter> GetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleCounter>> GetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleResetConter> ResetCounters(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleResetConter>> ResetCountersAsync(string firewallName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Mocking
{
    public partial class MockablePaloAltoNetworksNgfwArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePaloAltoNetworksNgfwArmClient() { }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectResource GetGlobalRulestackCertificateObjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnResource GetGlobalRulestackFqdnResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixResource GetGlobalRulestackPrefixResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource GetGlobalRulestackResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectResource GetLocalRulestackCertificateObjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnResource GetLocalRulestackFqdnResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixResource GetLocalRulestackPrefixResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource GetLocalRulestackResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleResource GetLocalRulestackRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource GetPaloAltoNetworksFirewallResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallStatusResource GetPaloAltoNetworksFirewallStatusResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleResource GetPostRulestackRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleResource GetPreRulestackRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePaloAltoNetworksNgfwResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePaloAltoNetworksNgfwResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestack(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource>> GetLocalRulestackAsync(string localRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCollection GetLocalRulestacks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetPaloAltoNetworksFirewall(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource>> GetPaloAltoNetworksFirewallAsync(string firewallName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallCollection GetPaloAltoNetworksFirewalls() { throw null; }
    }
    public partial class MockablePaloAltoNetworksNgfwSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePaloAltoNetworksNgfwSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestacks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackResource> GetLocalRulestacksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetPaloAltoNetworksFirewalls(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallResource> GetPaloAltoNetworksFirewallsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePaloAltoNetworksNgfwTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePaloAltoNetworksNgfwTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource> GetGlobalRulestack(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackResource>> GetGlobalRulestackAsync(string globalRulestackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCollection GetGlobalRulestacks() { throw null; }
    }
}
namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models
{
    public partial class AdvancedSecurityObject
    {
        internal AdvancedSecurityObject() { }
        public string AdvSecurityObjectModelType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject> Entry { get { throw null; } }
    }
    public partial class AdvancedSecurityObjectListResult
    {
        internal AdvancedSecurityObjectListResult() { }
        public string NextLink { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObject Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvancedSecurityObjectType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvancedSecurityObjectType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType Feeds { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType UrlCustom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowDnsProxyType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowDnsProxyType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType Disabled { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowEgressNatType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowEgressNatType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType Disabled { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class AppSeenInfoList
    {
        internal AppSeenInfoList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfo> AppSeenList { get { throw null; } }
        public int Count { get { throw null; } }
    }
    public static partial class ArmPaloAltoNetworksNgfwModelFactory
    {
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObject AdvancedSecurityObject(string advSecurityObjectModelType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject> entry = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObjectListResult AdvancedSecurityObjectListResult(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AdvancedSecurityObject value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfo AppSeenInfo(string title = null, string category = null, string subCategory = null, string risk = null, string tag = null, string technology = null, string standardPorts = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfoList AppSeenInfoList(int count = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfo> appSeenList = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanInfo FirewallBillingPlanInfo(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType? usageType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle billingCycle = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle), string planId = null, System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaConfiguration FirewallPanoramaConfiguration(string configString = null, string vmAuthKey = null, string panoramaServer = null, string panoramaServer2 = null, string dgName = null, string tplName = null, string cgName = null, string hostName = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaStatus FirewallPanoramaStatus(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus? panoramaServerStatus = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus? panoramaServer2Status = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleCounter FirewallRuleCounter(string priority = null, string ruleStackName = null, string ruleListName = null, string firewallName = null, string ruleName = null, int? hitCount = default(int?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfoList appSeen = null, System.DateTimeOffset? responseOn = default(System.DateTimeOffset?), System.DateTimeOffset? requestOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallRuleResetConter FirewallRuleResetConter(string priority = null, string ruleStackName = null, string ruleListName = null, string firewallName = null, string ruleName = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallSupportInfo FirewallSupportInfo(string productSku = null, string productSerial = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? accountRegistered = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), string accountId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? userDomainSupported = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? userRegistered = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? freeTrial = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), int? freeTrialDaysLeft = default(int?), int? freeTrialCreditLeft = default(int?), string helpURL = null, string supportURL = null, string registerURL = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackCertificateObjectData GlobalRulestackCertificateObjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string certificateSignerResourceId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType certificateSelfSigned = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType), string auditComment = null, string description = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackData GlobalRulestackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? panETag = default(Azure.ETag?), Azure.Core.AzureLocation? panLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType? scope = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType?), System.Collections.Generic.IEnumerable<string> associatedSubscriptions = null, string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode? defaultMode = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode?), string minAppIdVersion = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServices securityServices = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackFqdnData GlobalRulestackFqdnData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> fqdnList = null, Azure.ETag? etag = default(Azure.ETag?), string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackInfo GlobalRulestackInfo(string azureId = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.GlobalRulestackPrefixData GlobalRulestackPrefixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> prefixList = null, Azure.ETag? etag = default(Azure.ETag?), string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackCertificateObjectData LocalRulestackCertificateObjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string certificateSignerResourceId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType certificateSelfSigned = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType), string auditComment = null, string description = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackData LocalRulestackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? panETag = default(Azure.ETag?), Azure.Core.AzureLocation? panLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType? scope = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType?), System.Collections.Generic.IEnumerable<string> associatedSubscriptions = null, string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode? defaultMode = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode?), string minAppIdVersion = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServices securityServices = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackFqdnData LocalRulestackFqdnData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> fqdnList = null, Azure.ETag? etag = default(Azure.ETag?), string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackPrefixData LocalRulestackPrefixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> prefixList = null, Azure.ETag? etag = default(Azure.ETag?), string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.LocalRulestackRuleData LocalRulestackRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string ruleName = null, int? priority = default(int?), string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? ruleState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddressInfo source = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? negateSource = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddressInfo destination = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? negateDestination = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), System.Collections.Generic.IEnumerable<string> applications = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EdlMatchCategory category = null, string protocol = null, System.Collections.Generic.IEnumerable<string> protocolPortList = null, string inboundInspectionCertificate = null, string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType? actionType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? enableLogging = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType? decryptionRuleType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackTagInfo> tags = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject NameDescriptionObject(string name = null, string description = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallData PaloAltoNetworksFirewallData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? panETag = default(Azure.ETag?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkProfile networkProfile = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? isPanoramaManaged = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaConfiguration panoramaConfig = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackDetails associatedRulestack = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallDnsSettings dnsSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallFrontendSetting> frontEndSettings = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanInfo planData = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanFirewallMarketplaceDetails marketplaceDetails = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PaloAltoNetworksFirewallStatusData PaloAltoNetworksFirewallStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? isPanoramaManaged = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus? healthStatus = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus?), string healthReason = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaStatus panoramaStatus = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanFirewallMarketplaceDetails PanFirewallMarketplaceDetails(string marketplaceSubscriptionId = null, string offerId = null, string publisherId = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PostRulestackRuleData PostRulestackRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string ruleName = null, int? priority = default(int?), string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? ruleState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddressInfo source = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? negateSource = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddressInfo destination = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? negateDestination = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), System.Collections.Generic.IEnumerable<string> applications = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EdlMatchCategory category = null, string protocol = null, System.Collections.Generic.IEnumerable<string> protocolPortList = null, string inboundInspectionCertificate = null, string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType? actionType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? enableLogging = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType? decryptionRuleType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackTagInfo> tags = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PredefinedUrlCategory PredefinedUrlCategory(string action = null, string name = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.PreRulestackRuleData PreRulestackRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string ruleName = null, int? priority = default(int?), string description = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? ruleState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.SourceAddressInfo source = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? negateSource = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DestinationAddressInfo destination = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? negateDestination = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType?), System.Collections.Generic.IEnumerable<string> applications = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EdlMatchCategory category = null, string protocol = null, System.Collections.Generic.IEnumerable<string> protocolPortList = null, string inboundInspectionCertificate = null, string auditComment = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType? actionType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType? enableLogging = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType?), Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType? decryptionRuleType = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackTagInfo> tags = null, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState? provisioningState = default(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackChangelog RulestackChangelog(System.Collections.Generic.IEnumerable<string> changes = null, System.DateTimeOffset? lastCommittedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackCountry RulestackCountry(string code = null, string description = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceListResult RulestackSecurityServiceListResult(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceTypeList value = null, string nextLink = null) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceTypeList RulestackSecurityServiceTypeList(string securityServicesTypeListType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject> entry = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DecryptionRuleType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DecryptionRuleType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType None { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType SslInboundInspection { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType SslOutboundInspection { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.DecryptionRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DestinationAddressInfo
    {
        public DestinationAddressInfo() { }
        public System.Collections.Generic.IList<string> Cidrs { get { throw null; } }
        public System.Collections.Generic.IList<string> Countries { get { throw null; } }
        public System.Collections.Generic.IList<string> Feeds { get { throw null; } }
        public System.Collections.Generic.IList<string> FqdnLists { get { throw null; } }
        public System.Collections.Generic.IList<string> PrefixLists { get { throw null; } }
    }
    public partial class EdlMatchCategory
    {
        public EdlMatchCategory(System.Collections.Generic.IEnumerable<string> urlCustom, System.Collections.Generic.IEnumerable<string> feeds) { }
        public System.Collections.Generic.IList<string> Feeds { get { throw null; } }
        public System.Collections.Generic.IList<string> UrlCustom { get { throw null; } }
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
    public partial class EventHubConfiguration
    {
        public EventHubConfiguration() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string NameSpace { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class FirewallApplicationInsights
    {
        public FirewallApplicationInsights() { }
        public string Id { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallBillingCycle : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallBillingCycle(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle Monthly { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallBillingPlanInfo
    {
        public FirewallBillingPlanInfo(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle billingCycle, string planId) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingCycle BillingCycle { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public string PlanId { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType? UsageType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallBillingPlanUsageType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallBillingPlanUsageType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType Committed { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanUsageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallBooleanType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallBooleanType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType False { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallDnsSettings
    {
        public FirewallDnsSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressInfo> DnsServers { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EnabledDnsType? EnabledDnsType { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowDnsProxyType? EnableDnsProxy { get { throw null; } set { } }
    }
    public partial class FirewallEndpointConfiguration
    {
        public FirewallEndpointConfiguration(string port, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressInfo address) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressInfo Address { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
    }
    public partial class FirewallFrontendSetting
    {
        public FirewallFrontendSetting(string name, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType protocol, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallEndpointConfiguration frontendConfiguration, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallEndpointConfiguration backendConfiguration) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallEndpointConfiguration BackendConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallEndpointConfiguration FrontendConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType Protocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallHealthStatus : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus Green { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus Initializing { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus Red { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus Yellow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallLogDestination
    {
        public FirewallLogDestination() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.EventHubConfiguration EventHubConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MonitorLogConfiguration MonitorConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.StorageAccountConfiguration StorageConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallLogOption : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallLogOption(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption IndividualDestination { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption SameDestination { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallLogSettings
    {
        public FirewallLogSettings() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallApplicationInsights ApplicationInsights { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogDestination CommonDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogDestination DecryptLogDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogOption? LogOption { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType? LogType { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogDestination ThreatLogDestination { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogDestination TrafficLogDestination { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallLogType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallLogType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType Audit { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType Decryption { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType Dlp { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType Threat { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType Traffic { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType Wildfire { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallLogType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallNetworkProfile
    {
        public FirewallNetworkProfile(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType networkType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressInfo> publicIPs, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType enableEgressNat) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressInfo> EgressNatIP { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AllowEgressNatType EnableEgressNat { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType NetworkType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressInfo> PublicIPs { get { throw null; } }
        public System.Collections.Generic.IList<string> TrustedRanges { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallVnetConfiguration VnetConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallVwanConfiguration VwanConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallNetworkType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType Vnet { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType Vwan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallPanoramaConfiguration
    {
        public FirewallPanoramaConfiguration(string configString) { }
        public string CgName { get { throw null; } }
        public string ConfigString { get { throw null; } set { } }
        public string DgName { get { throw null; } }
        public string HostName { get { throw null; } }
        public string PanoramaServer { get { throw null; } }
        public string PanoramaServer2 { get { throw null; } }
        public string TplName { get { throw null; } }
        public string VmAuthKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallPanoramaServerStatus : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallPanoramaServerStatus(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus Down { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus Up { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallPanoramaStatus
    {
        internal FirewallPanoramaStatus() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus? PanoramaServer2Status { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaServerStatus? PanoramaServerStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallProtocolType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType Tcp { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallProvisioningState : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FirewallProvisioningStateType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FirewallProvisioningStateType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType Deleted { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType Failed { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallProvisioningStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FirewallRuleCounter
    {
        internal FirewallRuleCounter() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.AppSeenInfoList AppSeen { get { throw null; } }
        public string FirewallName { get { throw null; } }
        public int? HitCount { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string Priority { get { throw null; } }
        public System.DateTimeOffset? RequestOn { get { throw null; } }
        public System.DateTimeOffset? ResponseOn { get { throw null; } }
        public string RuleListName { get { throw null; } }
        public string RuleName { get { throw null; } }
        public string RuleStackName { get { throw null; } }
    }
    public partial class FirewallRuleResetConter
    {
        internal FirewallRuleResetConter() { }
        public string FirewallName { get { throw null; } }
        public string Priority { get { throw null; } }
        public string RuleListName { get { throw null; } }
        public string RuleName { get { throw null; } }
        public string RuleStackName { get { throw null; } }
    }
    public partial class FirewallSupportInfo
    {
        internal FirewallSupportInfo() { }
        public string AccountId { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? AccountRegistered { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? FreeTrial { get { throw null; } }
        public int? FreeTrialCreditLeft { get { throw null; } }
        public int? FreeTrialDaysLeft { get { throw null; } }
        public string HelpURL { get { throw null; } }
        public string ProductSerial { get { throw null; } }
        public string ProductSku { get { throw null; } }
        public string RegisterURL { get { throw null; } }
        public string SupportURL { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? UserDomainSupported { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? UserRegistered { get { throw null; } }
    }
    public partial class FirewallUpdateProperties
    {
        public FirewallUpdateProperties() { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackDetails AssociatedRulestack { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallDnsSettings DnsSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallFrontendSetting> FrontEndSettings { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBooleanType? IsPanoramaManaged { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.PanFirewallMarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ETag? PanETag { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallPanoramaConfiguration PanoramaConfig { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallBillingPlanInfo PlanData { get { throw null; } set { } }
    }
    public partial class FirewallVnetConfiguration
    {
        public FirewallVnetConfiguration(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo vnet, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo trustSubnet, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo unTrustSubnet) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressInfo IPOfTrustSubnetForUdr { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo TrustSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo UnTrustSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo Vnet { get { throw null; } set { } }
    }
    public partial class FirewallVwanConfiguration
    {
        public FirewallVwanConfiguration(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo vhub) { }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressInfo IPOfTrustSubnetForUdr { get { throw null; } set { } }
        public string NetworkVirtualApplianceId { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo TrustSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo UnTrustSubnet { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.IPAddressSpaceInfo Vhub { get { throw null; } set { } }
    }
    public partial class GlobalRulestackInfo
    {
        internal GlobalRulestackInfo() { }
        public string AzureId { get { throw null; } }
    }
    public partial class GlobalRulestackPatch
    {
        public GlobalRulestackPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.GlobalRulestackUpdateProperties Properties { get { throw null; } set { } }
    }
    public partial class GlobalRulestackUpdateProperties
    {
        public GlobalRulestackUpdateProperties() { }
        public System.Collections.Generic.IList<string> AssociatedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode? DefaultMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string MinAppIdVersion { get { throw null; } set { } }
        public Azure.ETag? PanETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? PanLocation { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServices SecurityServices { get { throw null; } set { } }
    }
    public partial class IPAddressInfo
    {
        public IPAddressInfo() { }
        public string Address { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class IPAddressSpaceInfo
    {
        public IPAddressSpaceInfo() { }
        public string AddressSpace { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class LocalRulestackPatch
    {
        public LocalRulestackPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.LocalRulestackUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class LocalRulestackUpdateProperties
    {
        public LocalRulestackUpdateProperties() { }
        public System.Collections.Generic.IList<string> AssociatedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode? DefaultMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string MinAppIdVersion { get { throw null; } set { } }
        public Azure.ETag? PanETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? PanLocation { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType? Scope { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServices SecurityServices { get { throw null; } set { } }
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
    public partial class MonitorLogConfiguration
    {
        public MonitorLogConfiguration() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
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
    public partial class PaloAltoNetworksFirewallPatch
    {
        public PaloAltoNetworksFirewallPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.FirewallUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PanFirewallMarketplaceDetails
    {
        public PanFirewallMarketplaceDetails(string offerId, string publisherId) { }
        public string MarketplaceSubscriptionId { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } set { } }
        public string OfferId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
    }
    public partial class PredefinedUrlCategory
    {
        internal PredefinedUrlCategory() { }
        public string Action { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleCreationDefaultMode : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleCreationDefaultMode(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode Firewall { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode IPS { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RuleCreationDefaultMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RulestackActionType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RulestackActionType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType DenyResetBoth { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType DenyResetServer { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType DenySilent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulestackChangelog
    {
        internal RulestackChangelog() { }
        public System.Collections.Generic.IReadOnlyList<string> Changes { get { throw null; } }
        public System.DateTimeOffset? LastCommittedOn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
    }
    public partial class RulestackCountry
    {
        internal RulestackCountry() { }
        public string Code { get { throw null; } }
        public string Description { get { throw null; } }
    }
    public partial class RulestackDetails
    {
        public RulestackDetails() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string RulestackId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RulestackScopeType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RulestackScopeType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType Global { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulestackSecurityServiceListResult
    {
        internal RulestackSecurityServiceListResult() { }
        public string NextLink { get { throw null; } }
        public Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceTypeList Value { get { throw null; } }
    }
    public partial class RulestackSecurityServices
    {
        public RulestackSecurityServices() { }
        public string AntiSpywareProfile { get { throw null; } set { } }
        public string AntiVirusProfile { get { throw null; } set { } }
        public string DnsSubscription { get { throw null; } set { } }
        public string FileBlockingProfile { get { throw null; } set { } }
        public string OutboundTrustCertificate { get { throw null; } set { } }
        public string OutboundUnTrustCertificate { get { throw null; } set { } }
        public string UrlFilteringProfile { get { throw null; } set { } }
        public string VulnerabilityProfile { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RulestackSecurityServiceType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RulestackSecurityServiceType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType AntiSpyware { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType AntiVirus { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType DnsSubscription { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType FileBlocking { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType IPsVulnerability { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType UrlFiltering { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackSecurityServiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulestackSecurityServiceTypeList
    {
        internal RulestackSecurityServiceTypeList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.NameDescriptionObject> Entry { get { throw null; } }
        public string SecurityServicesTypeListType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RulestackStateType : System.IEquatable<Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RulestackStateType(string value) { throw null; }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType Disabled { get { throw null; } }
        public static Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType left, Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models.RulestackStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulestackTagInfo
    {
        public RulestackTagInfo(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SourceAddressInfo
    {
        public SourceAddressInfo() { }
        public System.Collections.Generic.IList<string> Cidrs { get { throw null; } }
        public System.Collections.Generic.IList<string> Countries { get { throw null; } }
        public System.Collections.Generic.IList<string> Feeds { get { throw null; } }
        public System.Collections.Generic.IList<string> PrefixLists { get { throw null; } }
    }
    public partial class StorageAccountConfiguration
    {
        public StorageAccountConfiguration() { }
        public string AccountName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
}
