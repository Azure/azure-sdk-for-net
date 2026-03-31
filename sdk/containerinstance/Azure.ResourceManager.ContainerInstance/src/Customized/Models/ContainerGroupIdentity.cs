// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerGroupIdentity
    {
        /// <summary>
        /// Implicit conversion from <see cref="ManagedServiceIdentity"/> to <see cref="ContainerGroupIdentity"/>
        /// to support backward-compatible model factory overloads.
        /// </summary>
        public static implicit operator ContainerGroupIdentity(ManagedServiceIdentity value)
        {
            if (value == null)
            {
                return null;
            }
            return new ContainerGroupIdentity();
        }
    }
}
