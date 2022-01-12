// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Web PubSub. The attribute supports to invoke
    /// multiple kinds of operations to service. For details, <see cref="WebPubSubAction"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class WebPubSubAttribute : Attribute
    {
        /// <summary>
        /// The connection of target Web PubSub service.
        /// </summary>
        [ConnectionString]
        public string Connection { get; set; } = Constants.WebPubSubConnectionStringName;

        /// <summary>
        /// Target hub.
        /// </summary>
        [AutoResolve]
        public string Hub { get; set; }
    }
}
