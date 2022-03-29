// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Web PubSub service protocol with HttpTrigger.
    /// </summary>
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class WebPubSubContextAttribute : Attribute
    {
        /// <summary>
        /// Allowed Web PubSub service connections used for Abuse Protection and signature checks.
        /// </summary>
        public string[] Connections { get; set; }

        /// <summary>
        /// Constructor to build the attribute.
        /// </summary>
        /// <param name="connections">Allowed service connections.</param>
        public WebPubSubContextAttribute(params string[] connections)
        {
            Connections = connections;
        }

        /// <summary>
        /// Constructor to build the attribute.
        /// </summary>
        public WebPubSubContextAttribute()
        {
        }
    }
}
