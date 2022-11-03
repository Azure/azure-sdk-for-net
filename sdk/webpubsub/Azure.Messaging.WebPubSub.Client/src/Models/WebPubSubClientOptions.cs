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
    /// The set of options that can be specified when creating <see cref="WebPubSubClient"/> instance.
    /// </summary>
    public class WebPubSubClientOptions
    {
        /// <summary>
        /// Get or set the protocol to use.
        /// </summary>
        public WebPubSubProtocol Protocol { get; set; } = new WebPubSubJsonReliableProtocol();

        /// <summary>
        /// Get or set whether to auto reconnect
        /// </summary>
        public bool AutoReconnect { get; set; } = true;

        /// <summary>
        /// Get or set whether to auto restore groups after reconnecting
        /// </summary>
        public bool AutoRestoreGroups { get; set; } = true;

        /// <summary>
        /// Get or set the retry options for operations like joining group and sending messages
        /// </summary>
        public RetryOptions MessageRetryOptions { get; }

        /// <summary>
        /// Get or set the retry options for reconnecting
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
