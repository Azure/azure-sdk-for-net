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
    // TypeSpec generation exposes jobs through the ARM resource collection shape.
    // Keep the GA enumerable/pageable GetAll surface returning AutomationJobCollectionItemData.
    public partial class AutomationJobCollection : IEnumerable<AutomationJobCollectionItemData>, IAsyncEnumerable<AutomationJobCollectionItemData>
    {
        /// <summary>
        /// Retrieve a list of jobs.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Job_ListByAutomationAccount</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="clientRequestId"> Identifies this specific client request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutomationJobCollectionItemData"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AutomationJobCollectionItemData> GetAllAsync(string filter = default, string clientRequestId = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new JobGetAutomationJobsAsyncCollectionResultOfT(
                _jobRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                filter,
                clientRequestId,
                context,
                "AutomationJobCollection.GetAll");
        }

        /// <summary>
        /// Retrieve a list of jobs.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/jobs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Job_ListByAutomationAccount</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="clientRequestId"> Identifies this specific client request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutomationJobCollectionItemData"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AutomationJobCollectionItemData> GetAll(string filter = default, string clientRequestId = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new JobGetAutomationJobsCollectionResultOfT(
                _jobRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Name,
                filter,
                clientRequestId,
                context,
                "AutomationJobCollection.GetAll");
        }

        IEnumerator<AutomationJobCollectionItemData> IEnumerable<AutomationJobCollectionItemData>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<AutomationJobCollectionItemData> IAsyncEnumerable<AutomationJobCollectionItemData>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
