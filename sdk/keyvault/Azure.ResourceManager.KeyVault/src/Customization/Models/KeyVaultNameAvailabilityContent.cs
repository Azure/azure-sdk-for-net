// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.KeyVault.Models
{
    public partial class KeyVaultNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="KeyVaultNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The vault name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public KeyVaultNameAvailabilityContent(string name) : this(name, "Microsoft.KeyVault/vaults")
        {
        }
    }
}
