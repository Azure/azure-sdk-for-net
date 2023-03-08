namespace Azure.ResourceManager.ApplicationInsights
{
    public static partial class ApplicationInsightsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> GetComponentLinkedStorageAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> GetComponentLinkedStorageAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource GetComponentLinkedStorageAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection GetComponentLinkedStorageAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
    }
    public partial class ComponentLinkedStorageAccountCollection : Azure.ResourceManager.ArmCollection
    {
        protected ComponentLinkedStorageAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> Get(string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> GetAsync(string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentLinkedStorageAccountData : Azure.ResourceManager.Models.ResourceData
    {
        public ComponentLinkedStorageAccountData() { }
        public string LinkedStorageAccount { get { throw null; } set { } }
    }
    public partial class ComponentLinkedStorageAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentLinkedStorageAccountResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> Update(Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApplicationInsights.Mock
{
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection GetComponentLinkedStorageAccounts() { throw null; }
    }
}
namespace Azure.ResourceManager.ApplicationInsights.Models
{
    public partial class ComponentLinkedStorageAccountPatch
    {
        public ComponentLinkedStorageAccountPatch() { }
        public string LinkedStorageAccount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.StorageType ServiceProfiler { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.StorageType left, Azure.ResourceManager.ApplicationInsights.Models.StorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.StorageType left, Azure.ResourceManager.ApplicationInsights.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
