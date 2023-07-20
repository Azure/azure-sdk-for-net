namespace Azure.ResourceManager.EdgeConnectivityStatuses
{
    public static partial class EdgeConnectivityStatusesExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus> CreateOrUpdateConnectivityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string connectivityStatusName, Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus>> CreateOrUpdateConnectivityStatusAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string connectivityStatusName, Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation DeleteConnectivityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string connectivityStatusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteConnectivityStatusAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string connectivityStatusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus> GetConnectivityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string connectivityStatusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus>> GetConnectivityStatusAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string connectivityStatusName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus> GetConnectivityStatuses(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus> GetConnectivityStatusesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus> UpdateConnectivityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string connectivityStatusName, Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatusUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus>> UpdateConnectivityStatusAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string connectivityStatusName, Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatusUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeConnectivityStatuses.Models
{
    public static partial class ArmEdgeConnectivityStatusesModelFactory
    {
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.ConnectivityStatus ConnectivityStatus(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState?)) { throw null; }
    }
    public partial class ConnectivityStatus : Azure.ResourceManager.Models.ResourceData
    {
        public ConnectivityStatus() { }
        public Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } set { } }
    }
    public partial class ConnectivityStatusUpdate
    {
        public ConnectivityStatusUpdate() { }
        public Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState left, Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState left, Azure.ResourceManager.EdgeConnectivityStatuses.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status Connected { get { throw null; } }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status RecentlyConnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status left, Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status left, Azure.ResourceManager.EdgeConnectivityStatuses.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
}
