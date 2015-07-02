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

    public static partial class VirtualMachineImagesOperationsExtensions
    {
            /// <summary>
            /// Gets a virtual machine image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static VirtualMachineImage Get(this IVirtualMachineImagesOperations operations, string location, string publisherName, string offer, string skus, string version)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineImagesOperations)s).GetAsync(location, publisherName, offer, skus, version), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a virtual machine image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<VirtualMachineImage> GetAsync( this IVirtualMachineImagesOperations operations, string location, string publisherName, string offer, string skus, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineImage> result = await operations.GetWithOperationResponseAsync(location, publisherName, offer, skus, version, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of virtual machine image offers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            public static VirtualMachineImageResourceList ListOffers(this IVirtualMachineImagesOperations operations, string location, string publisherName)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineImagesOperations)s).ListOffersAsync(location, publisherName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of virtual machine image offers.
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
            public static async Task<VirtualMachineImageResourceList> ListOffersAsync( this IVirtualMachineImagesOperations operations, string location, string publisherName, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineImageResourceList> result = await operations.ListOffersWithOperationResponseAsync(location, publisherName, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of virtual machine image publishers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            public static VirtualMachineImageResourceList ListPublishers(this IVirtualMachineImagesOperations operations, string location)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineImagesOperations)s).ListPublishersAsync(location), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of virtual machine image publishers.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualMachineImageResourceList> ListPublishersAsync( this IVirtualMachineImagesOperations operations, string location, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineImageResourceList> result = await operations.ListPublishersWithOperationResponseAsync(location, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of virtual machine image skus.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='offer'>
            /// </param>
            public static VirtualMachineImageResourceList ListSkus(this IVirtualMachineImagesOperations operations, string location, string publisherName, string offer)
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineImagesOperations)s).ListSkusAsync(location, publisherName, offer), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of virtual machine image skus.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
            /// <param name='location'>
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='offer'>
            /// </param>
            /// <param name='cancellationToken'>
            /// Cancellation token.
            /// </param>
            public static async Task<VirtualMachineImageResourceList> ListSkusAsync( this IVirtualMachineImagesOperations operations, string location, string publisherName, string offer, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineImageResourceList> result = await operations.ListSkusWithOperationResponseAsync(location, publisherName, offer, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Gets a list of virtual machine images.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static VirtualMachineImageResourceList List(this IVirtualMachineImagesOperations operations, string location, string publisherName, string offer, string skus, string parametersFilterExpressionunencoded = default(string))
            {
                return Task.Factory.StartNew(s => ((IVirtualMachineImagesOperations)s).ListAsync(location, publisherName, offer, skus, parametersFilterExpressionunencoded), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of virtual machine images.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method
            /// </param>
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
            public static async Task<VirtualMachineImageResourceList> ListAsync( this IVirtualMachineImagesOperations operations, string location, string publisherName, string offer, string skus, string parametersFilterExpressionunencoded = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<VirtualMachineImageResourceList> result = await operations.ListWithOperationResponseAsync(location, publisherName, offer, skus, parametersFilterExpressionunencoded, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
