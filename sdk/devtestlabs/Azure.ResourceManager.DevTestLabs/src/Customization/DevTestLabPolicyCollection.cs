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
    /// A class representing a collection of <see cref="DevTestLabPolicyResource" /> and their operations.
    /// Each <see cref="DevTestLabPolicyResource" /> in the collection will belong to the same instance of <see cref="DevTestLabResource" />.
    /// To get a <see cref="DevTestLabPolicyCollection" /> instance call the GetDevTestLabPolicies method from an instance of <see cref="DevTestLabResource" />.
    /// </summary>
    public partial class DevTestLabPolicyCollection : ArmCollection, IEnumerable<DevTestLabPolicyResource>, IAsyncEnumerable<DevTestLabPolicyResource>
    {
        /// <summary>
        /// List policies in a given policy set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/policysets/{policySetName}/policies
        /// Operation Id: Policies_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=description)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabPolicyResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabPolicyResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabPolicyPoliciesClientDiagnostics.CreateScope("DevTestLabPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabPolicyPoliciesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, _policySetName, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabPolicyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabPolicyResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabPolicyPoliciesClientDiagnostics.CreateScope("DevTestLabPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabPolicyPoliciesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, _policySetName, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabPolicyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List policies in a given policy set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/policysets/{policySetName}/policies
        /// Operation Id: Policies_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=description)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabPolicyResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabPolicyResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabPolicyPoliciesClientDiagnostics.CreateScope("DevTestLabPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabPolicyPoliciesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, _policySetName, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabPolicyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabPolicyResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabPolicyPoliciesClientDiagnostics.CreateScope("DevTestLabPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabPolicyPoliciesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, _policySetName, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabPolicyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
