namespace Microsoft.Azure.Management.Compute
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// VirtualMachinesOperations operations.
    /// </summary>
    internal partial class VirtualMachinesOperations : IServiceOperations<ComputeManagementClient>, IVirtualMachinesOperations
    {
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
        public async Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders)
        {
            return await DeleteWithHttpMessagesAsync(resourceGroupName, vmName, false, customHeaders, default(CancellationToken));
        }

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
        public async Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            return await DeleteWithHttpMessagesAsync(resourceGroupName, vmName, false, customHeaders, cancellationToken);
        }

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
        /// Headers that will be added to request.
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders)
        {
            return await BeginDeleteWithHttpMessagesAsync(resourceGroupName, vmName, false, customHeaders, default(CancellationToken));
        }


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
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string vmName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken)
        {
            return await BeginDeleteWithHttpMessagesAsync(resourceGroupName, vmName, false, customHeaders, cancellationToken);
        }
    }
}
