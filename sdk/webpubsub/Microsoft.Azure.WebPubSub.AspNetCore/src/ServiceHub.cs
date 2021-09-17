// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Web PubSub hub methods.
    /// </summary>
    public abstract class ServiceHub : IDisposable
    {
        /// <summary>
        /// Connect event method.
        /// </summary>
        /// <param name="request"><see cref="ConnectedEventRequest"/> to get client connect request information.</param>
        /// <returns><see cref="ConnectResponse"/> or <see cref="ErrorResponse"/></returns>
        public abstract Task<ServiceResponse> Connect(ConnectEventRequest request);

        /// <summary>
        /// User event method.
        /// </summary>
        /// <param name="request"><see cref="MessageEventRequest"/> to get client message request information.</param>
        /// <returns><see cref="MessageResponse"/> or <see cref="ErrorResponse"/></returns>
        public abstract Task<ServiceResponse> Message(MessageEventRequest request);

        /// <summary>
        /// Connected event method.
        /// </summary>
        /// <param name="request"><see cref="ConnectedEventRequest"/> to get client connected request information.</param>
        public virtual Task Connected(ConnectedEventRequest request)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Disconnected event method.
        /// </summary>
        /// <param name="request"><see cref="DisconnectedEventRequest"/> to get client disconnected request information.</param>
        public virtual Task Disconnected(DisconnectedEventRequest request)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
