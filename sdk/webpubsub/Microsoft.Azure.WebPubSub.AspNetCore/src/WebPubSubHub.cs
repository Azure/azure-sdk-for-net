﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Web PubSub hub methods.
    /// </summary>
    public abstract class WebPubSubHub
    {
        /// <summary>
        /// Connect event method.
        /// </summary>
        /// <param name="request"><see cref="ConnectedEventRequest"/> to get client connect request information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <returns>
        /// Build a valid <see cref="ConnectEventResponse"/> with ConnectEventRequest.CreateResponse().
        /// Throw <see cref="UnauthorizedAccessException"/> or <see cref="AuthenticationException"/> will result 401 <see cref="StatusCodes.Status401Unauthorized"/> status with user assigned error messages.
        /// Throw other exceptions will result 500 <see cref="StatusCodes.Status500InternalServerError"/> with user assigned error messages.
        /// </returns>
        public virtual ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
        {
            return default;
        }

        /// <summary>
        /// User event method.
        /// </summary>
        /// <param name="request"><see cref="UserEventRequest"/> to get client message request information.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to cancel the request.</param>
        /// <returns>
        /// Build a valid <see cref="UserEventResponse"/> with UserEventRequest.CreateResponse().
        /// Throw <see cref="UnauthorizedAccessException"/> or <see cref="AuthenticationException"/> will result 401 <see cref="StatusCodes.Status401Unauthorized"/> status with user assigned error messages.
        /// Throw other exceptions will result 500 <see cref="StatusCodes.Status500InternalServerError"/> with user assigned error messages.
        /// </returns>
        public virtual ValueTask<UserEventResponse> OnMessageReceivedAsync(UserEventRequest request, CancellationToken cancellationToken)
        {
            return default;
        }

        /// <summary>
        /// Connected event method.
        /// </summary>
        /// <param name="request"><see cref="ConnectedEventRequest"/> to get client connected request information.</param>
        public virtual Task OnConnectedAsync(ConnectedEventRequest request)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Disconnected event method.
        /// </summary>
        /// <param name="request"><see cref="DisconnectedEventRequest"/> to get client disconnected request information.</param>
        public virtual Task OnDisconnectedAsync(DisconnectedEventRequest request)
        {
            return Task.CompletedTask;
        }
    }
}
