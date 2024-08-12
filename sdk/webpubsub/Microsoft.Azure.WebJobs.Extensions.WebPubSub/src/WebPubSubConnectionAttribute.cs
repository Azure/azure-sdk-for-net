// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.WebPubSub;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Web PubSub client negotiate websocket url.
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class WebPubSubConnectionAttribute : Attribute
    {
        /// <summary>
        /// Target Web PubSub service connection string.
        /// </summary>
        [ConnectionString]
        public string Connection { get; set; } = Constants.WebPubSubConnectionStringName;

        /// <summary>
        /// Target hub name.
        /// </summary>
        [AutoResolve]
        public string Hub { get; set; }

        /// <summary>
        /// Client userId.
        /// </summary>
        [AutoResolve]
        public string UserId { get; set; }

        /// <summary>
        /// The client protocol.
        /// </summary>
        public WebPubSubClientProtocol ClientProtocol { get; set; } = WebPubSubClientProtocol.Default;
    }
}
