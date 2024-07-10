namespace Azure.ResourceManager.ComputeFleet
{
    public static partial class ComputeFleetExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> GetFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.FleetResource GetFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.FleetCollection GetFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeFleet.FleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.FleetResource>, System.Collections.IEnumerable
    {
        protected FleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.FleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ComputeFleet.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.FleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ComputeFleet.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeFleet.FleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeFleet.FleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeFleet.FleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeFleet.FleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeFleet.FleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.FleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>
    {
        public FleetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.FleetProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.FleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.FleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetResource() { }
        public virtual Azure.ResourceManager.ComputeFleet.FleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet> GetVirtualMachineScaleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet> GetVirtualMachineScaleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeFleet.FleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.FleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.FleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.FleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.FleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeFleet.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.FleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeFleet.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeFleet.Mocking
{
    public partial class MockableComputeFleetArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetArmClient() { }
        public virtual Azure.ResourceManager.ComputeFleet.FleetResource GetFleetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeFleetResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleet(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.FleetResource>> GetFleetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeFleet.FleetCollection GetFleets() { throw null; }
    }
    public partial class MockableComputeFleetSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.FleetResource> GetFleetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeFleet.Models
{
    public partial class AdditionalUnattendContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent>
    {
        public AdditionalUnattendContent() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComponentName? ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.PassName? PassName { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SettingName? SettingName { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>
    {
        internal ApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase> Details { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.ApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiErrorBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase>
    {
        internal ApiErrorBase() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmComputeFleetModelFactory
    {
        public static Azure.ResourceManager.ComputeFleet.Models.ApiError ApiError(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase> details = null, Azure.ResourceManager.ComputeFleet.Models.InnerError innererror = null, string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ApiErrorBase ApiErrorBase(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.FleetData FleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeFleet.Models.FleetProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.FleetProperties FleetProperties(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState?), Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile spotPriorityProfile = null, Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile regularPriorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.ComputeFleet.Models.ComputeProfile computeProfile = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ImageReference ImageReference(string id = null, string publisher = null, string offer = null, string sku = null, string version = null, string exactVersion = null, string sharedGalleryImageId = null, string communityGalleryImageId = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.InnerError InnerError(string exceptiontype = null, string errordetail = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly SubResourceReadOnly(string id = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension VirtualMachineExtension(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties VirtualMachineExtensionProperties(string forceUpdateTag = null, string publisher = null, string virtualMachineExtensionPropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView instanceView = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet VirtualMachineScaleSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeFleet.Models.ProvisioningState operationStatus = default(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState), Azure.ResourceManager.ComputeFleet.Models.ApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension VirtualMachineScaleSetExtension(string id = null, string name = null, string resourceType = null, Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties VirtualMachineScaleSetExtensionProperties(string forceUpdateTag = null, string publisher = null, string virtualMachineScaleSetExtensionPropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference protectedSettingsFromKeyVault = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile VirtualMachineScaleSetVmProfile(Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile osProfile = null, Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile storageProfile = null, Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile networkProfile = null, Azure.ResourceManager.ComputeFleet.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics bootDiagnostics = null, Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile extensionProfile = null, string licenseType = null, Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType?), Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication> galleryApplications = null, Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties hardwareVmSizeProperties = null, Azure.Core.ResourceIdentifier serviceArtifactReferenceId = null, Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference securityPostureReference = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class BootDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics>
    {
        public BootDiagnostics() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentName : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComponentName MicrosoftWindowsShellSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComponentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComponentName left, Azure.ResourceManager.ComputeFleet.Models.ComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComponentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComponentName left, Azure.ResourceManager.ComputeFleet.Models.ComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>
    {
        public ComputeProfile(Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile baseVirtualMachineProfile) { }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile BaseVirtualMachineProfile { get { throw null; } set { } }
        public string ComputeApiVersion { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeProfileUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate>
    {
        public ComputeProfileUpdate() { }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile BaseVirtualMachineProfile { get { throw null; } set { } }
        public string ComputeApiVersion { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteOption : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.DeleteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.DeleteOption Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.DeleteOption Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.DeleteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.DeleteOption left, Azure.ResourceManager.ComputeFleet.Models.DeleteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.DeleteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.DeleteOption left, Azure.ResourceManager.ComputeFleet.Models.DeleteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskOption : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption left, Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption left, Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement left, Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement left, Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings>
    {
        public DiffDiskSettings() { }
        public Azure.ResourceManager.ComputeFleet.Models.DiffDiskOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType Attach { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType Empty { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType FromImage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType left, Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType left, Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDeleteOptionType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDeleteOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType left, Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType left, Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScopeType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScopeType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType left, Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType left, Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvictionPolicy : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy left, Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy left, Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FleetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>
    {
        public FleetPatch() { }
        public Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.FleetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.FleetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>
    {
        public FleetProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile> vmSizesProfile, Azure.ResourceManager.ComputeFleet.Models.ComputeProfile computeProfile) { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeProfile ComputeProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile RegularPriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile SpotPriorityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile> VmSizesProfile { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.FleetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.FleetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate>
    {
        public FleetPropertiesUpdate() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeProfileUpdate ComputeProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile RegularPriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile SpotPriorityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile> VmSizesProfile { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.FleetPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageReference : Azure.ResourceManager.ComputeFleet.Models.SubResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ImageReference>
    {
        public ImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.InnerError>
    {
        internal InnerError() { }
        public string Errordetail { get { throw null; } }
        public string Exceptiontype { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.InnerError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus>
    {
        public InstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.StatusLevelType? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPVersion : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.IPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPVersion(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.IPVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.IPVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.IPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.IPVersion left, Azure.ResourceManager.ComputeFleet.Models.IPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.IPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.IPVersion left, Azure.ResourceManager.ComputeFleet.Models.IPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference>
    {
        public KeyVaultSecretReference(System.Uri secretUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration>
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? EnableVmAgentPlatformUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings>
    {
        public LinuxPatchSettings() { }
        public Azure.ResourceManager.ComputeFleet.Models.LinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode? PatchMode { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxVmGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>
    {
        public LinuxVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.ComputeFleet.Models.LinuxVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType left, Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType left, Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServiceIdentityUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>
    {
        public ManagedServiceIdentityUpdate() { }
        public Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityType? IdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ManagedServiceIdentityUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.Mode Audit { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.Mode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.Mode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.Mode left, Azure.ResourceManager.ComputeFleet.Models.Mode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.Mode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.Mode left, Azure.ResourceManager.ComputeFleet.Models.Mode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkApiVersion : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkApiVersion(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion TwoThousandTwenty1101 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion left, Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion left, Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliaryMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode AcceleratedConnections { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode Floating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkInterfaceAuxiliarySku(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku A1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku A2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku A4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku A8 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class OSImageNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile>
    {
        public OSImageNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassName : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.PassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.PassName OobeSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.PassName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.PassName left, Azure.ResourceManager.ComputeFleet.Models.PassName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.PassName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.PassName left, Azure.ResourceManager.ComputeFleet.Models.PassName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.PatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.PatchSettings>
    {
        public PatchSettings() { }
        public Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? EnableHotpatching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode? PatchMode { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.PatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.PatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.PatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.PatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.PatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.PatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.PatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ProtocolType
    {
        Http = 0,
        Https = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState left, Azure.ResourceManager.ComputeFleet.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ProvisioningState left, Azure.ResourceManager.ComputeFleet.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyAgentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings>
    {
        public ProxyAgentSettings() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.Mode? Mode { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicIPAddressSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku>
    {
        public PublicIPAddressSku() { }
        public Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName left, Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName left, Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegularPriorityAllocationStrategy : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegularPriorityAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy left, Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy left, Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegularPriorityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>
    {
        public RegularPriorityProfile() { }
        public Azure.ResourceManager.ComputeFleet.Models.RegularPriorityAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public int? Capacity { get { throw null; } set { } }
        public int? MinCapacity { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledEventsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile>
    {
        public ScheduledEventsProfile() { }
        public Azure.ResourceManager.ComputeFleet.Models.OSImageNotificationProfile OSImageNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType DiskWithVmGuestState { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType VmGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType left, Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType left, Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityPostureReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference>
    {
        public SecurityPostureReference() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension> ExcludeExtensions { get { throw null; } }
        public string Id { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SecurityProfile>
    {
        public SecurityProfile() { }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SecurityType? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.UefiSettings UefiSettings { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.SecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.SecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.SecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.SecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.SecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.SecurityType left, Azure.ResourceManager.ComputeFleet.Models.SecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.SecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.SecurityType left, Azure.ResourceManager.ComputeFleet.Models.SecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SettingName
    {
        AutoLogon = 0,
        FirstLogonCommands = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpotAllocationStrategy : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpotAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy CapacityOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy PriceCapacityOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy left, Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy left, Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpotPriorityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>
    {
        public SpotPriorityProfile() { }
        public Azure.ResourceManager.ComputeFleet.Models.SpotAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.EvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public bool? Maintain { get { throw null; } set { } }
        public float? MaxPricePerVm { get { throw null; } set { } }
        public int? MinCapacity { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SshPublicKey>
    {
        public SshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.SshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum StatusLevelType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.StorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.StorageAccountType PremiumV2LRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.StorageAccountType PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.StorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.StorageAccountType StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.StorageAccountType StandardSSDZRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.StorageAccountType UltraSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.StorageAccountType left, Azure.ResourceManager.ComputeFleet.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.StorageAccountType left, Azure.ResourceManager.ComputeFleet.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SubResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SubResource>
    {
        public SubResource() { }
        public string Id { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.SubResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SubResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SubResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SubResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SubResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SubResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SubResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubResourceReadOnly : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly>
    {
        public SubResourceReadOnly() { }
        public string Id { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TerminateNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile>
    {
        public TerminateNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.TerminateNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.UefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.UefiSettings>
    {
        public UefiSettings() { }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public bool? VTpmEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.UefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.UefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.UefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.UefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.UefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.UefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.UefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VaultCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VaultCertificate>
    {
        public VaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VaultCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VaultCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VaultCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VaultCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VaultCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VaultCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VaultCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultSecretGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup>
    {
        public VaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VaultCertificate> VaultCertificates { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineEvictionPolicyType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineEvictionPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineExtension : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension>
    {
        public VirtualMachineExtension(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView>
    {
        public VirtualMachineExtensionInstanceView() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.InstanceViewStatus> Substatuses { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VirtualMachineExtensionInstanceViewType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties>
    {
        public VirtualMachineExtensionProperties() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VirtualMachineExtensionPropertiesType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePriorityType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePriorityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType Low { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType Regular { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType left, Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType left, Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineScaleSet : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>
    {
        internal VirtualMachineScaleSet() { }
        public Azure.ResourceManager.ComputeFleet.Models.ApiError Error { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ProvisioningState OperationStatus { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk>
    {
        public VirtualMachineScaleSetDataDisk(int lun, Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeFleet.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtension : Azure.ResourceManager.ComputeFleet.Models.SubResourceReadOnly, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension>
    {
        public VirtualMachineScaleSetExtension() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties Properties { get { throw null; } set { } }
        public string ResourceType { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile>
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtension> Extensions { get { throw null; } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties>
    {
        public VirtualMachineScaleSetExtensionProperties() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.KeyVaultSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VirtualMachineScaleSetExtensionPropertiesType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration>
    {
        public VirtualMachineScaleSetIPConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetIPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties>
    {
        public VirtualMachineScaleSetIPConfigurationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetIPTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag>
    {
        public VirtualMachineScaleSetIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetManagedDiskContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent>
    {
        public VirtualMachineScaleSetManagedDiskContent() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration>
    {
        public VirtualMachineScaleSetNetworkConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetNetworkConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties>
    {
        public VirtualMachineScaleSetNetworkConfigurationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration> ipConfigurations) { }
        public Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.NetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.DeleteOption? DeleteOption { get { throw null; } set { } }
        public bool? DisableTcpStateTracking { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration> IPConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile>
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk>
    {
        public VirtualMachineScaleSetOSDisk(Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeFleet.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetManagedDiskContent ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.OperatingSystemType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile>
    {
        public VirtualMachineScaleSetOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerNamePrefix { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.PublicIPAddressSku Sku { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.DomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties>
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationProperties() { }
        public Azure.ResourceManager.ComputeFleet.Models.DeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetIPTag> IPTags { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetPublicIPAddressConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile>
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public string DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile>
    {
        public VirtualMachineScaleSetVmProfile() { }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties HardwareVmSizeProperties { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachinePriorityType? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SecurityPostureReference SecurityPostureReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceArtifactReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachineScaleSetVmProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmDiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile>
    {
        public VmDiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmDiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmGalleryApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication>
    {
        public VmGalleryApplication(string packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string PackageReferenceId { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmGalleryApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmSizeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>
    {
        public VmSizeProfile(string name) { }
        public string Name { get { throw null; } set { } }
        public int? Rank { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmSizeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties>
    {
        public VmSizeProperties() { }
        public int? VCPUsAvailable { get { throw null; } set { } }
        public int? VCPUsPerCore { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VmSizeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration>
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? EnableVmAgentPlatformUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.PatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.WinRMListener> WinRMListeners { get { throw null; } }
        Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeFleet.Models.WindowsPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsVmGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>
    {
        public WindowsVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.ComputeFleet.Models.WindowsVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WinRMListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WinRMListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WinRMListener>
    {
        public WinRMListener() { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ProtocolType? Protocol { get { throw null; } set { } }
        Azure.ResourceManager.ComputeFleet.Models.WinRMListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WinRMListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WinRMListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.WinRMListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WinRMListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WinRMListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WinRMListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
