namespace Azure.ResourceManager.SelfHelp
{
    public partial class SelfHelpDiagnosticCollection : Azure.ResourceManager.ArmCollection
    {
        protected SelfHelpDiagnosticCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticsResourceName, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticsResourceName, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Get(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetAsync(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpDiagnosticData : Azure.ResourceManager.Models.ResourceData
    {
        public SelfHelpDiagnosticData() { }
        public System.DateTimeOffset? AcceptedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo> Diagnostics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> GlobalParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation> Insights { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class SelfHelpDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SelfHelpDiagnosticResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string diagnosticsResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SelfHelpExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult> CheckSelfHelpNameAvailability(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult>> CheckSelfHelpNameAvailabilityAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> GetSelfHelpDiagnostic(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetSelfHelpDiagnosticAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource GetSelfHelpDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticCollection GetSelfHelpDiagnostics(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata> GetSelfHelpDiscoverySolutionsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SelfHelp.Models
{
    public static partial class ArmSelfHelpModelFactory
    {
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticData SelfHelpDiagnosticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> globalParameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInvocation> insights = null, System.DateTimeOffset? acceptedOn = default(System.DateTimeOffset?), Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo> diagnostics = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInfo SelfHelpDiagnosticInfo(string solutionId = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus? status = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> insights = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpError error = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight SelfHelpDiagnosticInsight(string id = null, string title = null, string results = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel? insightImportanceLevel = default(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpError SelfHelpError(string code = null, string errorType = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpError> details = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpNameAvailabilityResult SelfHelpNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpSolutionMetadata SelfHelpSolutionMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string solutionId = null, string solutionType = null, string description = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> requiredParameterSets = null) { throw null; }
    }
    public partial class SelfHelpDiagnosticInfo
    {
        internal SelfHelpDiagnosticInfo() { }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpError Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticInsight> Insights { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus? Status { get { throw null; } }
    }
    public partial class SelfHelpDiagnosticInsight
    {
        internal SelfHelpDiagnosticInsight() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel? InsightImportanceLevel { get { throw null; } }
        public string Results { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class SelfHelpDiagnosticInvocation
    {
        public SelfHelpDiagnosticInvocation() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalParameters { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpDiagnosticStatus : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpDiagnosticStatus(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus MissingInputs { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus Running { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus left, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus left, Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnosticStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpError
    {
        internal SelfHelpError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpError> Details { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpImportanceLevel : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpImportanceLevel(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel Information { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel left, Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel left, Azure.ResourceManager.SelfHelp.Models.SelfHelpImportanceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpNameAvailabilityContent
    {
        public SelfHelpNameAvailabilityContent() { }
        public string ResourceName { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class SelfHelpNameAvailabilityResult
    {
        internal SelfHelpNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHelpProvisioningState : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHelpProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState PartialComplete { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState left, Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState left, Azure.ResourceManager.SelfHelp.Models.SelfHelpProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpSolutionMetadata : Azure.ResourceManager.Models.ResourceData
    {
        public SelfHelpSolutionMetadata() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> RequiredParameterSets { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
        public string SolutionType { get { throw null; } set { } }
    }
}
