// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Automation.Models;

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
        public virtual AsyncPageable<DscNodeConfigurationResource> GetAllAsync(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DscNodeConfigurationCollectionGetAllOptions
            {
                Filter = filter,
                Skip = skip,
                Top = top,
                Inlinecount = inlinecount
            }, cancellationToken);

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
        public virtual Pageable<DscNodeConfigurationResource> GetAll(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default) =>
            GetAll(new DscNodeConfigurationCollectionGetAllOptions
            {
                Filter = filter,
                Skip = skip,
                Top = top,
                Inlinecount = inlinecount
            }, cancellationToken);
    }
}
