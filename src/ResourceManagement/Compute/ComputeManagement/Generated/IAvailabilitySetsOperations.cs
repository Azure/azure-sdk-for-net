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
    public partial interface IAvailabilitySetsOperations
    {
        /// <summary>
        /// The operation to delete the availability set.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='availabilitySetName'>
        /// The name of the availability set.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string availabilitySetName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to get the availability set.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='availabilitySetName'>
        /// The name of the availability set.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<AvailabilitySet>> GetWithOperationResponseAsync(string resourceGroupName, string availabilitySetName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to list the availability sets.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<AvailabilitySetListResult>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Lists virtual-machine-sizes available to be used for an
        /// availability set.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='availabilitySetName'>
        /// The name of the availability set.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineSizeListResult>> ListAvailableSizesWithOperationResponseAsync(string resourceGroupName, string availabilitySetName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The operation to create or update the availability set.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='name'>
        /// Parameters supplied to the Create Availability Set operation.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Availability Set operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<AvailabilitySet>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string name, AvailabilitySet parameters, CancellationToken cancellationToken = default(CancellationToken));
    }
}
