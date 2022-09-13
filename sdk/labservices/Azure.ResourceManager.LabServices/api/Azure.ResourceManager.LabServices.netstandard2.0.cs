namespace Azure.ResourceManager.LabServices
{
    public partial class ImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.ImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.ImageResource>, System.Collections.IEnumerable
    {
        protected ImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.ImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.LabServices.ImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.ImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.LabServices.ImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.ImageResource> Get(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.ImageResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.ImageResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.ImageResource>> GetAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.ImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.ImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.ImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.ImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageData : Azure.ResourceManager.Models.ResourceData
    {
        public ImageData() { }
        public string Author { get { throw null; } }
        public System.Collections.Generic.IList<string> AvailableRegions { get { throw null; } }
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
        public string SharedGalleryId { get { throw null; } }
        public string Sku { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.EnableState? TermsStatus { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageResource() { }
        public virtual Azure.ResourceManager.LabServices.ImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labPlanName, string imageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.ImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.ImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.ImageResource> Update(Azure.ResourceManager.LabServices.Models.ImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.ImageResource>> UpdateAsync(Azure.ResourceManager.LabServices.Models.ImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.LabResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.LabResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.LabResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.LabResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LabData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.LabServices.Models.AutoShutdownProfile AutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionProfile ConnectionProfile { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string LabPlanId { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<string> AllowedRegions { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.AutoShutdownProfile DefaultAutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionProfile DefaultConnectionProfile { get { throw null; } set { } }
        public string DefaultNetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LinkedLmsInstance { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SharedGalleryId { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.LabServices.ImageResource> GetImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.ImageResource>> GetImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.ImageCollection GetImages() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.LabServices.ScheduleResource> GetSchedule(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.ScheduleResource>> GetScheduleAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.ScheduleCollection GetSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.UserResource> GetUser(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.UserResource>> GetUserAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.UserCollection GetUsers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.VirtualMachineResource> GetVirtualMachine(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.VirtualMachineResource>> GetVirtualMachineAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LabServices.VirtualMachineCollection GetVirtualMachines() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Publish(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PublishAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SyncGroup(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SyncGroupAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.LabResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.LabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class LabServicesExtensions
    {
        public static Azure.ResourceManager.LabServices.ImageResource GetImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.LabServices.Models.OperationResult> GetOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.Models.OperationResult>> GetOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LabServices.ScheduleResource GetScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LabServices.Models.AvailableLabServicesSku> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LabServices.Models.LabServicesUsage> GetUsagesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LabServices.Models.LabServicesUsage> GetUsagesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LabServices.UserResource GetUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LabServices.VirtualMachineResource GetVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.ScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.ScheduleResource>, System.Collections.IEnumerable
    {
        protected ScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.ScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.LabServices.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.ScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.LabServices.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.ScheduleResource> Get(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.ScheduleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.ScheduleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.ScheduleResource>> GetAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.ScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.ScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.ScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.ScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public ScheduleData() { }
        public string Notes { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.RecurrencePattern RecurrencePattern { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.DateTimeOffset? StopOn { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
    }
    public partial class ScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduleResource() { }
        public virtual Azure.ResourceManager.LabServices.ScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string scheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.ScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.ScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.ScheduleResource> Update(Azure.ResourceManager.LabServices.Models.SchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.ScheduleResource>> UpdateAsync(Azure.ResourceManager.LabServices.Models.SchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.UserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.UserResource>, System.Collections.IEnumerable
    {
        protected UserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.UserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string userName, Azure.ResourceManager.LabServices.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.UserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string userName, Azure.ResourceManager.LabServices.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.UserResource> Get(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.UserResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.UserResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.UserResource>> GetAsync(string userName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.UserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.UserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.UserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.UserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserData : Azure.ResourceManager.Models.ResourceData
    {
        public UserData(string email) { }
        public System.TimeSpan? AdditionalUsageQuota { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public string Email { get { throw null; } set { } }
        public System.DateTimeOffset? InvitationSent { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.InvitationState? InvitationState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.RegistrationState? RegistrationState { get { throw null; } }
        public System.TimeSpan? TotalUsage { get { throw null; } }
    }
    public partial class UserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserResource() { }
        public virtual Azure.ResourceManager.LabServices.UserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.UserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.UserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Invite(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.InviteBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InviteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.InviteBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.UserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.UserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LabServices.UserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LabServices.Models.UserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.VirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.VirtualMachineResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.VirtualMachineResource> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LabServices.VirtualMachineResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LabServices.VirtualMachineResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.VirtualMachineResource>> GetAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LabServices.VirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LabServices.VirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LabServices.VirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LabServices.VirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualMachineData() { }
        public string ClaimedByUserId { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineConnectionProfile ConnectionProfile { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineState? State { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineType? VmType { get { throw null; } }
    }
    public partial class VirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineResource() { }
        public virtual Azure.ResourceManager.LabServices.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string virtualMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LabServices.VirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LabServices.VirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
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
        public Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType? ScaleType { get { throw null; } }
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
    public partial class ConnectionProfile
    {
        public ConnectionProfile() { }
        public Azure.ResourceManager.LabServices.Models.ConnectionType? ClientRdpAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionType? ClientSshAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionType? WebRdpAccess { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionType? WebSshAccess { get { throw null; } set { } }
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
    public partial class Credentials
    {
        public Credentials(string username) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public enum EnableState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ImagePatch
    {
        public ImagePatch() { }
        public Azure.ResourceManager.LabServices.Models.EnableState? EnabledState { get { throw null; } set { } }
    }
    public partial class ImageReference
    {
        public ImageReference() { }
        public string ExactVersion { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public enum InvitationState
    {
        NotSent = 0,
        Sending = 1,
        Sent = 2,
        Failed = 3,
    }
    public partial class InviteBody
    {
        public InviteBody() { }
        public string Text { get { throw null; } set { } }
    }
    public partial class LabNetworkProfile
    {
        public LabNetworkProfile() { }
        public string LoadBalancerId { get { throw null; } set { } }
        public string PublicIPId { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class LabPatch : Azure.ResourceManager.LabServices.Models.TrackedResourceUpdate
    {
        public LabPatch() { }
        public Azure.ResourceManager.LabServices.Models.AutoShutdownProfile AutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionProfile ConnectionProfile { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string LabPlanId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.RosterProfile RosterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.VirtualMachineProfile VirtualMachineProfile { get { throw null; } set { } }
    }
    public partial class LabPlanPatch : Azure.ResourceManager.LabServices.Models.TrackedResourceUpdate
    {
        public LabPlanPatch() { }
        public System.Collections.Generic.IList<string> AllowedRegions { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.AutoShutdownProfile DefaultAutoShutdownProfile { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ConnectionProfile DefaultConnectionProfile { get { throw null; } set { } }
        public string DefaultNetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LinkedLmsInstance { get { throw null; } set { } }
        public string SharedGalleryId { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.SupportInfo SupportInfo { get { throw null; } set { } }
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
        public string Id { get { throw null; } }
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
    public partial class OperationResult
    {
        internal OperationResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.LabServices.Models.OperationStatus Status { get { throw null; } }
    }
    public enum OperationStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
        Canceled = 4,
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
    public partial class RecurrencePattern
    {
        public RecurrencePattern(Azure.ResourceManager.LabServices.Models.RecurrenceFrequency frequency, System.DateTimeOffset expireOn) { }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.RecurrenceFrequency Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.LabServices.Models.WeekDay> WeekDays { get { throw null; } }
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
        public string LabVirtualMachineId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class SchedulePatch
    {
        public SchedulePatch() { }
        public string Notes { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.RecurrencePattern RecurrencePattern { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.DateTimeOffset? StopOn { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuCapacityScaleType : System.IEquatable<Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuCapacityScaleType(string value) { throw null; }
        public static Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType left, Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType left, Azure.ResourceManager.LabServices.Models.SkuCapacityScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportInfo
    {
        public SupportInfo() { }
        public string Email { get { throw null; } set { } }
        public string Instructions { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
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
    public partial class UserPatch
    {
        public UserPatch() { }
        public System.TimeSpan? AdditionalUsageQuota { get { throw null; } set { } }
    }
    public partial class VirtualMachineConnectionProfile
    {
        internal VirtualMachineConnectionProfile() { }
        public string AdminUsername { get { throw null; } }
        public string NonAdminUsername { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } }
        public string RdpAuthority { get { throw null; } }
        public string RdpInBrowserUri { get { throw null; } }
        public string SshAuthority { get { throw null; } }
        public string SshInBrowserUri { get { throw null; } }
    }
    public partial class VirtualMachineProfile
    {
        public VirtualMachineProfile(Azure.ResourceManager.LabServices.Models.CreateOption createOption, Azure.ResourceManager.LabServices.Models.ImageReference imageReference, Azure.ResourceManager.LabServices.Models.LabServicesSku sku, System.TimeSpan usageQuota, Azure.ResourceManager.LabServices.Models.Credentials adminUser) { }
        public Azure.ResourceManager.LabServices.Models.EnableState? AdditionalCapabilitiesInstallGpuDrivers { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.Credentials AdminUser { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.CreateOption CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.LabServices.Models.Credentials NonAdminUser { get { throw null; } set { } }
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
    public enum WeekDay
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
}
