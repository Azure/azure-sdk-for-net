// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    public partial class AppServicePlanHybridConnectionNamespaceRelayResource
    {
        /// <summary>
        /// Description for Get all apps that use a Hybrid Connection in an App Service Plan.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}/sites</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServicePlans_ListWebAppsByHybridConnection</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServicePlanHybridConnectionNamespaceRelayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="String"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<String> GetWebAppsByHybridConnectionAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _appServicePlanHybridConnectionNamespaceRelayAppServicePlansRestClient.CreateListWebAppsByHybridConnectionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _appServicePlanHybridConnectionNamespaceRelayAppServicePlansRestClient.CreateListWebAppsByHybridConnectionNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => WebSiteData.DeserializeWebSiteData(e).ToString(), _appServicePlanHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics, Pipeline, "AppServicePlanHybridConnectionNamespaceRelayResource.GetAllWebAppsByHybridConnection", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Description for Get all apps that use a Hybrid Connection in an App Service Plan.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/serverfarms/{name}/hybridConnectionNamespaces/{namespaceName}/relays/{relayName}/sites</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AppServicePlans_ListWebAppsByHybridConnection</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppServicePlanHybridConnectionNamespaceRelayResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="String"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<String> GetWebAppsByHybridConnection(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _appServicePlanHybridConnectionNamespaceRelayAppServicePlansRestClient.CreateListWebAppsByHybridConnectionRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _appServicePlanHybridConnectionNamespaceRelayAppServicePlansRestClient.CreateListWebAppsByHybridConnectionNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => WebSiteData.DeserializeWebSiteData(e).ToString(), _appServicePlanHybridConnectionNamespaceRelayAppServicePlansClientDiagnostics, Pipeline, "AppServicePlanHybridConnectionNamespaceRelayResource.GetAllWebAppsByHybridConnection", "value", "nextLink", cancellationToken);
        }
    }
}
