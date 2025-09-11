// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.Core.Extensions;
using Azure.ResourceManager;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to add <see cref="ArmClient"/> client to clients builder.
    /// </summary>
    public static class ArmClientBuilderExtensions
    {
        /// <summary>
        /// Registers an <see cref="ArmClient"/> instance with the provided <paramref name="defaultSubscription"/>
        /// </summary>
        public static IAzureClientBuilder<ArmClient, ArmClientOptions> AddArmClient<TBuilder>(this TBuilder builder, string defaultSubscription)
            where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<ArmClient, ArmClientOptions>((options, cred) => new ArmClient(cred, defaultSubscription, options));
        }

        /// <summary>
        /// Registers an <see cref="ArmClient"/> instance with connection options loaded from the provided <paramref name="configuration"/> instance.
        /// </summary>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static IAzureClientBuilder<ArmClient, ArmClientOptions> AddArmClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
            where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ArmClient, ArmClientOptions>(configuration);
        }
    }
}
