// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Grafana.Models;

namespace Azure.ResourceManager.Grafana
{
    public partial class ManagedGrafanaResource
    {
        /// <summary>
        /// A synchronous resource action.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Dashboard/grafana/{workspaceName}/fetchAvailablePlugins. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedGrafanas_FetchAvailablePlugins. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedGrafanaResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GrafanaAvailablePlugin"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<GrafanaAvailablePlugin> FetchAvailablePluginsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new ManagedGrafanasFetchAvailablePluginsAsyncCollectionResultOfT(_managedGrafanasRestClient, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
        }

        /// <summary>
        /// A synchronous resource action.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Dashboard/grafana/{workspaceName}/fetchAvailablePlugins. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ManagedGrafanas_FetchAvailablePlugins. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-09-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ManagedGrafanaResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="GrafanaAvailablePlugin"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<GrafanaAvailablePlugin> FetchAvailablePlugins(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new ManagedGrafanasFetchAvailablePluginsCollectionResultOfT(_managedGrafanasRestClient, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
        }

        /// <summary>
        /// Update a workspace for Grafana resource.
        /// </summary>
        /// <param name="patch"> The parameters to update the Grafana resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ManagedGrafanaResource> Update(ManagedGrafanaPatch patch, CancellationToken cancellationToken = default)
        {
            return Update(WaitUntil.Completed, patch, cancellationToken).WaitForCompletion(cancellationToken);
        }

        /// <summary>
        /// Update a workspace for Grafana resource.
        /// </summary>
        /// <param name="patch"> The parameters to update the Grafana resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ManagedGrafanaResource>> UpdateAsync(ManagedGrafanaPatch patch, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
