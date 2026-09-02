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
        // The TypeSpec generator currently emits extra optional parameters for these operations
        // (skipToken/top and deleteAssociations), so we preserve the stable overloads here.
        /// <summary>
        /// Lists associations for the current data collection rule.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A collection of data collection rule associations.</returns>
        public virtual AsyncPageable<DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociationsByRuleAsync(CancellationToken cancellationToken = default)
            => GetDataCollectionRuleAssociationsByRuleAsync(skipToken: default, top: default, cancellationToken: cancellationToken);

        /// <summary>
        /// Lists associations for the current data collection rule.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>A collection of data collection rule associations.</returns>
        public virtual Pageable<DataCollectionRuleAssociationResource> GetDataCollectionRuleAssociationsByRule(CancellationToken cancellationToken = default)
            => GetDataCollectionRuleAssociationsByRule(skipToken: default, top: default, cancellationToken: cancellationToken);

        /// <summary>
        /// Deletes this data collection rule.
        /// </summary>
        /// <param name="waitUntil">When to wait for completion of the long-running operation.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An operation for tracking delete progress.</returns>
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => DeleteAsync(waitUntil, deleteAssociations: default, cancellationToken: cancellationToken);

        /// <summary>
        /// Deletes this data collection rule.
        /// </summary>
        /// <param name="waitUntil">When to wait for completion of the long-running operation.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An operation for tracking delete progress.</returns>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => Delete(waitUntil, deleteAssociations: default, cancellationToken: cancellationToken);
    }
}
