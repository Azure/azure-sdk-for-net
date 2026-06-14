// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    // Compatibility shim preserving the GA list-item pageable surface for account-level software update configurations.
    public partial class SoftwareUpdateConfigurationCollection : IEnumerable<SoftwareUpdateConfigurationCollectionItem>, IAsyncEnumerable<SoftwareUpdateConfigurationCollectionItem>
    {
        /// <summary>
        /// Get all software update configurations for the account.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AutomationAccounts_SoftwareUpdateConfigurationsList. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clientRequestId"> Identifies this specific client request. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SoftwareUpdateConfigurationCollectionItem"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SoftwareUpdateConfigurationCollectionItem> GetAllAsync(string clientRequestId = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new SoftwareUpdateConfigurationsGetSoftwareUpdateConfigurationsAsyncCollectionResultOfT(
                _softwareUpdateConfigurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                clientRequestId,
                filter,
                context,
                "SoftwareUpdateConfigurationCollection.GetAll");
        }

        /// <summary>
        /// Get all software update configurations for the account.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/softwareUpdateConfigurations. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> AutomationAccounts_SoftwareUpdateConfigurationsList. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="clientRequestId"> Identifies this specific client request. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SoftwareUpdateConfigurationCollectionItem"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SoftwareUpdateConfigurationCollectionItem> GetAll(string clientRequestId = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new SoftwareUpdateConfigurationsGetSoftwareUpdateConfigurationsCollectionResultOfT(
                _softwareUpdateConfigurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                clientRequestId,
                filter,
                context,
                "SoftwareUpdateConfigurationCollection.GetAll");
        }

        IEnumerator<SoftwareUpdateConfigurationCollectionItem> IEnumerable<SoftwareUpdateConfigurationCollectionItem>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SoftwareUpdateConfigurationCollectionItem> IAsyncEnumerable<SoftwareUpdateConfigurationCollectionItem>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
