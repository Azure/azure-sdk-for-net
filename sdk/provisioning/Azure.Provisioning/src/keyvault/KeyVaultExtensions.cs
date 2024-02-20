// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.KeyVaults
{
    /// <summary>
    /// Extension methods for <see cref="IConstruct"/>.
    /// </summary>
    public static class KeyVaultExtensions
    {
        /// <summary>
        /// Adds a <see cref="KeyVault"/> to the construct.
        /// </summary>
        /// <param name="construct">The construct.</param>
        /// <param name="resourceGroup">The parent.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static KeyVault AddKeyVault(this IConstruct construct, ResourceGroup? resourceGroup = null, string name = "kv")
        {
            return new KeyVault(construct, name: name, parent: resourceGroup);
        }

        /// <summary>
        /// Gets all of the <see cref="KeyVaultSecret"/> in the construct.
        /// </summary>
        /// <param name="construct"></param>
        /// <returns></returns>
        public static IEnumerable<KeyVaultSecret> GetSecrets(this IConstruct construct)
        {
            foreach (var resource in construct.GetResources())
            {
                if (resource is KeyVaultSecret secret)
                {
                    yield return secret;
                }
            }
        }
    }
}
