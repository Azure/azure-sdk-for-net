// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Media.Models;

namespace Azure.ResourceManager.Media
{
    /// <summary>
    /// A class representing a collection of <see cref="StreamingLocatorResource" /> and their operations.
    /// Each <see cref="StreamingLocatorResource" /> in the collection will belong to the same instance of <see cref="MediaServicesAccountResource" />.
    /// To get a <see cref="StreamingLocatorCollection" /> instance call the GetStreamingLocators method from an instance of <see cref="MediaServicesAccountResource" />.
    /// </summary>
    public partial class StreamingLocatorCollection : ArmCollection, IEnumerable<StreamingLocatorResource>, IAsyncEnumerable<StreamingLocatorResource>
    {
        /// <summary>
        /// Lists the Streaming Locators in the account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/streamingLocators
        /// Operation Id: StreamingLocators_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StreamingLocatorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StreamingLocatorResource> GetAllAsync(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new StreamingLocatorCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// Lists the Streaming Locators in the account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/streamingLocators
        /// Operation Id: StreamingLocators_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StreamingLocatorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StreamingLocatorResource> GetAll(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new StreamingLocatorCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);
    }
}
