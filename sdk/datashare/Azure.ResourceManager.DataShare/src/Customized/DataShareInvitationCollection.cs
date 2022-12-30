// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.DataShare.Models;

namespace Azure.ResourceManager.DataShare
{
    /// <summary>
    /// A class representing a collection of <see cref="DataShareInvitationResource" /> and their operations.
    /// Each <see cref="DataShareInvitationResource" /> in the collection will belong to the same instance of <see cref="DataShareResource" />.
    /// To get a <see cref="DataShareInvitationCollection" /> instance call the GetDataShareInvitations method from an instance of <see cref="DataShareResource" />.
    /// </summary>
    public partial class DataShareInvitationCollection : ArmCollection, IEnumerable<DataShareInvitationResource>, IAsyncEnumerable<DataShareInvitationResource>
    {
        /// <summary>
        /// List invitations in a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/invitations
        /// Operation Id: Invitations_ListByShare
        /// </summary>
        /// <param name="skipToken"> The continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataShareInvitationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataShareInvitationResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DataShareInvitationCollectionGetAllOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);

        /// <summary>
        /// List invitations in a share
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataShare/accounts/{accountName}/shares/{shareName}/invitations
        /// Operation Id: Invitations_ListByShare
        /// </summary>
        /// <param name="skipToken"> The continuation token. </param>
        /// <param name="filter"> Filters the results using OData syntax. </param>
        /// <param name="orderby"> Sorts the results using OData syntax. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataShareInvitationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataShareInvitationResource> GetAll(string skipToken = null, string filter = null, string orderby = null, CancellationToken cancellationToken = default) =>
            GetAll(new DataShareInvitationCollectionGetAllOptions
            {
                SkipToken = skipToken,
                Filter = filter,
                Orderby = orderby
            }, cancellationToken);
    }
}
