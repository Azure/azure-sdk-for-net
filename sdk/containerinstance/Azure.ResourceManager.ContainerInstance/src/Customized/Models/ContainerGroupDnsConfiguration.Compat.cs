// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupDnsConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupDnsConfiguration"/>. </summary>
        /// <param name="nameServers"> The name servers. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupDnsConfiguration(IEnumerable<string> nameServers)
            : this(nameServers?.ToList(), default, default, default)
        {
        }
    }
}
