namespace Azure.ResourceManager.Quota
{
    public partial class CurrentQuotaLimitBaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>, System.Collections.IEnumerable
    {
        protected CurrentQuotaLimitBaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CurrentQuotaLimitBaseData : Azure.ResourceManager.Models.ResourceData
    {
        public CurrentQuotaLimitBaseData() { }
        public Azure.ResourceManager.Quota.Models.QuotaProperties Properties { get { throw null; } set { } }
    }
    public partial class CurrentQuotaLimitBaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CurrentQuotaLimitBaseResource() { }
        public virtual Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Quota.CurrentQuotaLimitBaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CurrentUsagesBaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>, System.Collections.IEnumerable
    {
        protected CurrentUsagesBaseCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CurrentUsagesBaseData : Azure.ResourceManager.Models.ResourceData
    {
        internal CurrentUsagesBaseData() { }
        public Azure.ResourceManager.Quota.Models.UsagesProperties Properties { get { throw null; } }
    }
    public partial class CurrentUsagesBaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CurrentUsagesBaseResource() { }
        public virtual Azure.ResourceManager.Quota.CurrentUsagesBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class QuotaExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource> GetCurrentQuotaLimitBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource>> GetCurrentQuotaLimitBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentQuotaLimitBaseResource GetCurrentQuotaLimitBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentQuotaLimitBaseCollection GetCurrentQuotaLimitBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource> GetCurrentUsagesBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.CurrentUsagesBaseResource>> GetCurrentUsagesBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentUsagesBaseResource GetCurrentUsagesBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.CurrentUsagesBaseCollection GetCurrentUsagesBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Quota.Models.OperationResponse> GetQuotaOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Quota.Models.OperationResponse> GetQuotaOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetQuotaRequestDetail(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetQuotaRequestDetailAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailResource GetQuotaRequestDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Quota.QuotaRequestDetailCollection GetQuotaRequestDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class QuotaRequestDetailCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.QuotaRequestDetailResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.QuotaRequestDetailResource>, System.Collections.IEnumerable
    {
        protected QuotaRequestDetailCollection() { }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetAll(string filter = null, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Quota.QuotaRequestDetailResource> GetAllAsync(string filter = null, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Quota.QuotaRequestDetailResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Quota.QuotaRequestDetailResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Quota.QuotaRequestDetailResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Quota.QuotaRequestDetailResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QuotaRequestDetailData : Azure.ResourceManager.Models.ResourceData
    {
        internal QuotaRequestDetailData() { }
        public Azure.ResourceManager.Quota.Models.ServiceErrorDetail Error { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RequestSubmitOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Quota.Models.SubRequest> Value { get { throw null; } }
    }
    public partial class QuotaRequestDetailResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuotaRequestDetailResource() { }
        public virtual Azure.ResourceManager.Quota.QuotaRequestDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Quota.QuotaRequestDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Quota.Models
{
    public abstract partial class LimitJsonObject
    {
        protected LimitJsonObject() { }
    }
    public partial class LimitObject : Azure.ResourceManager.Quota.Models.LimitJsonObject
    {
        public LimitObject(int value) { }
        public Azure.ResourceManager.Quota.Models.QuotaLimitType? LimitType { get { throw null; } set { } }
        public int Value { get { throw null; } set { } }
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
        public Azure.ResourceManager.Quota.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaLimitType : System.IEquatable<Azure.ResourceManager.Quota.Models.QuotaLimitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaLimitType(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaLimitType Independent { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaLimitType Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.QuotaLimitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.QuotaLimitType left, Azure.ResourceManager.Quota.Models.QuotaLimitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.QuotaLimitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.QuotaLimitType left, Azure.ResourceManager.Quota.Models.QuotaLimitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaProperties
    {
        public QuotaProperties() { }
        public bool? IsQuotaApplicable { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.LimitJsonObject Limit { get { throw null; } set { } }
        public Azure.ResourceManager.Quota.Models.ResourceName Name { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public string QuotaPeriod { get { throw null; } }
        public string ResourceType { get { throw null; } set { } }
        public string Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaRequestState : System.IEquatable<Azure.ResourceManager.Quota.Models.QuotaRequestState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaRequestState(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState Failed { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.QuotaRequestState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.QuotaRequestState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.QuotaRequestState left, Azure.ResourceManager.Quota.Models.QuotaRequestState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.QuotaRequestState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.QuotaRequestState left, Azure.ResourceManager.Quota.Models.QuotaRequestState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceName
    {
        public ResourceName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ServiceErrorDetail
    {
        internal ServiceErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class SubRequest
    {
        internal SubRequest() { }
        public Azure.ResourceManager.Quota.Models.LimitJsonObject Limit { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.ResourceName Name { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.QuotaRequestState? ProvisioningState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string SubRequestId { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class UsagesObject
    {
        internal UsagesObject() { }
        public Azure.ResourceManager.Quota.Models.UsagesType? UsagesType { get { throw null; } }
        public int Value { get { throw null; } }
    }
    public partial class UsagesProperties
    {
        internal UsagesProperties() { }
        public bool? IsQuotaApplicable { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.ResourceName Name { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string Unit { get { throw null; } }
        public Azure.ResourceManager.Quota.Models.UsagesObject Usages { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsagesType : System.IEquatable<Azure.ResourceManager.Quota.Models.UsagesType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsagesType(string value) { throw null; }
        public static Azure.ResourceManager.Quota.Models.UsagesType Combined { get { throw null; } }
        public static Azure.ResourceManager.Quota.Models.UsagesType Individual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Quota.Models.UsagesType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Quota.Models.UsagesType left, Azure.ResourceManager.Quota.Models.UsagesType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Quota.Models.UsagesType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Quota.Models.UsagesType left, Azure.ResourceManager.Quota.Models.UsagesType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
