// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.StorageMover.Models
{
    /// <summary>
    /// The Credentials.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="AzureKeyVaultSmbCredentials"/>.
    /// </summary>
    public abstract partial class StorageMoverCredentials
    {
        /// <summary> Initializes a new instance of <see cref="StorageMoverCredentials"/> for deserialization. </summary>
        protected StorageMoverCredentials()    // The new MPG made this constructor private; change it back to protected to preserve backward compatibility.
        {
        }
    }
}
