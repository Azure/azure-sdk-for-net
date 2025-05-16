// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Cryptography;
using Azure.Extensions.AspNetCore.DataProtection.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

#pragma warning disable // TODO cleanup of all the warning messages. Issue https://github.com/Azure/azure-sdk-for-net/issues/43768
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
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, string keyIdentifier, TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(keyIdentifier, nameof(keyIdentifier));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));
            return builder.ProtectKeysWithAzureKeyVault(keyIdentifier, new KeyResolver(tokenCredential));
        }

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
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));
            return builder.ProtectKeysWithAzureKeyVault(keyIdentifier.ToString(), new KeyResolver(tokenCredential));
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure KeyVault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="keyResolver">The <see cref="IKeyEncryptionKeyResolver"/> to use for Key Vault access.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, string keyIdentifier, IKeyEncryptionKeyResolver keyResolver)
        {
            Argument.AssertNotNull(builder, nameof(builder));
            Argument.AssertNotNull(keyResolver, nameof(keyResolver));
            Argument.AssertNotNullOrEmpty(keyIdentifier, nameof(keyIdentifier));

            builder.Services.AddSingleton<IKeyEncryptionKeyResolver>(keyResolver);
            builder.Services.AddSingleton<IActivator, DecryptorTypeForwardingActivator>();
            builder.Services.Configure<KeyManagementOptions>(options =>
            {
                options.XmlEncryptor = new AzureKeyVaultXmlEncryptor(keyResolver, keyIdentifier);
            });

            return builder;
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure KeyVault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="keyResolver">The <see cref="IKeyEncryptionKeyResolver"/> to use for Key Vault access.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, Uri keyIdentifier, IKeyEncryptionKeyResolver keyResolver)
        {
            Argument.AssertNotNull(keyIdentifier, nameof(keyIdentifier));
            Argument.AssertNotNull(keyResolver, nameof(keyResolver));
            return builder.ProtectKeysWithAzureKeyVault(keyIdentifier.ToString(), keyResolver);
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure Key Vault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="keyResolverFactory">The factory delegate to create the <see cref="IKeyEncryptionKeyResolver"/> to use for Key Vault access.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, string keyIdentifier, Func<IServiceProvider, IKeyEncryptionKeyResolver> keyResolverFactory)
        {
            Argument.AssertNotNull(builder, nameof(builder));
            Argument.AssertNotNull(keyResolverFactory, nameof(keyResolverFactory));
            Argument.AssertNotNullOrEmpty(keyIdentifier, nameof(keyIdentifier));

            builder.Services.AddSingleton<IActivator, DecryptorTypeForwardingActivator>();
            builder.Services.AddSingleton<IKeyEncryptionKeyResolver>(keyResolverFactory);
            builder.Services.AddSingleton(sp =>
            {
                var keyResolver = sp.GetRequiredService<IKeyEncryptionKeyResolver>();
                return new AzureKeyVaultXmlEncryptor(keyResolver, keyIdentifier);
            });

            builder.Services.AddSingleton<IConfigureOptions<KeyManagementOptions>, ConfigureKeyManagementKeyVaultEncryptorClientOptions>();

            return builder;
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure Key Vault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="keyResolverFactory">The factory delegate to create the <see cref="IKeyEncryptionKeyResolver"/> to use for Key Vault access.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, Uri keyIdentifier, Func<IServiceProvider, IKeyEncryptionKeyResolver> keyResolverFactory)
        {
            Argument.AssertNotNull(keyIdentifier, nameof(keyIdentifier));
            Argument.AssertNotNull(keyResolverFactory, nameof(keyResolverFactory));
            return builder.ProtectKeysWithAzureKeyVault(keyIdentifier.ToString(), keyResolverFactory);
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure Key Vault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="tokenCredentialFactory">The factory delegate to create the <see cref="TokenCredential"/> to use for authenticating Key Vault access.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, string keyIdentifier, Func<IServiceProvider, TokenCredential> tokenCredentialFactory)
        {
            Argument.AssertNotNullOrEmpty(keyIdentifier, nameof(keyIdentifier));
            Argument.AssertNotNull(tokenCredentialFactory, nameof(tokenCredentialFactory));
            return builder.ProtectKeysWithAzureKeyVault(_ => keyIdentifier, tokenCredentialFactory);
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure Key Vault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifier">The Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="tokenCredentialFactory">The factory delegate to create the <see cref="TokenCredential"/> to use for authenticating Key Vault access.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, Uri keyIdentifier, Func<IServiceProvider, TokenCredential> tokenCredentialFactory)
        {
            Argument.AssertNotNull(keyIdentifier, nameof(keyIdentifier));
            return builder.ProtectKeysWithAzureKeyVault(_ => keyIdentifier, tokenCredentialFactory);
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure Key Vault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifierFactory">The factory delegate to create the Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="tokenCredentialFactory">The factory delegate to create the <see cref="TokenCredential"/> to use for authenticating Key Vault access.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, Func<IServiceProvider, string> keyIdentifierFactory, Func<IServiceProvider, TokenCredential> tokenCredentialFactory)
        {
            Argument.AssertNotNull(builder, nameof(builder));
            Argument.AssertNotNull(tokenCredentialFactory, nameof(tokenCredentialFactory));
            Argument.AssertNotNull(keyIdentifierFactory, nameof(keyIdentifierFactory));

            builder.Services.AddSingleton<IActivator, DecryptorTypeForwardingActivator>();

            builder.Services.AddSingleton<IKeyEncryptionKeyResolver>(sp =>
            {
                var tokenCredential = tokenCredentialFactory(sp);
                return new KeyResolver(tokenCredential);
            });

            builder.Services.AddSingleton(sp =>
            {
                var keyResolver = sp.GetRequiredService<IKeyEncryptionKeyResolver>();
                return new AzureKeyVaultXmlEncryptor(keyResolver, keyIdentifierFactory(sp));
            });

            builder.Services.AddSingleton<IConfigureOptions<KeyManagementOptions>, ConfigureKeyManagementKeyVaultEncryptorClientOptions>();

            return builder;
        }

        /// <summary>
        /// Configures the data protection system to protect keys with specified key in Azure Key Vault.
        /// </summary>
        /// <param name="builder">The builder instance to modify.</param>
        /// <param name="keyIdentifierFactory">The factory delegate to create the Azure Key Vault key identifier used for key encryption.</param>
        /// <param name="tokenCredentialFactory">The factory delegate to create the <see cref="TokenCredential"/> to use for authenticating Key Vault access.</param>
        /// <returns>The value <paramref name="builder"/>.</returns>
        public static IDataProtectionBuilder ProtectKeysWithAzureKeyVault(this IDataProtectionBuilder builder, Func<IServiceProvider, Uri> keyIdentifierFactory, Func<IServiceProvider, TokenCredential> tokenCredentialFactory)
        {
            Argument.AssertNotNull(keyIdentifierFactory, nameof(keyIdentifierFactory));
            Argument.AssertNotNull(tokenCredentialFactory, nameof(tokenCredentialFactory));
            return builder.ProtectKeysWithAzureKeyVault(sp => keyIdentifierFactory(sp).ToString(), tokenCredentialFactory);
        }
    }
}
