// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Hub methods.
    /// </summary>
    public abstract class ServiceHub : IDisposable
    {
        /// <summary>
        /// Connect event method.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ConnectResponse or ErrorResponse.</returns>
        public abstract Task<ServiceResponse> Connect(ConnectEventRequest request);

        /// <summary>
        /// User event method.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>MessageResponse or ErrorResponse.</returns>
        public abstract Task<ServiceResponse> Message(MessageEventRequest request);

        /// <summary>
        /// Connected event method.
        /// </summary>
        /// <param name="request"></param>
        public virtual Task Connected(ConnectedEventRequest request)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Disconnected event method.
        /// </summary>
        /// <param name="request"></param>
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
