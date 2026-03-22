// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.NotificationHubs.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NotificationHubs
{
    // Backward-compat: baseline had GetNotificationHubNamespaces overloads with CancellationToken-only parameter.
    public static partial class NotificationHubsExtensions
    {
        /// <summary> Lists all the available namespaces within the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNotificationHubsSubscriptionResource(subscriptionResource).GetNotificationHubNamespacesAsync(cancellationToken);
        }

        /// <summary> Lists all the available namespaces within the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<NotificationHubNamespaceResource> GetNotificationHubNamespaces(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableNotificationHubsSubscriptionResource(subscriptionResource).GetNotificationHubNamespaces(cancellationToken);
        }
    }
}
