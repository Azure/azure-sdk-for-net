// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    public partial class ActionGroupResource
    {
        /// <summary> Gets the test notifications by the notification id. </summary>
        /// <param name="notificationId"> The notification id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The notification status. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual Response<NotificationStatus> GetNotificationStatus(string notificationId, CancellationToken cancellationToken = default)
            => throw new System.NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the test notifications by the notification id. </summary>
        /// <param name="notificationId"> The notification id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The notification status. </returns>
        public virtual Task<Response<NotificationStatus>> GetNotificationStatusAsync(string notificationId, CancellationToken cancellationToken = default)
            => Task.FromException<Response<NotificationStatus>>(new System.NotSupportedException("This API is no longer supported."));
    }
}
