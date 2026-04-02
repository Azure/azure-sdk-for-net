// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class NGroupIdentity
    {
        /// <summary>
        /// Implicit conversion from <see cref="ManagedServiceIdentity"/> to <see cref="NGroupIdentity"/>
        /// to support backward-compatible model factory overloads.
        /// </summary>
        public static implicit operator NGroupIdentity(ManagedServiceIdentity value)
        {
            if (value == null)
            {
                return null;
            }
            return new NGroupIdentity();
        }
    }
}
