// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Monitor
{
    public static partial class MonitorExtensions
    {
        /// <summary>
        /// Sends test notifications to a set of provided receivers at resource group scope.
        /// </summary>
        /// <param name="resourceGroupResource">The <see cref="ResourceGroupResource"/> instance the method will execute against.</param>
        /// <param name="waitUntil">When to wait for completion of the long-running operation.</param>
        /// <param name="content">The notification request body which includes the contact details.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An operation for tracking notification progress.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="resourceGroupResource"/> is null.</exception>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMonitorResourceGroupResource(resourceGroupResource).CreateNotificationsAsync(waitUntil, content, cancellationToken);
        }

        /// <summary>
        /// Sends test notifications to a set of provided receivers at resource group scope.
        /// </summary>
        /// <param name="resourceGroupResource">The <see cref="ResourceGroupResource"/> instance the method will execute against.</param>
        /// <param name="waitUntil">When to wait for completion of the long-running operation.</param>
        /// <param name="content">The notification request body which includes the contact details.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An operation for tracking notification progress.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="resourceGroupResource"/> is null.</exception>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static ArmOperation<NotificationStatus> CreateNotifications(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMonitorResourceGroupResource(resourceGroupResource).CreateNotifications(waitUntil, content, cancellationToken);
        }

        /// <summary>
        /// Gets the test notification details at resource group scope by notification ID.
        /// </summary>
        /// <param name="resourceGroupResource">The <see cref="ResourceGroupResource"/> instance the method will execute against.</param>
        /// <param name="notificationId">The notification ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="resourceGroupResource"/> is null.</exception>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<NotificationStatus>> GetNotificationStatusAsync(this ResourceGroupResource resourceGroupResource, string notificationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMonitorResourceGroupResource(resourceGroupResource).GetNotificationStatusAsync(notificationId, cancellationToken);
        }

        /// <summary>
        /// Gets the test notification details at resource group scope by notification ID.
        /// </summary>
        /// <param name="resourceGroupResource">The <see cref="ResourceGroupResource"/> instance the method will execute against.</param>
        /// <param name="notificationId">The notification ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="resourceGroupResource"/> is null.</exception>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<NotificationStatus> GetNotificationStatus(this ResourceGroupResource resourceGroupResource, string notificationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableMonitorResourceGroupResource(resourceGroupResource).GetNotificationStatus(notificationId, cancellationToken);
        }

        /// <summary>
        /// Sends test notifications to a set of provided receivers at subscription scope.
        /// </summary>
        /// <param name="subscriptionResource">The <see cref="SubscriptionResource"/> instance the method will execute against.</param>
        /// <param name="waitUntil">When to wait for completion of the long-running operation.</param>
        /// <param name="content">The notification request body which includes the contact details.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An operation for tracking notification progress.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="subscriptionResource"/> is null.</exception>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMonitorSubscriptionResource(subscriptionResource).CreateNotificationsAsync(waitUntil, content, cancellationToken);
        }

        /// <summary>
        /// Sends test notifications to a set of provided receivers at subscription scope.
        /// </summary>
        /// <param name="subscriptionResource">The <see cref="SubscriptionResource"/> instance the method will execute against.</param>
        /// <param name="waitUntil">When to wait for completion of the long-running operation.</param>
        /// <param name="content">The notification request body which includes the contact details.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An operation for tracking notification progress.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="subscriptionResource"/> is null.</exception>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static ArmOperation<NotificationStatus> CreateNotifications(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMonitorSubscriptionResource(subscriptionResource).CreateNotifications(waitUntil, content, cancellationToken);
        }

        /// <summary>
        /// Gets the test notification details at subscription scope by notification ID.
        /// </summary>
        /// <param name="subscriptionResource">The <see cref="SubscriptionResource"/> instance the method will execute against.</param>
        /// <param name="notificationId">The notification ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="subscriptionResource"/> is null.</exception>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<NotificationStatus>> GetNotificationStatusAsync(this SubscriptionResource subscriptionResource, string notificationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMonitorSubscriptionResource(subscriptionResource).GetNotificationStatusAsync(notificationId, cancellationToken);
        }

        /// <summary>
        /// Gets the test notification details at subscription scope by notification ID.
        /// </summary>
        /// <param name="subscriptionResource">The <see cref="SubscriptionResource"/> instance the method will execute against.</param>
        /// <param name="notificationId">The notification ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="subscriptionResource"/> is null.</exception>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<NotificationStatus> GetNotificationStatus(this SubscriptionResource subscriptionResource, string notificationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableMonitorSubscriptionResource(subscriptionResource).GetNotificationStatus(notificationId, cancellationToken);
        }
    }
}
