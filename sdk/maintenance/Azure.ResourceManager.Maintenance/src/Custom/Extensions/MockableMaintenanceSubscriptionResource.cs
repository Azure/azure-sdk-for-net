// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Maintenance.Mocking
{
    public partial class MockableMaintenanceSubscriptionResource
    {
        private ClientDiagnostics _maintenanceApplyUpdateApplyUpdatesClientDiagnostics;
        private ApplyUpdatesRestOperations _maintenanceApplyUpdateApplyUpdatesRestClient;

        private ClientDiagnostics MaintenanceApplyUpdateApplyUpdatesClientDiagnostics => _maintenanceApplyUpdateApplyUpdatesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Maintenance", MaintenanceApplyUpdateResource.ResourceType.Namespace, Diagnostics);
        private ApplyUpdatesRestOperations MaintenanceApplyUpdateApplyUpdatesRestClient => _maintenanceApplyUpdateApplyUpdatesRestClient ??= new ApplyUpdatesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(MaintenanceApplyUpdateResource.ResourceType));

        /// <summary>
        /// Get Configuration records within a subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/applyUpdates</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplyUpdates_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceApplyUpdateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MaintenanceApplyUpdateResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdates(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => MaintenanceApplyUpdateApplyUpdatesRestClient.CreateListRequest(Id.SubscriptionId);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new MaintenanceApplyUpdateResource(Client, MaintenanceApplyUpdateData.DeserializeMaintenanceApplyUpdateData(e)), MaintenanceApplyUpdateApplyUpdatesClientDiagnostics, Pipeline, "MockableMaintenanceSubscriptionResource.GetMaintenanceApplyUpdates", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get Configuration records within a subscription
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/applyUpdates</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplyUpdates_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-10-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceApplyUpdateResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MaintenanceApplyUpdateResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdatesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => MaintenanceApplyUpdateApplyUpdatesRestClient.CreateListRequest(Id.SubscriptionId);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new MaintenanceApplyUpdateResource(Client, MaintenanceApplyUpdateData.DeserializeMaintenanceApplyUpdateData(e)), MaintenanceApplyUpdateApplyUpdatesClientDiagnostics, Pipeline, "MockableMaintenanceSubscriptionResource.GetMaintenanceApplyUpdates", "value", null, cancellationToken);
        }
    }
}
