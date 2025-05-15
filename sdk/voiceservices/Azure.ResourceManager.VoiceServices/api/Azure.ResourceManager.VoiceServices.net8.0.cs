namespace Azure.ResourceManager.VoiceServices
{
    public partial class AzureResourceManagerVoiceServicesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerVoiceServicesContext() { }
        public static Azure.ResourceManager.VoiceServices.AzureResourceManagerVoiceServicesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class VoiceServicesCommunicationsGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>, System.Collections.IEnumerable
    {
        protected VoiceServicesCommunicationsGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communicationsGatewayName, Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communicationsGatewayName, Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> Get(string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> GetAsync(string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetIfExists(string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> GetIfExistsAsync(string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VoiceServicesCommunicationsGatewayData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>
    {
        public VoiceServicesCommunicationsGatewayData(Azure.Core.AzureLocation location) { }
        public System.BinaryData ApiBridge { get { throw null; } set { } }
        public string AutoGeneratedDomainNameLabel { get { throw null; } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec> Codecs { get { throw null; } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity? Connectivity { get { throw null; } set { } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType? E911Type { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmergencyDialStrings { get { throw null; } }
        public bool? IsOnPremMcpEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform> Platforms { get { throw null; } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties> ServiceLocations { get { throw null; } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus? Status { get { throw null; } }
        public string TeamsVoicemailPilotNumber { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VoiceServicesCommunicationsGatewayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VoiceServicesCommunicationsGatewayResource() { }
        public virtual Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communicationsGatewayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> GetVoiceServicesTestLine(string testLineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> GetVoiceServicesTestLineAsync(string testLineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VoiceServices.VoiceServicesTestLineCollection GetVoiceServicesTestLines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> Update(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> UpdateAsync(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class VoiceServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult> CheckVoiceServicesNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>> CheckVoiceServicesNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetVoiceServicesCommunicationsGateway(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> GetVoiceServicesCommunicationsGatewayAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource GetVoiceServicesCommunicationsGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayCollection GetVoiceServicesCommunicationsGateways(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetVoiceServicesCommunicationsGateways(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetVoiceServicesCommunicationsGatewaysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource GetVoiceServicesTestLineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class VoiceServicesTestLineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>, System.Collections.IEnumerable
    {
        protected VoiceServicesTestLineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string testLineName, Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string testLineName, Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string testLineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string testLineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> Get(string testLineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> GetAsync(string testLineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> GetIfExists(string testLineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> GetIfExistsAsync(string testLineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VoiceServicesTestLineData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>
    {
        public VoiceServicesTestLineData(Azure.Core.AzureLocation location) { }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose? Purpose { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VoiceServicesTestLineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VoiceServicesTestLineResource() { }
        public virtual Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communicationsGatewayName, string testLineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource> Update(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource>> UpdateAsync(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.VoiceServices.Mocking
{
    public partial class MockableVoiceServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableVoiceServicesArmClient() { }
        public virtual Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource GetVoiceServicesCommunicationsGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.VoiceServices.VoiceServicesTestLineResource GetVoiceServicesTestLineResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableVoiceServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableVoiceServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetVoiceServicesCommunicationsGateway(string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource>> GetVoiceServicesCommunicationsGatewayAsync(string communicationsGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayCollection GetVoiceServicesCommunicationsGateways() { throw null; }
    }
    public partial class MockableVoiceServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableVoiceServicesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult> CheckVoiceServicesNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>> CheckVoiceServicesNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetVoiceServicesCommunicationsGateways(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayResource> GetVoiceServicesCommunicationsGatewaysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.VoiceServices.Models
{
    public static partial class ArmVoiceServicesModelFactory
    {
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult VoiceServicesCheckNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason? reason = default(Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.VoiceServices.VoiceServicesCommunicationsGatewayData VoiceServicesCommunicationsGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState? provisioningState = default(Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState?), Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus? status = default(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties> serviceLocations = null, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity? connectivity = default(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec> codecs = null, Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType? e911Type = default(Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform> platforms = null, System.BinaryData apiBridge = null, Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope?), string autoGeneratedDomainNameLabel = null, string teamsVoicemailPilotNumber = null, bool? isOnPremMcpEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> emergencyDialStrings = null) { throw null; }
        public static Azure.ResourceManager.VoiceServices.VoiceServicesTestLineData VoiceServicesTestLineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState? provisioningState = default(Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState?), string phoneNumber = null, Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose? purpose = default(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesAutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesAutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesAutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VoiceServicesCheckNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent>
    {
        public VoiceServicesCheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VoiceServicesCheckNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>
    {
        internal VoiceServicesCheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCheckNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesCommunicationsGatewayConnectivity : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesCommunicationsGatewayConnectivity(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity PublicAddress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayConnectivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VoiceServicesCommunicationsGatewayPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch>
    {
        public VoiceServicesCommunicationsGatewayPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesCommunicationsGatewayStatus : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesCommunicationsGatewayStatus(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus ChangePending { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus Complete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsGatewayStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesCommunicationsPlatform : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesCommunicationsPlatform(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform OperatorConnect { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform TeamsPhoneMobile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesCommunicationsPlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesEmergencyCallType : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesEmergencyCallType(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType DirectToEsrp { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesEmergencyCallType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesNameUnavailableReason : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VoiceServicesPrimaryRegionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties>
    {
        public VoiceServicesPrimaryRegionProperties(System.Collections.Generic.IEnumerable<string> operatorAddresses) { }
        public System.Collections.Generic.IList<string> AllowedMediaSourceAddressPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedSignalingSourceAddressPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<string> EsrpAddresses { get { throw null; } }
        public System.Collections.Generic.IList<string> OperatorAddresses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesProvisioningState : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VoiceServicesServiceRegionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties>
    {
        public VoiceServicesServiceRegionProperties(string name, Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties primaryRegionProperties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.VoiceServices.Models.VoiceServicesPrimaryRegionProperties PrimaryRegionProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesServiceRegionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesTeamsCodec : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesTeamsCodec(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec G722 { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec G7222 { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec Pcma { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec Pcmu { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec Silk16 { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec Silk8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesTeamsCodec right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VoiceServicesTestLinePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch>
    {
        public VoiceServicesTestLinePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceServicesTestLinePurpose : System.IEquatable<Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceServicesTestLinePurpose(string value) { throw null; }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose Automated { get { throw null; } }
        public static Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose left, Azure.ResourceManager.VoiceServices.Models.VoiceServicesTestLinePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
}
