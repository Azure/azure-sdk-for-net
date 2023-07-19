namespace Azure.ResourceManager.EdgeUpdates
{
    public static partial class EdgeUpdatesExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeUpdates.Models.Update> CreateOrModifyUpdate(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.EdgeUpdates.Models.Update resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeUpdates.Models.Update>> CreateOrModifyUpdateAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string updateName, Azure.ResourceManager.EdgeUpdates.Models.Update resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation DeleteUpdate(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteUpdateAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeUpdates.Models.Update> GetUpdate(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeUpdates.Models.Update>> GetUpdateAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string updateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeUpdates.Models.Update> GetUpdates(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeUpdates.Models.Update> GetUpdatesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeUpdates.Models.Update> ModifyUpdate(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string updateName, Azure.ResourceManager.EdgeUpdates.Models.UpdateUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeUpdates.Models.Update>> ModifyUpdateAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string updateName, Azure.ResourceManager.EdgeUpdates.Models.UpdateUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeUpdates.Models
{
    public static partial class ArmEdgeUpdatesModelFactory
    {
        public static Azure.ResourceManager.EdgeUpdates.Models.Update Update(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState left, Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState left, Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Update : Azure.ResourceManager.Models.ResourceData
    {
        public Update() { }
        public Azure.ResourceManager.EdgeUpdates.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } set { } }
    }
    public partial class UpdateUpdate
    {
        public UpdateUpdate() { }
        public string Status { get { throw null; } set { } }
    }
}
