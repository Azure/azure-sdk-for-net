// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Maintenance
{
    /// <summary>
    /// Partial class to add IEnumerable interface and GetAll methods for backward compatibility.
    /// The old (autorest-generated) SDK implemented IEnumerable/IAsyncEnumerable on this collection
    /// and had GetAll/GetAllAsync methods for listing.
    /// </summary>
    public partial class MaintenanceConfigurationCollection : IEnumerable<MaintenanceConfigurationResource>, IAsyncEnumerable<MaintenanceConfigurationResource>
    {
        private MaintenanceConfigurationsForResourceGroup _maintenanceConfigurationsForResourceGroupRestClient;

        private MaintenanceConfigurationsForResourceGroup GetForResourceGroupClient()
        {
            if (_maintenanceConfigurationsForResourceGroupRestClient == null)
            {
                TryGetApiVersion(MaintenanceConfigurationResource.ResourceType, out string apiVersion);
                _maintenanceConfigurationsForResourceGroupRestClient = new MaintenanceConfigurationsForResourceGroup(
                    _maintenanceConfigurationsClientDiagnostics,
                    Pipeline,
                    Endpoint,
                    apiVersion ?? "2023-10-01-preview");
            }
            return _maintenanceConfigurationsForResourceGroupRestClient;
        }

        /// <summary> Gets all maintenance configurations in the resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenanceConfigurationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            AsyncPageable<MaintenanceConfigurationData> source = new MaintenanceConfigurationsForResourceGroupGetAllAsyncCollectionResultOfT(
                GetForResourceGroupClient(),
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
                GetForResourceGroupClient(),
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                context);
            return new PageableWrapper<MaintenanceConfigurationData, MaintenanceConfigurationResource>(
                source,
                data => new MaintenanceConfigurationResource(Client, data));
        }

        IEnumerator<MaintenanceConfigurationResource> IEnumerable<MaintenanceConfigurationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MaintenanceConfigurationResource> IAsyncEnumerable<MaintenanceConfigurationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
