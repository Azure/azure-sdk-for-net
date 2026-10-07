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
    /// A class representing a collection of <see cref="MachineLearningEnvironmentVersionResource" /> and their operations.
    /// Each <see cref="MachineLearningEnvironmentVersionResource" /> in the collection will belong to the same instance of <see cref="MachineLearningEnvironmentContainerResource" />.
    /// To get a <see cref="MachineLearningEnvironmentVersionCollection" /> instance call the GetMachineLearningEnvironmentVersions method from an instance of <see cref="MachineLearningEnvironmentContainerResource" />.
    /// </summary>
    public partial class MachineLearningEnvironmentVersionCollection
    {
        /// <summary>
        /// List versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/environments/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EnvironmentVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MachineLearningEnvironmentVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MachineLearningEnvironmentVersionResource> GetAllAsync(string orderBy, string skip, int? top, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
        {
            async Task<Page<MachineLearningEnvironmentVersionResource>> GetPageAsync(Uri nextLink)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = nextLink is null
                    ? _environmentVersionsRestClient.CreateGetAllRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, orderBy, top, skip, listViewType?.ToString(), context)
                    : _environmentVersionsRestClient.CreateNextGetAllRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, orderBy, top, skip, listViewType?.ToString(), context);
                using DiagnosticScope scope = _environmentVersionsClientDiagnostics.CreateScope("MachineLearningEnvironmentVersionCollection.GetAll");
                scope.Start();
                try
                {
                    Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    EnvironmentVersionResourceArmPaginatedResult result = EnvironmentVersionResourceArmPaginatedResult.FromResponse(response);
                    return Page<MachineLearningEnvironmentVersionResource>.FromValues(
                        result.Value.Select(data => new MachineLearningEnvironmentVersionResource(Client, data)).ToList(),
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
        /// List versions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/environments/{name}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>EnvironmentVersions_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="orderBy"> Ordering of list. </param>
        /// <param name="skip"> Continuation token for pagination. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="listViewType"> View type for including/excluding (for example) archived entities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MachineLearningEnvironmentVersionResource" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MachineLearningEnvironmentVersionResource> GetAll(string orderBy, string skip, int? top, MachineLearningListViewType? listViewType, CancellationToken cancellationToken)
        {
            Page<MachineLearningEnvironmentVersionResource> GetPage(Uri nextLink)
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using HttpMessage message = nextLink is null
                    ? _environmentVersionsRestClient.CreateGetAllRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, orderBy, top, skip, listViewType?.ToString(), context)
                    : _environmentVersionsRestClient.CreateNextGetAllRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, orderBy, top, skip, listViewType?.ToString(), context);
                using DiagnosticScope scope = _environmentVersionsClientDiagnostics.CreateScope("MachineLearningEnvironmentVersionCollection.GetAll");
                scope.Start();
                try
                {
                    Response response = Pipeline.ProcessMessage(message, context);
                    EnvironmentVersionResourceArmPaginatedResult result = EnvironmentVersionResourceArmPaginatedResult.FromResponse(response);
                    return Page<MachineLearningEnvironmentVersionResource>.FromValues(
                        result.Value.Select(data => new MachineLearningEnvironmentVersionResource(Client, data)).ToList(),
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

        /// <summary> List versions. </summary>
        public virtual Pageable<MachineLearningEnvironmentVersionResource> GetAll(string orderBy = default, int? top = default, string skip = default, MachineLearningListViewType? listViewType = default, CancellationToken cancellationToken = default)
            => GetAll(orderBy, skip, top, listViewType, cancellationToken);

        private static string GetContinuationToken(Uri nextLink)
            => nextLink?.IsAbsoluteUri == true ? nextLink.AbsoluteUri : nextLink?.OriginalString;
    }
}
