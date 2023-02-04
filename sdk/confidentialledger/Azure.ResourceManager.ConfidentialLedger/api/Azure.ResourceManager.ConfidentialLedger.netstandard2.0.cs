namespace Azure.ResourceManager.ConfidentialLedger
{
    public partial class ConfidentialLedgerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>, System.Collections.IEnumerable
    {
        protected ConfidentialLedgerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ledgerName, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ledgerName, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Get(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfidentialLedgerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ConfidentialLedgerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties Properties { get { throw null; } set { } }
    }
    public static partial class ConfidentialLedgerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult> CheckConfidentialLedgerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>> CheckConfidentialLedgerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedger(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetConfidentialLedgerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource GetConfidentialLedgerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerCollection GetConfidentialLedgers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfidentialLedgerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfidentialLedgerResource() { }
        public virtual Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ledgerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ConfidentialLedger.Models
{
    public partial class AadBasedSecurityPrincipal
    {
        public AadBasedSecurityPrincipal() { }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName? LedgerRoleName { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class CertBasedSecurityPrincipal
    {
        public CertBasedSecurityPrincipal() { }
        public string Cert { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName? LedgerRoleName { get { throw null; } set { } }
    }
    public static partial class ConfidentialLedgerModelFactory
    {
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData ConfidentialLedgerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult ConfidentialLedgerNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason? reason = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties ConfidentialLedgerProperties(string ledgerName = null, System.Uri ledgerUri = null, System.Uri identityServiceUri = null, string ledgerInternalNamespace = null, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType? ledgerType = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? provisioningState = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal> aadBasedSecurityPrincipals = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal> certBasedSecurityPrincipals = null) { throw null; }
    }
    public partial class ConfidentialLedgerNameAvailabilityContent
    {
        public ConfidentialLedgerNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class ConfidentialLedgerNameAvailabilityResult
    {
        internal ConfidentialLedgerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerNameUnavailableReason : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfidentialLedgerProperties
    {
        public ConfidentialLedgerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal> AadBasedSecurityPrincipals { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal> CertBasedSecurityPrincipals { get { throw null; } }
        public System.Uri IdentityServiceUri { get { throw null; } }
        public string LedgerInternalNamespace { get { throw null; } }
        public string LedgerName { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType? LedgerType { get { throw null; } set { } }
        public System.Uri LedgerUri { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerProvisioningState : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerRoleName : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerRoleName(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Administrator { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Contributor { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Reader { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerType : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerType(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Private { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Public { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
