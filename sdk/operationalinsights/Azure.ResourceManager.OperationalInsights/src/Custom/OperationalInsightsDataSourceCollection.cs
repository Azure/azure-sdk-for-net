// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.OperationalInsights
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAllAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAll", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class OperationalInsightsDataSourceCollection
    {
        /// <summary>
        /// Gets the first page of data source instances in a workspace with the link to the next page.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/dataSources. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DataSources_ListByWorkspace. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-07-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="skipToken"> Starting point of the collection of data source instances. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="filter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> A collection of <see cref="OperationalInsightsDataSourceResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OperationalInsightsDataSourceResource> GetAllAsync(string filter, string skipToken = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filter, nameof(filter));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<OperationalInsightsDataSourceData, OperationalInsightsDataSourceResource>(new DataSourcesGetByWorkspaceAsyncCollectionResultOfT(
                _dataSourcesRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                filter,
                skipToken,
                context,
                "OperationalInsightsDataSourceCollection.GetAll"), data => new OperationalInsightsDataSourceResource(Client, data));
        }

        /// <summary>
        /// Gets the first page of data source instances in a workspace with the link to the next page.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/dataSources. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DataSources_ListByWorkspace. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-07-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="skipToken"> Starting point of the collection of data source instances. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="filter"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="filter"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> A collection of <see cref="OperationalInsightsDataSourceResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OperationalInsightsDataSourceResource> GetAll(string filter, string skipToken = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filter, nameof(filter));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<OperationalInsightsDataSourceData, OperationalInsightsDataSourceResource>(new DataSourcesGetByWorkspaceCollectionResultOfT(
                _dataSourcesRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                filter,
                skipToken,
                context,
                "OperationalInsightsDataSourceCollection.GetAll"), data => new OperationalInsightsDataSourceResource(Client, data));
        }
    }
}
