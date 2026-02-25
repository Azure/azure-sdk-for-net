// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
