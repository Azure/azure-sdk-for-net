// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class BgpConfiguration
    {
        // Backward compatibility shim for the TypeSpec migration. The generated constructor requires a
        // peer ASN, while the shipped SDK allowed parameterless construction. Removing it would break
        // callers that initialize BgpConfiguration and set optional properties later.
        /// <summary> Initializes a new instance of <see cref="BgpConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BgpConfiguration()
            : this(default)
        {
        }
    }
}
