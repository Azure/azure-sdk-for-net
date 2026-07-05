// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    public partial class WebSiteSlotTriggeredWebJobResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="WebSiteSlotTriggeredWebJobResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string webJobName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary>
        /// Description for Run a triggered web job for an app, or a deployment slot.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/run</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_RunTriggeredWebJob</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> RunAsync(CancellationToken cancellationToken = default)
        {
            TryGetApiVersion(WebSiteTriggeredwebJobResource.ResourceType, out string apiVersion);
            var clientDiagnostics = new Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, Diagnostics);
            var restClient = new TriggeredWebJobOperationGroup(clientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2026-03-15");
            using var scope = clientDiagnostics.CreateScope("WebSiteSlotTriggeredWebJobResource.Run");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using var message = restClient.CreateRunTriggeredWebJobRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/triggeredwebjobs/{webJobName}/run</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_RunTriggeredWebJob</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Run(CancellationToken cancellationToken = default)
        {
            TryGetApiVersion(WebSiteTriggeredwebJobResource.ResourceType, out string apiVersion);
            var clientDiagnostics = new Azure.Core.Pipeline.ClientDiagnostics("Azure.ResourceManager.AppService", ResourceType.Namespace, Diagnostics);
            var restClient = new TriggeredWebJobOperationGroup(clientDiagnostics, Pipeline, Endpoint, apiVersion ?? "2026-03-15");
            using var scope = clientDiagnostics.CreateScope("WebSiteSlotTriggeredWebJobResource.Run");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                using var message = restClient.CreateRunTriggeredWebJobRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
