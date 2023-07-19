namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// VirtualMachineScaleSetsOperations operations.
    /// </summary>
    public partial interface IVirtualMachineScaleSetsOperations
    {
        Task<AzureOperationResponse> DeallocateWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, IList<string> instanceIds, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<AzureOperationResponse> BeginDeallocateWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, IList<string> instanceIds, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<AzureOperationResponse<RecoveryWalkResponse>> ForceRecoveryServiceFabricPlatformUpdateDomainWalkWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, int platformUpdateDomain, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);
        /// <summary>
        /// Display information about a virtual machine scale set.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='vmScaleSetName'>
        /// The name of the VM scale set.
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
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<VirtualMachineScaleSet>> GetWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken);
      
      /// <summary>
      /// Display information about a virtual machine scale set.
      /// </summary>
      /// <param name='resourceGroupName'>
      /// The name of the resource group.
      /// </param>
      /// <param name='vmScaleSetName'>
      /// The name of the VM scale set.
      /// </param>
      /// <param name='customHeaders'>
      /// The headers that will be added to request.
      /// </param>
      /// <exception cref="Microsoft.Rest.Azure.CloudException">
      /// Thrown when the operation returned an invalid status code
      /// </exception>
      /// <exception cref="Microsoft.Rest.SerializationException">
      /// Thrown when unable to deserialize the response
      /// </exception>
      /// <exception cref="Microsoft.Rest.ValidationException">
      /// Thrown when a required parameter is null
      /// </exception>
      Task<AzureOperationResponse<VirtualMachineScaleSet>> GetWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName, Dictionary<string, List<string>> customHeaders);
      
      /// <summary>
      /// Display information about a virtual machine scale set.
      /// </summary>
      /// <param name='resourceGroupName'>
      /// The name of the resource group.
      /// </param>
      /// <param name='vmScaleSetName'>
      /// The name of the VM scale set.
      /// </param>
      /// <exception cref="Microsoft.Rest.Azure.CloudException">
      /// Thrown when the operation returned an invalid status code
      /// </exception>
      /// <exception cref="Microsoft.Rest.SerializationException">
      /// Thrown when unable to deserialize the response
      /// </exception>
      /// <exception cref="Microsoft.Rest.ValidationException">
      /// Thrown when a required parameter is null
      /// </exception>
      Task<AzureOperationResponse<VirtualMachineScaleSet>> GetWithHttpMessagesAsync(string resourceGroupName, string vmScaleSetName);
    }
    
}
