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
    // Backward-compat: baseline had DebugSend overloads accepting BinaryData parameter.
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
    }
}
