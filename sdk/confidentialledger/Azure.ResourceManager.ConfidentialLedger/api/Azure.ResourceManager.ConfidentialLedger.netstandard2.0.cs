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
    public partial class ConfidentialLedgerData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfidentialLedgerData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.LedgerProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public static partial class ConfidentialLedgerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.LedgerNameAvailabilityResult> CheckLedgerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ConfidentialLedger.Models.LedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.LedgerNameAvailabilityResult>> CheckLedgerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ConfidentialLedger.Models.LedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName? LedgerRoleName { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class CertBasedSecurityPrincipal
    {
        public CertBasedSecurityPrincipal() { }
        public string Cert { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName? LedgerRoleName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LedgerNameAvailabilityContent
    {
        public LedgerNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class LedgerNameAvailabilityResult
    {
        internal LedgerNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class LedgerProperties
    {
        public LedgerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal> AadBasedSecurityPrincipals { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal> CertBasedSecurityPrincipals { get { throw null; } }
        public System.Uri IdentityServiceUri { get { throw null; } }
        public string LedgerInternalNamespace { get { throw null; } }
        public string LedgerName { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.LedgerType? LedgerType { get { throw null; } set { } }
        public System.Uri LedgerUri { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LedgerProvisioningState : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LedgerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState left, Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState left, Azure.ResourceManager.ConfidentialLedger.Models.LedgerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LedgerRoleName : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LedgerRoleName(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName Administrator { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName Contributor { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName Reader { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName left, Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName left, Azure.ResourceManager.ConfidentialLedger.Models.LedgerRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LedgerType : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.LedgerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LedgerType(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerType Private { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerType Public { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.LedgerType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.LedgerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.LedgerType left, Azure.ResourceManager.ConfidentialLedger.Models.LedgerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.LedgerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.LedgerType left, Azure.ResourceManager.ConfidentialLedger.Models.LedgerType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
