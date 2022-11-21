// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A class representing a collection of <see cref="DscNodeResource" /> and their operations.
    /// Each <see cref="DscNodeResource" /> in the collection will belong to the same instance of <see cref="AutomationAccountResource" />.
    /// To get a <see cref="DscNodeCollection" /> instance call the GetDscNodes method from an instance of <see cref="AutomationAccountResource" />.
    /// </summary>
    public partial class DscNodeCollection : ArmCollection, IEnumerable<DscNodeResource>, IAsyncEnumerable<DscNodeResource>
    {
        /// <summary>
        /// Retrieve a list of dsc nodes.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes
        /// Operation Id: DscNode_ListByAutomationAccount
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="skip"> The number of rows to skip. </param>
        /// <param name="top"> The number of rows to take. </param>
        /// <param name="inlinecount"> Return total rows. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DscNodeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DscNodeResource> GetAllAsync(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DscNodeResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dscNodeRestClient.ListByAutomationAccountAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, skip, top, inlinecount, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DscNodeResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DscNodeResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dscNodeRestClient.ListByAutomationAccountNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, skip, top, inlinecount, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DscNodeResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Retrieve a list of dsc nodes.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodes
        /// Operation Id: DscNode_ListByAutomationAccount
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="skip"> The number of rows to skip. </param>
        /// <param name="top"> The number of rows to take. </param>
        /// <param name="inlinecount"> Return total rows. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DscNodeResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DscNodeResource> GetAll(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default)
        {
            Page<DscNodeResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dscNodeRestClient.ListByAutomationAccount(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, skip, top, inlinecount, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DscNodeResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DscNodeResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dscNodeClientDiagnostics.CreateScope("DscNodeCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dscNodeRestClient.ListByAutomationAccountNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, skip, top, inlinecount, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DscNodeResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
