// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Extensions;
using Azure.Security.KeyVault.Certificates;

#pragma warning disable AZC0001 // https://github.com/Azure/azure-sdk-tools/issues/213
namespace Microsoft.Extensions.Azure
#pragma warning restore AZC0001
{
    /// <summary>
    /// Extension methods to add <see cref="CertificateClient"/> to clients builder
    /// </summary>
    public static class CertificateClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="CertificateClient"/> instance with the provided <paramref name="vaultUri"/>
        /// </summary>
        public static IAzureClientBuilder<CertificateClient, CertificateClientOptions> AddCertificateClient<TBuilder>(this TBuilder builder, Uri vaultUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<CertificateClient, CertificateClientOptions>((options, cred) => new CertificateClient(vaultUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="CertificateClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        public static IAzureClientBuilder<CertificateClient, CertificateClientOptions> AddCertificateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<CertificateClient, CertificateClientOptions>(configuration);
        }
    }
}
