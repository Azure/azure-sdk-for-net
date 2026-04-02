// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat constructor shims for TypeSpec migration (ApiCompat MembersMustExist).

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupImageRegistryCredential
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupImageRegistryCredential"/>. </summary>
        /// <param name="server"> The server. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupImageRegistryCredential(string server)
            : this(server, default, default, default, default, default)
        {
        }

        /// <summary> Initializes a new instance of <see cref="ContainerGroupImageRegistryCredential"/>. </summary>
        /// <param name="server"> The server. </param>
        /// <param name="identity"> The identity. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupImageRegistryCredential(string server, string identity)
            : this(server, default, default, default, identity, default)
        {
        }
    }
}
