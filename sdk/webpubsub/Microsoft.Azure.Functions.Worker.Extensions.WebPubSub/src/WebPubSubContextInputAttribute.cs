// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Provides <see cref="WebPubSubContext"/> from a Web PubSub client event with HttpTrigger.
    /// </summary>
    public sealed class WebPubSubContextInputAttribute : InputBindingAttribute
    {
        /// <summary>
        /// Allowed Web PubSub service connections used for Abuse Protection and signature checks.
        /// </summary>
        public string[] Connections { get; set; }

        /// <summary>
        /// Constructor to build the attribute.
        /// </summary>
        /// <param name="connections">Allowed service connections.</param>
        public WebPubSubContextInputAttribute(params string[] connections)
        {
            Connections = connections;
        }

        /// <summary>
        /// Constructor to build the attribute.
        /// </summary>
        public WebPubSubContextInputAttribute()
        {
        }
    }
}
