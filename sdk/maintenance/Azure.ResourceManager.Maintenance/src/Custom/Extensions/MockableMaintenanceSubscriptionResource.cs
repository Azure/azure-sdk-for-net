// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;

namespace Azure.ResourceManager.Maintenance.Mocking
{
    // Backward-compat bridge: The TypeSpec migration uses OverrideResourceName on ExtensionOperations
    // in ApplyUpdate.tsp to create separate MaintenanceApplyUpdate*Resource/Collection classes per scope
    // variant. The old Swagger-based SDK (1.1.3) exposed subscription-level "GetMaintenanceApplyUpdates"
    // methods returning Pageable<MaintenanceApplyUpdateResource>. The new generated code produces
    // "GetMaintenanceApplyUpdateOperationGroups" returning Pageable<MaintenanceApplyUpdateOperationGroupResource>.
    // These bridge methods preserve the old method names and return types using the same REST client
    // (MaintenanceApplyUpdateRestClient) but wrapping results as MaintenanceApplyUpdateResource.
    public partial class MockableMaintenanceSubscriptionResource
    {
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
