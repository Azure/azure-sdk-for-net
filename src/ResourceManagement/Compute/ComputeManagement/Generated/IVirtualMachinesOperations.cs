namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IVirtualMachinesOperations
    {
        /// <summary>
        /// Captures the VM by copying VirtualHardDisks of the VM and outputs
        /// a template that can be used to create similar VMs.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Capture Virtual Machine operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> CaptureWithOperationResponseAsync(string resourceGroupName, string vmName, VirtualMachineCaptureParameters parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Captures the VM by copying VirtualHardDisks of the VM and outputs
        /// a template that can be used to create similar VMs.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Capture Virtual Machine operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginCaptureWithOperationResponseAsync(string resourceGroupName, string vmName, VirtualMachineCaptureParameters parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to create or update a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Virtual Machine operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachine>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string vmName, VirtualMachine parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to create or update a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Virtual Machine operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachine>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string vmName, VirtualMachine parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to get a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='expand'>
        /// Name of the property to expand. Allowed value is null or
        /// 'instanceView'.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachine>> GetWithOperationResponseAsync(string resourceGroupName, string vmName, string expand = default(string), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Shuts down the Virtual Machine and releases the compute resources.
        /// You are not billed for the compute resources that this Virtual
        /// Machine uses.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeallocateWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Shuts down the Virtual Machine and releases the compute resources.
        /// You are not billed for the compute resources that this Virtual
        /// Machine uses.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeallocateWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Sets the state of the VM as Generalized.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> GeneralizeWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to list virtual machines under a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineListResult>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the list of Virtual Machines in the subscription. Use
        /// nextLink property in the response to get the next page of Virtual
        /// Machines. Do this till nextLink is not null to fetch all the
        /// Virtual Machines.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineListResult>> ListAllWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists virtual-machine-sizes available to be used for a virtual
        /// machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineSizeListResult>> ListAvailableSizesWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the next page of Virtual Machines. NextLink is obtained by
        /// making a ListAll() callwhich fetches the first page of Virtual
        /// Machines and a link to fetch the next page.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to ListVirtualMachines
        /// operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to power off (stop) a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> PowerOffWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to power off (stop) a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginPowerOffWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to restart a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> RestartWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to restart a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginRestartWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to start a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> StartWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to start a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginStartWithOperationResponseAsync(string resourceGroupName, string vmName, CancellationToken cancellationToken = default(CancellationToken));
    }
}
