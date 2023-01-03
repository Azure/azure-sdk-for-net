// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Synapse.Models;

namespace Azure.ResourceManager.Synapse
{
    /// <summary>
    /// A Class representing a SynapseSqlPool along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SynapseSqlPoolResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSynapseSqlPoolResource method.
    /// Otherwise you can get one from its parent resource <see cref="SynapseWorkspaceResource" /> using the GetSynapseSqlPool method.
    /// </summary>
    public partial class SynapseSqlPoolResource : ArmResource
    {
        /// <summary>
        /// Gets sensitivity labels of a given SQL pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/recommendedSensitivityLabels
        /// Operation Id: SqlPoolSensitivityLabels_ListRecommended
        /// </summary>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="skipToken"> An OData query option to indicate how many elements to skip in the collection. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SynapseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SynapseSensitivityLabelResource> GetRecommendedSqlPoolSensitivityLabelsAsync(bool? includeDisabledRecommendations = null, string skipToken = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetRecommendedSqlPoolSensitivityLabelsAsync(new SynapseSqlPoolResourceGetRecommendedSqlPoolSensitivityLabelsOptions
            {
                IncludeDisabledRecommendations = includeDisabledRecommendations,
                SkipToken = skipToken,
                Filter = filter
            }, cancellationToken);

        /// <summary>
        /// Gets sensitivity labels of a given SQL pool.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/recommendedSensitivityLabels
        /// Operation Id: SqlPoolSensitivityLabels_ListRecommended
        /// </summary>
        /// <param name="includeDisabledRecommendations"> Specifies whether to include disabled recommendations or not. </param>
        /// <param name="skipToken"> An OData query option to indicate how many elements to skip in the collection. </param>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SynapseSensitivityLabelResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SynapseSensitivityLabelResource> GetRecommendedSqlPoolSensitivityLabels(bool? includeDisabledRecommendations = null, string skipToken = null, string filter = null, CancellationToken cancellationToken = default) =>
            GetRecommendedSqlPoolSensitivityLabels(new SynapseSqlPoolResourceGetRecommendedSqlPoolSensitivityLabelsOptions
            {
                IncludeDisabledRecommendations = includeDisabledRecommendations,
                SkipToken = skipToken,
                Filter = filter
            }, cancellationToken);
    }
}
