// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A class representing a collection of <see cref="DscConfigurationResource" /> and their operations.
    /// Each <see cref="DscConfigurationResource" /> in the collection will belong to the same instance of <see cref="AutomationAccountResource" />.
    /// To get a <see cref="DscConfigurationCollection" /> instance call the GetDscConfigurations method from an instance of <see cref="AutomationAccountResource" />.
    /// </summary>
    public partial class DscConfigurationCollection : ArmCollection, IEnumerable<DscConfigurationResource>, IAsyncEnumerable<DscConfigurationResource>
    {
        /// <summary>
        /// Retrieve a list of configurations.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/configurations
        /// Operation Id: DscConfiguration_ListByAutomationAccount
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="skip"> The number of rows to skip. </param>
        /// <param name="top"> The number of rows to take. </param>
        /// <param name="inlinecount"> Return total rows. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DscConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DscConfigurationResource> GetAllAsync(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new DscConfigurationCollectionGetAllOptions
            {
                Filter = filter,
                Skip = skip,
                Top = top,
                Inlinecount = inlinecount
            }, cancellationToken);

        /// <summary>
        /// Retrieve a list of configurations.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Automation/automationAccounts/{automationAccountName}/configurations
        /// Operation Id: DscConfiguration_ListByAutomationAccount
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="skip"> The number of rows to skip. </param>
        /// <param name="top"> The number of rows to take. </param>
        /// <param name="inlinecount"> Return total rows. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DscConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DscConfigurationResource> GetAll(string filter = null, int? skip = null, int? top = null, string inlinecount = null, CancellationToken cancellationToken = default) =>
            GetAll(new DscConfigurationCollectionGetAllOptions
            {
                Filter = filter,
                Skip = skip,
                Top = top,
                Inlinecount = inlinecount
            }, cancellationToken);
    }
}
