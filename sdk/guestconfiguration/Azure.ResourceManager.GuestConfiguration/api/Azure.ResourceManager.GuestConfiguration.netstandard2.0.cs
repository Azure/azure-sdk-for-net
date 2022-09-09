namespace Azure.ResourceManager.GuestConfiguration
{
    public partial class GuestConfigurationAssignmentData : Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationResourceData
    {
        public GuestConfigurationAssignmentData() { }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentProperties Properties { get { throw null; } set { } }
    }
    public static partial class GuestConfigurationExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetGuestConfigurationAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetGuestConfigurationAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetGuestConfigurationAssignmentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData> GetGuestConfigurationAssignmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> GetGuestConfigurationHcrpAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> GetGuestConfigurationHcrpAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource GetGuestConfigurationHcrpAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentCollection GetGuestConfigurationHcrpAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> GetGuestConfigurationVmAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> GetGuestConfigurationVmAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource GetGuestConfigurationVmAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentCollection GetGuestConfigurationVmAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> GetGuestConfigurationVmssAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmssName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> GetGuestConfigurationVmssAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmssName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource GetGuestConfigurationVmssAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentCollection GetGuestConfigurationVmssAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmssName) { throw null; }
    }
    public partial class GuestConfigurationHcrpAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>, System.Collections.IEnumerable
    {
        protected GuestConfigurationHcrpAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> Get(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> GetAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestConfigurationHcrpAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestConfigurationHcrpAssignmentResource() { }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName, string guestConfigurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReport(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>> GetReportAsync(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReports(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReportsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationHcrpAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestConfigurationVmAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>, System.Collections.IEnumerable
    {
        protected GuestConfigurationVmAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string guestConfigurationAssignmentName, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> Get(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> GetAsync(string guestConfigurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestConfigurationVmAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestConfigurationVmAssignmentResource() { }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string guestConfigurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReport(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>> GetReportAsync(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReports(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReportsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GuestConfigurationVmssAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>, System.Collections.IEnumerable
    {
        protected GuestConfigurationVmssAssignmentCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GuestConfigurationVmssAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GuestConfigurationVmssAssignmentResource() { }
        public virtual Azure.ResourceManager.GuestConfiguration.GuestConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmssName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.GuestConfigurationVmssAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReport(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport>> GetReportAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReports(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReport> GetReportsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.GuestConfiguration.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionAfterReboot : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionAfterReboot(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot ContinueConfiguration { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot StopConfiguration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot left, Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot left, Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignedGuestConfigurationMachineComplianceStatus : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignedGuestConfigurationMachineComplianceStatus(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus Compliant { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus NonCompliant { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus left, Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus left, Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssignmentReport
    {
        public AssignmentReport() { }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo Assignment { get { throw null; } set { } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType? OperationType { get { throw null; } }
        public System.Guid? ReportId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo> Resources { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo Vm { get { throw null; } set { } }
    }
    public partial class AssignmentReportResourceComplianceReason
    {
        public AssignmentReportResourceComplianceReason() { }
        public string Code { get { throw null; } }
        public string Phrase { get { throw null; } }
    }
    public partial class AssignmentReportResourceInfo
    {
        public AssignmentReportResourceInfo() { }
        public string AssignmentResourceSettingName { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceComplianceReason> Reasons { get { throw null; } }
    }
    public partial class ConfigurationInfo
    {
        public ConfigurationInfo() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ConfigurationParameter
    {
        public ConfigurationParameter() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class GuestConfigurationAssignmentInfo
    {
        public GuestConfigurationAssignmentInfo() { }
        public Azure.ResourceManager.GuestConfiguration.Models.ConfigurationInfo Configuration { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
    public partial class GuestConfigurationAssignmentProperties
    {
        public GuestConfigurationAssignmentProperties() { }
        public string AssignmentHash { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public string Context { get { throw null; } set { } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationNavigation GuestConfiguration { get { throw null; } set { } }
        public System.DateTimeOffset? LastComplianceStatusCheckedOn { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignmentReport LatestAssignmentReport { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LatestReportId { get { throw null; } }
        public string ParameterHash { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmssVmInfo> VmssVmList { get { throw null; } set { } }
    }
    public partial class GuestConfigurationAssignmentReport
    {
        internal GuestConfigurationAssignmentReport() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportProperties Properties { get { throw null; } }
    }
    public partial class GuestConfigurationAssignmentReportDetails
    {
        internal GuestConfigurationAssignmentReportDetails() { }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Guid? JobId { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType? OperationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.GuestConfiguration.Models.AssignmentReportResourceInfo> Resources { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class GuestConfigurationAssignmentReportProperties
    {
        internal GuestConfigurationAssignmentReportProperties() { }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentInfo Assignment { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportDetails Details { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Guid? ReportId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationVmInfo Vm { get { throw null; } }
        public string VmssResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestConfigurationAssignmentReportType : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestConfigurationAssignmentReportType(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType Consistency { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentReportType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestConfigurationAssignmentType : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestConfigurationAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType ApplyAndAutoCorrect { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType ApplyAndMonitor { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType Audit { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType DeployAndAutoCorrect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestConfigurationKind : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestConfigurationKind(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind Dsc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestConfigurationNavigation
    {
        public GuestConfigurationNavigation() { }
        public string AssignmentSource { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationAssignmentType? AssignmentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.ConfigurationParameter> ConfigurationParameter { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.GuestConfiguration.Models.ConfigurationParameter> ConfigurationProtectedParameter { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationSetting ConfigurationSetting { get { throw null; } }
        public string ContentHash { get { throw null; } set { } }
        public string ContentType { get { throw null; } }
        public System.Uri ContentUri { get { throw null; } set { } }
        public Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState left, Azure.ResourceManager.GuestConfiguration.Models.GuestConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuestConfigurationResourceData
    {
        public GuestConfigurationResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class GuestConfigurationVmInfo
    {
        public GuestConfigurationVmInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.Guid? Uuid { get { throw null; } }
    }
    public partial class GuestConfigurationVmssVmInfo
    {
        public GuestConfigurationVmssVmInfo() { }
        public Azure.ResourceManager.GuestConfiguration.Models.AssignedGuestConfigurationMachineComplianceStatus? ComplianceStatus { get { throw null; } }
        public System.DateTimeOffset? LastComplianceCheckedOn { get { throw null; } }
        public System.Guid? LatestReportId { get { throw null; } }
        public System.Guid? VmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LcmConfigurationMode : System.IEquatable<Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LcmConfigurationMode(string value) { throw null; }
        public static Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode ApplyAndAutoCorrect { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode ApplyAndMonitor { get { throw null; } }
        public static Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode ApplyOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode left, Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode left, Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LcmConfigurationSetting
    {
        internal LcmConfigurationSetting() { }
        public Azure.ResourceManager.GuestConfiguration.Models.ActionAfterReboot? ActionAfterReboot { get { throw null; } }
        public Azure.ResourceManager.GuestConfiguration.Models.LcmConfigurationMode? ConfigurationMode { get { throw null; } }
        public float? ConfigurationModeFrequencyInMins { get { throw null; } }
        public bool? IsModuleOverwriteAllowed { get { throw null; } }
        public bool? RebootIfNeeded { get { throw null; } }
        public float? RefreshFrequencyInMins { get { throw null; } }
    }
}
