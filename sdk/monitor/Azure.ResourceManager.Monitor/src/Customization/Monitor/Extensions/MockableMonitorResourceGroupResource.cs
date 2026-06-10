// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorResourceGroupResource : ArmResource
    {
        private ClientDiagnostics _deprecatedActionGroupClientDiagnostics;
        private DeprecatedActionGroupsRestOperations _deprecatedActionGroupRestClient;

        private ClientDiagnostics DeprecatedActionGroupClientDiagnostics => _deprecatedActionGroupClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Monitor", ActionGroupResource.ResourceType.Namespace, Diagnostics);
        private DeprecatedActionGroupsRestOperations DeprecatedActionGroupRestClient => _deprecatedActionGroupRestClient ??= new DeprecatedActionGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(ActionGroupResource.ResourceType));

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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The notification request body which includes the contact details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = DeprecatedActionGroupClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.CreateNotifications");
            scope.Start();
            try
            {
                var response = await DeprecatedActionGroupRestClient.CreateNotificationsAtResourceGroupLevelAsync(Id.SubscriptionId, Id.ResourceGroupName, content, cancellationToken).ConfigureAwait(false);
                var operation = new MonitorArmOperation<NotificationStatus>(new NotificationStatusOperationSource(), DeprecatedActionGroupClientDiagnostics, Pipeline, DeprecatedActionGroupRestClient.CreateCreateNotificationsAtResourceGroupLevelRequest(Id.SubscriptionId, Id.ResourceGroupName, content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The notification request body which includes the contact details. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationStatus> CreateNotifications(WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = DeprecatedActionGroupClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.CreateNotifications");
            scope.Start();
            try
            {
                var response = DeprecatedActionGroupRestClient.CreateNotificationsAtResourceGroupLevel(Id.SubscriptionId, Id.ResourceGroupName, content, cancellationToken);
                var operation = new MonitorArmOperation<NotificationStatus>(new NotificationStatusOperationSource(), DeprecatedActionGroupClientDiagnostics, Pipeline, DeprecatedActionGroupRestClient.CreateCreateNotificationsAtResourceGroupLevelRequest(Id.SubscriptionId, Id.ResourceGroupName, content).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="notificationId"> The notification id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NotificationStatus>> GetNotificationStatusAsync(string notificationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(notificationId, nameof(notificationId));

            using var scope = DeprecatedActionGroupClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetNotificationStatus");
            scope.Start();
            try
            {
                var response = await DeprecatedActionGroupRestClient.GetTestNotificationsAtResourceGroupLevelAsync(Id.SubscriptionId, Id.ResourceGroupName, notificationId, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        /// <param name="notificationId"> The notification id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationStatus> GetNotificationStatus(string notificationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(notificationId, nameof(notificationId));

            using var scope = DeprecatedActionGroupClientDiagnostics.CreateScope("ResourceGroupResourceExtensionClient.GetNotificationStatus");
            scope.Start();
            try
            {
                var response = DeprecatedActionGroupRestClient.GetTestNotificationsAtResourceGroupLevel(Id.SubscriptionId, Id.ResourceGroupName, notificationId, cancellationToken);
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
