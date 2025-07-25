namespace Azure.ResourceManager.LabServices
{
    public partial class AzureResourceManagerLabServicesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerLabServicesContext() { }
        public static Azure.ResourceManager.LabServices.AzureResourceManagerLabServicesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class LabCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabResource>, System.Collections.IEnumerable
    {
        protected LabCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string labName, Azure.ResourceManager.LabServices.LabData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string labName, Azure.ResourceManager.LabServices.LabData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabResource> Get(string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.LabResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabResource>> GetAsync(string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LabServices.LabResource> GetIfExists(string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LabServices.LabResource>> GetIfExistsAsync(string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabData>
    {
        public LabData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile AutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabConnectionProfile ConnectionProfile { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LabPlanId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabRosterProfile RosterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabState? State { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile VirtualMachineProfile { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabPlanResource>, System.Collections.IEnumerable
    {
        protected LabPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string labPlanName, Azure.ResourceManager.LabServices.LabPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string labPlanName, Azure.ResourceManager.LabServices.LabPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabPlanResource> Get(string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.LabPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabPlanResource>> GetAsync(string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LabServices.LabPlanResource> GetIfExists(string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LabServices.LabPlanResource>> GetIfExistsAsync(string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabPlanData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabPlanData>
    {
        public LabPlanData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> AllowedRegions { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile DefaultAutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabConnectionProfile DefaultConnectionProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefaultNetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri LinkedLmsInstance { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SharedGalleryId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo SupportInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabPlanResource() { }
        public virtual Azure.ResourceManager.LabServices.LabPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> GetLabVirtualMachineImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>> GetLabVirtualMachineImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabVirtualMachineImageCollection GetLabVirtualMachineImages() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SaveImage(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SaveImageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LabServices.LabPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabResource() { }
        public virtual Azure.ResourceManager.LabServices.LabData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabServicesScheduleResource> GetLabServicesSchedule(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabServicesScheduleResource>> GetLabServicesScheduleAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabServicesScheduleCollection GetLabServicesSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabUserResource> GetLabUser(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabUserResource>> GetLabUserAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabUserCollection GetLabUsers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineResource> GetLabVirtualMachine(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineResource>> GetLabVirtualMachineAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabVirtualMachineCollection GetLabVirtualMachines() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Publish(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PublishAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SyncGroup(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncGroupAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LabServices.LabData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class LabServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.LabServices.LabResource> GetLab(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabResource>> GetLabAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LabServices.LabPlanResource> GetLabPlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabPlanResource>> GetLabPlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LabServices.LabPlanResource GetLabPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LabServices.LabPlanCollection GetLabPlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LabServices.LabPlanResource> GetLabPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabPlanResource> GetLabPlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LabServices.LabResource GetLabResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LabServices.LabCollection GetLabs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LabServices.LabResource> GetLabs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabResource> GetLabsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LabServices.LabServicesScheduleResource GetLabServicesScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LabServices.LabUserResource GetLabUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LabServices.LabVirtualMachineImageResource GetLabVirtualMachineImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LabServices.LabVirtualMachineResource GetLabVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LabServices.Models.LabServicesUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LabServices.Models.LabServicesUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabServicesScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabServicesScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabServicesScheduleResource>, System.Collections.IEnumerable
    {
        protected LabServicesScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabServicesScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.LabServices.LabServicesScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabServicesScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.LabServices.LabServicesScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabServicesScheduleResource> Get(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.LabServicesScheduleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabServicesScheduleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabServicesScheduleResource>> GetAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LabServices.LabServicesScheduleResource> GetIfExists(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LabServices.LabServicesScheduleResource>> GetIfExistsAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabServicesScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabServicesScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabServicesScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabServicesScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabServicesScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>
    {
        public LabServicesScheduleData() { }
        public System.BinaryData Notes { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern RecurrencePattern { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.DateTimeOffset? StopOn { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabServicesScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabServicesScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabServicesScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabServicesScheduleResource() { }
        public virtual Azure.ResourceManager.LabServices.LabServicesScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string scheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabServicesScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabServicesScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LabServices.LabServicesScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabServicesScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabServicesScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabServicesScheduleResource> Update(Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabServicesScheduleResource>> UpdateAsync(Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabUserResource>, System.Collections.IEnumerable
    {
        protected LabUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string userName, Azure.ResourceManager.LabServices.LabUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string userName, Azure.ResourceManager.LabServices.LabUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabUserResource> Get(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.LabUserResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabUserResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabUserResource>> GetAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LabServices.LabUserResource> GetIfExists(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LabServices.LabUserResource>> GetIfExistsAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabUserData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabUserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabUserData>
    {
        public LabUserData(string email) { }
        public System.TimeSpan? AdditionalUsageQuota { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public string Email { get { throw null; } set { } }
        public System.DateTimeOffset? InvitationSentOn { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabUserInvitationState? InvitationState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabUserRegistrationState? RegistrationState { get { throw null; } }
        public System.TimeSpan? TotalUsage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabUserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabUserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabUserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabUserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabUserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabUserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabUserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabUserResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabUserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabUserData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabUserResource() { }
        public virtual Azure.ResourceManager.LabServices.LabUserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabUserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabUserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Invite(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InviteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LabServices.LabUserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabUserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabUserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabUserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabUserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabUserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabUserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabUserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabUserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected LabVirtualMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineResource> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.LabVirtualMachineResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabVirtualMachineResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineResource>> GetAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LabServices.LabVirtualMachineResource> GetIfExists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LabServices.LabVirtualMachineResource>> GetIfExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabVirtualMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>
    {
        public LabVirtualMachineData() { }
        public string ClaimedByUserId { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile ConnectionProfile { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineState? State { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineType? VmType { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabVirtualMachineImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>, System.Collections.IEnumerable
    {
        protected LabVirtualMachineImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.LabServices.LabVirtualMachineImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.LabServices.LabVirtualMachineImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> GetIfExists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>> GetIfExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabVirtualMachineImageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>
    {
        public LabVirtualMachineImageData() { }
        public string Author { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> AvailableRegions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesEnableState? EnabledState { get { throw null; } set { } }
        public System.Uri IconUri { get { throw null; } }
        public string Offer { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSState? OSState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSType? OSType { get { throw null; } }
        public string Plan { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } }
        public Azure.Core.ResourceIdentifier SharedGalleryId { get { throw null; } }
        public string Sku { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesEnableState? TermsStatus { get { throw null; } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabVirtualMachineImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabVirtualMachineImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabVirtualMachineImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabVirtualMachineImageResource() { }
        public virtual Azure.ResourceManager.LabServices.LabVirtualMachineImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labPlanName, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LabServices.LabVirtualMachineImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabVirtualMachineImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> Update(Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>> UpdateAsync(Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabVirtualMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabVirtualMachineResource() { }
        public virtual Azure.ResourceManager.LabServices.LabVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string virtualMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResetPassword(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetPasswordAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LabServices.LabVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.LabVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.LabVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.LabServices.Mocking
{
    public partial class MockableLabServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableLabServicesArmClient() { }
        public virtual Azure.ResourceManager.LabServices.LabPlanResource GetLabPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabResource GetLabResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabServicesScheduleResource GetLabServicesScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabUserResource GetLabUserResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabVirtualMachineImageResource GetLabVirtualMachineImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabVirtualMachineResource GetLabVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableLabServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLabServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabResource> GetLab(string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabResource>> GetLabAsync(string labName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabPlanResource> GetLabPlan(string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabPlanResource>> GetLabPlanAsync(string labPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabPlanCollection GetLabPlans() { throw null; }
        public virtual Azure.ResourceManager.LabServices.LabCollection GetLabs() { throw null; }
    }
    public partial class MockableLabServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLabServicesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.LabPlanResource> GetLabPlans(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabPlanResource> GetLabPlansAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.LabResource> GetLabs(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.LabResource> GetLabsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku> GetSkus(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku> GetSkusAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.Models.LabServicesUsage> GetUsages(Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.Models.LabServicesUsage> GetUsagesAsync(Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LabServices.Models
{
    public static partial class ArmLabServicesModelFactory
    {
        public static Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku AvailableLabServicesSku(string resourceType = null, string name = null, Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier? tier = default(Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier?), string size = null, string family = null, Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity capacity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability> capabilities = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost> costs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability AvailableLabServicesSkuCapability(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity AvailableLabServicesSkuCapacity(long? @default = default(long?), long? minimum = default(long?), long? maximum = default(long?), Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType? scaleType = default(Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType?)) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost AvailableLabServicesSkuCost(string meterId = null, float? quantity = default(float?), string extendedUnit = null) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions AvailableLabServicesSkuRestrictions(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType? labServicesSkuRestrictionType = default(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode? reasonCode = default(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode?)) { throw null; }
        public static Azure.ResourceManager.LabServices.LabData LabData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile autoShutdownProfile = null, Azure.ResourceManager.LabServices.Models.LabConnectionProfile connectionProfile = null, Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile virtualMachineProfile = null, Azure.ResourceManager.LabServices.Models.LabSecurityProfile securityProfile = null, Azure.ResourceManager.LabServices.Models.LabRosterProfile rosterProfile = null, Azure.Core.ResourceIdentifier labPlanId = null, string title = null, string description = null, Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? provisioningState = default(Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState?), Azure.ResourceManager.LabServices.Models.LabNetworkProfile networkProfile = null, Azure.ResourceManager.LabServices.Models.LabState? state = default(Azure.ResourceManager.LabServices.Models.LabState?)) { throw null; }
        public static Azure.ResourceManager.LabServices.LabPlanData LabPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.LabServices.Models.LabConnectionProfile defaultConnectionProfile = null, Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile defaultAutoShutdownProfile = null, Azure.Core.ResourceIdentifier defaultNetworkSubnetId = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> allowedRegions = null, Azure.Core.ResourceIdentifier sharedGalleryId = null, Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo supportInfo = null, System.Uri linkedLmsInstance = null, Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? provisioningState = default(Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabSecurityProfile LabSecurityProfile(string registrationCode = null, Azure.ResourceManager.LabServices.Models.LabServicesEnableState? openAccess = default(Azure.ResourceManager.LabServices.Models.LabServicesEnableState?)) { throw null; }
        public static Azure.ResourceManager.LabServices.LabServicesScheduleData LabServicesScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? stopOn = default(System.DateTimeOffset?), Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern recurrencePattern = null, string timeZoneId = null, System.BinaryData notes = null, Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? provisioningState = default(Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabServicesUsage LabServicesUsage(long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit? unit = default(Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit?), Azure.ResourceManager.LabServices.Models.LabServicesUsageName name = null, Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabServicesUsageName LabServicesUsageName(string localizedValue = null, System.Collections.Generic.IEnumerable<string> skuInstances = null, string value = null) { throw null; }
        public static Azure.ResourceManager.LabServices.LabUserData LabUserData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.TimeSpan? additionalUsageQuota = default(System.TimeSpan?), Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? provisioningState = default(Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState?), string displayName = null, string email = null, Azure.ResourceManager.LabServices.Models.LabUserRegistrationState? registrationState = default(Azure.ResourceManager.LabServices.Models.LabUserRegistrationState?), Azure.ResourceManager.LabServices.Models.LabUserInvitationState? invitationState = default(Azure.ResourceManager.LabServices.Models.LabUserInvitationState?), System.DateTimeOffset? invitationSentOn = default(System.DateTimeOffset?), System.TimeSpan? totalUsage = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile LabVirtualMachineConnectionProfile(System.Net.IPAddress privateIPAddress = null, string sshAuthority = null, System.Uri sshInBrowserUri = null, string rdpAuthority = null, System.Uri rdpInBrowserUri = null, string adminUsername = null, string nonAdminUsername = null) { throw null; }
        public static Azure.ResourceManager.LabServices.LabVirtualMachineData LabVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? provisioningState = default(Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState?), Azure.ResourceManager.LabServices.Models.LabVirtualMachineState? state = default(Azure.ResourceManager.LabServices.Models.LabVirtualMachineState?), Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile connectionProfile = null, string claimedByUserId = null, Azure.ResourceManager.LabServices.Models.LabVirtualMachineType? vmType = default(Azure.ResourceManager.LabServices.Models.LabVirtualMachineType?)) { throw null; }
        public static Azure.ResourceManager.LabServices.LabVirtualMachineImageData LabVirtualMachineImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.LabServices.Models.LabServicesEnableState? enabledState = default(Azure.ResourceManager.LabServices.Models.LabServicesEnableState?), Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState? provisioningState = default(Azure.ResourceManager.LabServices.Models.LabServicesProvisioningState?), string displayName = null, string description = null, System.Uri iconUri = null, string author = null, Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSType? osType = default(Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSType?), string plan = null, Azure.ResourceManager.LabServices.Models.LabServicesEnableState? termsStatus = default(Azure.ResourceManager.LabServices.Models.LabServicesEnableState?), string offer = null, string publisher = null, string sku = null, string version = null, Azure.Core.ResourceIdentifier sharedGalleryId = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> availableRegions = null, Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSState? osState = default(Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSState?)) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference LabVirtualMachineImageReference(Azure.Core.ResourceIdentifier id = null, string offer = null, string publisher = null, string sku = null, string version = null, string exactVersion = null) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile LabVirtualMachineProfile(Azure.ResourceManager.LabServices.Models.LabVirtualMachineCreateOption createOption = Azure.ResourceManager.LabServices.Models.LabVirtualMachineCreateOption.Image, Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference imageReference = null, Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSType? osType = default(Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSType?), Azure.ResourceManager.LabServices.Models.LabServicesSku sku = null, Azure.ResourceManager.LabServices.Models.LabServicesEnableState? additionalCapabilitiesInstallGpuDrivers = default(Azure.ResourceManager.LabServices.Models.LabServicesEnableState?), System.TimeSpan usageQuota = default(System.TimeSpan), Azure.ResourceManager.LabServices.Models.LabServicesEnableState? useSharedPassword = default(Azure.ResourceManager.LabServices.Models.LabServicesEnableState?), Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential adminUser = null, Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential nonAdminUser = null) { throw null; }
    }
    public partial class AvailableLabServicesSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku>
    {
        internal AvailableLabServicesSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier? Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableLabServicesSkuCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability>
    {
        internal AvailableLabServicesSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableLabServicesSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity>
    {
        internal AvailableLabServicesSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType? ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableLabServicesSkuCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost>
    {
        internal AvailableLabServicesSkuCost() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public float? Quantity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableLabServicesSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions>
    {
        internal AvailableLabServicesSkuRestrictions() { }
        public Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType? LabServicesSkuRestrictionType { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode? ReasonCode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailableLabServicesSkuTier : System.IEquatable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailableLabServicesSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier left, Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier left, Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LabAutoShutdownProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile>
    {
        public LabAutoShutdownProfile() { }
        public System.TimeSpan? DisconnectDelay { get { throw null; } set { } }
        public System.TimeSpan? IdleDelay { get { throw null; } set { } }
        public System.TimeSpan? NoConnectDelay { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesEnableState? ShutdownOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineShutdownOnIdleMode? ShutdownOnIdle { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesEnableState? ShutdownWhenNotConnected { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabConnectionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabConnectionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabConnectionProfile>
    {
        public LabConnectionProfile() { }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionType? ClientRdpAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionType? ClientSshAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionType? WebRdpAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionType? WebSshAccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabConnectionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabConnectionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabConnectionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabConnectionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabConnectionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabConnectionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabConnectionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabNetworkProfile>
    {
        public LabNetworkProfile() { }
        public Azure.Core.ResourceIdentifier LoadBalancerId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabPatch : Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPatch>
    {
        public LabPatch() { }
        public Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile AutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabConnectionProfile ConnectionProfile { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LabPlanId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabRosterProfile RosterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabSecurityProfile SecurityProfile { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile VirtualMachineProfile { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabPlanPatch : Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPlanPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPlanPatch>
    {
        public LabPlanPatch() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> AllowedRegions { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabAutoShutdownProfile DefaultAutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabConnectionProfile DefaultConnectionProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefaultNetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri LinkedLmsInstance { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SharedGalleryId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo SupportInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabPlanPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPlanPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPlanPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabPlanPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPlanPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPlanPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPlanPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabPlanSupportInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo>
    {
        public LabPlanSupportInfo() { }
        public string Email { get { throw null; } set { } }
        public string Instructions { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabPlanSupportInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabRosterProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabRosterProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabRosterProfile>
    {
        public LabRosterProfile() { }
        public string ActiveDirectoryGroupId { get { throw null; } set { } }
        public System.Uri LmsInstance { get { throw null; } set { } }
        public string LtiClientId { get { throw null; } set { } }
        public string LtiContextId { get { throw null; } set { } }
        public System.Uri LtiRosterEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabRosterProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabRosterProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabRosterProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabRosterProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabRosterProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabRosterProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabRosterProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabSecurityProfile>
    {
        public LabSecurityProfile() { }
        public Azure.ResourceManager.LabServices.Models.LabServicesEnableState? OpenAccess { get { throw null; } set { } }
        public string RegistrationCode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LabServicesDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public enum LabServicesEnableState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class LabServicesPatchBaseInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo>
    {
        public LabServicesPatchBaseInfo() { }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesPatchBaseInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LabServicesProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Locked = 5,
    }
    public enum LabServicesRecurrenceFrequency
    {
        Daily = 0,
        Weekly = 1,
    }
    public partial class LabServicesRecurrencePattern : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern>
    {
        public LabServicesRecurrencePattern(Azure.ResourceManager.LabServices.Models.LabServicesRecurrenceFrequency frequency, System.DateTimeOffset expireOn) { }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesRecurrenceFrequency Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.LabServices.Models.LabServicesDayOfWeek> WeekDays { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabServicesSchedulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch>
    {
        public LabServicesSchedulePatch() { }
        public System.BinaryData Notes { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern RecurrencePattern { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.DateTimeOffset? StopOn { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesSchedulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabServicesSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesSku>
    {
        public LabServicesSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabServicesSkuCapacityScaleType : System.IEquatable<Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabServicesSkuCapacityScaleType(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType left, Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType left, Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabServicesSkuRestrictionReasonCode : System.IEquatable<Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabServicesSkuRestrictionReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode left, Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode left, Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabServicesSkuRestrictionType : System.IEquatable<Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabServicesSkuRestrictionType(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType Location { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType left, Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType left, Azure.ResourceManager.LabServices.Models.LabServicesSkuRestrictionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum LabServicesSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class LabServicesUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesUsage>
    {
        internal LabServicesUsage() { }
        public long? CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesUsageName Name { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabServicesUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesUsageName>
    {
        internal LabServicesUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SkuInstances { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabServicesUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabServicesUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabServicesUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabServicesUsageUnit : System.IEquatable<Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabServicesUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit left, Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit left, Azure.ResourceManager.LabServices.Models.LabServicesUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum LabState
    {
        Draft = 0,
        Publishing = 1,
        Scaling = 2,
        Syncing = 3,
        Published = 4,
    }
    public enum LabUserInvitationState
    {
        NotSent = 0,
        Sending = 1,
        Sent = 2,
        Failed = 3,
    }
    public partial class LabUserInviteRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent>
    {
        public LabUserInviteRequestContent() { }
        public System.BinaryData Text { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabUserInviteRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabUserPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabUserPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabUserPatch>
    {
        public LabUserPatch() { }
        public System.TimeSpan? AdditionalUsageQuota { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabUserPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabUserPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabUserPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabUserPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabUserPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabUserPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabUserPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LabUserRegistrationState
    {
        Registered = 0,
        NotRegistered = 1,
    }
    public partial class LabVirtualMachineConnectionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile>
    {
        internal LabVirtualMachineConnectionProfile() { }
        public string AdminUsername { get { throw null; } }
        public string NonAdminUsername { get { throw null; } }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } }
        public string RdpAuthority { get { throw null; } }
        public System.Uri RdpInBrowserUri { get { throw null; } }
        public string SshAuthority { get { throw null; } }
        public System.Uri SshInBrowserUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LabVirtualMachineConnectionType
    {
        None = 0,
        Public = 1,
        Private = 2,
    }
    public enum LabVirtualMachineCreateOption
    {
        Image = 0,
        TemplateVm = 1,
    }
    public partial class LabVirtualMachineCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential>
    {
        public LabVirtualMachineCredential(string username) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabVirtualMachineImageContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent>
    {
        public LabVirtualMachineImageContent() { }
        public Azure.Core.ResourceIdentifier LabVirtualMachineId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LabVirtualMachineImageOSState
    {
        Generalized = 0,
        Specialized = 1,
    }
    public enum LabVirtualMachineImageOSType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class LabVirtualMachineImagePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch>
    {
        public LabVirtualMachineImagePatch() { }
        public Azure.ResourceManager.LabServices.Models.LabServicesEnableState? EnabledState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabVirtualMachineImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference>
    {
        public LabVirtualMachineImageReference() { }
        public string ExactVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabVirtualMachineProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile>
    {
        public LabVirtualMachineProfile(Azure.ResourceManager.LabServices.Models.LabVirtualMachineCreateOption createOption, Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference imageReference, Azure.ResourceManager.LabServices.Models.LabServicesSku sku, System.TimeSpan usageQuota, Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential adminUser) { }
        public Azure.ResourceManager.LabServices.Models.LabServicesEnableState? AdditionalCapabilitiesInstallGpuDrivers { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential AdminUser { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineCreateOption CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential NonAdminUser { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageOSType? OSType { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesSku Sku { get { throw null; } set { } }
        public System.TimeSpan UsageQuota { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesEnableState? UseSharedPassword { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabVirtualMachineResetPasswordContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent>
    {
        public LabVirtualMachineResetPasswordContent(string username, string password) { }
        public string Password { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LabServices.Models.LabVirtualMachineResetPasswordContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LabVirtualMachineShutdownOnIdleMode
    {
        None = 0,
        UserAbsence = 1,
        LowUsage = 2,
    }
    public enum LabVirtualMachineState
    {
        Stopped = 0,
        Starting = 1,
        Running = 2,
        Stopping = 3,
        ResettingPassword = 4,
        Reimaging = 5,
        Redeploying = 6,
    }
    public enum LabVirtualMachineType
    {
        User = 0,
        Template = 1,
    }
}
