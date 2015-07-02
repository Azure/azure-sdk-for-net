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
    public partial interface IVirtualMachineImagesOperations
    {
        /// <summary>
        /// Gets a virtual machine image.
        /// </summary>
        /// <param name='location'>
        /// </param>
        /// <param name='publisherName'>
        /// </param>
        /// <param name='offer'>
        /// </param>
        /// <param name='skus'>
        /// </param>
        /// <param name='version'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineImage>> GetWithOperationResponseAsync(string location, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of virtual machine image offers.
        /// </summary>
        /// <param name='location'>
        /// </param>
        /// <param name='publisherName'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineImageResourceList>> ListOffersWithOperationResponseAsync(string location, string publisherName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of virtual machine image publishers.
        /// </summary>
        /// <param name='location'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineImageResourceList>> ListPublishersWithOperationResponseAsync(string location, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of virtual machine image skus.
        /// </summary>
        /// <param name='location'>
        /// </param>
        /// <param name='publisherName'>
        /// </param>
        /// <param name='offer'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineImageResourceList>> ListSkusWithOperationResponseAsync(string location, string publisherName, string offer, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of virtual machine images.
        /// </summary>
        /// <param name='location'>
        /// </param>
        /// <param name='publisherName'>
        /// </param>
        /// <param name='offer'>
        /// </param>
        /// <param name='skus'>
        /// </param>
        /// <param name='parametersFilterExpressionunencoded'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineImageResourceList>> ListWithOperationResponseAsync(string location, string publisherName, string offer, string skus, string parametersFilterExpressionunencoded = default(string), CancellationToken cancellationToken = default(CancellationToken));
    }
}
