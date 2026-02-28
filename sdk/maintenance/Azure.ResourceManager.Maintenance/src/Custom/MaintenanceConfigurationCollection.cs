// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.Maintenance
{
    /// <summary>
    /// Custom code: Adds GetAll/GetAllAsync methods to list maintenance configurations in the resource group.
    /// The emitter fix (PR #56624) correctly assigns the RG-scoped list operation to this resource,
    /// so the generated code now initializes _maintenanceConfigurationsForResourceGroupRestClient and
    /// implements IEnumerable/IAsyncEnumerable. This custom code only provides the GetAll/GetAllAsync
    /// pageable methods that wrap the generated CollectionResult types.
    /// </summary>
    public partial class MaintenanceConfigurationCollection
    {
        /// <summary> Gets all maintenance configurations in the resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenanceConfigurationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            AsyncPageable<MaintenanceConfigurationData> source = new MaintenanceConfigurationsForResourceGroupGetAllAsyncCollectionResultOfT(
                _maintenanceConfigurationsForResourceGroupRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                context);
            return new AsyncPageableWrapper<MaintenanceConfigurationData, MaintenanceConfigurationResource>(
                source,
                data => new MaintenanceConfigurationResource(Client, data));
        }

        /// <summary> Gets all maintenance configurations in the resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MaintenanceConfigurationResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            Pageable<MaintenanceConfigurationData> source = new MaintenanceConfigurationsForResourceGroupGetAllCollectionResultOfT(
                _maintenanceConfigurationsForResourceGroupRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                context);
            return new PageableWrapper<MaintenanceConfigurationData, MaintenanceConfigurationResource>(
                source,
                data => new MaintenanceConfigurationResource(Client, data));
        }
    }
}
