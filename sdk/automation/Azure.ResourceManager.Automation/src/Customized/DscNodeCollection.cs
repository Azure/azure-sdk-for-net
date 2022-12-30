// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Automation.Models;

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
        public virtual AsyncPageable<DscNodeResource> GetAllAsync(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DscNodeCollectionGetAllOptions
            {
                Filter = filter,
                Skip = skip,
                Top = top,
                Inlinecount = inlinecount
            }, cancellationToken);

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
        public virtual Pageable<DscNodeResource> GetAll(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default) =>
            GetAll(new DscNodeCollectionGetAllOptions
            {
                Filter = filter,
                Skip = skip,
                Top = top,
                Inlinecount = inlinecount
            }, cancellationToken);
    }
}
