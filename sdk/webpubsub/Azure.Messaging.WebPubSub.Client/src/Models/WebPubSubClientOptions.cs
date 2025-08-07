// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The set of options that can be specified when creating a <see cref="WebPubSubClient"/> instance.
    /// </summary>
    public class WebPubSubClientOptions
    {
        /// <summary>
        /// Get or set the protocol to use.
        /// </summary>
        public WebPubSubProtocol Protocol { get; set; } = new WebPubSubJsonReliableProtocol();

        /// <summary>
        /// Get or set whether to auto reconnect. If enabled, the client tries to reconnect after connection drop and unrecovered.
        /// </summary>
        public bool AutoReconnect { get; set; } = true;

        /// <summary>
        /// Get or set whether to auto rejoin groups after reconnecting. Groups that have joined by client will be rejoined after reconnection
        /// </summary>
        public bool AutoRejoinGroups { get; set; } = true;

        /// <summary>
        /// Get or set the retry options for message-related client operations, including
        /// <see cref="WebPubSubClient.JoinGroupAsync(string, long?, System.Threading.CancellationToken)"/>,
        /// <see cref="WebPubSubClient.LeaveGroupAsync(string, long?, System.Threading.CancellationToken)"/>,
        /// <see cref="WebPubSubClient.SendToGroupAsync(string, BinaryData, WebPubSubDataType, long?, bool, bool, System.Threading.CancellationToken)"/>,
        /// <see cref="WebPubSubClient.SendEventAsync(string, BinaryData, WebPubSubDataType, long?, bool, System.Threading.CancellationToken)"/>.
        /// </summary>
        public RetryOptions MessageRetryOptions { get; }

        /// <summary>
        /// Get or set the retry options for client connection management.
        /// </summary>
        internal RetryOptions ReconnectRetryOptions { get; }

        /// <summary>
        /// Construct a WebPubSubClientOptions
        /// </summary>
        public WebPubSubClientOptions()
        {
            MessageRetryOptions = Utils.GetRetryOptions();

            ReconnectRetryOptions = Utils.GetRetryOptions();
            ReconnectRetryOptions.MaxRetries = int.MaxValue;
            ReconnectRetryOptions.Delay = TimeSpan.FromSeconds(1);
            ReconnectRetryOptions.MaxDelay = TimeSpan.FromSeconds(5);
        }
    }
}
