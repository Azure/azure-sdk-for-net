namespace Azure.ResourceManager.Communication
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Communication.CommunicationService GetCommunicationService(this Azure.ResourceManager.ArmClient armClient, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class CommunicationService : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommunicationService() { }
        public virtual Azure.ResourceManager.Communication.CommunicationServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communicationServiceName) { throw null; }
        public virtual Azure.ResourceManager.Communication.Models.CommunicationServiceDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Communication.Models.CommunicationServiceDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationService> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationService>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.LinkedNotificationHub> LinkNotificationHub(Azure.ResourceManager.Communication.Models.LinkNotificationHubOptions linkNotificationHubParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>> LinkNotificationHubAsync(Azure.ResourceManager.Communication.Models.LinkNotificationHubOptions linkNotificationHubParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys> RegenerateKey(Azure.ResourceManager.Communication.Models.RegenerateKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>> RegenerateKeyAsync(Azure.ResourceManager.Communication.Models.RegenerateKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationService> Update(Azure.ResourceManager.Communication.CommunicationServiceData parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationService>> UpdateAsync(Azure.ResourceManager.Communication.CommunicationServiceData parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationServiceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.CommunicationService>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.CommunicationService>, System.Collections.IEnumerable
    {
        protected CommunicationServiceCollection() { }
        public virtual Azure.ResourceManager.Communication.Models.CommunicationServiceCreateOrUpdateOperation CreateOrUpdate(string communicationServiceName, Azure.ResourceManager.Communication.CommunicationServiceData parameters = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Communication.Models.CommunicationServiceCreateOrUpdateOperation> CreateOrUpdateAsync(string communicationServiceName, Azure.ResourceManager.Communication.CommunicationServiceData parameters = null, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationService> Get(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.CommunicationService> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.CommunicationService> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationService>> GetAsync(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationService> GetIfExists(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationService>> GetIfExistsAsync(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.CommunicationService> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.CommunicationService>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.CommunicationService> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.CommunicationService>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommunicationServiceData : Azure.ResourceManager.Models.Resource
    {
        public CommunicationServiceData() { }
        public string DataLocation { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public string ImmutableResourceId { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string NotificationHubId { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.Communication.CommunicationServiceCollection GetCommunicationServices(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Communication.Models.NameAvailability> CheckNameAvailabilityCommunicationService(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Communication.Models.NameAvailabilityOptions nameAvailabilityParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.NameAvailability>> CheckNameAvailabilityCommunicationServiceAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Communication.Models.NameAvailabilityOptions nameAvailabilityParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Communication.CommunicationService> GetCommunicationServices(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetCommunicationServicesAsGenericResources(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetCommunicationServicesAsGenericResourcesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Communication.CommunicationService> GetCommunicationServicesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class CommunicationServiceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Communication.CommunicationService>
    {
        protected CommunicationServiceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Communication.CommunicationService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Communication.CommunicationService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Communication.CommunicationService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationServiceDeleteOperation : Azure.Operation
    {
        protected CommunicationServiceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationServiceKeys
    {
        internal CommunicationServiceKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class CommunicationServiceUpdateOperation : Azure.Operation<Azure.ResourceManager.Communication.CommunicationService>
    {
        protected CommunicationServiceUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Communication.CommunicationService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Communication.CommunicationService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Communication.CommunicationService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class LinkNotificationHubOptions
    {
        public LinkNotificationHubOptions(string resourceId, string connectionString) { }
        public string ConnectionString { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class NameAvailability
    {
        internal NameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class NameAvailabilityOptions
    {
        public NameAvailabilityOptions(string type, string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
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
    public partial class RegenerateKeyOptions
    {
        public RegenerateKeyOptions() { }
        public Azure.ResourceManager.Communication.Models.KeyType? KeyType { get { throw null; } set { } }
    }
}
