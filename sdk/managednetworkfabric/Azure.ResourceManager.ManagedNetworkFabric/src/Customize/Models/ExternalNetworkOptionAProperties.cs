// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class ExternalNetworkOptionAProperties
    {
        // Backward compatibility shim for the TypeSpec migration. The generated constructor requires
        // VLAN and peer ASN values, while the shipped SDK allowed parameterless construction. Removing it
        // would break callers that initialize the optional properties after construction.
        /// <summary> Initializes a new instance of <see cref="ExternalNetworkOptionAProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ExternalNetworkOptionAProperties() : this(default, default)
        {
        }
    }
}
