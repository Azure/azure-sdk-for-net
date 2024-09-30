// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Attribute used to bind a parameter to an Web PubSub for Socket.IO. The attribute supports to invoke
    /// multiple kinds of operations to service. For details, <see cref="SocketIOAction"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class SocketIOAttribute : Attribute
    {
        /// <summary>
        /// The connection of target Web PubSub for Socket.IO.
        /// </summary>
        public string Connection { get; set; } = Constants.SocketIOConnectionStringName;

        /// <summary>
        /// Target hub.
        /// </summary>
        [AutoResolve]
        public string Hub { get; set; }
    }
}
