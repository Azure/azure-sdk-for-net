namespace Azure.ResourceManager.LabServices
{
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LabData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.LabServices.Models.AutoShutdownProfile AutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile ConnectionProfile { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LabPlanId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.RosterProfile RosterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabState? State { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineProfile VirtualMachineProfile { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabPlanData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LabPlanData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> AllowedRegions { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.AutoShutdownProfile DefaultAutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile DefaultConnectionProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefaultNetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri LinkedLmsInstance { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SharedGalleryId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.SupportInfo SupportInfo { get { throw null; } set { } }
    }
    public partial class LabPlanResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation SaveImage(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.SaveImageBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SaveImageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.SaveImageBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabResource : Azure.ResourceManager.ArmResource
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
        public static Azure.Pageable<Azure.ResourceManager.LabServices.Models.LabServicesUsage> GetUsagesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LabServices.Models.LabServicesUsage> GetUsagesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabServicesScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabServicesScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabServicesScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabServicesScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabServicesScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public LabServicesScheduleData() { }
        public string Notes { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern RecurrencePattern { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.DateTimeOffset? StopOn { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
    }
    public partial class LabServicesScheduleResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabUserData : Azure.ResourceManager.Models.ResourceData
    {
        public LabUserData(string email) { }
        public System.TimeSpan? AdditionalUsageQuota { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public string Email { get { throw null; } set { } }
        public System.DateTimeOffset? InvitationSentOn { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.InvitationState? InvitationState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.RegistrationState? RegistrationState { get { throw null; } }
        public System.TimeSpan? TotalUsage { get { throw null; } }
    }
    public partial class LabUserResource : Azure.ResourceManager.ArmResource
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabVirtualMachineData : Azure.ResourceManager.Models.ResourceData
    {
        public LabVirtualMachineData() { }
        public string ClaimedByUserId { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineConnectionProfile ConnectionProfile { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineState? State { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineType? VmType { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabVirtualMachineImageData : Azure.ResourceManager.Models.ResourceData
    {
        public LabVirtualMachineImageData() { }
        public string Author { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> AvailableRegions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.EnableState? EnabledState { get { throw null; } set { } }
        public System.Uri IconUri { get { throw null; } }
        public string Offer { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.OSState? OSState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.OSType? OSType { get { throw null; } }
        public string Plan { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } }
        public Azure.Core.ResourceIdentifier SharedGalleryId { get { throw null; } }
        public string Sku { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.EnableState? TermsStatus { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class LabVirtualMachineImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabVirtualMachineImageResource() { }
        public virtual Azure.ResourceManager.LabServices.LabVirtualMachineImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labPlanName, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource> Update(Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.LabVirtualMachineImageResource>> UpdateAsync(Azure.ResourceManager.LabServices.Models.LabVirtualMachineImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabVirtualMachineResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation ResetPassword(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.ResetPasswordBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetPasswordAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.ResetPasswordBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LabServices.Models
{
    public partial class AutoShutdownProfile
    {
        public AutoShutdownProfile() { }
        public System.TimeSpan? DisconnectDelay { get { throw null; } set { } }
        public System.TimeSpan? IdleDelay { get { throw null; } set { } }
        public System.TimeSpan? NoConnectDelay { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.EnableState? ShutdownOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ShutdownOnIdleMode? ShutdownOnIdle { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.EnableState? ShutdownWhenNotConnected { get { throw null; } set { } }
    }
    public partial class AvailableLabServicesSku
    {
        internal AvailableLabServicesSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuCost> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.AvailableLabServicesSkuTier? Tier { get { throw null; } }
    }
    public partial class AvailableLabServicesSkuCapabilities
    {
        internal AvailableLabServicesSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class AvailableLabServicesSkuCapacity
    {
        internal AvailableLabServicesSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    public partial class AvailableLabServicesSkuCost
    {
        internal AvailableLabServicesSkuCost() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public float? Quantity { get { throw null; } }
    }
    public partial class AvailableLabServicesSkuRestrictions
    {
        internal AvailableLabServicesSkuRestrictions() { }
        public Azure.ResourceManager.LabServices.Models.RestrictionReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.RestrictionType? RestrictionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
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
    public enum ConnectionType
    {
        None = 0,
        Public = 1,
        Private = 2,
    }
    public enum CreateOption
    {
        Image = 0,
        TemplateVm = 1,
    }
    public enum EnableState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum InvitationState
    {
        NotSent = 0,
        Sending = 1,
        Sent = 2,
        Failed = 3,
    }
    public partial class LabNetworkProfile
    {
        public LabNetworkProfile() { }
        public Azure.Core.ResourceIdentifier LoadBalancerId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class LabPatch : Azure.ResourceManager.LabServices.Models.TrackedResourceUpdate
    {
        public LabPatch() { }
        public Azure.ResourceManager.LabServices.Models.AutoShutdownProfile AutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile ConnectionProfile { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LabPlanId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.RosterProfile RosterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineProfile VirtualMachineProfile { get { throw null; } set { } }
    }
    public partial class LabPlanPatch : Azure.ResourceManager.LabServices.Models.TrackedResourceUpdate
    {
        public LabPlanPatch() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> AllowedRegions { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.AutoShutdownProfile DefaultAutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineConnectionProfile DefaultConnectionProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefaultNetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri LinkedLmsInstance { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SharedGalleryId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.SupportInfo SupportInfo { get { throw null; } set { } }
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
    public partial class LabServicesRecurrencePattern
    {
        public LabServicesRecurrencePattern(Azure.ResourceManager.LabServices.Models.RecurrenceFrequency frequency, System.DateTimeOffset expireOn) { }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.LabServices.Models.LabServicesDayOfWeek> WeekDays { get { throw null; } }
    }
    public partial class LabServicesSchedulePatch
    {
        public LabServicesSchedulePatch() { }
        public string Notes { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesRecurrencePattern RecurrencePattern { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.DateTimeOffset? StopOn { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
    }
    public partial class LabServicesSku
    {
        public LabServicesSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabServicesSkuTier? Tier { get { throw null; } set { } }
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
    public enum LabServicesSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class LabServicesUsage
    {
        internal LabServicesUsage() { }
        public long? CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.UsageName Name { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.UsageUnit? Unit { get { throw null; } }
    }
    public enum LabState
    {
        Draft = 0,
        Publishing = 1,
        Scaling = 2,
        Syncing = 3,
        Published = 4,
    }
    public partial class LabUserInviteRequestContent
    {
        public LabUserInviteRequestContent() { }
        public System.BinaryData Text { get { throw null; } set { } }
    }
    public partial class LabUserPatch
    {
        public LabUserPatch() { }
        public System.TimeSpan? AdditionalUsageQuota { get { throw null; } set { } }
    }
    public partial class LabVirtualMachineConnectionProfile
    {
        public LabVirtualMachineConnectionProfile() { }
        public Azure.ResourceManager.LabServices.Models.ConnectionType? ClientRdpAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionType? ClientSshAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionType? WebRdpAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionType? WebSshAccess { get { throw null; } set { } }
    }
    public partial class LabVirtualMachineCredential
    {
        public LabVirtualMachineCredential(string username) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class LabVirtualMachineImagePatch
    {
        public LabVirtualMachineImagePatch() { }
        public Azure.ResourceManager.LabServices.Models.EnableState? EnabledState { get { throw null; } set { } }
    }
    public partial class LabVirtualMachineImageReference
    {
        public LabVirtualMachineImageReference() { }
        public string ExactVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public enum OSState
    {
        Generalized = 0,
        Specialized = 1,
    }
    public enum OSType
    {
        Windows = 0,
        Linux = 1,
    }
    public enum ProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Locked = 5,
    }
    public enum RecurrenceFrequency
    {
        Daily = 0,
        Weekly = 1,
    }
    public enum RegistrationState
    {
        Registered = 0,
        NotRegistered = 1,
    }
    public partial class ResetPasswordBody
    {
        public ResetPasswordBody(string username, string password) { }
        public string Password { get { throw null; } }
        public string Username { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestrictionReasonCode : System.IEquatable<Azure.ResourceManager.LabServices.Models.RestrictionReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestrictionReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.RestrictionReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.LabServices.Models.RestrictionReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.RestrictionReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.RestrictionReasonCode left, Azure.ResourceManager.LabServices.Models.RestrictionReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.RestrictionReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.RestrictionReasonCode left, Azure.ResourceManager.LabServices.Models.RestrictionReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestrictionType : System.IEquatable<Azure.ResourceManager.LabServices.Models.RestrictionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestrictionType(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.RestrictionType Location { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.RestrictionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.RestrictionType left, Azure.ResourceManager.LabServices.Models.RestrictionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.RestrictionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.RestrictionType left, Azure.ResourceManager.LabServices.Models.RestrictionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RosterProfile
    {
        public RosterProfile() { }
        public string ActiveDirectoryGroupId { get { throw null; } set { } }
        public string LmsInstance { get { throw null; } set { } }
        public string LtiClientId { get { throw null; } set { } }
        public string LtiContextId { get { throw null; } set { } }
        public string LtiRosterEndpoint { get { throw null; } set { } }
    }
    public partial class SaveImageBody
    {
        public SaveImageBody() { }
        public Azure.Core.ResourceIdentifier LabVirtualMachineId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class SecurityProfile
    {
        public SecurityProfile() { }
        public Azure.ResourceManager.LabServices.Models.EnableState? OpenAccess { get { throw null; } set { } }
        public string RegistrationCode { get { throw null; } }
    }
    public enum ShutdownOnIdleMode
    {
        None = 0,
        UserAbsence = 1,
        LowUsage = 2,
    }
    public partial class SupportInfo
    {
        public SupportInfo() { }
        public string Email { get { throw null; } set { } }
        public string Instructions { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class TrackedResourceUpdate
    {
        public TrackedResourceUpdate() { }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SkuInstances { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageUnit : System.IEquatable<Azure.ResourceManager.LabServices.Models.UsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.UsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.UsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.UsageUnit left, Azure.ResourceManager.LabServices.Models.UsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.UsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.UsageUnit left, Azure.ResourceManager.LabServices.Models.UsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineConnectionProfile
    {
        internal VirtualMachineConnectionProfile() { }
        public string AdminUsername { get { throw null; } }
        public string NonAdminUsername { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } }
        public string RdpAuthority { get { throw null; } }
        public System.Uri RdpInBrowserUri { get { throw null; } }
        public string SshAuthority { get { throw null; } }
        public System.Uri SshInBrowserUri { get { throw null; } }
    }
    public partial class VirtualMachineProfile
    {
        public VirtualMachineProfile(Azure.ResourceManager.LabServices.Models.CreateOption createOption, Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference imageReference, Azure.ResourceManager.LabServices.Models.LabServicesSku sku, System.TimeSpan usageQuota, Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential adminUser) { }
        public Azure.ResourceManager.LabServices.Models.EnableState? AdditionalCapabilitiesInstallGpuDrivers { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential AdminUser { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.CreateOption CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.LabVirtualMachineCredential NonAdminUser { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.OSType? OSType { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.LabServicesSku Sku { get { throw null; } set { } }
        public System.TimeSpan UsageQuota { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.EnableState? UseSharedPassword { get { throw null; } set { } }
    }
    public enum VirtualMachineState
    {
        Stopped = 0,
        Starting = 1,
        Running = 2,
        Stopping = 3,
        ResettingPassword = 4,
        Reimaging = 5,
        Redeploying = 6,
    }
    public enum VirtualMachineType
    {
        User = 0,
        Template = 1,
    }
}
