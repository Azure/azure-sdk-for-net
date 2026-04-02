// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupIPAddress
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupIPAddress"/>. </summary>
        /// <param name="ports"> The ports. </param>
        /// <param name="type"> The IP address type. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupIPAddress(IEnumerable<ContainerGroupPort> ports, ContainerGroupIPAddressType type)
            : this(ports?.ToList(), type, default, default, default, default, default)
        {
        }
    }
}
