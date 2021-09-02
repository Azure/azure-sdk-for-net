// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;

namespace Azure.Messaging.WebPubSub
{
    internal interface ITokenProvider
    {
        public Uri Endpoint { get; }

        /// <summary>
        /// Get access token that can access WebPubSub resources.
        /// </summary>
        /// <param name="audience"></param>
        /// <returns></returns>
        public AccessToken GetServerToken(string audience);

        /// <summary>
        /// Get access token that can access WebPubSub resources.
        /// </summary>
        /// <param name="audience"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<AccessToken> GetServerTokenAsync(string audience, CancellationToken token = default);

        /// <summary>
        /// Get access token for client to connect to WebPubSub resources.
        /// </summary>
        /// <param name="audience"></param>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <param name="expiresAt"></param>
        /// <returns></returns>
        public AccessToken GetClientToken(string audience,
                                          string userId,
                                          string[] roles,
                                          DateTimeOffset expiresAt);

        /// <summary>
        /// Get access token for client to connect to WebPubSub resources.
        /// </summary>
        /// <param name="audience"></param>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <param name="expiresAt"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<AccessToken> GetClientTokenAsync(string audience,
                                                     string userId,
                                                     string[] roles,
                                                     DateTimeOffset expiresAt,
                                                     CancellationToken token = default);
    }
}
