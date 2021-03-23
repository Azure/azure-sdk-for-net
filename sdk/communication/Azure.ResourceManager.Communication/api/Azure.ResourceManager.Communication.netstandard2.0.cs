namespace Azure.ResourceManager.Communication
{
    public partial class CommunicationManagementClient
    {
        protected CommunicationManagementClient() { }
        public CommunicationManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Communication.CommunicationManagementClientOptions options = null) { }
        public CommunicationManagementClient(System.Uri endpoint, string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Communication.CommunicationManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.Communication.CommunicationServiceOperations CommunicationService { get { throw null; } }
        public virtual Azure.ResourceManager.Communication.Operations Operations { get { throw null; } }
        public virtual Azure.ResourceManager.Communication.OperationStatusesOperations OperationStatuses { get { throw null; } }
    }
    public partial class CommunicationManagementClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationManagementClientOptions() { }
    }
    public partial class CommunicationServiceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Communication.Models.CommunicationServiceResource>
    {
        protected CommunicationServiceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Communication.Models.CommunicationServiceResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationServiceDeleteOperation : Azure.Operation<Azure.Response>
    {
        protected CommunicationServiceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationServiceOperations
    {
        protected CommunicationServiceOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.NameAvailability> CheckNameAvailability(Azure.ResourceManager.Communication.Models.NameAvailabilityParameters nameAvailabilityParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.NameAvailability>> CheckNameAvailabilityAsync(Azure.ResourceManager.Communication.Models.NameAvailabilityParameters nameAvailabilityParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceResource> Get(string resourceGroupName, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceResource>> GetAsync(string resourceGroupName, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.LinkedNotificationHub> LinkNotificationHub(string resourceGroupName, string communicationServiceName, Azure.ResourceManager.Communication.Models.LinkNotificationHubParameters linkNotificationHubParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>> LinkNotificationHubAsync(string resourceGroupName, string communicationServiceName, Azure.ResourceManager.Communication.Models.LinkNotificationHubParameters linkNotificationHubParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.Models.CommunicationServiceResource> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.Models.CommunicationServiceResource> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.Models.CommunicationServiceResource> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.Models.CommunicationServiceResource> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys> ListKeys(string resourceGroupName, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>> ListKeysAsync(string resourceGroupName, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys> RegenerateKey(string resourceGroupName, string communicationServiceName, Azure.ResourceManager.Communication.Models.RegenerateKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>> RegenerateKeyAsync(string resourceGroupName, string communicationServiceName, Azure.ResourceManager.Communication.Models.RegenerateKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.CommunicationServiceCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string communicationServiceName, Azure.ResourceManager.Communication.Models.CommunicationServiceResource parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Communication.CommunicationServiceCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string communicationServiceName, Azure.ResourceManager.Communication.Models.CommunicationServiceResource parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.CommunicationServiceDeleteOperation StartDelete(string resourceGroupName, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Communication.CommunicationServiceDeleteOperation> StartDeleteAsync(string resourceGroupName, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceResource> Update(string resourceGroupName, string communicationServiceName, Azure.ResourceManager.Communication.Models.CommunicationServiceResource parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceResource>> UpdateAsync(string resourceGroupName, string communicationServiceName, Azure.ResourceManager.Communication.Models.CommunicationServiceResource parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Operations
    {
        protected Operations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationStatusesOperations
    {
        protected OperationStatusesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.OperationStatus> Get(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.OperationStatus>> GetAsync(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Communication.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.Communication.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.ActionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.ActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.ActionType left, Azure.ResourceManager.Communication.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.ActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.ActionType left, Azure.ResourceManager.Communication.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommunicationServiceKeys
    {
        internal CommunicationServiceKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class CommunicationServiceResource : Azure.ResourceManager.Communication.Models.Resource
    {
        public CommunicationServiceResource() { }
        public string DataLocation { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public string ImmutableResourceId { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string NotificationHubId { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.Communication.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.CreatedByType left, Azure.ResourceManager.Communication.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.CreatedByType left, Azure.ResourceManager.Communication.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorAdditionalInfo
    {
        internal ErrorAdditionalInfo() { }
        public object Info { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class ErrorDetail
    {
        internal ErrorDetail() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Communication.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Communication.Models.ErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public enum KeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class LinkedNotificationHub
    {
        internal LinkedNotificationHub() { }
        public string ResourceId { get { throw null; } }
    }
    public partial class LinkNotificationHubParameters
    {
        public LinkNotificationHubParameters(string resourceId, string connectionString) { }
        public string ConnectionString { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class LocationResource
    {
        public LocationResource() { }
        public string Location { get { throw null; } set { } }
    }
    public partial class NameAvailability
    {
        internal NameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class NameAvailabilityParameters
    {
        public NameAvailabilityParameters(string type, string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.Communication.Models.ActionType? ActionType { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.Origin? Origin { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.ErrorDetail Error { get { throw null; } }
        public string Id { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.Status? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Origin : System.IEquatable<Azure.ResourceManager.Communication.Models.Origin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Origin(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.Origin System { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.Origin User { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.Origin UserSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.Origin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.Origin left, Azure.ResourceManager.Communication.Models.Origin right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.Origin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.Origin left, Azure.ResourceManager.Communication.Models.Origin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Communication.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.ProvisioningState left, Azure.ResourceManager.Communication.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.ProvisioningState left, Azure.ResourceManager.Communication.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateKeyParameters
    {
        public RegenerateKeyParameters() { }
        public Azure.ResourceManager.Communication.Models.KeyType? KeyType { get { throw null; } set { } }
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Communication.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.Status Canceled { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.Status Creating { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.Status Deleting { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.Status Failed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.Status Moving { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.Status Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.Status left, Azure.ResourceManager.Communication.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.Status left, Azure.ResourceManager.Communication.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SystemData
    {
        internal SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.CreatedByType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.CreatedByType? LastModifiedByType { get { throw null; } }
    }
    public partial class TaggedResource
    {
        public TaggedResource() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
