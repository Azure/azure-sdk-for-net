namespace Azure.ResourceManager.DigitalTwins
{
    public partial class DigitalTwinsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription>
    {
        internal DigitalTwinsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal DigitalTwinsDeleteOperation() { }
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
    public partial class DigitalTwinsEndpointCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource>
    {
        internal DigitalTwinsEndpointCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsEndpointDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal DigitalTwinsEndpointDeleteOperation() { }
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
    public partial class DigitalTwinsEndpointOperations
    {
        protected DigitalTwinsEndpointOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource> Get(string resourceGroupName, string resourceName, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource>> GetAsync(string resourceGroupName, string resourceName, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource> List(string resourceGroupName, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource> ListAsync(string resourceGroupName, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string resourceName, string endpointName, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties properties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string resourceName, string endpointName, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties properties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointDeleteOperation StartDelete(string resourceGroupName, string resourceName, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointDeleteOperation> StartDeleteAsync(string resourceGroupName, string resourceName, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsManagementClient
    {
        protected DigitalTwinsManagementClient() { }
        public DigitalTwinsManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.DigitalTwins.DigitalTwinsManagementClientOptions options = null) { }
        public DigitalTwinsManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.DigitalTwins.DigitalTwinsManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsOperations DigitalTwins { get { throw null; } }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsEndpointOperations DigitalTwinsEndpoint { get { throw null; } }
        public virtual Azure.ResourceManager.DigitalTwins.Operations Operations { get { throw null; } }
    }
    public partial class DigitalTwinsManagementClientOptions : Azure.Core.ClientOptions
    {
        public DigitalTwinsManagementClientOptions() { }
    }
    public partial class DigitalTwinsOperations
    {
        protected DigitalTwinsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.Models.CheckNameResult> CheckNameAvailability(string location, string name, string type = "Microsoft.DigitalTwins/digitalTwinsInstances", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.CheckNameResult>> CheckNameAvailabilityAsync(string location, string name, string type = "Microsoft.DigitalTwins/digitalTwinsInstances", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription> Get(string resourceGroupName, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription>> GetAsync(string resourceGroupName, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string resourceName, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription digitalTwinsCreate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DigitalTwins.DigitalTwinsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string resourceName, Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription digitalTwinsCreate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsDeleteOperation StartDelete(string resourceGroupName, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DigitalTwins.DigitalTwinsDeleteOperation> StartDeleteAsync(string resourceGroupName, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DigitalTwins.DigitalTwinsUpdateOperation StartUpdate(string resourceGroupName, string resourceName, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DigitalTwins.DigitalTwinsUpdateOperation> StartUpdateAsync(string resourceGroupName, string resourceName, System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DigitalTwinsUpdateOperation : Azure.Operation<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription>
    {
        internal DigitalTwinsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Operations
    {
        protected Operations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DigitalTwins.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DigitalTwins.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DigitalTwins.Models
{
    public partial class CheckNameRequest
    {
        public CheckNameRequest(string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class CheckNameResult
    {
        internal CheckNameResult() { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.Reason? Reason { get { throw null; } }
    }
    public partial class DigitalTwinsDescription : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsResource
    {
        public DigitalTwinsDescription(string location) : base (default(string)) { }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public string HostName { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTime { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class DigitalTwinsDescriptionListResult
    {
        internal DigitalTwinsDescriptionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsDescription> Value { get { throw null; } }
    }
    public partial class DigitalTwinsEndpointResource : Azure.ResourceManager.DigitalTwins.Models.ExternalResource
    {
        public DigitalTwinsEndpointResource() { }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class DigitalTwinsEndpointResourceListResult
    {
        internal DigitalTwinsEndpointResourceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResource> Value { get { throw null; } }
    }
    public partial class DigitalTwinsEndpointResourceProperties
    {
        public DigitalTwinsEndpointResourceProperties() { }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class DigitalTwinsPatchDescription
    {
        public DigitalTwinsPatchDescription() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class DigitalTwinsResource
    {
        public DigitalTwinsResource(string location) { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsSkuInfo Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public partial class DigitalTwinsSkuInfo
    {
        public DigitalTwinsSkuInfo() { }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.EndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointType EventGrid { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointType EventHub { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.EndpointType ServiceBus { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.EndpointType left, Azure.ResourceManager.DigitalTwins.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.EndpointType left, Azure.ResourceManager.DigitalTwins.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGrid : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public EventGrid(string accessKey1, string accessKey2) { }
        public string AccessKey1 { get { throw null; } set { } }
        public string AccessKey2 { get { throw null; } set { } }
        public string TopicEndpoint { get { throw null; } set { } }
    }
    public partial class EventHub : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public EventHub(string connectionStringPrimaryKey, string connectionStringSecondaryKey) { }
        public string ConnectionStringPrimaryKey { get { throw null; } set { } }
        public string ConnectionStringSecondaryKey { get { throw null; } set { } }
    }
    public partial class ExternalResource
    {
        public ExternalResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.DigitalTwins.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationListResult
    {
        internal OperationListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DigitalTwins.Models.Operation> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.ProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.ProvisioningState left, Azure.ResourceManager.DigitalTwins.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Reason : System.IEquatable<Azure.ResourceManager.DigitalTwins.Models.Reason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Reason(string value) { throw null; }
        public static Azure.ResourceManager.DigitalTwins.Models.Reason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DigitalTwins.Models.Reason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DigitalTwins.Models.Reason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DigitalTwins.Models.Reason left, Azure.ResourceManager.DigitalTwins.Models.Reason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DigitalTwins.Models.Reason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DigitalTwins.Models.Reason left, Azure.ResourceManager.DigitalTwins.Models.Reason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceBus : Azure.ResourceManager.DigitalTwins.Models.DigitalTwinsEndpointResourceProperties
    {
        public ServiceBus(string primaryConnectionString, string secondaryConnectionString) { }
        public string PrimaryConnectionString { get { throw null; } set { } }
        public string SecondaryConnectionString { get { throw null; } set { } }
    }
}
