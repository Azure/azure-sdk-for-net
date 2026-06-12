// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;

namespace Azure.ResourceManager.Monitor
{
    public partial class DataCollectionEndpointResource
    {
        /// <summary> Lists associations for the specified data collection endpoint. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of data collection rule associations. </returns>
        public virtual Pageable<DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociations(CancellationToken cancellationToken = default)
            => GetByDataCollectionEndpoint(cancellationToken);

        /// <summary> Lists associations for the specified data collection endpoint. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of data collection rule associations. </returns>
        public virtual AsyncPageable<DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociationsAsync(CancellationToken cancellationToken = default)
            => GetByDataCollectionEndpointAsync(cancellationToken);
    }
}
