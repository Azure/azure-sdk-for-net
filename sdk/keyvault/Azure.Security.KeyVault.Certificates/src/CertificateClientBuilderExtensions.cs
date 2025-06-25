// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Azure.Security.KeyVault.Certificates;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="CertificateClient"/> to clients builder.
    /// </summary>
    public static class CertificateClientBuilderExtensions
    {
        /// <summary>
        /// Registers a <see cref="CertificateClient"/> instance with the provided <paramref name="vaultUri"/>.
        /// </summary>
        public static IAzureClientBuilder<CertificateClient, CertificateClientOptions> AddCertificateClient<TBuilder>(this TBuilder builder, Uri vaultUri)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<CertificateClient, CertificateClientOptions>((options, cred) => new CertificateClient(vaultUri, cred, options));
        }

        /// <summary>
        /// Registers a <see cref="CertificateClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<CertificateClient, CertificateClientOptions> AddCertificateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<CertificateClient, CertificateClientOptions>(configuration);
        }
    }
}
