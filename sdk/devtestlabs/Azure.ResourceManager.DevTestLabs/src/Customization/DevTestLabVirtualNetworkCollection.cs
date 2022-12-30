// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DevTestLabs.Models;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabVirtualNetworkResource" /> and their operations.
    /// Each <see cref="DevTestLabVirtualNetworkResource" /> in the collection will belong to the same instance of <see cref="DevTestLabResource" />.
    /// To get a <see cref="DevTestLabVirtualNetworkCollection" /> instance call the GetDevTestLabVirtualNetworks method from an instance of <see cref="DevTestLabResource" />.
    /// </summary>
    public partial class DevTestLabVirtualNetworkCollection : ArmCollection, IEnumerable<DevTestLabVirtualNetworkResource>, IAsyncEnumerable<DevTestLabVirtualNetworkResource>
    {
        /// <summary>
        /// List virtual networks in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/virtualnetworks
        /// Operation Id: VirtualNetworks_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($expand=externalSubnets)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabVirtualNetworkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabVirtualNetworkResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DevTestLabVirtualNetworkCollectionGetAllOptions
            {
                Expand = expand,
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List virtual networks in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/virtualnetworks
        /// Operation Id: VirtualNetworks_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($expand=externalSubnets)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabVirtualNetworkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabVirtualNetworkResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new DevTestLabVirtualNetworkCollectionGetAllOptions
            {
                Expand = expand,
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);
    }
}
