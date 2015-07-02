namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    public static partial class VirtualMachineExtensionImagesOperationsExtensions
    {
            /// <summary>
            /// Gets a virtual machine extension image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='version'>
            /// </param>
            public static VirtualMachineExtensionImage Get(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, string type, string version)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineExtensionImagesOperations)s).GetAsync(location, publisherName, type, version), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a virtual machine extension image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<VirtualMachineExtensionImage> GetAsync( this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, string type, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineExtensionImage> result = await operations.GetWithOperationResponseAsync(location, publisherName, type, version, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of virtual machine extension image versions.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='parametersFilterExpressionunencoded'>
            /// </param>
            public static VirtualMachineImageResourceList ListVersions(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, string type, string parametersFilterExpressionunencoded = default(string))
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineExtensionImagesOperations)s).ListVersionsAsync(location, publisherName, type, parametersFilterExpressionunencoded), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of virtual machine extension image versions.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<VirtualMachineImageResourceList> ListVersionsAsync( this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, string type, string parametersFilterExpressionunencoded = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineImageResourceList> result = await operations.ListVersionsWithOperationResponseAsync(location, publisherName, type, parametersFilterExpressionunencoded, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of virtual machine extension image types.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            public static VirtualMachineImageResourceList ListTypes(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineExtensionImagesOperations)s).ListTypesAsync(location, publisherName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of virtual machine extension image types.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualMachineImageResourceList> ListTypesAsync( this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineImageResourceList> result = await operations.ListTypesWithOperationResponseAsync(location, publisherName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
