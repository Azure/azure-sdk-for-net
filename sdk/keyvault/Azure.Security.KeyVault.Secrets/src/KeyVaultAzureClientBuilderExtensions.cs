// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;

namespace Azure.ApplicationModel.Configuration
{
    public static class KeyVaultAzureClientBuilderExtensions
    {
        public static TBuilder AddKeyVaultSecrets<TBuilder>(this TBuilder builder,
            string name,
            Uri vaultUri,
            TokenCredential tokenCredential = null,
            Action<SecretClientOptions> configureOptions = null)
            where TBuilder: IAzureClientsBuilderWithCredential
        {
            builder.RegisterClient<SecretClient, SecretClientOptions>(name, (options, cred) => new SecretClient(vaultUri, tokenCredential, options), configureOptions, tokenCredential);
            return builder;
        }

        public static TBuilder AddKeyVaultSecrets<TBuilder, TConfiguration>(this TBuilder builder, string name, TConfiguration configuration)
            where TBuilder: IAzureClientsBuilderWithConfiguration<TConfiguration>
        {
            builder.RegisterClient<SecretClient, SecretClientOptions>(name, configuration);
            return builder;
        }
    }
}
