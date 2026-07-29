// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.WebPubSub.Chat
{
    /// <summary>
    /// Options for generating a client access URI via
    /// <see cref="WebPubSubChatServiceClient.GetClientAccessUri(GetClientAccessTokenOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class GetClientAccessTokenOptions
    {
        /// <summary>
        /// Optional user ID to embed in the token. When set, the token is bound to this user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// How long the token remains valid. Defaults to one hour.
        /// </summary>
        public TimeSpan ExpiresAfter { get; set; } = TimeSpan.FromHours(1);
    }
}
