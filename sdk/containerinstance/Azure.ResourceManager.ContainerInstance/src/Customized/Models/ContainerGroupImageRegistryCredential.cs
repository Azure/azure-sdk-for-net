// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Image registry credential. </summary>
    public partial class ContainerGroupImageRegistryCredential
    {
        /// <summary> Initializes a new instance of ContainerGroupImageRegistryCredential. </summary>
        /// <param name="server"> The Docker image registry server without a protocol such as &quot;http&quot; and &quot;https&quot;. </param>
        /// <param name="username"> The username for the private registry. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="server"/> or <paramref name="username"/> is null. </exception>
        [Obsolete("This method is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContainerGroupImageRegistryCredential(string server, string username)
        {
            Argument.AssertNotNull(server, nameof(server));
            Argument.AssertNotNull(username, nameof(username));

            Server = server;
            Username = username;
        }
    }
}
