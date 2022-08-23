namespace Azure.ResourceManager.ChangeAnalysis
{
    public static partial class ChangeAnalysisExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.Change> GetChangesByResourceGroupChanges(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.Change> GetChangesByResourceGroupChangesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.Change> GetChangesBySubscriptionChanges(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.Change> GetChangesBySubscriptionChangesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.Change> GetResourceChanges(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.Change> GetResourceChangesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ChangeAnalysis.Models
{
    public partial class Change : Azure.ResourceManager.Models.ResourceData
    {
        internal Change() { }
        public Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties Properties { get { throw null; } }
    }
    public enum ChangeCategory
    {
        User = 0,
        System = 1,
    }
    public partial class ChangeProperties
    {
        internal ChangeProperties() { }
        public Azure.ResourceManager.ChangeAnalysis.Models.ChangeType? ChangeType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InitiatedByList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange> PropertyChanges { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeType : System.IEquatable<Azure.ResourceManager.ChangeAnalysis.Models.ChangeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeType(string value) { throw null; }
        public static Azure.ResourceManager.ChangeAnalysis.Models.ChangeType Add { get { throw null; } }
        public static Azure.ResourceManager.ChangeAnalysis.Models.ChangeType Remove { get { throw null; } }
        public static Azure.ResourceManager.ChangeAnalysis.Models.ChangeType Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType left, Azure.ResourceManager.ChangeAnalysis.Models.ChangeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ChangeAnalysis.Models.ChangeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType left, Azure.ResourceManager.ChangeAnalysis.Models.ChangeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Level : System.IEquatable<Azure.ResourceManager.ChangeAnalysis.Models.Level>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Level(string value) { throw null; }
        public static Azure.ResourceManager.ChangeAnalysis.Models.Level Important { get { throw null; } }
        public static Azure.ResourceManager.ChangeAnalysis.Models.Level Noisy { get { throw null; } }
        public static Azure.ResourceManager.ChangeAnalysis.Models.Level Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ChangeAnalysis.Models.Level other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ChangeAnalysis.Models.Level left, Azure.ResourceManager.ChangeAnalysis.Models.Level right) { throw null; }
        public static implicit operator Azure.ResourceManager.ChangeAnalysis.Models.Level (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ChangeAnalysis.Models.Level left, Azure.ResourceManager.ChangeAnalysis.Models.Level right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PropertyChange
    {
        internal PropertyChange() { }
        public Azure.ResourceManager.ChangeAnalysis.Models.ChangeCategory? ChangeCategory { get { throw null; } }
        public Azure.ResourceManager.ChangeAnalysis.Models.ChangeType? ChangeType { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsDataMasked { get { throw null; } }
        public string JsonPath { get { throw null; } }
        public Azure.ResourceManager.ChangeAnalysis.Models.Level? Level { get { throw null; } }
        public string NewValue { get { throw null; } }
        public string OldValue { get { throw null; } }
    }
}
