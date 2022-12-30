// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DevTestLabs.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabGlobalScheduleResource" /> and their operations.
    /// Each <see cref="DevTestLabGlobalScheduleResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="DevTestLabGlobalScheduleCollection" /> instance call the GetDevTestLabGlobalSchedules method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class DevTestLabGlobalScheduleCollection : ArmCollection, IEnumerable<DevTestLabGlobalScheduleResource>, IAsyncEnumerable<DevTestLabGlobalScheduleResource>
    {
        /// <summary>
        /// List schedules in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/schedules
        /// Operation Id: GlobalSchedules_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabGlobalScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabGlobalScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DevTestLabGlobalScheduleCollectionGetAllOptions
            {
                Expand = expand,
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List schedules in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/schedules
        /// Operation Id: GlobalSchedules_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=status)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabGlobalScheduleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabGlobalScheduleResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new DevTestLabGlobalScheduleCollectionGetAllOptions
            {
                Expand = expand,
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);
    }
}
