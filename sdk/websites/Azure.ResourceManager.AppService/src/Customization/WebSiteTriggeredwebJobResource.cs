// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    public partial class WebSiteTriggeredwebJobResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="AppService.WebSiteTriggeredwebJobResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string slot, string webJobName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary>
        /// Description for Run a triggered web job for an app, or a deployment slot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/run</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_RunTriggeredWebJobSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RunTriggeredWebJobSlotAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteTriggeredwebJobWebAppsClientDiagnostics.CreateScope("WebSiteTriggeredwebJobResource.RunTriggeredWebJobSlot");
            scope.Start();
            try
            {
                var response = await _webSiteTriggeredwebJobWebAppsRestClient.RunTriggeredWebJobSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Run a triggered web job for an app, or a deployment slot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/triggeredwebjobs/{webJobName}/run</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_RunTriggeredWebJobSlot</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response RunTriggeredWebJobSlot(CancellationToken cancellationToken = default)
        {
            using var scope = _webSiteTriggeredwebJobWebAppsClientDiagnostics.CreateScope("WebSiteTriggeredwebJobResource.RunTriggeredWebJobSlot");
            scope.Start();
            try
            {
                var response = _webSiteTriggeredwebJobWebAppsRestClient.RunTriggeredWebJobSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
