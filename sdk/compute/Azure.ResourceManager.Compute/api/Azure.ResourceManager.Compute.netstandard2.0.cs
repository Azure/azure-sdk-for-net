namespace Azure.ResourceManager.Compute
{
    public partial class AvailabilitySetsClient
    {
        protected AvailabilitySetsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.AvailabilitySet> CreateOrUpdate(string resourceGroupName, string availabilitySetName, Azure.ResourceManager.Compute.Models.AvailabilitySet parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.AvailabilitySet>> CreateOrUpdateAsync(string resourceGroupName, string availabilitySetName, Azure.ResourceManager.Compute.Models.AvailabilitySet parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.AvailabilitySet> Get(string resourceGroupName, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.AvailabilitySet>> GetAsync(string resourceGroupName, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.AvailabilitySet> List(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.AvailabilitySet> ListAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> ListAvailableSizes(string resourceGroupName, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> ListAvailableSizesAsync(string resourceGroupName, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.AvailabilitySet> ListBySubscription(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.AvailabilitySet> ListBySubscriptionAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.AvailabilitySet> Update(string resourceGroupName, string availabilitySetName, Azure.ResourceManager.Compute.Models.AvailabilitySetUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.AvailabilitySet>> UpdateAsync(string resourceGroupName, string availabilitySetName, Azure.ResourceManager.Compute.Models.AvailabilitySetUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputeManagementClient
    {
        protected ComputeManagementClient() { }
        public ComputeManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Compute.ComputeManagementClientOptions options = null) { }
        public ComputeManagementClient(System.Uri endpoint, string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.Compute.ComputeManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.Compute.AvailabilitySetsClient GetAvailabilitySetsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.ContainerServicesClient GetContainerServicesClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostGroupsClient GetDedicatedHostGroupsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostsClient GetDedicatedHostsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.DiskEncryptionSetsClient GetDiskEncryptionSetsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.DisksClient GetDisksClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleriesClient GetGalleriesClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationsClient GetGalleryApplicationsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationVersionsClient GetGalleryApplicationVersionsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImagesClient GetGalleryImagesClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImageVersionsClient GetGalleryImageVersionsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.ImagesClient GetImagesClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.LogAnalyticsClient GetLogAnalyticsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.OperationsClient GetOperationsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.ProximityPlacementGroupsClient GetProximityPlacementGroupsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.ResourceSkusClient GetResourceSkusClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.SnapshotsClient GetSnapshotsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.SshPublicKeysClient GetSshPublicKeysClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.UsageClient GetUsageClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionImagesClient GetVirtualMachineExtensionImagesClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionsClient GetVirtualMachineExtensionsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineImagesClient GetVirtualMachineImagesClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandsClient GetVirtualMachineRunCommandsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionsClient GetVirtualMachineScaleSetExtensionsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradesClient GetVirtualMachineScaleSetRollingUpgradesClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsClient GetVirtualMachineScaleSetsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMExtensionsClient GetVirtualMachineScaleSetVMExtensionsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsClient GetVirtualMachineScaleSetVMsClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesClient GetVirtualMachinesClient() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineSizesClient GetVirtualMachineSizesClient() { throw null; }
    }
    public partial class ComputeManagementClientOptions : Azure.Core.ClientOptions
    {
        public ComputeManagementClientOptions() { }
    }
    public partial class ContainerServicesClient
    {
        protected ContainerServicesClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.ContainerService> Get(string resourceGroupName, string containerServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.ContainerService>> GetAsync(string resourceGroupName, string containerServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.ContainerService> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ContainerService> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.ContainerService> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ContainerService> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.ContainerServicesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string containerServiceName, Azure.ResourceManager.Compute.Models.ContainerService parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.ContainerServicesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string containerServiceName, Azure.ResourceManager.Compute.Models.ContainerService parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.ContainerServicesDeleteOperation StartDelete(string resourceGroupName, string containerServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.ContainerServicesDeleteOperation> StartDeleteAsync(string resourceGroupName, string containerServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServicesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.ContainerService>
    {
        internal ContainerServicesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.ContainerService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.ContainerService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.ContainerService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServicesDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal ContainerServicesDeleteOperation() { }
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
    public partial class DedicatedHostGroupsClient
    {
        protected DedicatedHostGroupsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHostGroup> CreateOrUpdate(string resourceGroupName, string hostGroupName, Azure.ResourceManager.Compute.Models.DedicatedHostGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHostGroup>> CreateOrUpdateAsync(string resourceGroupName, string hostGroupName, Azure.ResourceManager.Compute.Models.DedicatedHostGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string hostGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string hostGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHostGroup> Get(string resourceGroupName, string hostGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHostGroup>> GetAsync(string resourceGroupName, string hostGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.DedicatedHostGroup> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.DedicatedHostGroup> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.DedicatedHostGroup> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.DedicatedHostGroup> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHostGroup> Update(string resourceGroupName, string hostGroupName, Azure.ResourceManager.Compute.Models.DedicatedHostGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHostGroup>> UpdateAsync(string resourceGroupName, string hostGroupName, Azure.ResourceManager.Compute.Models.DedicatedHostGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostsClient
    {
        protected DedicatedHostsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHost> Get(string resourceGroupName, string hostGroupName, string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHost>> GetAsync(string resourceGroupName, string hostGroupName, string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.DedicatedHost> ListByHostGroup(string resourceGroupName, string hostGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.DedicatedHost> ListByHostGroupAsync(string resourceGroupName, string hostGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string hostGroupName, string hostName, Azure.ResourceManager.Compute.Models.DedicatedHost parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DedicatedHostsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string hostGroupName, string hostName, Azure.ResourceManager.Compute.Models.DedicatedHost parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostsDeleteOperation StartDelete(string resourceGroupName, string hostGroupName, string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DedicatedHostsDeleteOperation> StartDeleteAsync(string resourceGroupName, string hostGroupName, string hostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostsUpdateOperation StartUpdate(string resourceGroupName, string hostGroupName, string hostName, Azure.ResourceManager.Compute.Models.DedicatedHostUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DedicatedHostsUpdateOperation> StartUpdateAsync(string resourceGroupName, string hostGroupName, string hostName, Azure.ResourceManager.Compute.Models.DedicatedHostUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.DedicatedHost>
    {
        internal DedicatedHostsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.DedicatedHost Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHost>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHost>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal DedicatedHostsDeleteOperation() { }
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
    public partial class DedicatedHostsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.DedicatedHost>
    {
        internal DedicatedHostsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.DedicatedHost Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHost>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.DedicatedHost>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskEncryptionSetsClient
    {
        protected DiskEncryptionSetsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.DiskEncryptionSet> Get(string resourceGroupName, string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.DiskEncryptionSet>> GetAsync(string resourceGroupName, string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.DiskEncryptionSet> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.DiskEncryptionSet> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.DiskEncryptionSet> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.DiskEncryptionSet> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DiskEncryptionSetsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string diskEncryptionSetName, Azure.ResourceManager.Compute.Models.DiskEncryptionSet diskEncryptionSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DiskEncryptionSetsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string diskEncryptionSetName, Azure.ResourceManager.Compute.Models.DiskEncryptionSet diskEncryptionSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DiskEncryptionSetsDeleteOperation StartDelete(string resourceGroupName, string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DiskEncryptionSetsDeleteOperation> StartDeleteAsync(string resourceGroupName, string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DiskEncryptionSetsUpdateOperation StartUpdate(string resourceGroupName, string diskEncryptionSetName, Azure.ResourceManager.Compute.Models.DiskEncryptionSetUpdate diskEncryptionSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DiskEncryptionSetsUpdateOperation> StartUpdateAsync(string resourceGroupName, string diskEncryptionSetName, Azure.ResourceManager.Compute.Models.DiskEncryptionSetUpdate diskEncryptionSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskEncryptionSetsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.DiskEncryptionSet>
    {
        internal DiskEncryptionSetsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.DiskEncryptionSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.DiskEncryptionSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.DiskEncryptionSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskEncryptionSetsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal DiskEncryptionSetsDeleteOperation() { }
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
    public partial class DiskEncryptionSetsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.DiskEncryptionSet>
    {
        internal DiskEncryptionSetsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.DiskEncryptionSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.DiskEncryptionSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.DiskEncryptionSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisksClient
    {
        protected DisksClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.Disk> Get(string resourceGroupName, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.Disk>> GetAsync(string resourceGroupName, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Disk> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Disk> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Disk> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Disk> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DisksCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string diskName, Azure.ResourceManager.Compute.Models.Disk disk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DisksCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string diskName, Azure.ResourceManager.Compute.Models.Disk disk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DisksDeleteOperation StartDelete(string resourceGroupName, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DisksDeleteOperation> StartDeleteAsync(string resourceGroupName, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DisksGrantAccessOperation StartGrantAccess(string resourceGroupName, string diskName, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DisksGrantAccessOperation> StartGrantAccessAsync(string resourceGroupName, string diskName, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DisksRevokeAccessOperation StartRevokeAccess(string resourceGroupName, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DisksRevokeAccessOperation> StartRevokeAccessAsync(string resourceGroupName, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DisksUpdateOperation StartUpdate(string resourceGroupName, string diskName, Azure.ResourceManager.Compute.Models.DiskUpdate disk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.DisksUpdateOperation> StartUpdateAsync(string resourceGroupName, string diskName, Azure.ResourceManager.Compute.Models.DiskUpdate disk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisksCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.Disk>
    {
        internal DisksCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.Disk Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Disk>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Disk>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisksDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal DisksDeleteOperation() { }
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
    public partial class DisksGrantAccessOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.AccessUri>
    {
        internal DisksGrantAccessOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.AccessUri Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisksRevokeAccessOperation : Azure.Operation<Azure.Response>
    {
        internal DisksRevokeAccessOperation() { }
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
    public partial class DisksUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.Disk>
    {
        internal DisksUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.Disk Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Disk>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Disk>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleriesClient
    {
        protected GalleriesClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.Gallery> Get(string resourceGroupName, string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.Gallery>> GetAsync(string resourceGroupName, string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Gallery> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Gallery> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Gallery> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Gallery> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleriesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string galleryName, Azure.ResourceManager.Compute.Models.Gallery gallery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleriesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string galleryName, Azure.ResourceManager.Compute.Models.Gallery gallery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleriesDeleteOperation StartDelete(string resourceGroupName, string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleriesDeleteOperation> StartDeleteAsync(string resourceGroupName, string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleriesUpdateOperation StartUpdate(string resourceGroupName, string galleryName, Azure.ResourceManager.Compute.Models.GalleryUpdate gallery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleriesUpdateOperation> StartUpdateAsync(string resourceGroupName, string galleryName, Azure.ResourceManager.Compute.Models.GalleryUpdate gallery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleriesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.Gallery>
    {
        internal GalleriesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.Gallery Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Gallery>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Gallery>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleriesDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal GalleriesDeleteOperation() { }
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
    public partial class GalleriesUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.Gallery>
    {
        internal GalleriesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.Gallery Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Gallery>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Gallery>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationsClient
    {
        protected GalleryApplicationsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplication> Get(string resourceGroupName, string galleryName, string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplication>> GetAsync(string resourceGroupName, string galleryName, string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.GalleryApplication> ListByGallery(string resourceGroupName, string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.GalleryApplication> ListByGalleryAsync(string resourceGroupName, string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string galleryName, string galleryApplicationName, Azure.ResourceManager.Compute.Models.GalleryApplication galleryApplication, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryApplicationsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string galleryName, string galleryApplicationName, Azure.ResourceManager.Compute.Models.GalleryApplication galleryApplication, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationsDeleteOperation StartDelete(string resourceGroupName, string galleryName, string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryApplicationsDeleteOperation> StartDeleteAsync(string resourceGroupName, string galleryName, string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationsUpdateOperation StartUpdate(string resourceGroupName, string galleryName, string galleryApplicationName, Azure.ResourceManager.Compute.Models.GalleryApplicationUpdate galleryApplication, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryApplicationsUpdateOperation> StartUpdateAsync(string resourceGroupName, string galleryName, string galleryApplicationName, Azure.ResourceManager.Compute.Models.GalleryApplicationUpdate galleryApplication, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.GalleryApplication>
    {
        internal GalleryApplicationsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.GalleryApplication Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplication>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplication>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal GalleryApplicationsDeleteOperation() { }
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
    public partial class GalleryApplicationsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.GalleryApplication>
    {
        internal GalleryApplicationsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.GalleryApplication Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplication>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplication>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationVersionsClient
    {
        protected GalleryApplicationVersionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion> Get(string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion>> GetAsync(string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion> ListByGalleryApplication(string resourceGroupName, string galleryName, string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion> ListByGalleryApplicationAsync(string resourceGroupName, string galleryName, string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationVersionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.GalleryApplicationVersion galleryApplicationVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryApplicationVersionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.GalleryApplicationVersion galleryApplicationVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationVersionsDeleteOperation StartDelete(string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryApplicationVersionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationVersionsUpdateOperation StartUpdate(string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionUpdate galleryApplicationVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryApplicationVersionsUpdateOperation> StartUpdateAsync(string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionUpdate galleryApplicationVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationVersionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion>
    {
        internal GalleryApplicationVersionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.GalleryApplicationVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationVersionsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal GalleryApplicationVersionsDeleteOperation() { }
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
    public partial class GalleryApplicationVersionsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion>
    {
        internal GalleryApplicationVersionsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.GalleryApplicationVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImagesClient
    {
        protected GalleryImagesClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImage> Get(string resourceGroupName, string galleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImage>> GetAsync(string resourceGroupName, string galleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.GalleryImage> ListByGallery(string resourceGroupName, string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.GalleryImage> ListByGalleryAsync(string resourceGroupName, string galleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImagesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string galleryName, string galleryImageName, Azure.ResourceManager.Compute.Models.GalleryImage galleryImage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryImagesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string galleryName, string galleryImageName, Azure.ResourceManager.Compute.Models.GalleryImage galleryImage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImagesDeleteOperation StartDelete(string resourceGroupName, string galleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryImagesDeleteOperation> StartDeleteAsync(string resourceGroupName, string galleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImagesUpdateOperation StartUpdate(string resourceGroupName, string galleryName, string galleryImageName, Azure.ResourceManager.Compute.Models.GalleryImageUpdate galleryImage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryImagesUpdateOperation> StartUpdateAsync(string resourceGroupName, string galleryName, string galleryImageName, Azure.ResourceManager.Compute.Models.GalleryImageUpdate galleryImage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImagesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.GalleryImage>
    {
        internal GalleryImagesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.GalleryImage Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImage>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImage>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImagesDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal GalleryImagesDeleteOperation() { }
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
    public partial class GalleryImagesUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.GalleryImage>
    {
        internal GalleryImagesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.GalleryImage Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImage>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImage>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageVersionsClient
    {
        protected GalleryImageVersionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImageVersion> Get(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImageVersion>> GetAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.GalleryImageVersion> ListByGalleryImage(string resourceGroupName, string galleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.GalleryImageVersion> ListByGalleryImageAsync(string resourceGroupName, string galleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImageVersionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, Azure.ResourceManager.Compute.Models.GalleryImageVersion galleryImageVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryImageVersionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, Azure.ResourceManager.Compute.Models.GalleryImageVersion galleryImageVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImageVersionsDeleteOperation StartDelete(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryImageVersionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImageVersionsUpdateOperation StartUpdate(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, Azure.ResourceManager.Compute.Models.GalleryImageVersionUpdate galleryImageVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.GalleryImageVersionsUpdateOperation> StartUpdateAsync(string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName, Azure.ResourceManager.Compute.Models.GalleryImageVersionUpdate galleryImageVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageVersionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.GalleryImageVersion>
    {
        internal GalleryImageVersionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.GalleryImageVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImageVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImageVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageVersionsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal GalleryImageVersionsDeleteOperation() { }
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
    public partial class GalleryImageVersionsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.GalleryImageVersion>
    {
        internal GalleryImageVersionsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.GalleryImageVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImageVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.GalleryImageVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImagesClient
    {
        protected ImagesClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.Image> Get(string resourceGroupName, string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.Image>> GetAsync(string resourceGroupName, string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Image> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Image> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Image> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Image> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.ImagesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string imageName, Azure.ResourceManager.Compute.Models.Image parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.ImagesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string imageName, Azure.ResourceManager.Compute.Models.Image parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.ImagesDeleteOperation StartDelete(string resourceGroupName, string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.ImagesDeleteOperation> StartDeleteAsync(string resourceGroupName, string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.ImagesUpdateOperation StartUpdate(string resourceGroupName, string imageName, Azure.ResourceManager.Compute.Models.ImageUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.ImagesUpdateOperation> StartUpdateAsync(string resourceGroupName, string imageName, Azure.ResourceManager.Compute.Models.ImageUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImagesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.Image>
    {
        internal ImagesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.Image Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Image>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Image>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImagesDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal ImagesDeleteOperation() { }
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
    public partial class ImagesUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.Image>
    {
        internal ImagesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.Image Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Image>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Image>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogAnalyticsClient
    {
        protected LogAnalyticsClient() { }
        public virtual Azure.ResourceManager.Compute.LogAnalyticsExportRequestRateByIntervalOperation StartExportRequestRateByInterval(string location, Azure.ResourceManager.Compute.Models.RequestRateByIntervalInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.LogAnalyticsExportRequestRateByIntervalOperation> StartExportRequestRateByIntervalAsync(string location, Azure.ResourceManager.Compute.Models.RequestRateByIntervalInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.LogAnalyticsExportThrottledRequestsOperation StartExportThrottledRequests(string location, Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.LogAnalyticsExportThrottledRequestsOperation> StartExportThrottledRequestsAsync(string location, Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogAnalyticsExportRequestRateByIntervalOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.LogAnalyticsOperationResult>
    {
        internal LogAnalyticsExportRequestRateByIntervalOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.LogAnalyticsOperationResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.LogAnalyticsOperationResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.LogAnalyticsOperationResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogAnalyticsExportThrottledRequestsOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.LogAnalyticsOperationResult>
    {
        internal LogAnalyticsExportThrottledRequestsOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.LogAnalyticsOperationResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.LogAnalyticsOperationResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.LogAnalyticsOperationResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationsClient
    {
        protected OperationsClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.ComputeOperationValue> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ComputeOperationValue> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProximityPlacementGroupsClient
    {
        protected ProximityPlacementGroupsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup> CreateOrUpdate(string resourceGroupName, string proximityPlacementGroupName, Azure.ResourceManager.Compute.Models.ProximityPlacementGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup>> CreateOrUpdateAsync(string resourceGroupName, string proximityPlacementGroupName, Azure.ResourceManager.Compute.Models.ProximityPlacementGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string proximityPlacementGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string proximityPlacementGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup> Get(string resourceGroupName, string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup>> GetAsync(string resourceGroupName, string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup> Update(string resourceGroupName, string proximityPlacementGroupName, Azure.ResourceManager.Compute.Models.UpdateResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup>> UpdateAsync(string resourceGroupName, string proximityPlacementGroupName, Azure.ResourceManager.Compute.Models.UpdateResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceSkusClient
    {
        protected ResourceSkusClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.ResourceSku> List(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ResourceSku> ListAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotsClient
    {
        protected SnapshotsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.Snapshot> Get(string resourceGroupName, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.Snapshot>> GetAsync(string resourceGroupName, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Snapshot> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Snapshot> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Snapshot> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Snapshot> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SnapshotsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string snapshotName, Azure.ResourceManager.Compute.Models.Snapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.SnapshotsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string snapshotName, Azure.ResourceManager.Compute.Models.Snapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SnapshotsDeleteOperation StartDelete(string resourceGroupName, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.SnapshotsDeleteOperation> StartDeleteAsync(string resourceGroupName, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SnapshotsGrantAccessOperation StartGrantAccess(string resourceGroupName, string snapshotName, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.SnapshotsGrantAccessOperation> StartGrantAccessAsync(string resourceGroupName, string snapshotName, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SnapshotsRevokeAccessOperation StartRevokeAccess(string resourceGroupName, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.SnapshotsRevokeAccessOperation> StartRevokeAccessAsync(string resourceGroupName, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SnapshotsUpdateOperation StartUpdate(string resourceGroupName, string snapshotName, Azure.ResourceManager.Compute.Models.SnapshotUpdate snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.SnapshotsUpdateOperation> StartUpdateAsync(string resourceGroupName, string snapshotName, Azure.ResourceManager.Compute.Models.SnapshotUpdate snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.Snapshot>
    {
        internal SnapshotsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.Snapshot Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Snapshot>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Snapshot>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal SnapshotsDeleteOperation() { }
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
    public partial class SnapshotsGrantAccessOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.AccessUri>
    {
        internal SnapshotsGrantAccessOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.AccessUri Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotsRevokeAccessOperation : Azure.Operation<Azure.Response>
    {
        internal SnapshotsRevokeAccessOperation() { }
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
    public partial class SnapshotsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.Snapshot>
    {
        internal SnapshotsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.Snapshot Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Snapshot>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.Snapshot>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SshPublicKeysClient
    {
        protected SshPublicKeysClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyResource> Create(string resourceGroupName, string sshPublicKeyName, Azure.ResourceManager.Compute.Models.SshPublicKeyResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyResource>> CreateAsync(string resourceGroupName, string sshPublicKeyName, Azure.ResourceManager.Compute.Models.SshPublicKeyResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult> GenerateKeyPair(string resourceGroupName, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>> GenerateKeyPairAsync(string resourceGroupName, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyResource> Get(string resourceGroupName, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyResource>> GetAsync(string resourceGroupName, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.SshPublicKeyResource> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.SshPublicKeyResource> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.SshPublicKeyResource> ListBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.SshPublicKeyResource> ListBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyResource> Update(string resourceGroupName, string sshPublicKeyName, Azure.ResourceManager.Compute.Models.SshPublicKeyUpdateResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyResource>> UpdateAsync(string resourceGroupName, string sshPublicKeyName, Azure.ResourceManager.Compute.Models.SshPublicKeyUpdateResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UsageClient
    {
        protected UsageClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.Usage> List(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Usage> ListAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionImagesClient
    {
        protected VirtualMachineExtensionImagesClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionImage> Get(string location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionImage>> GetAsync(string location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionImage>> ListTypes(string location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionImage>>> ListTypesAsync(string location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionImage>> ListVersions(string location, string publisherName, string type, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionImage>>> ListVersionsAsync(string location, string publisherName, string type, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionsClient
    {
        protected VirtualMachineExtensionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension> Get(string resourceGroupName, string vmName, string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> GetAsync(string resourceGroupName, string vmName, string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionsListResult> List(string resourceGroupName, string vmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionsListResult>> ListAsync(string resourceGroupName, string vmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string vmName, string vmExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineExtension extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineExtensionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string vmName, string vmExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineExtension extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionsDeleteOperation StartDelete(string resourceGroupName, string vmName, string vmExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineExtensionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string vmName, string vmExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionsUpdateOperation StartUpdate(string resourceGroupName, string vmName, string vmExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineExtensionsUpdateOperation> StartUpdateAsync(string resourceGroupName, string vmName, string vmExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>
    {
        internal VirtualMachineExtensionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineExtensionsDeleteOperation() { }
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
    public partial class VirtualMachineExtensionsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>
    {
        internal VirtualMachineExtensionsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineImagesClient
    {
        protected VirtualMachineImagesClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage> Get(string location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage>> GetAsync(string location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource>> List(string location, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource>>> ListAsync(string location, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource>> ListOffers(string location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource>>> ListOffersAsync(string location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource>> ListPublishers(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource>>> ListPublishersAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource>> ListSkus(string location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource>>> ListSkusAsync(string location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRunCommandsClient
    {
        protected VirtualMachineRunCommandsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument> Get(string location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument>> GetAsync(string location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> List(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> ListAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionsClient
    {
        protected VirtualMachineScaleSetExtensionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension> Get(string resourceGroupName, string vmScaleSetName, string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension>> GetAsync(string resourceGroupName, string vmScaleSetName, string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension> List(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension> ListAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string vmScaleSetName, string vmssExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string vmScaleSetName, string vmssExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionsDeleteOperation StartDelete(string resourceGroupName, string vmScaleSetName, string vmssExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string vmScaleSetName, string vmssExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionsUpdateOperation StartUpdate(string resourceGroupName, string vmScaleSetName, string vmssExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionsUpdateOperation> StartUpdateAsync(string resourceGroupName, string vmScaleSetName, string vmssExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension>
    {
        internal VirtualMachineScaleSetExtensionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetExtensionsDeleteOperation() { }
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
    public partial class VirtualMachineScaleSetExtensionsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension>
    {
        internal VirtualMachineScaleSetExtensionsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetRollingUpgradesCancelOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetRollingUpgradesCancelOperation() { }
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
    public partial class VirtualMachineScaleSetRollingUpgradesClient
    {
        protected VirtualMachineScaleSetRollingUpgradesClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RollingUpgradeStatusInfo> GetLatest(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RollingUpgradeStatusInfo>> GetLatestAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradesCancelOperation StartCancel(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradesCancelOperation> StartCancelAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradesStartExtensionUpgradeOperation StartStartExtensionUpgrade(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradesStartExtensionUpgradeOperation> StartStartExtensionUpgradeAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradesStartOSUpgradeOperation StartStartOSUpgrade(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradesStartOSUpgradeOperation> StartStartOSUpgradeAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetRollingUpgradesStartExtensionUpgradeOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetRollingUpgradesStartExtensionUpgradeOperation() { }
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
    public partial class VirtualMachineScaleSetRollingUpgradesStartOSUpgradeOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetRollingUpgradesStartOSUpgradeOperation() { }
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
    public partial class VirtualMachineScaleSetsClient
    {
        protected VirtualMachineScaleSetsClient() { }
        public virtual Azure.Response ConvertToSinglePlacementGroup(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VMScaleSetConvertToSinglePlacementGroupInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ConvertToSinglePlacementGroupAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VMScaleSetConvertToSinglePlacementGroupInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse> ForceRecoveryServiceFabricPlatformUpdateDomainWalk(string resourceGroupName, string vmScaleSetName, int platformUpdateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>> ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(string resourceGroupName, string vmScaleSetName, int platformUpdateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet> Get(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>> GetAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView> GetInstanceView(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>> GetInstanceViewAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistory(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistoryAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet> List(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet> ListAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet> ListAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet> ListAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku> ListSkus(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku> ListSkusAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsDeallocateOperation StartDeallocate(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsDeallocateOperation> StartDeallocateAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsDeleteOperation StartDelete(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsDeleteOperation> StartDeleteAsync(string resourceGroupName, string vmScaleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsDeleteInstancesOperation StartDeleteInstances(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceRequiredIDs vmInstanceIDs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsDeleteInstancesOperation> StartDeleteInstancesAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceRequiredIDs vmInstanceIDs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsPerformMaintenanceOperation StartPerformMaintenance(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsPerformMaintenanceOperation> StartPerformMaintenanceAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsPowerOffOperation StartPowerOff(string resourceGroupName, string vmScaleSetName, bool? skipShutdown = default(bool?), Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsPowerOffOperation> StartPowerOffAsync(string resourceGroupName, string vmScaleSetName, bool? skipShutdown = default(bool?), Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsRedeployOperation StartRedeploy(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsRedeployOperation> StartRedeployAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsReimageOperation StartReimage(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageParameters vmScaleSetReimageInput = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsReimageAllOperation StartReimageAll(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsReimageAllOperation> StartReimageAllAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsReimageOperation> StartReimageAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageParameters vmScaleSetReimageInput = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsRestartOperation StartRestart(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsRestartOperation> StartRestartAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsSetOrchestrationServiceStateOperation StartSetOrchestrationServiceState(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsSetOrchestrationServiceStateOperation> StartSetOrchestrationServiceStateAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsStartOperation StartStart(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsStartOperation> StartStartAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceIDs vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsUpdateOperation StartUpdate(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsUpdateOperation> StartUpdateAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetsUpdateInstancesOperation StartUpdateInstances(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceRequiredIDs vmInstanceIDs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetsUpdateInstancesOperation> StartUpdateInstancesAsync(string resourceGroupName, string vmScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceRequiredIDs vmInstanceIDs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>
    {
        internal VirtualMachineScaleSetsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetsDeallocateOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsDeallocateOperation() { }
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
    public partial class VirtualMachineScaleSetsDeleteInstancesOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsDeleteInstancesOperation() { }
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
    public partial class VirtualMachineScaleSetsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsDeleteOperation() { }
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
    public partial class VirtualMachineScaleSetsPerformMaintenanceOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsPerformMaintenanceOperation() { }
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
    public partial class VirtualMachineScaleSetsPowerOffOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsPowerOffOperation() { }
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
    public partial class VirtualMachineScaleSetsRedeployOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsRedeployOperation() { }
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
    public partial class VirtualMachineScaleSetsReimageAllOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsReimageAllOperation() { }
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
    public partial class VirtualMachineScaleSetsReimageOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsReimageOperation() { }
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
    public partial class VirtualMachineScaleSetsRestartOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsRestartOperation() { }
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
    public partial class VirtualMachineScaleSetsSetOrchestrationServiceStateOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsSetOrchestrationServiceStateOperation() { }
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
    public partial class VirtualMachineScaleSetsStartOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsStartOperation() { }
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
    public partial class VirtualMachineScaleSetsUpdateInstancesOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetsUpdateInstancesOperation() { }
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
    public partial class VirtualMachineScaleSetsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>
    {
        internal VirtualMachineScaleSetsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVMExtensionsClient
    {
        protected VirtualMachineScaleSetVMExtensionsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension> Get(string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> GetAsync(string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionsListResult> List(string resourceGroupName, string vmScaleSetName, string instanceId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionsListResult>> ListAsync(string resourceGroupName, string vmScaleSetName, string instanceId, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineExtension extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineExtension extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMExtensionsDeleteOperation StartDelete(string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMExtensionsDeleteOperation> StartDeleteAsync(string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMExtensionsUpdateOperation StartUpdate(string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMExtensionsUpdateOperation> StartUpdateAsync(string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>
    {
        internal VirtualMachineScaleSetVMExtensionsCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVMExtensionsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMExtensionsDeleteOperation() { }
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
    public partial class VirtualMachineScaleSetVMExtensionsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>
    {
        internal VirtualMachineScaleSetVMExtensionsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVMsClient
    {
        protected VirtualMachineScaleSetVMsClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM> Get(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM>> GetAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceView> GetInstanceView(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceView>> GetInstanceViewAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM> List(string resourceGroupName, string virtualMachineScaleSetName, string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM> ListAsync(string resourceGroupName, string virtualMachineScaleSetName, string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsDeallocateOperation StartDeallocate(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsDeallocateOperation> StartDeallocateAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsDeleteOperation StartDelete(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsDeleteOperation> StartDeleteAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsPerformMaintenanceOperation StartPerformMaintenance(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsPerformMaintenanceOperation> StartPerformMaintenanceAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsPowerOffOperation StartPowerOff(string resourceGroupName, string vmScaleSetName, string instanceId, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsPowerOffOperation> StartPowerOffAsync(string resourceGroupName, string vmScaleSetName, string instanceId, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsRedeployOperation StartRedeploy(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsRedeployOperation> StartRedeployAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsReimageOperation StartReimage(string resourceGroupName, string vmScaleSetName, string instanceId, Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters vmScaleSetVMReimageInput = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsReimageAllOperation StartReimageAll(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsReimageAllOperation> StartReimageAllAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsReimageOperation> StartReimageAsync(string resourceGroupName, string vmScaleSetName, string instanceId, Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters vmScaleSetVMReimageInput = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsRestartOperation StartRestart(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsRestartOperation> StartRestartAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsRunCommandOperation StartRunCommand(string resourceGroupName, string vmScaleSetName, string instanceId, Azure.ResourceManager.Compute.Models.RunCommandInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsRunCommandOperation> StartRunCommandAsync(string resourceGroupName, string vmScaleSetName, string instanceId, Azure.ResourceManager.Compute.Models.RunCommandInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsStartOperation StartStart(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsStartOperation> StartStartAsync(string resourceGroupName, string vmScaleSetName, string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsUpdateOperation StartUpdate(string resourceGroupName, string vmScaleSetName, string instanceId, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachineScaleSetVMsUpdateOperation> StartUpdateAsync(string resourceGroupName, string vmScaleSetName, string instanceId, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVMsDeallocateOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsDeallocateOperation() { }
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
    public partial class VirtualMachineScaleSetVMsDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsDeleteOperation() { }
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
    public partial class VirtualMachineScaleSetVMsPerformMaintenanceOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsPerformMaintenanceOperation() { }
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
    public partial class VirtualMachineScaleSetVMsPowerOffOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsPowerOffOperation() { }
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
    public partial class VirtualMachineScaleSetVMsRedeployOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsRedeployOperation() { }
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
    public partial class VirtualMachineScaleSetVMsReimageAllOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsReimageAllOperation() { }
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
    public partial class VirtualMachineScaleSetVMsReimageOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsReimageOperation() { }
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
    public partial class VirtualMachineScaleSetVMsRestartOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsRestartOperation() { }
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
    public partial class VirtualMachineScaleSetVMsRunCommandOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.RunCommandResult>
    {
        internal VirtualMachineScaleSetVMsRunCommandOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.RunCommandResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVMsStartOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachineScaleSetVMsStartOperation() { }
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
    public partial class VirtualMachineScaleSetVMsUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM>
    {
        internal VirtualMachineScaleSetVMsUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachinesCaptureOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>
    {
        internal VirtualMachinesCaptureOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachinesClient
    {
        protected VirtualMachinesClient() { }
        public virtual Azure.Response Generalize(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GeneralizeAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachine> Get(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachine>> GetAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView> InstanceView(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>> InstanceViewAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachine> List(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachine> ListAll(string statusOnly = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachine> ListAllAsync(string statusOnly = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachine> ListAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> ListAvailableSizes(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> ListAvailableSizesAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachine> ListByLocation(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachine> ListByLocationAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesCaptureOperation StartCapture(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.VirtualMachineCaptureParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesCaptureOperation> StartCaptureAsync(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.VirtualMachineCaptureParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesConvertToManagedDisksOperation StartConvertToManagedDisks(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesConvertToManagedDisksOperation> StartConvertToManagedDisksAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.VirtualMachine parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.VirtualMachine parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesDeallocateOperation StartDeallocate(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesDeallocateOperation> StartDeallocateAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesDeleteOperation StartDelete(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesDeleteOperation> StartDeleteAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesPerformMaintenanceOperation StartPerformMaintenance(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesPerformMaintenanceOperation> StartPerformMaintenanceAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesPowerOffOperation StartPowerOff(string resourceGroupName, string vmName, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesPowerOffOperation> StartPowerOffAsync(string resourceGroupName, string vmName, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesReapplyOperation StartReapply(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesReapplyOperation> StartReapplyAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesRedeployOperation StartRedeploy(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesRedeployOperation> StartRedeployAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesReimageOperation StartReimage(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesReimageOperation> StartReimageAsync(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesRestartOperation StartRestart(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesRestartOperation> StartRestartAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesRunCommandOperation StartRunCommand(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.RunCommandInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesRunCommandOperation> StartRunCommandAsync(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.RunCommandInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesStartOperation StartStart(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesStartOperation> StartStartAsync(string resourceGroupName, string vmName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachinesUpdateOperation StartUpdate(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.VirtualMachineUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.VirtualMachinesUpdateOperation> StartUpdateAsync(string resourceGroupName, string vmName, Azure.ResourceManager.Compute.Models.VirtualMachineUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachinesConvertToManagedDisksOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesConvertToManagedDisksOperation() { }
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
    public partial class VirtualMachinesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachine>
    {
        internal VirtualMachinesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachine Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachine>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachine>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachinesDeallocateOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesDeallocateOperation() { }
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
    public partial class VirtualMachinesDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesDeleteOperation() { }
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
    public partial class VirtualMachineSizesClient
    {
        protected VirtualMachineSizesClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> List(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> ListAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachinesPerformMaintenanceOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesPerformMaintenanceOperation() { }
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
    public partial class VirtualMachinesPowerOffOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesPowerOffOperation() { }
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
    public partial class VirtualMachinesReapplyOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesReapplyOperation() { }
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
    public partial class VirtualMachinesRedeployOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesRedeployOperation() { }
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
    public partial class VirtualMachinesReimageOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesReimageOperation() { }
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
    public partial class VirtualMachinesRestartOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesRestartOperation() { }
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
    public partial class VirtualMachinesRunCommandOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.RunCommandResult>
    {
        internal VirtualMachinesRunCommandOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.RunCommandResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachinesStartOperation : Azure.Operation<Azure.Response>
    {
        internal VirtualMachinesStartOperation() { }
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
    public partial class VirtualMachinesUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachine>
    {
        internal VirtualMachinesUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachine Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachine>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachine>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessLevel : System.IEquatable<Azure.ResourceManager.Compute.Models.AccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.AccessLevel None { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AccessLevel Read { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AccessLevel Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.AccessLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.AccessLevel left, Azure.ResourceManager.Compute.Models.AccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.AccessLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.AccessLevel left, Azure.ResourceManager.Compute.Models.AccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessUri
    {
        internal AccessUri() { }
        public string AccessSAS { get { throw null; } }
    }
    public partial class AdditionalCapabilities
    {
        public AdditionalCapabilities() { }
        public bool? UltraSSDEnabled { get { throw null; } set { } }
    }
    public partial class AdditionalUnattendContent
    {
        public AdditionalUnattendContent() { }
        public string ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public string PassName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SettingNames? SettingName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregatedReplicationState : System.IEquatable<Azure.ResourceManager.Compute.Models.AggregatedReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregatedReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.AggregatedReplicationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AggregatedReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AggregatedReplicationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AggregatedReplicationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.AggregatedReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.AggregatedReplicationState left, Azure.ResourceManager.Compute.Models.AggregatedReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.AggregatedReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.AggregatedReplicationState left, Azure.ResourceManager.Compute.Models.AggregatedReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiEntityReference
    {
        public ApiEntityReference() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class ApiError
    {
        public ApiError() { }
        public string Code { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.ApiErrorBase> Details { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.InnerError Innererror { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
    }
    public partial class ApiErrorBase
    {
        public ApiErrorBase() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
    }
    public partial class AutomaticOSUpgradePolicy
    {
        public AutomaticOSUpgradePolicy() { }
        public bool? DisableAutomaticRollback { get { throw null; } set { } }
        public bool? EnableAutomaticOSUpgrade { get { throw null; } set { } }
    }
    public partial class AutomaticOSUpgradeProperties
    {
        public AutomaticOSUpgradeProperties(bool automaticOSUpgradeSupported) { }
        public bool AutomaticOSUpgradeSupported { get { throw null; } set { } }
    }
    public partial class AutomaticRepairsPolicy
    {
        public AutomaticRepairsPolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string GracePeriod { get { throw null; } set { } }
    }
    public partial class AvailabilitySet : Azure.ResourceManager.Compute.Models.Resource
    {
        public AvailabilitySet(string location) : base (default(string)) { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> VirtualMachines { get { throw null; } set { } }
    }
    public partial class AvailabilitySetListResult
    {
        internal AvailabilitySetListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.AvailabilitySet> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilitySetSkuTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilitySetSkuTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes Aligned { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes Classic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes left, Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes left, Azure.ResourceManager.Compute.Models.AvailabilitySetSkuTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailabilitySetUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public AvailabilitySetUpdate() { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> VirtualMachines { get { throw null; } set { } }
    }
    public partial class BillingProfile
    {
        public BillingProfile() { }
        public double? MaxPrice { get { throw null; } set { } }
    }
    public partial class BootDiagnostics
    {
        public BootDiagnostics() { }
        public bool? Enabled { get { throw null; } set { } }
        public string StorageUri { get { throw null; } set { } }
    }
    public partial class BootDiagnosticsInstanceView
    {
        public BootDiagnosticsInstanceView() { }
        public string ConsoleScreenshotBlobUri { get { throw null; } }
        public string SerialConsoleLogBlobUri { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
    }
    public enum CachingTypes
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public partial class Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties
    {
        public Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
    }
    public partial class ComponentsNj115SSchemasVirtualmachinescalesetidentityPropertiesUserassignedidentitiesAdditionalproperties
    {
        public ComponentsNj115SSchemasVirtualmachinescalesetidentityPropertiesUserassignedidentitiesAdditionalproperties() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
    }
    public partial class ComputeOperationListResult
    {
        internal ComputeOperationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeOperationValue> Value { get { throw null; } }
    }
    public partial class ComputeOperationValue
    {
        internal ComputeOperationValue() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Origin { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class ContainerService : Azure.ResourceManager.Compute.Models.Resource
    {
        public ContainerService(string location) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.ContainerServiceAgentPoolProfile> AgentPoolProfiles { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ContainerServiceCustomProfile CustomProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ContainerServiceDiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ContainerServiceLinuxProfile LinuxProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ContainerServiceMasterProfile MasterProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ContainerServiceOrchestratorProfile OrchestratorProfile { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ContainerServicePrincipalProfile ServicePrincipalProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ContainerServiceWindowsProfile WindowsProfile { get { throw null; } set { } }
    }
    public partial class ContainerServiceAgentPoolProfile
    {
        public ContainerServiceAgentPoolProfile(string name, int count, Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes vmSize, string dnsPrefix) { }
        public int Count { get { throw null; } set { } }
        public string DnsPrefix { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes VmSize { get { throw null; } set { } }
    }
    public partial class ContainerServiceCustomProfile
    {
        public ContainerServiceCustomProfile(string orchestrator) { }
        public string Orchestrator { get { throw null; } set { } }
    }
    public partial class ContainerServiceDiagnosticsProfile
    {
        public ContainerServiceDiagnosticsProfile(Azure.ResourceManager.Compute.Models.ContainerServiceVMDiagnostics vmDiagnostics) { }
        public Azure.ResourceManager.Compute.Models.ContainerServiceVMDiagnostics VmDiagnostics { get { throw null; } set { } }
    }
    public partial class ContainerServiceLinuxProfile
    {
        public ContainerServiceLinuxProfile(string adminUsername, Azure.ResourceManager.Compute.Models.ContainerServiceSshConfiguration ssh) { }
        public string AdminUsername { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ContainerServiceSshConfiguration Ssh { get { throw null; } set { } }
    }
    public partial class ContainerServiceListResult
    {
        internal ContainerServiceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ContainerService> Value { get { throw null; } }
    }
    public partial class ContainerServiceMasterProfile
    {
        public ContainerServiceMasterProfile(string dnsPrefix) { }
        public Azure.ResourceManager.Compute.Models.Enum27? Count { get { throw null; } set { } }
        public string DnsPrefix { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
    }
    public partial class ContainerServiceOrchestratorProfile
    {
        public ContainerServiceOrchestratorProfile(Azure.ResourceManager.Compute.Models.ContainerServiceOrchestratorTypes orchestratorType) { }
        public Azure.ResourceManager.Compute.Models.ContainerServiceOrchestratorTypes OrchestratorType { get { throw null; } set { } }
    }
    public enum ContainerServiceOrchestratorTypes
    {
        Swarm = 0,
        Dcos = 1,
        Custom = 2,
        Kubernetes = 3,
    }
    public partial class ContainerServicePrincipalProfile
    {
        public ContainerServicePrincipalProfile(string clientId, string secret) { }
        public string ClientId { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    public partial class ContainerServiceSshConfiguration
    {
        public ContainerServiceSshConfiguration(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ContainerServiceSshPublicKey> publicKeys) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.ContainerServiceSshPublicKey> PublicKeys { get { throw null; } }
    }
    public partial class ContainerServiceSshPublicKey
    {
        public ContainerServiceSshPublicKey(string keyData) { }
        public string KeyData { get { throw null; } set { } }
    }
    public partial class ContainerServiceVMDiagnostics
    {
        public ContainerServiceVMDiagnostics(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public string StorageUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceVMSizeTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceVMSizeTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes StandardGS5 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes left, Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes left, Azure.ResourceManager.Compute.Models.ContainerServiceVMSizeTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceWindowsProfile
    {
        public ContainerServiceWindowsProfile(string adminUsername, string adminPassword) { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
    }
    public partial class CreationData
    {
        public CreationData(Azure.ResourceManager.Compute.Models.DiskCreateOption createOption) { }
        public Azure.ResourceManager.Compute.Models.DiskCreateOption CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageDiskReference GalleryImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageDiskReference ImageReference { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string SourceUniqueId { get { throw null; } }
        public string SourceUri { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public long? UploadSizeBytes { get { throw null; } set { } }
    }
    public partial class DataDisk
    {
        public DataDisk(int lun, Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } }
        public long? DiskMBpsReadWrite { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Image { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ToBeDetached { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Vhd { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class DataDiskImage
    {
        public DataDiskImage() { }
        public int? Lun { get { throw null; } }
    }
    public partial class DataDiskImageEncryption : Azure.ResourceManager.Compute.Models.DiskImageEncryption
    {
        public DataDiskImageEncryption(int lun) { }
        public int Lun { get { throw null; } set { } }
    }
    public partial class DedicatedHost : Azure.ResourceManager.Compute.Models.Resource
    {
        public DedicatedHost(string location, Azure.ResourceManager.Compute.Models.Sku sku) : base (default(string)) { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostLicenseTypes? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningTime { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResourceReadOnly> VirtualMachines { get { throw null; } }
    }
    public partial class DedicatedHostAllocatableVM
    {
        public DedicatedHostAllocatableVM() { }
        public double? Count { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class DedicatedHostAvailableCapacity
    {
        public DedicatedHostAvailableCapacity() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVM> AllocatableVMs { get { throw null; } set { } }
    }
    public partial class DedicatedHostGroup : Azure.ResourceManager.Compute.Models.Resource
    {
        public DedicatedHostGroup(string location) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResourceReadOnly> Hosts { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } set { } }
    }
    public partial class DedicatedHostGroupListResult
    {
        internal DedicatedHostGroupListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostGroup> Value { get { throw null; } }
    }
    public partial class DedicatedHostGroupUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public DedicatedHostGroupUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResourceReadOnly> Hosts { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } set { } }
    }
    public partial class DedicatedHostInstanceView
    {
        public DedicatedHostInstanceView() { }
        public string AssetId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostAvailableCapacity AvailableCapacity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } set { } }
    }
    public enum DedicatedHostLicenseTypes
    {
        None = 0,
        WindowsServerHybrid = 1,
        WindowsServerPerpetual = 2,
    }
    public partial class DedicatedHostListResult
    {
        internal DedicatedHostListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHost> Value { get { throw null; } }
    }
    public partial class DedicatedHostUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public DedicatedHostUpdate() { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostLicenseTypes? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningTime { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResourceReadOnly> VirtualMachines { get { throw null; } }
    }
    public partial class DiagnosticsProfile
    {
        public DiagnosticsProfile() { }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Compute.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiffDiskPlacement left, Azure.ResourceManager.Compute.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiffDiskPlacement left, Azure.ResourceManager.Compute.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings
    {
        public DiffDiskSettings() { }
        public string Option { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
    }
    public partial class Disallowed
    {
        public Disallowed() { }
        public System.Collections.Generic.IList<string> DiskTypes { get { throw null; } set { } }
    }
    public partial class Disk : Azure.ResourceManager.Compute.Models.Resource
    {
        public Disk(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.CreationData CreationData { get { throw null; } set { } }
        public long? DiskIopsReadOnly { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadOnly { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public long? DiskSizeBytes { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskState? DiskState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingsCollection EncryptionSettingsCollection { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public System.Collections.Generic.IList<string> ManagedByExtended { get { throw null; } }
        public int? MaxShares { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.ShareInfoElement> ShareInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOption : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskCreateOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOption(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Attach { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Copy { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Empty { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption FromImage { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Import { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Restore { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Upload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskCreateOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskCreateOption left, Azure.ResourceManager.Compute.Models.DiskCreateOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskCreateOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskCreateOption left, Azure.ResourceManager.Compute.Models.DiskCreateOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes Attach { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes Empty { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes FromImage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes left, Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes left, Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskEncryptionSet : Azure.ResourceManager.Compute.Models.Resource
    {
        public DiskEncryptionSet(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.KeyVaultAndKeyReference ActiveKey { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSetIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.KeyVaultAndKeyReference> PreviousKeys { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class DiskEncryptionSetList
    {
        internal DiskEncryptionSetList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DiskEncryptionSet> Value { get { throw null; } }
    }
    public partial class DiskEncryptionSetParameters : Azure.ResourceManager.Compute.Models.SubResource
    {
        public DiskEncryptionSetParameters() { }
    }
    public partial class DiskEncryptionSettings
    {
        public DiskEncryptionSettings() { }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
    }
    public partial class DiskEncryptionSetUpdate
    {
        public DiskEncryptionSetUpdate() { }
        public Azure.ResourceManager.Compute.Models.KeyVaultAndKeyReference ActiveKey { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class DiskImageEncryption
    {
        public DiskImageEncryption() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
    }
    public partial class DiskInstanceView
    {
        public DiskInstanceView() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings> EncryptionSettings { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } set { } }
    }
    public partial class DiskList
    {
        internal DiskList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.Disk> Value { get { throw null; } }
    }
    public partial class DiskSku
    {
        public DiskSku() { }
        public Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskState : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskState ActiveSAS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState ActiveUpload { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState Attached { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState ReadyToUpload { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState Reserved { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState Unattached { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskState left, Azure.ResourceManager.Compute.Models.DiskState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskState left, Azure.ResourceManager.Compute.Models.DiskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskStorageAccountTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskStorageAccountTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes UltraSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes left, Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes left, Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskUpdate
    {
        public DiskUpdate() { }
        public long? DiskIopsReadOnly { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadOnly { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingsCollection EncryptionSettingsCollection { get { throw null; } set { } }
        public int? MaxShares { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class Encryption
    {
        public Encryption() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionType? Type { get { throw null; } set { } }
    }
    public partial class EncryptionImages
    {
        public EncryptionImages() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDiskImageEncryption> DataDiskImages { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskImageEncryption OsDiskImage { get { throw null; } set { } }
    }
    public partial class EncryptionSetIdentity
    {
        public EncryptionSetIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string Type { get { throw null; } set { } }
    }
    public partial class EncryptionSettingsCollection
    {
        public EncryptionSettingsCollection(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.EncryptionSettingsElement> EncryptionSettings { get { throw null; } set { } }
        public string EncryptionSettingsVersion { get { throw null; } set { } }
    }
    public partial class EncryptionSettingsElement
    {
        public EncryptionSettingsElement() { }
        public Azure.ResourceManager.Compute.Models.KeyVaultAndSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultAndKeyReference KeyEncryptionKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionType : System.IEquatable<Azure.ResourceManager.Compute.Models.EncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.EncryptionType EncryptionAtRestWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.EncryptionType EncryptionAtRestWithPlatformKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.EncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.EncryptionType left, Azure.ResourceManager.Compute.Models.EncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.EncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.EncryptionType left, Azure.ResourceManager.Compute.Models.EncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enum27 : System.IEquatable<Azure.ResourceManager.Compute.Models.Enum27>
    {
        private readonly int _dummyPrimitive;
        public Enum27(int value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.Enum27 Five { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.Enum27 One { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.Enum27 Three { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.Enum27 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.Enum27 left, Azure.ResourceManager.Compute.Models.Enum27 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.Enum27 (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.Enum27 left, Azure.ResourceManager.Compute.Models.Enum27 right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Gallery : Azure.ResourceManager.Compute.Models.Resource
    {
        public Gallery(string location) : base (default(string)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class GalleryApplication : Azure.ResourceManager.Compute.Models.Resource
    {
        public GalleryApplication(string location) : base (default(string)) { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public string PrivacyStatementUri { get { throw null; } set { } }
        public string ReleaseNoteUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? SupportedOSType { get { throw null; } set { } }
    }
    public partial class GalleryApplicationList
    {
        internal GalleryApplicationList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.GalleryApplication> Value { get { throw null; } }
    }
    public partial class GalleryApplicationUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryApplicationUpdate() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public string PrivacyStatementUri { get { throw null; } set { } }
        public string ReleaseNoteUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? SupportedOSType { get { throw null; } set { } }
    }
    public partial class GalleryApplicationVersion : Azure.ResourceManager.Compute.Models.Resource
    {
        public GalleryApplicationVersion(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
    }
    public partial class GalleryApplicationVersionList
    {
        internal GalleryApplicationVersionList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.GalleryApplicationVersion> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryApplicationVersionPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryApplicationVersionPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryApplicationVersionPublishingProfile : Azure.ResourceManager.Compute.Models.GalleryArtifactPublishingProfileBase
    {
        public GalleryApplicationVersionPublishingProfile(Azure.ResourceManager.Compute.Models.UserArtifactSource source) { }
        public string ContentType { get { throw null; } set { } }
        public bool? EnableHealthCheck { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UserArtifactSource Source { get { throw null; } set { } }
    }
    public partial class GalleryApplicationVersionUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryApplicationVersionUpdate() { }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
    }
    public partial class GalleryArtifactPublishingProfileBase
    {
        public GalleryArtifactPublishingProfileBase() { }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
        public bool? ExcludeFromLatest { get { throw null; } set { } }
        public System.DateTimeOffset? PublishedDate { get { throw null; } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.TargetRegion> TargetRegions { get { throw null; } set { } }
    }
    public partial class GalleryArtifactVersionSource
    {
        public GalleryArtifactVersionSource() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class GalleryDataDiskImage : Azure.ResourceManager.Compute.Models.GalleryDiskImage
    {
        public GalleryDataDiskImage(int lun) { }
        public int Lun { get { throw null; } set { } }
    }
    public partial class GalleryDiskImage
    {
        public GalleryDiskImage() { }
        public Azure.ResourceManager.Compute.Models.HostCaching? HostCaching { get { throw null; } set { } }
        public int? SizeInGB { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryArtifactVersionSource Source { get { throw null; } set { } }
    }
    public partial class GalleryIdentifier
    {
        public GalleryIdentifier() { }
        public string UniqueName { get { throw null; } }
    }
    public partial class GalleryImage : Azure.ResourceManager.Compute.Models.Resource
    {
        public GalleryImage(string location) : base (default(string)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Disallowed Disallowed { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes? OsState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public string PrivacyStatementUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImagePurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RecommendedMachineConfiguration Recommended { get { throw null; } set { } }
        public string ReleaseNoteUri { get { throw null; } set { } }
    }
    public partial class GalleryImageIdentifier
    {
        public GalleryImageIdentifier(string publisher, string offer, string sku) { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
    }
    public partial class GalleryImageList
    {
        internal GalleryImageList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.GalleryImage> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryImagePropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryImagePropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryImageUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryImageUpdate() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Disallowed Disallowed { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes? OsState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public string PrivacyStatementUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImagePurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RecommendedMachineConfiguration Recommended { get { throw null; } set { } }
        public string ReleaseNoteUri { get { throw null; } set { } }
    }
    public partial class GalleryImageVersion : Azure.ResourceManager.Compute.Models.Resource
    {
        public GalleryImageVersion(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryArtifactPublishingProfileBase PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class GalleryImageVersionList
    {
        internal GalleryImageVersionList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.GalleryImageVersion> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryImageVersionPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryImageVersionPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryImageVersionPublishingProfile : Azure.ResourceManager.Compute.Models.GalleryArtifactPublishingProfileBase
    {
        public GalleryImageVersionPublishingProfile() { }
    }
    public partial class GalleryImageVersionStorageProfile
    {
        public GalleryImageVersionStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.GalleryDataDiskImage> DataDiskImages { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryDiskImage OsDiskImage { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryArtifactVersionSource Source { get { throw null; } set { } }
    }
    public partial class GalleryImageVersionUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryImageVersionUpdate() { }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryArtifactPublishingProfileBase PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class GalleryList
    {
        internal GalleryList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.Gallery> Value { get { throw null; } }
    }
    public partial class GalleryOSDiskImage : Azure.ResourceManager.Compute.Models.GalleryDiskImage
    {
        public GalleryOSDiskImage() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryUpdate() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class GrantAccessData
    {
        public GrantAccessData(Azure.ResourceManager.Compute.Models.AccessLevel access, int durationInSeconds) { }
        public Azure.ResourceManager.Compute.Models.AccessLevel Access { get { throw null; } }
        public int DurationInSeconds { get { throw null; } }
    }
    public partial class HardwareProfile
    {
        public HardwareProfile() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes? VmSize { get { throw null; } set { } }
    }
    public enum HostCaching
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.Compute.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.HyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.HyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.HyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.HyperVGeneration left, Azure.ResourceManager.Compute.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.HyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.HyperVGeneration left, Azure.ResourceManager.Compute.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGenerationType : System.IEquatable<Azure.ResourceManager.Compute.Models.HyperVGenerationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGenerationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.HyperVGenerationType V1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.HyperVGenerationType V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.HyperVGenerationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.HyperVGenerationType left, Azure.ResourceManager.Compute.Models.HyperVGenerationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.HyperVGenerationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.HyperVGenerationType left, Azure.ResourceManager.Compute.Models.HyperVGenerationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGenerationTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.HyperVGenerationTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGenerationTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.HyperVGenerationTypes V1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.HyperVGenerationTypes V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.HyperVGenerationTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.HyperVGenerationTypes left, Azure.ResourceManager.Compute.Models.HyperVGenerationTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.HyperVGenerationTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.HyperVGenerationTypes left, Azure.ResourceManager.Compute.Models.HyperVGenerationTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Image : Azure.ResourceManager.Compute.Models.Resource
    {
        public Image(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SubResource SourceVirtualMachine { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class ImageDataDisk : Azure.ResourceManager.Compute.Models.ImageDisk
    {
        public ImageDataDisk(int lun) { }
        public int Lun { get { throw null; } set { } }
    }
    public partial class ImageDisk
    {
        public ImageDisk() { }
        public string BlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource DiskEncryptionSet { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource ManagedDisk { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource Snapshot { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
    }
    public partial class ImageDiskReference
    {
        public ImageDiskReference(string id) { }
        public string Id { get { throw null; } set { } }
        public int? Lun { get { throw null; } set { } }
    }
    public partial class ImageListResult
    {
        internal ImageListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.Image> Value { get { throw null; } }
    }
    public partial class ImageOSDisk : Azure.ResourceManager.Compute.Models.ImageDisk
    {
        public ImageOSDisk(Azure.ResourceManager.Compute.Models.OperatingSystemTypes osType, Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes osState) { }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes OsState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes OsType { get { throw null; } set { } }
    }
    public partial class ImagePurchasePlan
    {
        public ImagePurchasePlan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class ImageReference : Azure.ResourceManager.Compute.Models.SubResource
    {
        public ImageReference() { }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ImageStorageProfile
    {
        public ImageStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.ImageDataDisk> DataDisks { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageOSDisk OsDisk { get { throw null; } set { } }
        public bool? ZoneResilient { get { throw null; } set { } }
    }
    public partial class ImageUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public ImageUpdate() { }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SubResource SourceVirtualMachine { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class InnerError
    {
        public InnerError() { }
        public string Errordetail { get { throw null; } set { } }
        public string Exceptiontype { get { throw null; } set { } }
    }
    public partial class InstanceViewStatus
    {
        public InstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StatusLevelTypes? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
    }
    public enum IntervalInMins
    {
        ThreeMins = 0,
        FiveMins = 1,
        ThirtyMins = 2,
        SixtyMins = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPVersion : System.IEquatable<Azure.ResourceManager.Compute.Models.IPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPVersion(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.IPVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.IPVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.IPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.IPVersion left, Azure.ResourceManager.Compute.Models.IPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.IPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.IPVersion left, Azure.ResourceManager.Compute.Models.IPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultAndKeyReference
    {
        public KeyVaultAndKeyReference(Azure.ResourceManager.Compute.Models.SourceVault sourceVault, string keyUrl) { }
        public string KeyUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SourceVault SourceVault { get { throw null; } set { } }
    }
    public partial class KeyVaultAndSecretReference
    {
        public KeyVaultAndSecretReference(Azure.ResourceManager.Compute.Models.SourceVault sourceVault, string secretUrl) { }
        public string SecretUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SourceVault SourceVault { get { throw null; } set { } }
    }
    public partial class KeyVaultKeyReference
    {
        public KeyVaultKeyReference(string keyUrl, Azure.ResourceManager.Compute.Models.SubResource sourceVault) { }
        public string KeyUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource SourceVault { get { throw null; } set { } }
    }
    public partial class KeyVaultSecretReference
    {
        public KeyVaultSecretReference(string secretUrl, Azure.ResourceManager.Compute.Models.SubResource sourceVault) { }
        public string SecretUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource SourceVault { get { throw null; } set { } }
    }
    public partial class LinuxConfiguration
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public bool? ProvisionVMAgent { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SshConfiguration Ssh { get { throw null; } set { } }
    }
    public partial class ListUsagesResult
    {
        internal ListUsagesResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.Usage> Value { get { throw null; } }
    }
    public partial class LogAnalyticsInputBase
    {
        public LogAnalyticsInputBase(string blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime) { }
        public string BlobContainerSasUri { get { throw null; } }
        public System.DateTimeOffset FromTime { get { throw null; } }
        public bool? GroupByOperationName { get { throw null; } set { } }
        public bool? GroupByResourceName { get { throw null; } set { } }
        public bool? GroupByThrottlePolicy { get { throw null; } set { } }
        public System.DateTimeOffset ToTime { get { throw null; } }
    }
    public partial class LogAnalyticsOperationResult
    {
        internal LogAnalyticsOperationResult() { }
        public Azure.ResourceManager.Compute.Models.LogAnalyticsOutput Properties { get { throw null; } }
    }
    public partial class LogAnalyticsOutput
    {
        internal LogAnalyticsOutput() { }
        public string Output { get { throw null; } }
    }
    public enum MaintenanceOperationResultCodeTypes
    {
        None = 0,
        RetryLater = 1,
        MaintenanceAborted = 2,
        MaintenanceCompleted = 3,
    }
    public partial class MaintenanceRedeployStatus
    {
        public MaintenanceRedeployStatus() { }
        public bool? IsCustomerInitiatedMaintenanceAllowed { get { throw null; } set { } }
        public string LastOperationMessage { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.MaintenanceOperationResultCodeTypes? LastOperationResultCode { get { throw null; } set { } }
        public System.DateTimeOffset? MaintenanceWindowEndTime { get { throw null; } set { } }
        public System.DateTimeOffset? MaintenanceWindowStartTime { get { throw null; } set { } }
        public System.DateTimeOffset? PreMaintenanceWindowEndTime { get { throw null; } set { } }
        public System.DateTimeOffset? PreMaintenanceWindowStartTime { get { throw null; } set { } }
    }
    public partial class ManagedDiskParameters : Azure.ResourceManager.Compute.Models.SubResource
    {
        public ManagedDiskParameters() { }
        public Azure.ResourceManager.Compute.Models.SubResource DiskEncryptionSet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
    }
    public partial class NetworkInterfaceReference : Azure.ResourceManager.Compute.Models.SubResource
    {
        public NetworkInterfaceReference() { }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.NetworkInterfaceReference> NetworkInterfaces { get { throw null; } set { } }
    }
    public enum OperatingSystemStateTypes
    {
        Generalized = 0,
        Specialized = 1,
    }
    public enum OperatingSystemTypes
    {
        Windows = 0,
        Linux = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationServiceState : System.IEquatable<Azure.ResourceManager.Compute.Models.OrchestrationServiceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceState NotRunning { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceState Running { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.OrchestrationServiceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.OrchestrationServiceState left, Azure.ResourceManager.Compute.Models.OrchestrationServiceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.OrchestrationServiceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.OrchestrationServiceState left, Azure.ResourceManager.Compute.Models.OrchestrationServiceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationServiceStateAction : System.IEquatable<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceStateAction(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction Resume { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction Suspend { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction left, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction left, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrchestrationServiceStateInput
    {
        public OrchestrationServiceStateInput(Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction action) { }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction Action { get { throw null; } }
        public string ServiceName { get { throw null; } }
    }
    public partial class OrchestrationServiceSummary
    {
        internal OrchestrationServiceSummary() { }
        public string ServiceName { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceState? ServiceState { get { throw null; } }
    }
    public partial class OSDisk
    {
        public OSDisk(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Image { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Vhd { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class OSDiskImage
    {
        public OSDiskImage(Azure.ResourceManager.Compute.Models.OperatingSystemTypes operatingSystem) { }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes OperatingSystem { get { throw null; } set { } }
    }
    public partial class OSDiskImageEncryption : Azure.ResourceManager.Compute.Models.DiskImageEncryption
    {
        public OSDiskImageEncryption() { }
    }
    public partial class OSProfile
    {
        public OSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class Plan
    {
        public Plan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public enum ProtocolTypes
    {
        Http = 0,
        Https = 1,
    }
    public partial class ProximityPlacementGroup : Azure.ResourceManager.Compute.Models.Resource
    {
        public ProximityPlacementGroup(string location) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResourceWithColocationStatus> AvailabilitySets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType? ProximityPlacementGroupType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResourceWithColocationStatus> VirtualMachines { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResourceWithColocationStatus> VirtualMachineScaleSets { get { throw null; } }
    }
    public partial class ProximityPlacementGroupListResult
    {
        internal ProximityPlacementGroupListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ProximityPlacementGroup> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProximityPlacementGroupType : System.IEquatable<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProximityPlacementGroupType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType Standard { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType Ultra { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType left, Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType left, Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProximityPlacementGroupUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public ProximityPlacementGroupUpdate() { }
    }
    public partial class PurchasePlan
    {
        public PurchasePlan(string publisher, string name, string product) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class RecommendedMachineConfiguration
    {
        public RecommendedMachineConfiguration() { }
        public Azure.ResourceManager.Compute.Models.ResourceRange Memory { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ResourceRange VCPUs { get { throw null; } set { } }
    }
    public partial class RecoveryWalkResponse
    {
        internal RecoveryWalkResponse() { }
        public int? NextPlatformUpdateDomain { get { throw null; } }
        public bool? WalkPerformed { get { throw null; } }
    }
    public partial class RegionalReplicationStatus
    {
        public RegionalReplicationStatus() { }
        public string Details { get { throw null; } }
        public int? Progress { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ReplicationState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationState : System.IEquatable<Azure.ResourceManager.Compute.Models.ReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ReplicationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ReplicationState Replicating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ReplicationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ReplicationState left, Azure.ResourceManager.Compute.Models.ReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ReplicationState left, Azure.ResourceManager.Compute.Models.ReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReplicationStatus
    {
        public ReplicationStatus() { }
        public Azure.ResourceManager.Compute.Models.AggregatedReplicationState? AggregatedState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RegionalReplicationStatus> Summary { get { throw null; } }
    }
    public partial class RequestRateByIntervalInput : Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase
    {
        public RequestRateByIntervalInput(string blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, Azure.ResourceManager.Compute.Models.IntervalInMins intervalLength) : base (default(string), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        public Azure.ResourceManager.Compute.Models.IntervalInMins IntervalLength { get { throw null; } }
    }
    public partial class Resource
    {
        public Resource(string location) { }
        public string Id { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    public partial class ResourceRange
    {
        public ResourceRange() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
    }
    public partial class ResourceSku
    {
        internal ResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ResourceSkuCapabilities
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceSkuCapacity
    {
        internal ResourceSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    public enum ResourceSkuCapacityScaleType
    {
        Automatic = 0,
        Manual = 1,
        None = 2,
    }
    public partial class ResourceSkuCosts
    {
        internal ResourceSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterID { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class ResourceSkuLocationInfo
    {
        internal ResourceSkuLocationInfo() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictionInfo
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictions
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionsType? Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public enum ResourceSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum ResourceSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class ResourceSkusResult
    {
        internal ResourceSkusResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSku> Value { get { throw null; } }
    }
    public partial class ResourceSkuZoneDetails
    {
        internal ResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    public partial class RollbackStatusInfo
    {
        internal RollbackStatusInfo() { }
        public int? FailedRolledbackInstanceCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ApiError RollbackError { get { throw null; } }
        public int? SuccessfullyRolledbackInstanceCount { get { throw null; } }
    }
    public enum RollingUpgradeActionType
    {
        Start = 0,
        Cancel = 1,
    }
    public partial class RollingUpgradePolicy
    {
        public RollingUpgradePolicy() { }
        public int? MaxBatchInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyUpgradedInstancePercent { get { throw null; } set { } }
        public string PauseTimeBetweenBatches { get { throw null; } set { } }
    }
    public partial class RollingUpgradeProgressInfo
    {
        public RollingUpgradeProgressInfo() { }
        public int? FailedInstanceCount { get { throw null; } }
        public int? InProgressInstanceCount { get { throw null; } }
        public int? PendingInstanceCount { get { throw null; } }
        public int? SuccessfulInstanceCount { get { throw null; } }
    }
    public partial class RollingUpgradeRunningStatus
    {
        public RollingUpgradeRunningStatus() { }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeStatusCode? Code { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeActionType? LastAction { get { throw null; } }
        public System.DateTimeOffset? LastActionTime { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
    }
    public enum RollingUpgradeStatusCode
    {
        RollingForward = 0,
        Cancelled = 1,
        Completed = 2,
        Faulted = 3,
    }
    public partial class RollingUpgradeStatusInfo : Azure.ResourceManager.Compute.Models.Resource
    {
        public RollingUpgradeStatusInfo(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradePolicy Policy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus RunningStatus { get { throw null; } }
    }
    public partial class RunCommandDocument : Azure.ResourceManager.Compute.Models.RunCommandDocumentBase
    {
        internal RunCommandDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition> Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Script { get { throw null; } }
    }
    public partial class RunCommandDocumentBase
    {
        internal RunCommandDocumentBase() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Label { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes OsType { get { throw null; } }
        public string Schema { get { throw null; } }
    }
    public partial class RunCommandInput
    {
        public RunCommandInput(string commandId) { }
        public string CommandId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Script { get { throw null; } set { } }
    }
    public partial class RunCommandInputParameter
    {
        public RunCommandInputParameter(string name, string value) { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class RunCommandListResult
    {
        internal RunCommandListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> Value { get { throw null; } }
    }
    public partial class RunCommandParameterDefinition
    {
        internal RunCommandParameterDefinition() { }
        public string DefaultValue { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Required { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class RunCommandResult
    {
        internal RunCommandResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Value { get { throw null; } }
    }
    public partial class ScaleInPolicy
    {
        public ScaleInPolicy() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules> Rules { get { throw null; } set { } }
    }
    public partial class ScheduledEventsProfile
    {
        public ScheduledEventsProfile() { }
        public Azure.ResourceManager.Compute.Models.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
    }
    public enum SettingNames
    {
        AutoLogon = 0,
        FirstLogonCommands = 1,
    }
    public partial class ShareInfoElement
    {
        public ShareInfoElement() { }
        public string VmUri { get { throw null; } }
    }
    public partial class Sku
    {
        public Sku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class Snapshot : Azure.ResourceManager.Compute.Models.Resource
    {
        public Snapshot(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.CreationData CreationData { get { throw null; } set { } }
        public long? DiskSizeBytes { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingsCollection EncryptionSettingsCollection { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public bool? Incremental { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SnapshotSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class SnapshotList
    {
        internal SnapshotList() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.Snapshot> Value { get { throw null; } }
    }
    public partial class SnapshotSku
    {
        public SnapshotSku() { }
        public Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotStorageAccountTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotStorageAccountTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes StandardZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes left, Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes left, Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotUpdate
    {
        public SnapshotUpdate() { }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingsCollection EncryptionSettingsCollection { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SnapshotSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class SourceVault
    {
        public SourceVault() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class SshConfiguration
    {
        public SshConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SshPublicKey> PublicKeys { get { throw null; } set { } }
    }
    public partial class SshPublicKey
    {
        public SshPublicKey() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class SshPublicKeyGenerateKeyPairResult
    {
        internal SshPublicKeyGenerateKeyPairResult() { }
        public string Id { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
    }
    public partial class SshPublicKeyResource : Azure.ResourceManager.Compute.Models.Resource
    {
        public SshPublicKeyResource(string location) : base (default(string)) { }
        public string PublicKey { get { throw null; } set { } }
    }
    public partial class SshPublicKeysGroupListResult
    {
        internal SshPublicKeysGroupListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.SshPublicKeyResource> Value { get { throw null; } }
    }
    public partial class SshPublicKeyUpdateResource : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public SshPublicKeyUpdateResource() { }
        public string PublicKey { get { throw null; } set { } }
    }
    public enum StatusLevelTypes
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.Compute.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType StandardZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.StorageAccountType left, Azure.ResourceManager.Compute.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.StorageAccountType left, Azure.ResourceManager.Compute.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.StorageAccountTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes UltraSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.StorageAccountTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.StorageAccountTypes left, Azure.ResourceManager.Compute.Models.StorageAccountTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.StorageAccountTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.StorageAccountTypes left, Azure.ResourceManager.Compute.Models.StorageAccountTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageProfile
    {
        public StorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDisk> DataDisks { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSDisk OsDisk { get { throw null; } set { } }
    }
    public partial class SubResource
    {
        public SubResource() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class SubResourceReadOnly
    {
        public SubResourceReadOnly() { }
        public string Id { get { throw null; } }
    }
    public partial class SubResourceWithColocationStatus : Azure.ResourceManager.Compute.Models.SubResource
    {
        public SubResourceWithColocationStatus() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
    }
    public partial class TargetRegion
    {
        public TargetRegion(string name) { }
        public Azure.ResourceManager.Compute.Models.EncryptionImages Encryption { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? RegionalReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
    }
    public partial class TerminateNotificationProfile
    {
        public TerminateNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
    }
    public partial class ThrottledRequestsInput : Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase
    {
        public ThrottledRequestsInput(string blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime) : base (default(string), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
    }
    public partial class UpdateResource
    {
        public UpdateResource() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class UpdateResourceDefinition
    {
        public UpdateResourceDefinition() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    public enum UpgradeMode
    {
        Automatic = 0,
        Manual = 1,
        Rolling = 2,
    }
    public partial class UpgradeOperationHistoricalStatusInfo
    {
        internal UpgradeOperationHistoricalStatusInfo() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class UpgradeOperationHistoricalStatusInfoProperties
    {
        internal UpgradeOperationHistoricalStatusInfoProperties() { }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollbackStatusInfo RollbackInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus RunningStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationInvoker? StartedBy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageReference TargetImageReference { get { throw null; } }
    }
    public partial class UpgradeOperationHistoryStatus
    {
        internal UpgradeOperationHistoryStatus() { }
        public Azure.ResourceManager.Compute.Models.UpgradeState? Code { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
    }
    public enum UpgradeOperationInvoker
    {
        Unknown = 0,
        User = 1,
        Platform = 2,
    }
    public partial class UpgradePolicy
    {
        public UpgradePolicy() { }
        public Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy AutomaticOSUpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UpgradeMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradePolicy RollingUpgradePolicy { get { throw null; } set { } }
    }
    public enum UpgradeState
    {
        RollingForward = 0,
        Cancelled = 1,
        Completed = 2,
        Faulted = 3,
    }
    public partial class Usage
    {
        internal Usage() { }
        public int CurrentValue { get { throw null; } }
        public long Limit { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class UserArtifactSource
    {
        public UserArtifactSource(string fileName, string mediaLink) { }
        public string FileName { get { throw null; } set { } }
        public string MediaLink { get { throw null; } set { } }
    }
    public partial class VaultCertificate
    {
        public VaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public string CertificateUrl { get { throw null; } set { } }
    }
    public partial class VaultSecretGroup
    {
        public VaultSecretGroup() { }
        public Azure.ResourceManager.Compute.Models.SubResource SourceVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultCertificate> VaultCertificates { get { throw null; } set { } }
    }
    public partial class VirtualHardDisk
    {
        public VirtualHardDisk() { }
        public string Uri { get { throw null; } set { } }
    }
    public partial class VirtualMachine : Azure.ResourceManager.Compute.Models.Resource
    {
        public VirtualMachine(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource AvailabilitySet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BillingProfile BillingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource Host { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SubResource ProximityPlacementGroup { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineExtension> Resources { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource VirtualMachineScaleSet { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } set { } }
    }
    public partial class VirtualMachineAgentInstanceView
    {
        public VirtualMachineAgentInstanceView() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } set { } }
        public string VmAgentVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineCaptureParameters
    {
        public VirtualMachineCaptureParameters(string vhdPrefix, string destinationContainerName, bool overwriteVhds) { }
        public string DestinationContainerName { get { throw null; } }
        public bool OverwriteVhds { get { throw null; } }
        public string VhdPrefix { get { throw null; } }
    }
    public partial class VirtualMachineCaptureResult : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineCaptureResult() { }
        public string ContentVersion { get { throw null; } }
        public object Parameters { get { throw null; } }
        public System.Collections.Generic.IList<object> Resources { get { throw null; } }
        public string Schema { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineEvictionPolicyTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineEvictionPolicyTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes left, Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes left, Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineExtension : Azure.ResourceManager.Compute.Models.Resource
    {
        public VirtualMachineExtension(string location) : base (default(string)) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionHandlerInstanceView
    {
        public VirtualMachineExtensionHandlerInstanceView() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionImage : Azure.ResourceManager.Compute.Models.Resource
    {
        public VirtualMachineExtensionImage(string location) : base (default(string)) { }
        public string ComputeRole { get { throw null; } set { } }
        public string HandlerSchema { get { throw null; } set { } }
        public string OperatingSystem { get { throw null; } set { } }
        public bool? SupportsMultipleExtensions { get { throw null; } set { } }
        public bool? VmScaleSetEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionInstanceView
    {
        public VirtualMachineExtensionInstanceView() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Substatuses { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionsListResult
    {
        internal VirtualMachineExtensionsListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtension> Value { get { throw null; } }
    }
    public partial class VirtualMachineExtensionUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public VirtualMachineExtensionUpdate() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineHealthStatus
    {
        public VirtualMachineHealthStatus() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
    }
    public partial class VirtualMachineIdentity
    {
        public VirtualMachineIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Compute.Models.Components1H8M3EpSchemasVirtualmachineidentityPropertiesUserassignedidentitiesAdditionalproperties> UserAssignedIdentities { get { throw null; } set { } }
    }
    public partial class VirtualMachineImage : Azure.ResourceManager.Compute.Models.VirtualMachineImageResource
    {
        public VirtualMachineImage(string name, string location) : base (default(string), default(string)) { }
        public Azure.ResourceManager.Compute.Models.AutomaticOSUpgradeProperties AutomaticOSUpgradeProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDiskImage> DataDiskImages { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSDiskImage OsDiskImage { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PurchasePlan Plan { get { throw null; } set { } }
    }
    public partial class VirtualMachineImageResource : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineImageResource(string name, string location) { }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class VirtualMachineInstanceView
    {
        public VirtualMachineInstanceView() { }
        public Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DiskInstanceView> Disks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationType? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } set { } }
        public string OsName { get { throw null; } set { } }
        public string OsVersion { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public int? PlatformUpdateDomain { get { throw null; } set { } }
        public string RdpThumbPrint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView VmAgent { get { throw null; } set { } }
    }
    public partial class VirtualMachineListResult
    {
        internal VirtualMachineListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachine> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePriorityTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePriorityTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes Low { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes Regular { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes left, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes left, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineReimageParameters
    {
        public VirtualMachineReimageParameters() { }
        public bool? TempDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSet : Azure.ResourceManager.Compute.Models.Resource
    {
        public VirtualMachineScaleSet(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVMs { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIdentity Identity { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMProfile VirtualMachineProfile { get { throw null; } set { } }
        public bool? ZoneBalance { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetDataDisk
    {
        public VirtualMachineScaleSetDataDisk(int lun, Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtension : Azure.ResourceManager.Compute.Models.SubResourceReadOnly
    {
        public VirtualMachineScaleSetExtension() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionListResult
    {
        internal VirtualMachineScaleSetExtensionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension> Value { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetExtensionProfile
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtension> Extensions { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionUpdate : Azure.ResourceManager.Compute.Models.SubResourceReadOnly
    {
        public VirtualMachineScaleSetExtensionUpdate() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public object ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetIdentity
    {
        public VirtualMachineScaleSetIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Compute.Models.ComponentsNj115SSchemasVirtualmachinescalesetidentityPropertiesUserassignedidentitiesAdditionalproperties> UserAssignedIdentities { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetInstanceView
    {
        internal VirtualMachineScaleSetInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMExtensionsSummary> Extensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary> OrchestrationServices { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceViewStatusesSummary VirtualMachine { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetInstanceViewStatusesSummary
    {
        internal VirtualMachineScaleSetInstanceViewStatusesSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> StatusesSummary { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetIPConfiguration : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineScaleSetIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> ApplicationGatewayBackendAddressPools { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> ApplicationSecurityGroups { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> LoadBalancerBackendAddressPools { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> LoadBalancerInboundNatPools { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ApiEntityReference Subnet { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetIpTag
    {
        public VirtualMachineScaleSetIpTag() { }
        public string IpTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetListOSUpgradeHistory
    {
        internal VirtualMachineScaleSetListOSUpgradeHistory() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo> Value { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetListResult
    {
        internal VirtualMachineScaleSetListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet> Value { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetListSkusResult
    {
        internal VirtualMachineScaleSetListSkusResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku> Value { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetListWithLinkResult
    {
        internal VirtualMachineScaleSetListWithLinkResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSet> Value { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetManagedDiskParameters
    {
        public VirtualMachineScaleSetManagedDiskParameters() { }
        public Azure.ResourceManager.Compute.Models.SubResource DiskEncryptionSet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineScaleSetNetworkConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration> IpConfigurations { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource NetworkSecurityGroup { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkConfigurationDnsSettings
    {
        public VirtualMachineScaleSetNetworkConfigurationDnsSettings() { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkProfile
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.ResourceManager.Compute.Models.ApiEntityReference HealthProbe { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetOSDisk
    {
        public VirtualMachineScaleSetOSDisk(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Image { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OsType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetOSProfile
    {
        public VirtualMachineScaleSetOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerNamePrefix { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIpTag> IpTags { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource PublicIPPrefix { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetReimageParameters : Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters
    {
        public VirtualMachineScaleSetReimageParameters() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineScaleSetScaleInRules : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineScaleSetScaleInRules(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules Default { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules NewestVM { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules OldestVM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules left, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules left, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineScaleSetSku
    {
        internal VirtualMachineScaleSetSku() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetSkuCapacity
    {
        internal VirtualMachineScaleSetSkuCapacity() { }
        public long? DefaultCapacity { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuScaleType? ScaleType { get { throw null; } }
    }
    public enum VirtualMachineScaleSetSkuScaleType
    {
        Automatic = 0,
        None = 1,
    }
    public partial class VirtualMachineScaleSetStorageProfile
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk OsDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public VirtualMachineScaleSetUpdate() { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVMs { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIdentity Identity { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVMProfile VirtualMachineProfile { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineScaleSetUpdateIPConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> ApplicationGatewayBackendAddressPools { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> ApplicationSecurityGroups { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> LoadBalancerBackendAddressPools { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SubResource> LoadBalancerInboundNatPools { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ApiEntityReference Subnet { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkConfiguration : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineScaleSetUpdateNetworkConfiguration() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration> IpConfigurations { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource NetworkSecurityGroup { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkProfile
    {
        public VirtualMachineScaleSetUpdateNetworkProfile() { }
        public Azure.ResourceManager.Compute.Models.ApiEntityReference HealthProbe { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateOSDisk
    {
        public VirtualMachineScaleSetUpdateOSDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Image { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateOSProfile
    {
        public VirtualMachineScaleSetUpdateOSProfile() { }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdatePublicIPAddressConfiguration
    {
        public VirtualMachineScaleSetUpdatePublicIPAddressConfiguration() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateStorageProfile
    {
        public VirtualMachineScaleSetUpdateStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk OsDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateVMProfile
    {
        public VirtualMachineScaleSetUpdateVMProfile() { }
        public Azure.ResourceManager.Compute.Models.BillingProfile BillingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVM : Azure.ResourceManager.Compute.Models.Resource
    {
        public VirtualMachineScaleSetVM(string location) : base (default(string)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource AvailabilitySet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public string InstanceId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMInstanceView InstanceView { get { throw null; } }
        public bool? LatestModelApplied { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public string ModelDefinitionApplied { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMNetworkProfileConfiguration NetworkProfileConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVMProtectionPolicy ProtectionPolicy { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineExtension> Resources { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVMExtensionsSummary
    {
        internal VirtualMachineScaleSetVMExtensionsSummary() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> StatusesSummary { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVMInstanceIDs
    {
        public VirtualMachineScaleSetVMInstanceIDs() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVMInstanceRequiredIDs
    {
        public VirtualMachineScaleSetVMInstanceRequiredIDs(System.Collections.Generic.IEnumerable<string> instanceIds) { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVMInstanceView
    {
        public VirtualMachineScaleSetVMInstanceView() { }
        public Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DiskInstanceView> Disks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } set { } }
        public string PlacementGroupId { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public int? PlatformUpdateDomain { get { throw null; } set { } }
        public string RdpThumbPrint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView VmAgent { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineHealthStatus VmHealth { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVMListResult
    {
        internal VirtualMachineScaleSetVMListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVM> Value { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVMNetworkProfileConfiguration
    {
        public VirtualMachineScaleSetVMNetworkProfileConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVMProfile
    {
        public VirtualMachineScaleSetVMProfile() { }
        public Azure.ResourceManager.Compute.Models.BillingProfile BillingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVMProtectionPolicy
    {
        public VirtualMachineScaleSetVMProtectionPolicy() { }
        public bool? ProtectFromScaleIn { get { throw null; } set { } }
        public bool? ProtectFromScaleSetActions { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVMReimageParameters : Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters
    {
        public VirtualMachineScaleSetVMReimageParameters() { }
    }
    public partial class VirtualMachineSize
    {
        internal VirtualMachineSize() { }
        public int? MaxDataDiskCount { get { throw null; } }
        public int? MemoryInMB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public int? OsDiskSizeInMB { get { throw null; } }
        public int? ResourceDiskSizeInMB { get { throw null; } }
    }
    public partial class VirtualMachineSizeListResult
    {
        internal VirtualMachineSizeListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineSize> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineSizeTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineSizeTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA0 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA2MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA4MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA8MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA8V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB1Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB1S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB2Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB2S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB4Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB8Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD15V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD16V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD2V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD32V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD4V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD64V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD8V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS11V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS12V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS132V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS134V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS144V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS148V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS14V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS15V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE16V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE2V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE3216V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE328SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE32V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE4V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE6416SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE6432SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE64V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE8V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF16 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF16S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF1S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF2S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF2SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF4S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF4SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF72SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF8S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS44 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS48 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS516 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS58 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH16 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH16M { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH16Mr { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH16R { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH8M { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardL32S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM12832Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM12864Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM128Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM128S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM6416Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM6432Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM64Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM64S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC12SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC12SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24R { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24RsV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24RsV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC6 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC6SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC6SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardND12S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardND24Rs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardND24S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardND6S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNV12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNV24 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes left, Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes left, Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineStatusCodeCount
    {
        internal VirtualMachineStatusCodeCount() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
    }
    public partial class VirtualMachineUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public VirtualMachineUpdate() { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource AvailabilitySet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BillingProfile BillingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource Host { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SubResource VirtualMachineScaleSet { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } set { } }
    }
    public partial class VMScaleSetConvertToSinglePlacementGroupInput
    {
        public VMScaleSetConvertToSinglePlacementGroupInput() { }
        public string ActivePlacementGroupId { get { throw null; } set { } }
    }
    public partial class WindowsConfiguration
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } set { } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public bool? ProvisionVMAgent { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WinRMConfiguration WinRM { get { throw null; } set { } }
    }
    public partial class WinRMConfiguration
    {
        public WinRMConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.WinRMListener> Listeners { get { throw null; } set { } }
    }
    public partial class WinRMListener
    {
        public WinRMListener() { }
        public string CertificateUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ProtocolTypes? Protocol { get { throw null; } set { } }
    }
}
