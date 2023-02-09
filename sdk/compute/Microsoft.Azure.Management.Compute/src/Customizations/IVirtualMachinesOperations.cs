namespace Microsoft.Azure.Management.Compute
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;
    using Microsoft.Azure.Management.Compute.Models;

    /// <summary>
    /// VirtualMachinesOperations operations.
    /// </summary>
    public partial interface IVirtualMachinesOperations
    {
        Task<AzureOperationResponse<IPage<VirtualMachine>>> ListWithHttpMessagesAsync(string resourceGroupName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken = default(CancellationToken));
        Task<AzureOperationResponse<IPage<VirtualMachine>>> ListAllWithHttpMessagesAsync(string statusOnly, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders);
        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);
        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders);
        /// <summary>
        /// The operation to delete a virtual machine.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmName'>
        /// The name of the virtual machine.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);

        Task<AzureOperationResponse> DeallocateWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);
        Task<AzureOperationResponse> DeallocateWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders);

        Task<AzureOperationResponse> BeginDeallocateWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);
        Task<AzureOperationResponse> BeginDeallocateWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders);

        Task<AzureOperationResponse> ReimageWithHttpMessagesAsync(string resourceGroupName, string vmName, bool? tempDisk = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<AzureOperationResponse> BeginReimageWithHttpMessagesAsync(string resourceGroupName, string vmName, bool? tempDisk = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
