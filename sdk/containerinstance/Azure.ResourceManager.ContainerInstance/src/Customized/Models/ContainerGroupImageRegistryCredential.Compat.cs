// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

// Backward-compat constructor and property shims for TypeSpec migration.

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
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        public ContainerGroupImageRegistryCredential(string server, string identity)
            : this(server, default, default, default, identity, default)
        {
        }

        /// <summary> The identity for the private registry (as URI). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri IdentityUri
        {
            get => Identity != null ? (Uri.TryCreate(Identity, UriKind.Absolute, out var uri) ? uri : null) : null;
            set => Identity = value?.AbsoluteUri;
        }
    }
}
