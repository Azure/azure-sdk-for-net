// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Monitor
{
    public static partial class MonitorExtensions
    {
        /// <summary>
        /// Send test notifications to a set of provided receivers
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/createNotifications</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ActionGroups_PostTestNotifications</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The notification request body which includes the contact details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableMonitorSubscriptionResource(subscriptionResource).CreateNotificationsAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Send test notifications to a set of provided receivers
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/createNotifications</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ActionGroups_PostTestNotifications</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The notification request body which includes the contact details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<NotificationStatus> CreateNotifications(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableMonitorSubscriptionResource(subscriptionResource).CreateNotifications(waitUntil, content, cancellationToken);
        }

        /// <summary>
        /// Get the test notifications by the notification id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/notificationStatus/{notificationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ActionGroups_GetTestNotifications</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="notificationId"> The notification id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="notificationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="notificationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NotificationStatus>> GetNotificationStatusAsync(this SubscriptionResource subscriptionResource, string notificationId, CancellationToken cancellationToken = default)
        {
            return await GetMockableMonitorSubscriptionResource(subscriptionResource).GetNotificationStatusAsync(notificationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the test notifications by the notification id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Insights/notificationStatus/{notificationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ActionGroups_GetTestNotifications</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="notificationId"> The notification id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="notificationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="notificationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NotificationStatus> GetNotificationStatus(this SubscriptionResource subscriptionResource, string notificationId, CancellationToken cancellationToken = default)
        {
            return GetMockableMonitorSubscriptionResource(subscriptionResource).GetNotificationStatus(notificationId, cancellationToken);
        }

        /// <summary>
        /// Send test notifications to a set of provided receivers
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/createNotifications</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ActionGroups_CreateNotificationsAtResourceGroupLevel</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The notification request body which includes the contact details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            return await GetMockableMonitorResourceGroupResource(resourceGroupResource).CreateNotificationsAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Send test notifications to a set of provided receivers
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/createNotifications</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ActionGroups_CreateNotificationsAtResourceGroupLevel</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The notification request body which includes the contact details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation<NotificationStatus> CreateNotifications(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            return GetMockableMonitorResourceGroupResource(resourceGroupResource).CreateNotifications(waitUntil, content, cancellationToken);
        }

        /// <summary>
        /// Get the test notifications by the notification id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/notificationStatus/{notificationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ActionGroups_GetTestNotificationsAtResourceGroupLevel</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="notificationId"> The notification id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="notificationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="notificationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<NotificationStatus>> GetNotificationStatusAsync(this ResourceGroupResource resourceGroupResource, string notificationId, CancellationToken cancellationToken = default)
        {
            return await GetMockableMonitorResourceGroupResource(resourceGroupResource).GetNotificationStatusAsync(notificationId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the test notifications by the notification id
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Insights/notificationStatus/{notificationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ActionGroups_GetTestNotificationsAtResourceGroupLevel</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="notificationId"> The notification id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="notificationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="notificationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<NotificationStatus> GetNotificationStatus(this ResourceGroupResource resourceGroupResource, string notificationId, CancellationToken cancellationToken = default)
        {
            return GetMockableMonitorResourceGroupResource(resourceGroupResource).GetNotificationStatus(notificationId, cancellationToken);
        }
    }
}
