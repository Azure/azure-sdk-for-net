// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Secrets.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable AZC0001 // Extension methods have to be in the correct namespace to appear in intellisense.
namespace Microsoft.AspNetCore.DataProtection
#pragma warning disable
{
    /// <summary>
    /// Contains Azure KeyVault-specific extension methods for modifying a <see cref="IDataProtectionBuilder"/>.
    /// </summary>
    public static class AzureDataProtectionKeyVaultKeyBuilderExtensions
    {
        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure KeyVault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, string keyIdentifier)
        {
            return ProtectKeysWithAzureKeyVault(builder, keyIdentifier, new DefaultAzureCredential());
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure KeyVault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="tokenCredential">The token credential to use for authentication.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, string keyIdentifier, TokenCredential tokenCredential)
        {
            return ProtectKeysWithAzureKeyVault(builder, new KeyResolver(tokenCredential), keyIdentifier);
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure KeyVault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="client">The <see cref="IKeyEncryptionKeyResolver"/> to use for Key Vault access.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, IKeyEncryptionKeyResolver client, string keyIdentifier)
        {
            Argument.AssertNotNull(builder, nameof(builder));
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNullOrEmpty(keyIdentifier, nameof(keyIdentifier));

            builder.Services.AddSingleton<IKeyEncryptionKeyResolver>(client);
            builder.Services.Configure<KeyManagementOptions>(options =>
            {
                options.XmlEncryptor = new AzureKeyVaultXmlEncryptor(client, keyIdentifier);
            });

            return builder;
        }
    }
}
