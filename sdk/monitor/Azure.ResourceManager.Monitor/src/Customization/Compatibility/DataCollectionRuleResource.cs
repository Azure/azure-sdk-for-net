// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Monitor
{
    public partial class DataCollectionRuleResource
    {
        /// <summary> Deletes a data collection rule. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => DeleteAsync(waitUntil, deleteAssociations: default, cancellationToken);

        /// <summary> Deletes a data collection rule. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => Delete(waitUntil, deleteAssociations: default, cancellationToken);

        /// <summary> Lists associations for the specified data collection rule. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of data collection rule associations. </returns>
        public virtual AsyncPageable<DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociationsByRuleAsync(CancellationToken cancellationToken = default)
            => GetByRuleAsync(cancellationToken: cancellationToken);

        /// <summary> Lists associations for the specified data collection rule. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of data collection rule associations. </returns>
        public virtual Pageable<DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociationsByRule(CancellationToken cancellationToken = default)
            => GetByRule(cancellationToken: cancellationToken);
    }
}
