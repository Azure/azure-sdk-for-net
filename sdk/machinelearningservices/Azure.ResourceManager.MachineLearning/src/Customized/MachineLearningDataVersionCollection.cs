// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing a collection of <see cref="MachineLearningDataVersionResource" /> and their operations.
    /// Each <see cref="MachineLearningDataVersionResource" /> in the collection will belong to the same instance of <see cref="MachineLearningDataContainerResource" />.
    /// To get a <see cref="MachineLearningDataVersionCollection" /> instance call the GetMachineLearningDataVersions method from an instance of <see cref="MachineLearningDataContainerResource" />.
    /// </summary>
    public partial class MachineLearningDataVersionCollection
    {
        /// <summary>
        /// List data versions in the data container
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Please choose OrderBy value from ['createdtime', 'modifiedtime']. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="top">
        /// Top count of results, top count cannot be greater than the page size.
        ///                               If topCount &gt; page size, results with be default page size count will be returned
        /// </param>
        /// <param name="tags"> Comma-separated list of tag names (and optionally values). Example: tag1,tag2=value2. </param>
        /// <param name="listViewType"> [MachineLearningListViewType.ActiveOnly, MachineLearningListViewType.ArchivedOnly, MachineLearningListViewType.All]View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningDataVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningDataVersionResource> GetAllAsync(string orderBy, string skip, int? top, string tags, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
        {
            async Task<Page<MachineLearningDataVersionResource>> GetPageAsync(Uri nextLink)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = nextLink is null
                    ? _dataVersionsRestClient.CreateGetAllRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, orderBy, top, skip, tags, listViewType?.ToString(), context)
                    : _dataVersionsRestClient.CreateNextGetAllRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, orderBy, top, skip, tags, listViewType?.ToString(), context);
                using DiagnosticScope scope = _dataVersionsClientDiagnostics.CreateScope("MachineLearningDataVersionCollection.GetAll");
                scope.Start();
                try
                {
                    Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    DataVersionBaseResourceArmPaginatedResult result = DataVersionBaseResourceArmPaginatedResult.FromResponse(response);
                    return Page<MachineLearningDataVersionResource>.FromValues(
                        result.Value.Select(data => new MachineLearningDataVersionResource(Client, data)).ToList(),
                        GetContinuationToken(result.NextLink),
                        response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(
                _ => GetPageAsync(null),
                (nextLink, _) => GetPageAsync(new Uri(nextLink)));
        }

        /// <summary>
        /// List data versions in the data container
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/data/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Please choose OrderBy value from ['createdtime', 'modifiedtime']. </param>
        ///  <param name="skip"> Continuation token for pagination. </param>
        /// <param name="top">
        /// Top count of results, top count cannot be greater than the page size.
        ///                               If topCount &gt; page size, results with be default page size count will be returned
        /// </param>
        /// <param name="tags"> Comma-separated list of tag names (and optionally values). Example: tag1,tag2=value2. </param>
        /// <param name="listViewType"> [MachineLearningListViewType.ActiveOnly, MachineLearningListViewType.ArchivedOnly, MachineLearningListViewType.All]View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningDataVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningDataVersionResource> GetAll(string orderBy, string skip, int? top, string tags, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
        {
            Page<MachineLearningDataVersionResource> GetPage(Uri nextLink)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = nextLink is null
                    ? _dataVersionsRestClient.CreateGetAllRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, orderBy, top, skip, tags, listViewType?.ToString(), context)
                    : _dataVersionsRestClient.CreateNextGetAllRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, orderBy, top, skip, tags, listViewType?.ToString(), context);
                using DiagnosticScope scope = _dataVersionsClientDiagnostics.CreateScope("MachineLearningDataVersionCollection.GetAll");
                scope.Start();
                try
                {
                    Response response = Pipeline.ProcessMessage(message, context);
                    DataVersionBaseResourceArmPaginatedResult result = DataVersionBaseResourceArmPaginatedResult.FromResponse(response);
                    return Page<MachineLearningDataVersionResource>.FromValues(
                        result.Value.Select(data => new MachineLearningDataVersionResource(Client, data)).ToList(),
                        GetContinuationToken(result.NextLink),
                        response);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(
                _ => GetPage(null),
                (nextLink, _) => GetPage(new Uri(nextLink)));
        }

        /// <summary> List data versions in the data container. </summary>
        public virtual Pageable<MachineLearningDataVersionResource> GetAll(string orderBy = default, int? top = default, string skip = default, string tags = default, MachineLearningListViewType? listViewType = default, CancellationToken cancellationToken = default)
            => GetAll(orderBy, skip, top, tags, listViewType, cancellationToken);

        private static string GetContinuationToken(Uri nextLink)
            => nextLink?.IsAbsoluteUri == true ? nextLink.AbsoluteUri : nextLink?.OriginalString;
    }
}
