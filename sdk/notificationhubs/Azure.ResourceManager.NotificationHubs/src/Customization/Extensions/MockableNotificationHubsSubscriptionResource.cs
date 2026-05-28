// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;

namespace Azure.ResourceManager.NotificationHubs.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableNotificationHubsSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Lists all the available namespaces within the subscription irrespective of the resourceGroups.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NotificationHubs/namespaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_ListAll</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NotificationHubNamespaceResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(CancellationToken cancellationToken)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => NotificationHubNamespaceNamespacesRestClient.CreateListAllRequest(Id.SubscriptionId, null, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => NotificationHubNamespaceNamespacesRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, null, null);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new NotificationHubNamespaceResource(Client, NotificationHubNamespaceData.DeserializeNotificationHubNamespaceData(e)), NotificationHubNamespaceNamespacesClientDiagnostics, Pipeline, "MockableNotificationHubsSubscriptionResource.GetNotificationHubNamespaces", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all the available namespaces within the subscription irrespective of the resourceGroups.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.NotificationHubs/namespaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Namespaces_ListAll</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NotificationHubNamespaceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NotificationHubNamespaceResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NotificationHubNamespaceResource> GetNotificationHubNamespaces(CancellationToken cancellationToken)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => NotificationHubNamespaceNamespacesRestClient.CreateListAllRequest(Id.SubscriptionId, null, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => NotificationHubNamespaceNamespacesRestClient.CreateListAllNextPageRequest(nextLink, Id.SubscriptionId, null, null);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new NotificationHubNamespaceResource(Client, NotificationHubNamespaceData.DeserializeNotificationHubNamespaceData(e)), NotificationHubNamespaceNamespacesClientDiagnostics, Pipeline, "MockableNotificationHubsSubscriptionResource.GetNotificationHubNamespaces", "value", "nextLink", cancellationToken);
        }
    }
}
