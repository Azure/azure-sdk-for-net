// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Azure.Identity.Broker
{
    /// <summary>
    /// Extension methods for registering <see cref="BrokerCredentialResolver"/>
    /// with a dependency-injection container.
    /// </summary>
    [Experimental("SCME0002")]
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Registers <see cref="BrokerCredentialResolver"/> in the service collection.
        /// Idempotent — repeated calls do not produce duplicate registrations.
        /// </summary>
        /// <param name="services">The service collection to register on.</param>
        /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> is null.</exception>
        public static IServiceCollection AddBrokerCredentialResolver(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Register the static singleton instance so DI shares resolver
            // identity with the standalone path that uses
            // BrokerCredentialResolver.Instance directly. SCM's CredentialCache
            // keys entries by (sectionHash, resolver reference), so sharing
            // the instance lets both paths reuse cached credentials when their
            // bound sections are content-identical. TryAddEnumerable dedupes
            // by implementation type.
            services.TryAddEnumerable(ServiceDescriptor.Singleton<CredentialResolver>(BrokerCredentialResolver.Instance));
            return services;
        }

        /// <summary>
        /// Registers <see cref="BrokerCredentialResolver"/> on the host's service collection.
        /// Idempotent — repeated calls do not produce duplicate registrations.
        /// </summary>
        /// <param name="builder">The host builder to register on.</param>
        /// <returns>The same <see cref="IHostApplicationBuilder"/> for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="builder"/> is null.</exception>
        public static IHostApplicationBuilder AddBrokerCredentialResolver(this IHostApplicationBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddBrokerCredentialResolver();
            return builder;
        }
    }
}
