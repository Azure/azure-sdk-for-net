// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabArtifactResource" /> and their operations.
    /// Each <see cref="DevTestLabArtifactResource" /> in the collection will belong to the same instance of <see cref="DevTestLabArtifactSourceResource" />.
    /// To get a <see cref="DevTestLabArtifactCollection" /> instance call the GetDevTestLabArtifacts method from an instance of <see cref="DevTestLabArtifactSourceResource" />.
    /// </summary>
    public partial class DevTestLabArtifactCollection : ArmCollection, IEnumerable<DevTestLabArtifactResource>, IAsyncEnumerable<DevTestLabArtifactResource>
    {
        /// <summary>
        /// List artifacts in a given artifact source.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/artifactsources/{artifactSourceName}/artifacts
        /// Operation Id: Artifacts_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=title)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabArtifactResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabArtifactResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabArtifactResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabArtifactArtifactsClientDiagnostics.CreateScope("DevTestLabArtifactCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabArtifactArtifactsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabArtifactResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabArtifactResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabArtifactArtifactsClientDiagnostics.CreateScope("DevTestLabArtifactCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabArtifactArtifactsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabArtifactResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List artifacts in a given artifact source.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/artifactsources/{artifactSourceName}/artifacts
        /// Operation Id: Artifacts_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=title)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabArtifactResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabArtifactResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabArtifactResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabArtifactArtifactsClientDiagnostics.CreateScope("DevTestLabArtifactCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabArtifactArtifactsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabArtifactResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabArtifactResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabArtifactArtifactsClientDiagnostics.CreateScope("DevTestLabArtifactCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabArtifactArtifactsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabArtifactResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
