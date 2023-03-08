namespace Azure.ResourceManager.RecoveryServices
{
    public static partial class RecoveryServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult> CheckRecoveryServicesNameAvailability(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>> CheckRecoveryServicesNameAvailabilityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult> GetRecoveryServiceCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>> GetRecoveryServiceCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource GetRecoveryServicesPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> GetRecoveryServicesVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource GetRecoveryServicesVaultExtendedInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource GetRecoveryServicesVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultCollection GetRecoveryServicesVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class RecoveryServicesVaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>, System.Collections.IEnumerable
    {
        protected RecoveryServicesVaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryServicesVaultData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RecoveryServicesVaultData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku Sku { get { throw null; } set { } }
    }
    public partial class RecoveryServicesVaultExtendedInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public RecoveryServicesVaultExtendedInfoData() { }
        public string Algorithm { get { throw null; } set { } }
        public string EncryptionKey { get { throw null; } set { } }
        public string EncryptionKeyThumbprint { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string IntegrityKey { get { throw null; } set { } }
    }
    public partial class RecoveryServicesVaultExtendedInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryServicesVaultExtendedInfoResource() { }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource> Update(Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource>> UpdateAsync(Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryServicesVaultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryServicesVaultResource() { }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult> CreateVaultCertificate(string certificateName, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.VaultCertificateResult>> CreateVaultCertificateAsync(string certificateName, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRegisteredIdentity(string identityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRegisteredIdentityAsync(string identityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource> GetRecoveryServicesPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResource>> GetRecoveryServicesPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesPrivateLinkResourceCollection GetRecoveryServicesPrivateLinkResources() { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultExtendedInfoResource GetRecoveryServicesVaultExtendedInfo() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage> GetReplicationUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.Models.ReplicationUsage> GetReplicationUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.Models.VaultUsage> GetUsagesByVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.Models.VaultUsage> GetUsagesByVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServices.Mock
{
    public partial class RecoveryServicesVaultResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected RecoveryServicesVaultResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultResource> GetRecoveryServicesVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult> CheckRecoveryServicesNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityResult>> CheckRecoveryServicesNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServices.RecoveryServicesVaultCollection GetRecoveryServicesVaults() { throw null; }
    }
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult> GetRecoveryServiceCapabilities(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServices.Models.CapabilitiesResult>> GetRecoveryServiceCapabilitiesAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilities input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServices.Models
{
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
        public CapabilitiesResult(Azure.Core.ResourceType resourceCapabilitiesBaseType) : base (default(Azure.Core.ResourceType)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServices.Models.DnsZoneResult> CapabilitiesResultDnsZones { get { throw null; } }
    }
    public partial class CmkKekIdentity
    {
        public CmkKekIdentity() { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
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
    public partial class DnsZoneResult : Azure.ResourceManager.RecoveryServices.Models.DnsZone
    {
        public DnsZoneResult() { }
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
    public partial class RawCertificateData
    {
        public RawCertificateData() { }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType? AuthType { get { throw null; } set { } }
        public byte[] Certificate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesAlertsState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesAlertsState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesAuthType : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesAuthType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType Aad { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType AccessControlService { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType Acs { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType AzureActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryServicesCertificateContent
    {
        public RecoveryServicesCertificateContent() { }
        public Azure.ResourceManager.RecoveryServices.Models.RawCertificateData Properties { get { throw null; } set { } }
    }
    public partial class RecoveryServicesNameAvailabilityContent
    {
        public RecoveryServicesNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class RecoveryServicesNameAvailabilityResult
    {
        internal RecoveryServicesNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class RecoveryServicesPrivateEndpointConnection
    {
        internal RecoveryServicesPrivateEndpointConnection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServices.Models.VaultSubResourceType> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryServicesPrivateEndpointConnectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryServicesPrivateEndpointConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryServicesPrivateEndpointConnectionVaultProperties : Azure.ResourceManager.Models.ResourceData
    {
        internal RecoveryServicesPrivateEndpointConnectionVaultProperties() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnection Properties { get { throw null; } }
    }
    public partial class RecoveryServicesPrivateLinkServiceConnectionState
    {
        internal RecoveryServicesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionStatus? Status { get { throw null; } }
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
    public partial class RecoveryServicesVaultPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RecoveryServicesVaultPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSku Sku { get { throw null; } set { } }
    }
    public partial class RecoveryServicesVaultProperties
    {
        public RecoveryServicesVaultProperties() { }
        public Azure.ResourceManager.RecoveryServices.Models.BackupStorageVersion? BackupStorageVersion { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.ImmutabilityState? ImmutabilityState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSettings MonitoringSettings { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesMoveDetails MoveDetails { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.ResourceMoveState? MoveState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesPrivateEndpointConnectionVaultProperties> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState? PrivateEndpointStateForBackup { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPrivateEndpointState? PrivateEndpointStateForSiteRecovery { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultPropertiesRedundancySettings RedundancySettings { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeDetails UpgradeDetails { get { throw null; } set { } }
    }
    public partial class ReplicationJobSummary
    {
        internal ReplicationJobSummary() { }
        public int? FailedJobs { get { throw null; } }
        public int? InProgressJobs { get { throw null; } }
        public int? SuspendedJobs { get { throw null; } }
    }
    public partial class ReplicationUsage
    {
        internal ReplicationUsage() { }
        public Azure.ResourceManager.RecoveryServices.Models.ReplicationJobSummary JobsSummary { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultMonitoringSummary MonitoringSummary { get { throw null; } }
        public int? ProtectedItemCount { get { throw null; } }
        public int? RecoveryPlanCount { get { throw null; } }
        public int? RecoveryServicesProviderAuthType { get { throw null; } }
        public int? RegisteredServersCount { get { throw null; } }
    }
    public partial class ResourceCapabilities : Azure.ResourceManager.RecoveryServices.Models.ResourceCapabilitiesBase
    {
        public ResourceCapabilities(Azure.Core.ResourceType resourceCapabilitiesBaseType) : base (default(Azure.Core.ResourceType)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServices.Models.DnsZone> CapabilitiesDnsZones { get { throw null; } }
    }
    public partial class ResourceCapabilitiesBase
    {
        public ResourceCapabilitiesBase(Azure.Core.ResourceType resourceCapabilitiesBaseType) { }
        public Azure.Core.ResourceType ResourceCapabilitiesBaseType { get { throw null; } set { } }
    }
    public partial class ResourceCertificateAndAadDetails : Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails
    {
        internal ResourceCertificateAndAadDetails() { }
        public string AadAudience { get { throw null; } }
        public string AadAuthority { get { throw null; } }
        public System.Guid AadTenantId { get { throw null; } }
        public string AzureManagementEndpointAudience { get { throw null; } }
        public string ServicePrincipalClientId { get { throw null; } }
        public string ServicePrincipalObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceResourceId { get { throw null; } }
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
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.DateTimeOffset? ValidEndOn { get { throw null; } }
        public System.DateTimeOffset? ValidStartOn { get { throw null; } }
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
    public partial class VaultCertificateResult : Azure.ResourceManager.Models.ResourceData
    {
        internal VaultCertificateResult() { }
        public Azure.ResourceManager.RecoveryServices.Models.ResourceCertificateDetails Properties { get { throw null; } }
    }
    public partial class VaultMonitoringSettings
    {
        public VaultMonitoringSettings() { }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState? AzureMonitorAlertAlertsForAllJobFailures { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesAlertsState? ClassicAlertAlertsForCriticalOperations { get { throw null; } set { } }
    }
    public partial class VaultMonitoringSummary
    {
        internal VaultMonitoringSummary() { }
        public int? DeprecatedProviderCount { get { throw null; } }
        public int? EventsCount { get { throw null; } }
        public int? SupportedProviderCount { get { throw null; } }
        public int? UnHealthyProviderCount { get { throw null; } }
        public int? UnHealthyVmCount { get { throw null; } }
        public int? UnsupportedProviderCount { get { throw null; } }
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
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
    }
    public partial class VaultPropertiesRedundancySettings
    {
        public VaultPropertiesRedundancySettings() { }
        public Azure.ResourceManager.RecoveryServices.Models.CrossRegionRestore? CrossRegionRestore { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.StandardTierStorageRedundancy? StandardTierStorageRedundancy { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess left, Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess left, Azure.ResourceManager.RecoveryServices.Models.VaultPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class VaultUpgradeDetails
    {
        public VaultUpgradeDetails() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PreviousResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeState? Status { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType? TriggerType { get { throw null; } }
        public Azure.Core.ResourceIdentifier UpgradedResourceId { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultUpgradeTriggerType : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultUpgradeTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType ForcedUpgrade { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType UserTriggered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType left, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType left, Azure.ResourceManager.RecoveryServices.Models.VaultUpgradeTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultUsage
    {
        internal VaultUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUsageNameInfo Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit? Unit { get { throw null; } }
    }
    public partial class VaultUsageNameInfo
    {
        internal VaultUsageNameInfo() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultUsageUnit : System.IEquatable<Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit Count { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit left, Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit left, Azure.ResourceManager.RecoveryServices.Models.VaultUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
}
