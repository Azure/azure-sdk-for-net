// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Attribute used to bind a parameter to an Socket.IO negotiation result.
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class SocketIONegotiationAttribute : Attribute
    {
        /// <summary>
        /// Target Web PubSub for Socket.IO connection string.
        /// </summary>
        public string Connection { get; set; } = Constants.SocketIOConnectionStringName;

        /// <summary>
        /// Target hub name.
        /// </summary>
        [AutoResolve]
        public string Hub { get; set; }
    }
}
