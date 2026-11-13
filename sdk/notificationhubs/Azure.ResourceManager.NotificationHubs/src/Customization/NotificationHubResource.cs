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
    // Backward-compat: baseline had DebugSend overloads accepting BinaryData parameter,
    // and Update overloads accepting NotificationHubUpdateContent.
    public partial class NotificationHubResource
    {
        /// <summary> Test send a push notification. </summary>
        /// <param name="anyObject"> Debug send parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NotificationHubTestSendResult>> DebugSendAsync(BinaryData anyObject, CancellationToken cancellationToken)
            => await DebugSendAsync(cancellationToken).ConfigureAwait(false);

        /// <summary> Test send a push notification. </summary>
        /// <param name="anyObject"> Debug send parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationHubTestSendResult> DebugSend(BinaryData anyObject, CancellationToken cancellationToken)
            => DebugSend(cancellationToken);

        /// <summary> Patch a NotificationHub in a namespace. </summary>
        /// <param name="content"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NotificationHubResource>> UpdateAsync(NotificationHubUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is obsolete and not supported.");
        }

        /// <summary> Patch a NotificationHub in a namespace. </summary>
        /// <param name="content"> Request content. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete and will be removed in a future version.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationHubResource> Update(NotificationHubUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This method is obsolete and not supported.");
        }
    }
}
