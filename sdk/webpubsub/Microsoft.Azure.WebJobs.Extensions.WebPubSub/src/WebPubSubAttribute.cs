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
        /// The configuration section name that resolves to the identity-based connection or a connection string of the service.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Target hub.
        /// </summary>
        [AutoResolve]
        public string Hub { get; set; }
    }
}
