// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DevTestLabs.Models;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabNotificationChannelResource" /> and their operations.
    /// Each <see cref="DevTestLabNotificationChannelResource" /> in the collection will belong to the same instance of <see cref="DevTestLabResource" />.
    /// To get a <see cref="DevTestLabNotificationChannelCollection" /> instance call the GetDevTestLabNotificationChannels method from an instance of <see cref="DevTestLabResource" />.
    /// </summary>
    public partial class DevTestLabNotificationChannelCollection : ArmCollection, IEnumerable<DevTestLabNotificationChannelResource>, IAsyncEnumerable<DevTestLabNotificationChannelResource>
    {
        /// <summary>
        /// List notification channels in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/notificationchannels
        /// Operation Id: NotificationChannels_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=webHookUrl)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabNotificationChannelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabNotificationChannelResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DevTestLabNotificationChannelCollectionGetAllOptions
            {
                Expand = expand,
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List notification channels in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/notificationchannels
        /// Operation Id: NotificationChannels_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=webHookUrl)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabNotificationChannelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabNotificationChannelResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new DevTestLabNotificationChannelCollectionGetAllOptions
            {
                Expand = expand,
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);
    }
}
