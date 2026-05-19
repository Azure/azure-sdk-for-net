// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.NotificationHubs.Mocking
{
    // Backward-compat: baseline had GetNotificationHubNamespaces overloads with CancellationToken-only parameter.
    public partial class MockableNotificationHubsSubscriptionResource
    {
        /// <summary> Lists all the available namespaces within the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(CancellationToken cancellationToken)
            => GetNotificationHubNamespacesAsync(null, null, cancellationToken);

        /// <summary> Lists all the available namespaces within the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NotificationHubNamespaceResource> GetNotificationHubNamespaces(CancellationToken cancellationToken)
            => GetNotificationHubNamespaces(null, null, cancellationToken);
    }
}
