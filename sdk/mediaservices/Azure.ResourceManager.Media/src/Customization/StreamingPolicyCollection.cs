// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Media.Models;

namespace Azure.ResourceManager.Media
{
    /// <summary>
    /// A class representing a collection of <see cref="StreamingPolicyResource" /> and their operations.
    /// Each <see cref="StreamingPolicyResource" /> in the collection will belong to the same instance of <see cref="MediaServicesAccountResource" />.
    /// To get a <see cref="StreamingPolicyCollection" /> instance call the GetStreamingPolicies method from an instance of <see cref="MediaServicesAccountResource" />.
    /// </summary>
    public partial class StreamingPolicyCollection : ArmCollection, IEnumerable<StreamingPolicyResource>, IAsyncEnumerable<StreamingPolicyResource>
    {
        /// <summary>
        /// Lists the Streaming Policies in the account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/streamingPolicies
        /// Operation Id: StreamingPolicies_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StreamingPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StreamingPolicyResource> GetAllAsync(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new StreamingPolicyCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// Lists the Streaming Policies in the account
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/streamingPolicies
        /// Operation Id: StreamingPolicies_List
        /// </summary>
        /// <param name="filter"> Restricts the set of items returned. </param>
        /// <param name="top"> Specifies a non-negative integer n that limits the number of items returned from a collection. The service returns the number of available items up to but not greater than the specified value n. </param>
        /// <param name="orderby"> Specifies the key by which the result collection should be ordered. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StreamingPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StreamingPolicyResource> GetAll(string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new StreamingPolicyCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Orderby = orderby
            }, cancellationToken);
    }
}
