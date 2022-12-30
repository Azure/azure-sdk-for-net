// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A class representing a collection of <see cref="VirtualMachineExtensionImageResource" /> and their operations.
    /// Each <see cref="VirtualMachineExtensionImageResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="VirtualMachineExtensionImageCollection" /> instance call the GetVirtualMachineExtensionImages method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class VirtualMachineExtensionImageCollection : ArmCollection, IEnumerable<VirtualMachineExtensionImageResource>, IAsyncEnumerable<VirtualMachineExtensionImageResource>
    {
        /// <summary>
        /// Gets a list of virtual machine extension image versions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions
        /// Operation Id: VirtualMachineExtensionImages_ListVersions
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> is null. </exception>
        /// <returns> An async collection of <see cref="VirtualMachineExtensionImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualMachineExtensionImageResource> GetAllAsync(string type, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new VirtualMachineExtensionImageCollectionGetAllOptions(type)
            {
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// Gets a list of virtual machine extension image versions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions
        /// Operation Id: VirtualMachineExtensionImages_ListVersions
        /// </summary>
        /// <param name="type"> The String to use. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="top"> The Integer to use. </param>
        /// <param name="orderby"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="type"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="type"/> is null. </exception>
        /// <returns> A collection of <see cref="VirtualMachineExtensionImageResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualMachineExtensionImageResource> GetAll(string type, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new VirtualMachineExtensionImageCollectionGetAllOptions(type)
            {
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);
    }
}
