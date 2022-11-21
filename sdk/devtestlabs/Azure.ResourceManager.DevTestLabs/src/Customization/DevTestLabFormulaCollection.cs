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
    /// A class representing a collection of <see cref="DevTestLabFormulaResource" /> and their operations.
    /// Each <see cref="DevTestLabFormulaResource" /> in the collection will belong to the same instance of <see cref="DevTestLabResource" />.
    /// To get a <see cref="DevTestLabFormulaCollection" /> instance call the GetDevTestLabFormulas method from an instance of <see cref="DevTestLabResource" />.
    /// </summary>
    public partial class DevTestLabFormulaCollection : ArmCollection, IEnumerable<DevTestLabFormulaResource>, IAsyncEnumerable<DevTestLabFormulaResource>
    {
        /// <summary>
        /// List formulas in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/formulas
        /// Operation Id: Formulas_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=description)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabFormulaResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabFormulaResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabFormulaResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabFormulaFormulasClientDiagnostics.CreateScope("DevTestLabFormulaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabFormulaFormulasRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabFormulaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabFormulaResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabFormulaFormulasClientDiagnostics.CreateScope("DevTestLabFormulaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabFormulaFormulasRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabFormulaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List formulas in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/formulas
        /// Operation Id: Formulas_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=description)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabFormulaResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabFormulaResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabFormulaResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabFormulaFormulasClientDiagnostics.CreateScope("DevTestLabFormulaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabFormulaFormulasRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabFormulaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabFormulaResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabFormulaFormulasClientDiagnostics.CreateScope("DevTestLabFormulaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabFormulaFormulasRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabFormulaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
