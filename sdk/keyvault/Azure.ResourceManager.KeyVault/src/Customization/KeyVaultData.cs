// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.KeyVault
{
    [CodeGenType("KeyVault")]
    public partial class KeyVaultData
    {
        /// <summary> Initializes a new instance of <see cref="KeyVaultData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public KeyVaultData(AzureLocation location, Models.KeyVaultProperties properties) : base(location)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
        }

        /// <summary> Properties of the vault. </summary>
        [WirePath("properties")]
        public Models.KeyVaultProperties Properties { get; set; }
    }
}
