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
        /// The connection setting names or configuration section names allowed for abuse protection and signature validation.
        /// </summary>
        public string[] Connections { get; set; }

        /// <summary>
        /// The connection setting name or configuration section name allowed for abuse protection and signature validation.
        /// Use <see cref="Connections"/> instead for multiple connections.
        /// If both <see cref="Connection"/> and <see cref="Connections"/> are set, <see cref="Connections"/> takes precedence.
        /// </summary>
        [Obsolete("Use Connections instead.")]
        public string Connection
        {
            get => Connections?.Length > 0 ? Connections[0] : null;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                if (Connections == null || Connections.Length == 0)
                {
                    Connections = new[] { value };
                }
            }
        }

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
