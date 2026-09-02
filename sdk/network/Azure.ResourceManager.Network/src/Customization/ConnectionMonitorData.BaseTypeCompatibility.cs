// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ConnectionMonitorData type. </summary>
    public partial class ConnectionMonitorData : ResourceData
    {
        /// <summary> Resource tags. </summary>
        [Azure.ResourceManager.Network.WirePath("tags")]
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
