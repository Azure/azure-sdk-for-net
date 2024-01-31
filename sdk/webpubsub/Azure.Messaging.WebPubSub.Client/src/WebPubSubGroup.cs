// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// Web PubSub Group operations
    /// </summary>
    internal class WebPubSubGroup
    {
        public bool Joined { get; set; }

        internal WebPubSubGroup(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name of group
        /// </summary>
        public string Name { get; }
    }
}
