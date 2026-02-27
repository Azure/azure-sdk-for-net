// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Maintenance;

namespace Azure.ResourceManager.Maintenance.Mocking
{
    /// <summary>
    /// Backward-compatibility extension methods for MockableMaintenanceSubscriptionResource.
    /// </summary>
    public partial class MockableMaintenanceSubscriptionResource
    {
        private ClientDiagnostics _maintenanceConfigurationsClientDiagnostics;
        private MaintenanceConfigurations _maintenanceConfigurationsRestClient;
        private ClientDiagnostics _publicMaintenanceConfigurationsClientDiagnostics;
        private PublicMaintenanceConfigurations _publicMaintenanceConfigurationsRestClient;

        private ClientDiagnostics MaintenanceConfigurationsClientDiagnostics => _maintenanceConfigurationsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Maintenance.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);

        private MaintenanceConfigurations MaintenanceConfigurationsRestClient => _maintenanceConfigurationsRestClient ??= new MaintenanceConfigurations(MaintenanceConfigurationsClientDiagnostics, Pipeline, Endpoint, "2023-10-01-preview");

        private ClientDiagnostics PublicMaintenanceConfigurationsClientDiagnostics => _publicMaintenanceConfigurationsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Maintenance.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);

        private PublicMaintenanceConfigurations PublicMaintenanceConfigurationsRestClient => _publicMaintenanceConfigurationsRestClient ??= new PublicMaintenanceConfigurations(PublicMaintenanceConfigurationsClientDiagnostics, Pipeline, Endpoint, "2023-10-01-preview");

        /// <summary> Gets a collection of MaintenancePublicConfigurations in the SubscriptionResource. </summary>
        public virtual MaintenancePublicConfigurationCollection GetMaintenancePublicConfigurations()
        {
            return new MaintenancePublicConfigurationCollection(Client, Id);
        }

        /// <summary> Gets the specified public maintenance configuration. </summary>
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<MaintenancePublicConfigurationResource>> GetMaintenancePublicConfigurationAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            return await GetMaintenancePublicConfigurations().GetAsync(resourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specified public maintenance configuration. </summary>
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<MaintenancePublicConfigurationResource> GetMaintenancePublicConfiguration(string resourceName, CancellationToken cancellationToken = default)
        {
            return GetMaintenancePublicConfigurations().Get(resourceName, cancellationToken);
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenanceConfigurationResource> GetMaintenanceConfigurationsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<MaintenanceConfigurationData, MaintenanceConfigurationResource>(
                new MaintenanceConfigurationsGetAllAsyncCollectionResult(MaintenanceConfigurationsRestClient, Guid.Parse(Id.SubscriptionId), context),
                data => new MaintenanceConfigurationResource(Client, data));
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MaintenanceConfigurationResource> GetMaintenanceConfigurations(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<MaintenanceConfigurationData, MaintenanceConfigurationResource>(
                new MaintenanceConfigurationsGetAllCollectionResult(MaintenanceConfigurationsRestClient, Guid.Parse(Id.SubscriptionId), context),
                data => new MaintenanceConfigurationResource(Client, data));
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdatesAsync(CancellationToken cancellationToken = default)
        {
            return GetApplyUpdatesAsync(cancellationToken);
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdates(CancellationToken cancellationToken = default)
        {
            return GetApplyUpdates(cancellationToken);
        }
    }
}
