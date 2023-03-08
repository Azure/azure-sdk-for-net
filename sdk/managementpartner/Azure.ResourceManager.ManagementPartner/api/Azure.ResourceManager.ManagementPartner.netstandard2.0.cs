namespace Azure.ResourceManager.ManagementPartner
{
    public static partial class ManagementPartnerExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ManagementPartner.Models.OperationResponse> GetOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagementPartner.Models.OperationResponse> GetOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagementPartner.PartnerResponseResource> GetPartnerResponse(this Azure.ResourceManager.Resources.TenantResource tenantResource, string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementPartner.PartnerResponseResource>> GetPartnerResponseAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagementPartner.PartnerResponseResource GetPartnerResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagementPartner.PartnerResponseCollection GetPartnerResponses(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class PartnerResponseCollection : Azure.ResourceManager.ArmCollection
    {
        protected PartnerResponseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagementPartner.PartnerResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagementPartner.PartnerResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementPartner.PartnerResponseResource> Get(string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementPartner.PartnerResponseResource>> GetAsync(string partnerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerResponseData : Azure.ResourceManager.Models.ResourceData
    {
        internal PartnerResponseData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? ETag { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public string PartnerId { get { throw null; } }
        public string PartnerName { get { throw null; } }
        public Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState? State { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class PartnerResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerResponseResource() { }
        public virtual Azure.ResourceManager.ManagementPartner.PartnerResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string partnerId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementPartner.PartnerResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementPartner.PartnerResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagementPartner.PartnerResponseResource> Update(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagementPartner.PartnerResponseResource>> UpdateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagementPartner.Mock
{
    public partial class TenantResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected TenantResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagementPartner.Models.OperationResponse> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagementPartner.Models.OperationResponse> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagementPartner.PartnerResponseCollection GetPartnerResponses() { throw null; }
    }
}
namespace Azure.ResourceManager.ManagementPartner.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementPartnerState : System.IEquatable<Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementPartnerState(string value) { throw null; }
        public static Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState Active { get { throw null; } }
        public static Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState Deleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState left, Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState left, Azure.ResourceManager.ManagementPartner.Models.ManagementPartnerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationResponse
    {
        internal OperationResponse() { }
        public Azure.ResourceManager.ManagementPartner.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
    }
}
