// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;

namespace Azure.Security.KeyVault.Secrets
{
    public static class SecretClientBuilderExtensions
    {
        public static IAzureClientBuilder<SecretClient, SecretClientOptions> AddSecretClient<TBuilder>(this TBuilder builder, Uri vaultUri)
            where TBuilder: IAzureClientsBuilderWithCredential
        {
            return builder.RegisterClient<SecretClient, SecretClientOptions>((options, cred) => new SecretClient(vaultUri, cred, options));
        }

        public static IAzureClientBuilder<SecretClient, SecretClientOptions> AddSecretClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder: IAzureClientsBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClient<SecretClient, SecretClientOptions>(configuration);
        }
    }
}
