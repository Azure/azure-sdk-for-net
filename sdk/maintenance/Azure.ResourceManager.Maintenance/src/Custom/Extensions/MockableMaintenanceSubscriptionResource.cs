// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Mocking
{
    // The subscription list is emitted as an extension without an applyUpdates resource
    // version lookup. Keep that lookup for both the generated and compatibility methods.
    // Remove this workaround once https://github.com/Azure/azure-sdk-for-net/issues/65190 is fixed.
    [CodeGenSuppress(nameof(MaintenanceApplyUpdateRestClient))]
    public partial class MockableMaintenanceSubscriptionResource
    {
        private MaintenanceApplyUpdate MaintenanceApplyUpdateRestClient => _maintenanceApplyUpdateRestClient ??= new MaintenanceApplyUpdate(
            MaintenanceApplyUpdateClientDiagnostics, Pipeline, Diagnostics.ApplicationId, Endpoint,
            TryGetApiVersion(MaintenanceApplyUpdateResource.ResourceType, out string apiVersion) ? apiVersion : "2025-10-01-preview");

        // The compatibility methods wrap the same list response in the GA resource type.
        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdatesAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<MaintenanceApplyUpdateData, MaintenanceApplyUpdateResource>(
                new MaintenanceApplyUpdateGetAllAsyncCollectionResultOfT(MaintenanceApplyUpdateRestClient, Guid.Parse(Id.SubscriptionId), context, "MockableMaintenanceSubscriptionResource.GetMaintenanceApplyUpdates"),
                data => new MaintenanceApplyUpdateResource(Client, data));
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdates(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<MaintenanceApplyUpdateData, MaintenanceApplyUpdateResource>(
                new MaintenanceApplyUpdateGetAllCollectionResultOfT(MaintenanceApplyUpdateRestClient, Guid.Parse(Id.SubscriptionId), context, "MockableMaintenanceSubscriptionResource.GetMaintenanceApplyUpdates"),
                data => new MaintenanceApplyUpdateResource(Client, data));
        }
    }
}
