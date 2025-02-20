// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.Core.Extensions
{
    /// <summary>
    /// Abstraction for registering Azure clients in dependency injection containers and initializing them using <c>IConfiguration</c> objects.
    /// </summary>
    public interface IAzureClientFactoryBuilderWithConfiguration<in TConfiguration> : IAzureClientFactoryBuilder
    {
        /// <summary>
        /// Registers a client in the dependency injection container using the configuration to create a client instance.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The client options type used the client.</typeparam>
        /// <param name="configuration">Instance of <typeparamref name="TConfiguration"/> to use.</param>
        /// <returns><see cref="IAzureClientBuilder{TClient,TOptions}"/> that allows customizing the client registration.</returns>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(TConfiguration configuration) where TOptions : class;
    }
}
