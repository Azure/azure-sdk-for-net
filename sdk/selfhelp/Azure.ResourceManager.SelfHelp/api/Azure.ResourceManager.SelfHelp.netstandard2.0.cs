namespace Azure.ResourceManager.SelfHelp
{
    public partial class SelfHelpDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SelfHelpDiagnosticResource() { }
        public virtual Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string diagnosticsResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpDiagnosticResourceCollection : Azure.ResourceManager.ArmCollection
    {
        protected SelfHelpDiagnosticResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticsResourceName, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticsResourceName, Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> Get(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetAsync(string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SelfHelpDiagnosticResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SelfHelpDiagnosticResourceData() { }
        public string AcceptedTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnostic> Diagnostics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> GlobalParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SelfHelp.Models.DiagnosticInvocation> Insights { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public static partial class SelfHelpExtensions
    {
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource GetSelfHelpDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource> GetSelfHelpDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResource>> GetSelfHelpDiagnosticResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string diagnosticsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResourceCollection GetSelfHelpDiagnosticResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.SelfHelp.Models
{
    public static partial class ArmSelfHelpModelFactory
    {
        public static Azure.ResourceManager.SelfHelp.Models.DiagnosticInsight DiagnosticInsight(string insightId = null, string insightTitle = null, string insightResults = null, Azure.ResourceManager.SelfHelp.Models.ImportanceLevel? insightImportanceLevel = default(Azure.ResourceManager.SelfHelp.Models.ImportanceLevel?)) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnostic SelfHelpDiagnostic(string solutionId = null, Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus? status = default(Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.DiagnosticInsight> insights = null, Azure.ResourceManager.SelfHelp.Models.SelfHelpError error = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.SelfHelpDiagnosticResourceData SelfHelpDiagnosticResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> globalParameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.DiagnosticInvocation> insights = null, string acceptedTime = null, Azure.ResourceManager.SelfHelp.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.SelfHelp.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpDiagnostic> diagnostics = null) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.SelfHelpError SelfHelpError(string errorCode = null, string errorType = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SelfHelp.Models.SelfHelpError> details = null) { throw null; }
    }
    public partial class DiagnosticInsight
    {
        internal DiagnosticInsight() { }
        public string InsightId { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.ImportanceLevel? InsightImportanceLevel { get { throw null; } }
        public string InsightResults { get { throw null; } }
        public string InsightTitle { get { throw null; } }
    }
    public partial class DiagnosticInvocation
    {
        public DiagnosticInvocation() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalParameters { get { throw null; } }
        public string SolutionId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnosticStatus : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnosticStatus(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus MissingInputs { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus Running { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus left, Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus left, Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImportanceLevel : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.ImportanceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImportanceLevel(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ImportanceLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ImportanceLevel Information { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ImportanceLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.ImportanceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.ImportanceLevel left, Azure.ResourceManager.SelfHelp.Models.ImportanceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.ImportanceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.ImportanceLevel left, Azure.ResourceManager.SelfHelp.Models.ImportanceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.SelfHelp.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SelfHelp.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ProvisioningState PartialComplete { get { throw null; } }
        public static Azure.ResourceManager.SelfHelp.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SelfHelp.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SelfHelp.Models.ProvisioningState left, Azure.ResourceManager.SelfHelp.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SelfHelp.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SelfHelp.Models.ProvisioningState left, Azure.ResourceManager.SelfHelp.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHelpDiagnostic
    {
        internal SelfHelpDiagnostic() { }
        public Azure.ResourceManager.SelfHelp.Models.SelfHelpError Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.DiagnosticInsight> Insights { get { throw null; } }
        public string SolutionId { get { throw null; } }
        public Azure.ResourceManager.SelfHelp.Models.DiagnosticStatus? Status { get { throw null; } }
    }
    public partial class SelfHelpError
    {
        internal SelfHelpError() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SelfHelp.Models.SelfHelpError> Details { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string Message { get { throw null; } }
    }
}
