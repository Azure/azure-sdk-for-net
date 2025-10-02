namespace Azure.ResourceManager.ComputeFleet
{
    public partial class AzureResourceManagerComputeFleetContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeFleetContext() { }
        public static Azure.ResourceManager.ComputeFleet.AzureResourceManagerComputeFleetContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ComputeFleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>, System.Collections.IEnumerable
    {
        protected ComputeFleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ComputeFleet.ComputeFleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ComputeFleet.ComputeFleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputeFleetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>
    {
        public ComputeFleetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.ComputeFleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.ComputeFleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ComputeFleetExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetComputeFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> GetComputeFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.ComputeFleetResource GetComputeFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.ComputeFleetCollection GetComputeFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetComputeFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetComputeFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeFleetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputeFleetResource() { }
        public virtual Azure.ResourceManager.ComputeFleet.ComputeFleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine> GetVirtualMachines(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine> GetVirtualMachinesAsync(string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss> GetVirtualMachineScaleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss> GetVirtualMachineScaleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeFleet.ComputeFleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.ComputeFleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.ComputeFleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeFleet.Mocking
{
    public partial class MockableComputeFleetArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetArmClient() { }
        public virtual Azure.ResourceManager.ComputeFleet.ComputeFleetResource GetComputeFleetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeFleetResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetComputeFleet(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeFleet.ComputeFleetResource>> GetComputeFleetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeFleet.ComputeFleetCollection GetComputeFleets() { throw null; }
    }
    public partial class MockableComputeFleetSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeFleetSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetComputeFleets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeFleet.ComputeFleetResource> GetComputeFleetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeFleet.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceleratorManufacturer : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceleratorManufacturer(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer AMD { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer Nvidia { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer Xilinx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer left, Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer left, Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceleratorType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.AcceleratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceleratorType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.AcceleratorType FPGA { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.AcceleratorType GPU { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.AcceleratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.AcceleratorType left, Azure.ResourceManager.ComputeFleet.Models.AcceleratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.AcceleratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.AcceleratorType left, Azure.ResourceManager.ComputeFleet.Models.AcceleratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdditionalCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities>
    {
        public AdditionalCapabilities() { }
        public bool? IsHibernationEnabled { get { throw null; } set { } }
        public bool? IsUltraSSDEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalInformationSettingName : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalInformationSettingName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName AutoLogon { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName FirstLogonCommands { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName left, Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName left, Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArchitectureType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ArchitectureType ARM64 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ArchitectureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ArchitectureType left, Azure.ResourceManager.ComputeFleet.Models.ArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ArchitectureType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ArchitectureType left, Azure.ResourceManager.ComputeFleet.Models.ArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmComputeFleetModelFactory
    {
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError ComputeFleetApiError(string code = null, string target = null, string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo> details = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError innererror = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo ComputeFleetApiErrorInfo(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.ComputeFleetData ComputeFleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference ComputeFleetImageReference(Azure.Core.ResourceIdentifier id = null, string publisher = null, string offer = null, string sku = null, string version = null, string exactVersion = null, string sharedGalleryImageId = null, string communityGalleryImageId = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError ComputeFleetInnerError(string exceptionType = null, string errorDetail = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties ComputeFleetProperties(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState? provisioningState, Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile spotPriorityProfile, Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile regularPriorityProfile, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile> vmSizesProfile, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes vmAttributes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.LocationProfile> additionalLocationsLocationProfiles, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile computeProfile, System.DateTimeOffset? createdOn, string uniqueId) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties ComputeFleetProperties(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState? provisioningState = default(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState?), Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile spotPriorityProfile = null, Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile regularPriorityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile> vmSizesProfile = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes vmAttributes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.LocationProfile> additionalLocationsLocationProfiles = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile computeProfile = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string uniqueId = null, Azure.ResourceManager.ComputeFleet.Models.FleetMode? mode = default(Azure.ResourceManager.ComputeFleet.Models.FleetMode?), Azure.ResourceManager.ComputeFleet.Models.CapacityType? capacityType = default(Azure.ResourceManager.ComputeFleet.Models.CapacityType?), Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy zoneAllocationPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile ComputeFleetVmProfile(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile osProfile = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile storageProfile = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile networkProfile = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile securityProfile = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics bootDiagnostics = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile extensionProfile = null, string licenseType = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication> galleryApplications = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties hardwareVmSizeProperties = null, Azure.Core.ResourceIdentifier serviceArtifactReferenceId = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference securityPostureReference = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss ComputeFleetVmss(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState operationStatus = default(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState), Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension ComputeFleetVmssExtension(Azure.Core.ResourceIdentifier id = null, string name = null, string extensionType = null, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties ComputeFleetVmssExtensionProperties(string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? shouldAutoUpgradeMinorVersion = default(bool?), bool? isAutomaticUpgradeEnabled = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> protectedSettings = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, bool? isSuppressFailuresEnabled = default(bool?), Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference protectedSettingsFromKeyVault = null) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VirtualMachine VirtualMachine(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus operationStatus = default(Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus), Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError error = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.CapacityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.CapacityType VCpu { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.CapacityType Vm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.CapacityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.CapacityType left, Azure.ResourceManager.ComputeFleet.Models.CapacityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.CapacityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.CapacityType left, Azure.ResourceManager.ComputeFleet.Models.CapacityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError>
    {
        internal ComputeFleetApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo> Details { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetApiErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo>
    {
        internal ComputeFleetApiErrorInfo() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetBootDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics>
    {
        public ComputeFleetBootDiagnostics() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetCachingType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetCachingType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType None { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetComputeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile>
    {
        public ComputeFleetComputeProfile(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile baseVirtualMachineProfile) { }
        public Azure.ResourceManager.ComputeFleet.Models.AdditionalCapabilities AdditionalVirtualMachineCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile BaseVirtualMachineProfile { get { throw null; } set { } }
        public string ComputeApiVersion { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetDiffDiskOption : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetDiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetDiffDiskPlacement : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetDiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement NvmeDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetDiffDiskSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings>
    {
        public ComputeFleetDiffDiskSettings() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskPlacement? Placement { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetDiskControllerType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetDiskControllerType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType Nvme { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType Scsi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetDiskCreateOptionType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetDiskCreateOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType Attach { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType Copy { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType Empty { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType FromImage { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetDiskDeleteOptionType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetDiskDeleteOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetDomainNameLabelScopeType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetDomainNameLabelScopeType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetEvictionPolicy : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetEvictionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference>
    {
        public ComputeFleetImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string ExactVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetInnerError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError>
    {
        internal ComputeFleetInnerError() { }
        public string ErrorDetail { get { throw null; } }
        public string ExceptionType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetInnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetIPVersion : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetIPVersion(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetKeyVaultSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference>
    {
        public ComputeFleetKeyVaultSecretReference(System.Uri secretUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration>
    {
        public ComputeFleetLinuxConfiguration() { }
        public bool? IsPasswordAuthenticationDisabled { get { throw null; } set { } }
        public bool? IsVmAgentPlatformUpdatesEnabled { get { throw null; } set { } }
        public bool? IsVmAgentProvisioned { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey> SshPublicKeys { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetLinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetLinuxPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetLinuxPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings>
    {
        public ComputeFleetLinuxPatchSettings() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode? PatchMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings>
    {
        public ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? IsBypassPlatformSafetyChecksOnUserScheduleEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetLinuxVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetLinuxVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetNetworkApiVersion : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetNetworkApiVersion(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion V20201101 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetNetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetNetworkInterfaceAuxiliaryMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode AcceleratedConnections { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode Floating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetNetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetNetworkInterfaceAuxiliarySku(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku A1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku A2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku A4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku A8 { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetOperatingSystemType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetOperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetOSImageNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile>
    {
        public ComputeFleetOSImageNotificationProfile() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch>
    {
        public ComputeFleetPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties>
    {
        public ComputeFleetProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile> vmSizesProfile, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile computeProfile) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.LocationProfile> AdditionalLocationsLocationProfiles { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.CapacityType? CapacityType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetComputeProfile ComputeProfile { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.FleetMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile RegularPriorityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile SpotPriorityProfile { get { throw null; } set { } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes VmAttributes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile> VmSizesProfile { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetProtocolType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType Http { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetProvisioningState : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetProxyAgentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings>
    {
        public ComputeFleetProxyAgentSettings() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode? Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetPublicIPAddressSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku>
    {
        public ComputeFleetPublicIPAddressSku() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetPublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetPublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetPublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetPublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetScheduledEventsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile>
    {
        public ComputeFleetScheduledEventsProfile() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOSImageNotificationProfile OSImageNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetSecurityEncryptionType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetSecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType DiskWithVmGuestState { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType NonPersistedTpm { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType VmGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetSecurityPostureReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference>
    {
        public ComputeFleetSecurityPostureReference() { }
        public System.Collections.Generic.IList<string> ExcludeExtensions { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public bool? IsOverridable { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile>
    {
        public ComputeFleetSecurityProfile() { }
        public bool? IsEncryptionAtHostEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings UefiSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetSecurityType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetSecurityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey>
    {
        public ComputeFleetSshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetStorageAccountType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType PremiumV2LRS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType StandardSsdLrd { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType StandardSsdZrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType UltraSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetTerminateNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile>
    {
        public ComputeFleetTerminateNotificationProfile() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetTerminateNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetUefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings>
    {
        public ComputeFleetUefiSettings() { }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public bool? IsVTpmEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetUefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVaultCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate>
    {
        public ComputeFleetVaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVaultSecretGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup>
    {
        public ComputeFleetVaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultCertificate> VaultCertificates { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmAttributeMinMaxDouble : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble>
    {
        public ComputeFleetVmAttributeMinMaxDouble() { }
        public double? Max { get { throw null; } set { } }
        public double? Min { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmAttributeMinMaxInteger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger>
    {
        public ComputeFleetVmAttributeMinMaxInteger() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmAttributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes>
    {
        public ComputeFleetVmAttributes(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger vCpuCount, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble memoryInGiB) { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger AcceleratorCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.AcceleratorManufacturer> AcceleratorManufacturers { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport? AcceleratorSupport { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.AcceleratorType> AcceleratorTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ArchitectureType> ArchitectureTypes { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport? BurstableSupport { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer> CpuManufacturers { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger DataDiskCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedVmSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType> LocalStorageDiskTypes { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble LocalStorageInGiB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport? LocalStorageSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble MemoryInGiB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble MemoryInGiBPerVCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxDouble NetworkBandwidthInMbps { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger NetworkInterfaceCount { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger RdmaNetworkInterfaceCount { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport? RdmaSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeMinMaxInteger VCpuCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory> VmCategories { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetVmAttributeSupport : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetVmAttributeSupport(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport Excluded { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport Included { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmAttributeSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetVmCategory : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetVmCategory(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory FpgaAccelerated { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory GpuAccelerated { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory HighPerformanceCompute { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory MemoryOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory StorageOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetVmDeleteOption : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetVmDeleteOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetVmDiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile>
    {
        public ComputeFleetVmDiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmGalleryApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication>
    {
        public ComputeFleetVmGalleryApplication(Azure.Core.ResourceIdentifier packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public bool? IsAutomaticUpgradeEnabled { get { throw null; } set { } }
        public bool? IsTreatFailureAsDeploymentFailureEnabled { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PackageReferenceId { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmGuestPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings>
    {
        public ComputeFleetVmGuestPatchSettings() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? IsHotPatchingEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode? PatchMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile>
    {
        public ComputeFleetVmProfile() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetBootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties HardwareVmSizeProperties { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityPostureReference SecurityPostureReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceArtifactReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmSizeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile>
    {
        public ComputeFleetVmSizeProfile(string name) { }
        public string Name { get { throw null; } set { } }
        public int? Rank { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmSizeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties>
    {
        public ComputeFleetVmSizeProperties() { }
        public int? VCPUsAvailable { get { throw null; } set { } }
        public int? VCPUsPerCore { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmSizeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmss : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss>
    {
        internal ComputeFleetVmss() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError Error { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProvisioningState OperationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmss>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk>
    {
        public ComputeFleetVmssDataDisk(int lun, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMbpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public bool? IsWriteAcceleratorEnabled { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension>
    {
        public ComputeFleetVmssExtension() { }
        public string ExtensionType { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssExtensionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile>
    {
        public ComputeFleetVmssExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtension> Extensions { get { throw null; } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties>
    {
        public ComputeFleetVmssExtensionProperties() { }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public bool? IsAutomaticUpgradeEnabled { get { throw null; } set { } }
        public bool? IsSuppressFailuresEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ProtectedSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetKeyVaultSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public bool? ShouldAutoUpgradeMinorVersion { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration>
    {
        public ComputeFleetVmssIPConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssIPConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties>
    {
        public ComputeFleetVmssIPConfigurationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public bool? IsPrimary { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssIPTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag>
    {
        public ComputeFleetVmssIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssManagedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk>
    {
        public ComputeFleetVmssManagedDisk() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetStorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration>
    {
        public ComputeFleetVmssNetworkConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssNetworkConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties>
    {
        public ComputeFleetVmssNetworkConfigurationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration> ipConfigurations) { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPConfiguration> IPConfigurations { get { throw null; } }
        public bool? IsAcceleratedNetworkingEnabled { get { throw null; } set { } }
        public bool? IsFpgaEnabled { get { throw null; } set { } }
        public bool? IsIPForwardingEnabled { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile>
    {
        public ComputeFleetVmssNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetNetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk>
    {
        public ComputeFleetVmssOSDisk(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetCachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public bool? IsWriteAcceleratorEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetOperatingSystemType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile>
    {
        public ComputeFleetVmssOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AreExtensionOperationsAllowed { get { throw null; } set { } }
        public string ComputerNamePrefix { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public bool? IsGuestProvisionSignalRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssPublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration>
    {
        public ComputeFleetVmssPublicIPAddressConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetPublicIPAddressSku Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssPublicIPAddressConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties>
    {
        public ComputeFleetVmssPublicIPAddressConfigurationProperties() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssIPTag> IPTags { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetIPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssPublicIPAddressDnsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings>
    {
        public ComputeFleetVmssPublicIPAddressDnsSettings(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssPublicIPAddressDnsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetVmssStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile>
    {
        public ComputeFleetVmssStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetDiskControllerType? DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssOSDisk OSDisk { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmssStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeFleetWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration>
    {
        public ComputeFleetWindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation> AdditionalUnattendContent { get { throw null; } }
        public bool? IsAutomaticUpdatesEnabled { get { throw null; } set { } }
        public bool? IsVmAgentPlatformUpdatesEnabled { get { throw null; } set { } }
        public bool? IsVmAgentProvisioned { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmGuestPatchSettings PatchSettings { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener> WinRMListeners { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetWindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetWindowsPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings>
    {
        public ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? IsBypassPlatformSafetyChecksOnUserScheduleEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeFleetWindowsVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeFleetWindowsVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode left, Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWindowsVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeFleetWinRMListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener>
    {
        public ComputeFleetWinRMListener() { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetProtocolType? Protocol { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ComputeFleetWinRMListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CpuManufacturer : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CpuManufacturer(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer AMD { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer Ampere { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer Intel { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer Microsoft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer left, Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer left, Azure.ResourceManager.ComputeFleet.Models.CpuManufacturer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.FleetMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.FleetMode Instance { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.FleetMode Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.FleetMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.FleetMode left, Azure.ResourceManager.ComputeFleet.Models.FleetMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.FleetMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.FleetMode left, Azure.ResourceManager.ComputeFleet.Models.FleetMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalStorageDiskType : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalStorageDiskType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType HDD { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType SSD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType left, Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType left, Azure.ResourceManager.ComputeFleet.Models.LocalStorageDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LocationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LocationProfile>
    {
        public LocationProfile(Azure.Core.AzureLocation location) { }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetVmProfile VirtualMachineProfileOverride { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.LocationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LocationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.LocationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.LocationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LocationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LocationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.LocationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProxyAgentExecuteMode : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProxyAgentExecuteMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode Audit { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode left, Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode left, Azure.ResourceManager.ComputeFleet.Models.ProxyAgentExecuteMode right) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.RegularPriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetEvictionPolicy? EvictionPolicy { get { throw null; } set { } }
        public bool? IsMaintainEnabled { get { throw null; } set { } }
        public float? MaxPricePerVm { get { throw null; } set { } }
        public int? MinCapacity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.SpotPriorityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachine : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine>
    {
        internal VirtualMachine() { }
        public Azure.ResourceManager.ComputeFleet.Models.ComputeFleetApiError Error { get { throw null; } }
        public Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus OperationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachine System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.VirtualMachine System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.VirtualMachine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmOperationStatus : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus CancelFailedStatusUnknown { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus left, Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus left, Azure.ResourceManager.ComputeFleet.Models.VmOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsSetupAdditionalInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation>
    {
        public WindowsSetupAdditionalInformation() { }
        public Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName? ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName? PassName { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeFleet.Models.AdditionalInformationSettingName? SettingName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsSetupAdditionalInformationComponentName : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsSetupAdditionalInformationComponentName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName MicrosoftWindowsShellSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName left, Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName left, Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsSetupAdditionalInformationPassName : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsSetupAdditionalInformationPassName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName OobeSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName left, Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName left, Azure.ResourceManager.ComputeFleet.Models.WindowsSetupAdditionalInformationPassName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ZoneAllocationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy>
    {
        public ZoneAllocationPolicy(Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy distributionStrategy) { }
        public Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy DistributionStrategy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeFleet.Models.ZonePreference> ZonePreferences { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ZoneAllocationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneDistributionStrategy : System.IEquatable<Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneDistributionStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy BestEffortSingleZone { get { throw null; } }
        public static Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy left, Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy left, Azure.ResourceManager.ComputeFleet.Models.ZoneDistributionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ZonePreference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ZonePreference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ZonePreference>
    {
        public ZonePreference(string zone) { }
        public int? Rank { get { throw null; } set { } }
        public string Zone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ZonePreference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ZonePreference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeFleet.Models.ZonePreference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeFleet.Models.ZonePreference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ZonePreference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ZonePreference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeFleet.Models.ZonePreference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
