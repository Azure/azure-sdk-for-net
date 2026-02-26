// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The SendMessage method's parameter type changed from
// UserSessionMessage to SendMessageParameterBody. These overloads preserve the old
// SendMessage(UserSessionMessage, CancellationToken) signature by wrapping the old type
// into the new body type, so existing callers are not broken.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class UserSessionResource
    {
        /// <summary> Send a message to a user. </summary>
        /// <param name="sendMessage"> Object containing message body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> SendMessageAsync(UserSessionMessage sendMessage, CancellationToken cancellationToken = default)
        {
            var body = new SendMessageParameterBody() { SendMessage = sendMessage };
            return await SendMessageAsync(body, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Send a message to a user. </summary>
        /// <param name="sendMessage"> Object containing message body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response SendMessage(UserSessionMessage sendMessage, CancellationToken cancellationToken = default)
        {
            var body = new SendMessageParameterBody() { SendMessage = sendMessage };
            return SendMessage(body, cancellationToken);
        }
    }
}
