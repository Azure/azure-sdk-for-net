// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
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
            => GetNotificationStatusAsync(Id.Parent.Name, Id.Name, notificationId, cancellationToken);

        /// <summary>
        /// Gets the notification status for this action group.
        /// </summary>
        /// <param name="notificationId">The ID of the notification.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        public virtual Response<NotificationStatus> GetNotificationStatus(string notificationId, CancellationToken cancellationToken = default)
            => GetNotificationStatus(Id.Parent.Name, Id.Name, notificationId, cancellationToken);
    }
}
