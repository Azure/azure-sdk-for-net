// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added peerAsn as a required constructor parameter.
    // This preserves the parameterless constructor from v1.1.2.
    public partial class InternalNetworkBgpConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="InternalNetworkBgpConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InternalNetworkBgpConfiguration() : this(default(long?))
        {
        }
    }
}
