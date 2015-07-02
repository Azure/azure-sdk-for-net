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
    public partial interface IVirtualMachineExtensionImagesOperations
    {
        /// <summary>
        /// Gets a virtual machine extension image.
        /// </summary>
        /// <param name='location'>
        /// </param>
        /// <param name='publisherName'>
        /// </param>
        /// <param name='type'>
        /// </param>
        /// <param name='version'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineExtensionImage>> GetWithOperationResponseAsync(string location, string publisherName, string type, string version, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of virtual machine extension image versions.
        /// </summary>
        /// <param name='location'>
        /// </param>
        /// <param name='publisherName'>
        /// </param>
        /// <param name='type'>
        /// </param>
        /// <param name='parametersFilterExpressionunencoded'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineImageResourceList>> ListVersionsWithOperationResponseAsync(string location, string publisherName, string type, string parametersFilterExpressionunencoded = default(string), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets a list of virtual machine extension image types.
        /// </summary>
        /// <param name='location'>
        /// </param>
        /// <param name='publisherName'>
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<VirtualMachineImageResourceList>> ListTypesWithOperationResponseAsync(string location, string publisherName, CancellationToken cancellationToken = default(CancellationToken));
    }
}
