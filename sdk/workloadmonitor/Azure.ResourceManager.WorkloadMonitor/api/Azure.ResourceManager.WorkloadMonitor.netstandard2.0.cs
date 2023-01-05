namespace Azure.ResourceManager.WorkloadMonitor
{
    public partial class HealthMonitorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource>, System.Collections.IEnumerable
    {
        protected HealthMonitorCollection() { }
        public virtual Azure.Response<bool> Exists(string monitorId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource> Get(string monitorId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource> GetAll(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource> GetAllAsync(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource>> GetAsync(string monitorId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthMonitorData : Azure.ResourceManager.Models.ResourceData
    {
        internal HealthMonitorData() { }
        public Azure.ResourceManager.WorkloadMonitor.Models.HealthState? CurrentMonitorState { get { throw null; } }
        public string CurrentStateFirstObservedTimestamp { get { throw null; } }
        public string EvaluationTimestamp { get { throw null; } }
        public System.BinaryData Evidence { get { throw null; } }
        public string LastReportedTimestamp { get { throw null; } }
        public System.BinaryData MonitorConfiguration { get { throw null; } }
        public string MonitoredObject { get { throw null; } }
        public string MonitorName { get { throw null; } }
        public string MonitorType { get { throw null; } }
        public string ParentMonitorName { get { throw null; } }
        public Azure.ResourceManager.WorkloadMonitor.Models.HealthState? PreviousMonitorState { get { throw null; } }
    }
    public partial class HealthMonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthMonitorResource() { }
        public virtual Azure.ResourceManager.WorkloadMonitor.HealthMonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceCollectionName, string resourceName, string monitorId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource> GetHealthMonitorStateChange(string timestampUnix, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource>> GetHealthMonitorStateChangeAsync(string timestampUnix, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeCollection GetHealthMonitorStateChanges() { throw null; }
    }
    public partial class HealthMonitorStateChangeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource>, System.Collections.IEnumerable
    {
        protected HealthMonitorStateChangeCollection() { }
        public virtual Azure.Response<bool> Exists(string timestampUnix, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string timestampUnix, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource> Get(string timestampUnix, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource> GetAll(string filter = null, string expand = null, System.DateTimeOffset? startTimestampUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimestampUtc = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource> GetAllAsync(string filter = null, string expand = null, System.DateTimeOffset? startTimestampUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimestampUtc = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource>> GetAsync(string timestampUnix, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthMonitorStateChangeData : Azure.ResourceManager.Models.ResourceData
    {
        internal HealthMonitorStateChangeData() { }
        public Azure.ResourceManager.WorkloadMonitor.Models.HealthState? CurrentMonitorState { get { throw null; } }
        public string CurrentStateFirstObservedTimestamp { get { throw null; } }
        public string EvaluationTimestamp { get { throw null; } }
        public System.BinaryData Evidence { get { throw null; } }
        public System.BinaryData MonitorConfiguration { get { throw null; } }
        public string MonitoredObject { get { throw null; } }
        public string MonitorName { get { throw null; } }
        public string MonitorType { get { throw null; } }
        public Azure.ResourceManager.WorkloadMonitor.Models.HealthState? PreviousMonitorState { get { throw null; } }
    }
    public partial class HealthMonitorStateChangeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthMonitorStateChangeResource() { }
        public virtual Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceCollectionName, string resourceName, string monitorId, string timestampUnix) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class WorkloadMonitorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource> GetHealthMonitor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceCollectionName, string resourceName, string monitorId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource>> GetHealthMonitorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceCollectionName, string resourceName, string monitorId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadMonitor.HealthMonitorResource GetHealthMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadMonitor.HealthMonitorCollection GetHealthMonitors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceCollectionName, string resourceName) { throw null; }
        public static Azure.ResourceManager.WorkloadMonitor.HealthMonitorStateChangeResource GetHealthMonitorStateChangeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadMonitor.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthState : System.IEquatable<Azure.ResourceManager.WorkloadMonitor.Models.HealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadMonitor.Models.HealthState Critical { get { throw null; } }
        public static Azure.ResourceManager.WorkloadMonitor.Models.HealthState Disabled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadMonitor.Models.HealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadMonitor.Models.HealthState None { get { throw null; } }
        public static Azure.ResourceManager.WorkloadMonitor.Models.HealthState Unknown { get { throw null; } }
        public static Azure.ResourceManager.WorkloadMonitor.Models.HealthState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadMonitor.Models.HealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadMonitor.Models.HealthState left, Azure.ResourceManager.WorkloadMonitor.Models.HealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadMonitor.Models.HealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadMonitor.Models.HealthState left, Azure.ResourceManager.WorkloadMonitor.Models.HealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
