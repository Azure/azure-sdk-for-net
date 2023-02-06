namespace Azure.ResourceManager.RecoveryServices
{
    public static partial class RecoveryServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CheckNameAvailabilityResult> CheckNameAvailabilityRecoveryService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityRecoveryServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult> GetCapabilitiesRecoveryService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>> GetCapabilitiesRecoveryServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource GetRecoveryServicesPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource> GetVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource>> GetVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResource GetVaultExtendedInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.VaultResource GetVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.VaultCollection GetVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServices.VaultResource> GetVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.VaultResource> GetVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryServicesPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryServicesPrivateLinkResource() { }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryServicesPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected RecoveryServicesPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryServicesPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal RecoveryServicesPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class VaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.VaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.VaultResource>, System.Collections.IEnumerable
    {
        protected VaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.VaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServices.VaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.VaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServices.VaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.VaultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.VaultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServices.VaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.VaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServices.VaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.VaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VaultData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VaultData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku Sku { get { throw null; } set { } }
    }
    public partial class VaultExtendedInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VaultExtendedInfoResource() { }
        public virtual Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResource> Update(Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResource>> UpdateAsync(Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultExtendedInfoResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public VaultExtendedInfoResourceData() { }
        public string Algorithm { get { throw null; } set { } }
        public string EncryptionKey { get { throw null; } set { } }
        public string EncryptionKeyThumbprint { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string IntegrityKey { get { throw null; } set { } }
    }
    public partial class VaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VaultResource() { }
        public virtual Azure.ResourceManager.RecoveryServices.VaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResponse> CreateVaultCertificate(string certificateName, Azure.ResourceManager.RecoveryServices.Models.CertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResponse>> CreateVaultCertificateAsync(string certificateName, Azure.ResourceManager.RecoveryServices.Models.CertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRegisteredIdentity(string identityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRegisteredIdentityAsync(string identityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> GetRecoveryServicesPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>> GetRecoveryServicesPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceCollection GetRecoveryServicesPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage> GetReplicationUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage> GetReplicationUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.Models.VaultUsage> GetUsagesByVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.Models.VaultUsage> GetUsagesByVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.VaultExtendedInfoResource GetVaultExtendedInfoResource() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.VaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.VaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.Models.VaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.VaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.Models.VaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServices.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.AlertsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.AlertsState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.AlertsState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.AlertsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.AlertsState left, Azure.ResourceManager.RecoveryServices.Models.AlertsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.AlertsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.AlertsState left, Azure.ResourceManager.RecoveryServices.Models.AlertsState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthType : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.AuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.AuthType AAD { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.AuthType AccessControlService { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.AuthType ACS { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.AuthType AzureActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.AuthType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.AuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.AuthType left, Azure.ResourceManager.RecoveryServices.Models.AuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.AuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.AuthType left, Azure.ResourceManager.RecoveryServices.Models.AuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupStorageVersion : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupStorageVersion(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion Unassigned { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion V1 { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion left, Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion left, Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapabilitiesResult : Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase
    {
        public CapabilitiesResult(string resourceCapabilitiesBaseType) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResponse> CapabilitiesResponseDnsZones { get { throw null; } }
    }
    public partial class CertificateContent
    {
        public CertificateContent() { }
        public Azure.ResourceManager.RecoveryServices.Models.RawCertificateData Properties { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class CmkKekIdentity
    {
        public CmkKekIdentity() { }
        public string UserAssignedIdentity { get { throw null; } set { } }
        public bool? UseSystemAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CrossRegionRestore : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CrossRegionRestore(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore left, Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore left, Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsZone
    {
        public DnsZone() { }
        public Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType? SubResource { get { throw null; } set { } }
    }
    public partial class DnsZoneResponse : Azure.ResourceManager.RecoveryServices.Models.DnsZone
    {
        public DnsZoneResponse() { }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutabilityState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutabilityState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState Locked { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState left, Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState left, Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InfrastructureEncryptionState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InfrastructureEncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState left, Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState left, Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobsSummary
    {
        internal JobsSummary() { }
        public int? FailedJobs { get { throw null; } }
        public int? InProgressJobs { get { throw null; } }
        public int? SuspendedJobs { get { throw null; } }
    }
    public partial class MonitoringSettings
    {
        public MonitoringSettings() { }
        public Azure.ResourceManager.RecoveryServices.Models.AlertsState? AzureMonitorAlertAlertsForAllJobFailures { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.AlertsState? ClassicAlertAlertsForCriticalOperations { get { throw null; } set { } }
    }
    public partial class MonitoringSummary
    {
        internal MonitoringSummary() { }
        public int? DeprecatedProviderCount { get { throw null; } }
        public int? EventsCount { get { throw null; } }
        public int? SupportedProviderCount { get { throw null; } }
        public int? UnHealthyProviderCount { get { throw null; } }
        public int? UnHealthyVmCount { get { throw null; } }
        public int? UnsupportedProviderCount { get { throw null; } }
    }
    public partial class NameInfo
    {
        internal NameInfo() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionVaultProperties : Azure.ResourceManager.Models.ResourceData
    {
        internal PrivateEndpointConnectionVaultProperties() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.ProvisioningState left, Azure.ResourceManager.RecoveryServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.ProvisioningState left, Azure.ResourceManager.RecoveryServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess left, Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess left, Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RawCertificateData
    {
        public RawCertificateData() { }
        public Azure.ResourceManager.RecoveryServices.Models.AuthType? AuthType { get { throw null; } set { } }
        public byte[] Certificate { get { throw null; } set { } }
    }
    public partial class RecoveryServicesPrivateEndpointConnection
    {
        internal RecoveryServicesPrivateEndpointConnection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class RecoveryServicesPrivateLinkServiceConnectionState
    {
        internal RecoveryServicesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionStatus? Status { get { throw null; } }
    }
    public partial class RecoveryServicesSku
    {
        public RecoveryServicesSku(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName name) { }
        public string Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesSkuName : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesSkuName(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName RS0 { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReplicationUsage
    {
        internal ReplicationUsage() { }
        public Azure.ResourceManager.RecoveryServices.Models.JobsSummary JobsSummary { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.MonitoringSummary MonitoringSummary { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public int? RecoveryPlanCount { get { throw null; } }
        public int? RecoveryServicesProviderAuthType { get { throw null; } }
        public int? RegisteredServersCount { get { throw null; } }
    }
    public partial class ResourceCapabilities : Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase
    {
        public ResourceCapabilities(string resourceCapabilitiesBaseType) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServices.Models.DnsZone> CapabilitiesDnsZones { get { throw null; } }
    }
    public partial class ResourceCapabilitiesBase
    {
        public ResourceCapabilitiesBase(string resourceCapabilitiesBaseType) { }
        public string ResourceCapabilitiesBaseType { get { throw null; } set { } }
    }
    public partial class ResourceCertificateAndAadDetails : Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails
    {
        internal ResourceCertificateAndAadDetails() { }
        public string AadAudience { get { throw null; } }
        public string AadAuthority { get { throw null; } }
        public string AadTenantId { get { throw null; } }
        public string AzureManagementEndpointAudience { get { throw null; } }
        public string ServicePrincipalClientId { get { throw null; } }
        public string ServicePrincipalObjectId { get { throw null; } }
        public string ServiceResourceId { get { throw null; } }
    }
    public partial class ResourceCertificateAndAcsDetails : Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails
    {
        internal ResourceCertificateAndAcsDetails() { }
        public string GlobalAcsHostName { get { throw null; } }
        public string GlobalAcsNamespace { get { throw null; } }
        public string GlobalAcsRPRealm { get { throw null; } }
    }
    public abstract partial class ResourceCertificateDetails
    {
        protected ResourceCertificateDetails() { }
        public byte[] Certificate { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string Issuer { get { throw null; } }
        public long? ResourceId { get { throw null; } }
        public string Subject { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public System.DateTimeOffset? ValidFrom { get { throw null; } }
        public System.DateTimeOffset? ValidTo { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceMoveState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceMoveState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState CommitFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState CommitTimedout { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState CriticalFailure { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState Failure { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState InProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState MoveSucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState PartialSuccess { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState PrepareFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState PrepareTimedout { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState left, Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState left, Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StandardTierStorageRedundancy : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StandardTierStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy left, Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy left, Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerType : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.TriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.TriggerType ForcedUpgrade { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.TriggerType UserTriggered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.TriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.TriggerType left, Azure.ResourceManager.RecoveryServices.Models.TriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.TriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.TriggerType left, Azure.ResourceManager.RecoveryServices.Models.TriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpgradeDetails
    {
        public UpgradeDetails() { }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimeUtc { get { throw null; } }
        public string Message { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string PreviousResourceId { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState? Status { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.TriggerType? TriggerType { get { throw null; } }
        public string UpgradedResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsagesUnit : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.UsagesUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsagesUnit(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.UsagesUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.UsagesUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.UsagesUnit Count { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.UsagesUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.UsagesUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.UsagesUnit Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.UsagesUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.UsagesUnit left, Azure.ResourceManager.RecoveryServices.Models.UsagesUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.UsagesUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.UsagesUnit left, Azure.ResourceManager.RecoveryServices.Models.UsagesUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultCertificateResponse : Azure.ResourceManager.Models.ResourceData
    {
        internal VaultCertificateResponse() { }
        public Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails Properties { get { throw null; } }
    }
    public partial class VaultPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VaultPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku Sku { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultPrivateEndpointState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultPrivateEndpointState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState left, Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState left, Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultProperties
    {
        public VaultProperties() { }
        public Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion? BackupStorageVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState? ImmutabilityState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.MonitoringSettings MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails MoveDetails { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState? MoveState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServices.Models.PrivateEndpointConnectionVaultProperties> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState? PrivateEndpointStateForBackup { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState? PrivateEndpointStateForSiteRecovery { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings RedundancySettings { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.UpgradeDetails UpgradeDetails { get { throw null; } set { } }
    }
    public partial class VaultPropertiesEncryption
    {
        public VaultPropertiesEncryption() { }
        public Azure.ResourceManager.RecoveryServices.Models.InfrastructureEncryptionState? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.CmkKekIdentity KekIdentity { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
    }
    public partial class VaultPropertiesMoveDetails
    {
        public VaultPropertiesMoveDetails() { }
        public System.DateTimeOffset? CompletionTimeUtc { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string SourceResourceId { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
    }
    public partial class VaultPropertiesRedundancySettings
    {
        public VaultPropertiesRedundancySettings() { }
        public Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore? CrossRegionRestore { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy? StandardTierStorageRedundancy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultSubResourceType : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultSubResourceType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType AzureBackup { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType AzureBackupSecondary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType AzureSiteRecovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType left, Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType left, Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultUpgradeState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultUpgradeState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState InProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState Unknown { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState Upgraded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState left, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState left, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultUsage
    {
        internal VaultUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.NameInfo Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.UsagesUnit? Unit { get { throw null; } }
    }
}
