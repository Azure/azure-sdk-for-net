// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A Class representing a SiteInstanceProcess along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="SiteInstanceProcessResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetSiteInstanceProcessResource method.
    /// Otherwise you can get one from its parent resource <see cref="SiteInstanceResource"/> using the GetSiteInstanceProcess method.
    /// </summary>
    public partial class SiteInstanceProcessResource : ArmResource
    {
        /// <summary>
        /// Description for List the threads in a process by its ID for a specific scaled-out instance in a web site.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/threads</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListInstanceProcessThreads</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SiteInstanceProcessResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ProcessThreadInfo"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ProcessThreadInfo> GetInstanceProcessThreadsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _siteInstanceProcessWebAppsRestClient.CreateListInstanceProcessThreadsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _siteInstanceProcessWebAppsRestClient.CreateListInstanceProcessThreadsNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ProcessThreadInfo(WebAppProcessThreadInfo.DeserializeWebAppProcessThreadInfo(e)), _siteInstanceProcessWebAppsClientDiagnostics, Pipeline, "SiteInstanceProcessResource.GetInstanceProcessThreads", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Description for List the threads in a process by its ID for a specific scaled-out instance in a web site.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/threads</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WebApps_ListInstanceProcessThreads</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SiteInstanceProcessResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ProcessThreadInfo"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ProcessThreadInfo> GetInstanceProcessThreads(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _siteInstanceProcessWebAppsRestClient.CreateListInstanceProcessThreadsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _siteInstanceProcessWebAppsRestClient.CreateListInstanceProcessThreadsNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ProcessThreadInfo(WebAppProcessThreadInfo.DeserializeWebAppProcessThreadInfo(e)), _siteInstanceProcessWebAppsClientDiagnostics, Pipeline, "SiteInstanceProcessResource.GetInstanceProcessThreads", "value", "nextLink", cancellationToken);
        }
    }
}
