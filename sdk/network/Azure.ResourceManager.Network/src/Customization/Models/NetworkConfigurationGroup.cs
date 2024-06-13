// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> The network configuration group resource. </summary>
    public partial class NetworkConfigurationGroup
    {
        /// <summary> Unique identifier for this resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? ResourceGuid { get; }
    }
}
