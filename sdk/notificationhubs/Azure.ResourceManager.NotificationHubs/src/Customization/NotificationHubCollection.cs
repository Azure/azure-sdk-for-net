// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.NotificationHubs.Models;

namespace Azure.ResourceManager.NotificationHubs
{
    // Backward-compat: baseline had CreateOrUpdate overloads accepting NotificationHubCreateOrUpdateContent
    // and GetAll overloads with CancellationToken-only parameter.
    public partial class NotificationHubCollection
    {
        /// <summary> Creates/Update a NotificationHub in a namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="notificationHubName"> The notification hub name. </param>
        /// <param name="content"> Parameters supplied to the create/update a NotificationHub Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<NotificationHubResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string notificationHubName, NotificationHubCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This method is obsolete and not supported.");
        }

        /// <summary> Creates/Update a NotificationHub in a namespace. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> or <see cref="WaitUntil.Started"/>. </param>
        /// <param name="notificationHubName"> The notification hub name. </param>
        /// <param name="content"> Parameters supplied to the create/update a NotificationHub Resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationHubResource> CreateOrUpdate(WaitUntil waitUntil, string notificationHubName, NotificationHubCreateOrUpdateContent content, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This method is obsolete and not supported.");
        }

        /// <summary> Lists the notification hubs associated with a namespace. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NotificationHubResource> GetAllAsync(CancellationToken cancellationToken)
            => GetAllAsync(null, null, cancellationToken);

        /// <summary> Lists the notification hubs associated with a namespace. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NotificationHubResource> GetAll(CancellationToken cancellationToken)
            => GetAll(null, null, cancellationToken);
    }
}
