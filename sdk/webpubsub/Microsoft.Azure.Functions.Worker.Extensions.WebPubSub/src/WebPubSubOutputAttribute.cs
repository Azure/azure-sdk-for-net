// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Web PubSub. The attribute supports to invoke
    /// multiple kinds of operations to service. For details, <see cref="WebPubSubAction"/>.
    /// </summary>
    public sealed class WebPubSubOutputAttribute : OutputBindingAttribute
    {
        /// <summary>
        /// The connection of target Web PubSub service.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Target hub.
        /// </summary>
        public string Hub { get; set; }
    }
}
