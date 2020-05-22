// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Extensions.AspNetCore.DataProtection.Keys;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Security.KeyVault.Keys.Cryptography;
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
        /// <param name="tokenCredential">The token credential to use for authentication.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, Uri keyIdentifier, TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(keyIdentifier, nameof(keyIdentifier));
            return ProtectKeysWithAzureKeyVault(builder, keyIdentifier.ToString(), new KeyResolver(tokenCredential));
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure KeyVault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyResolver">The <see cref="IKeyEncryptionKeyResolver"/> to use for Key Vault access.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, string keyIdentifier, IKeyEncryptionKeyResolver keyResolver)
        {
            Argument.AssertNotNull(builder, nameof(builder));
            Argument.AssertNotNull(keyResolver, nameof(keyResolver));
            Argument.AssertNotNullOrEmpty(keyIdentifier, nameof(keyIdentifier));

            builder.Services.AddSingleton<IKeyEncryptionKeyResolver>(keyResolver);
            builder.Services.Configure<KeyManagementOptions>(options =>
            {
                options.XmlEncryptor = new AzureKeyVaultXmlEncryptor(keyResolver, keyIdentifier);
            });

            return builder;
        }
    }
}
