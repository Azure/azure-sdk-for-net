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
    /// A class representing a collection of <see cref="DscNodeConfigurationResource" /> and their operations.
    /// Each <see cref="DscNodeConfigurationResource" /> in the collection will belong to the same instance of <see cref="AutomationAccountResource" />.
    /// To get a <see cref="DscNodeConfigurationCollection" /> instance call the GetDscNodeConfigurations method from an instance of <see cref="AutomationAccountResource" />.
    /// </summary>
    public partial class DscNodeConfigurationCollection : ArmCollection, IEnumerable<DscNodeConfigurationResource>, IAsyncEnumerable<DscNodeConfigurationResource>
    {
        /// <summary>
        /// Retrieve a list of dsc node configurations.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodeConfigurations
        /// Operation Id: DscNodeConfiguration_ListByAutomationAccount
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="skip"> The number of rows to skip. </param>
        /// <param name="top"> The number of rows to take. </param>
        /// <param name="inlinecount"> Return total rows. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DscNodeConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DscNodeConfigurationResource> GetAllAsync(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DscNodeConfigurationResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dscNodeConfigurationRestClient.ListByAutomationAccountAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, skip, top, inlinecount, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DscNodeConfigurationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DscNodeConfigurationResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dscNodeConfigurationRestClient.ListByAutomationAccountNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, skip, top, inlinecount, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DscNodeConfigurationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Retrieve a list of dsc node configurations.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/nodeConfigurations
        /// Operation Id: DscNodeConfiguration_ListByAutomationAccount
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="skip"> The number of rows to skip. </param>
        /// <param name="top"> The number of rows to take. </param>
        /// <param name="inlinecount"> Return total rows. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DscNodeConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DscNodeConfigurationResource> GetAll(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default)
        {
            Page<DscNodeConfigurationResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dscNodeConfigurationRestClient.ListByAutomationAccount(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, skip, top, inlinecount, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DscNodeConfigurationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DscNodeConfigurationResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dscNodeConfigurationClientDiagnostics.CreateScope("DscNodeConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dscNodeConfigurationRestClient.ListByAutomationAccountNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, skip, top, inlinecount, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DscNodeConfigurationResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
