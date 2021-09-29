// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// A <see cref="Hub"/> activator abstraction.
    /// </summary>
    /// <typeparam name="THub">The hub type.</typeparam>
    public interface IHubActivator<THub> where THub : WebPubSubHub
    {
        /// <summary>
        /// Creates a hub.
        /// </summary>
        /// <returns>The created hub.</returns>
        THub Create();

        /// <summary>
        /// Releases the specified hub.
        /// </summary>
        /// <param name="hub">The hub to release.</param>
        void Release(THub hub);
    }
}
