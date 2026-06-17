// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    public partial class ActionGroupResource
    {
        /// <summary>
        /// Gets the notification status for this action group.
        /// </summary>
        /// <param name="notificationId">The ID of the notification.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        public virtual Task<Response<NotificationStatus>> GetNotificationStatusAsync(string notificationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(notificationId, nameof(notificationId));

            using DiagnosticScope scope = _actionGroupsClientDiagnostics.CreateScope("ActionGroupResource.GetNotificationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _actionGroupsRestClient.CreateGetNotificationStatusRequest(Guid.Parse(Id.SubscriptionId), Id.Parent.Name, Id.Name, notificationId, context);
                return GetNotificationStatusAsync(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the notification status for this action group.
        /// </summary>
        /// <param name="notificationId">The ID of the notification.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        public virtual Response<NotificationStatus> GetNotificationStatus(string notificationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(notificationId, nameof(notificationId));

            using DiagnosticScope scope = _actionGroupsClientDiagnostics.CreateScope("ActionGroupResource.GetNotificationStatus");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _actionGroupsRestClient.CreateGetNotificationStatusRequest(Guid.Parse(Id.SubscriptionId), Id.Parent.Name, Id.Name, notificationId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(NotificationStatus.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<NotificationStatus>> GetNotificationStatusAsync(HttpMessage message, RequestContext context)
        {
            Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            return Response.FromValue(NotificationStatus.FromResponse(result), result);
        }
    }
}
