// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shim for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupPort
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupPort"/>. </summary>
        /// <param name="port"> The port number. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupPort(int port)
            : this(default, port, default)
        {
        }
    }
}
