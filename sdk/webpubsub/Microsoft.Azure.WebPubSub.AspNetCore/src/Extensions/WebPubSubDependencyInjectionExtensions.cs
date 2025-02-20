// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebPubSub.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods to add required services to use Azure Web PubSub service Hub methods.
    /// </summary>
    public static class WebPubSubDependencyInjectionExtensions
    {
        /// <summary>
        /// Adds the minimum essential Azure Web PubSub services to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configure">A callback to configure the <see cref="WebPubSubOptions"/>.</param>
        /// <returns>The same instance of the <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddWebPubSub(this IServiceCollection services, Action<WebPubSubOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            services.Configure(configure);

            return services.AddWebPubSubCore();
        }

        /// <summary>
        /// Adds the minimum essential Azure Web PubSub services to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The same instance of the <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddWebPubSub(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // Add a default option to avoid null, inbound traffic validation will always succeed.
            // And customer will not be able to `AddWebPubSubServiceClient` in this case.
            return services.AddWebPubSub(o => o = new());
        }

        /// <summary>
        /// Adds the Web PubSub service clients to be able to inject in <see cref="WebPubSubHub"/> and invoke service.
        /// </summary>
        /// <typeparam name="THub">User implemented <see cref="WebPubSubHub"/>.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The same instance of the <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddWebPubSubServiceClient<THub>(this IServiceCollection services) where THub : WebPubSubHub
        {
            services.AddSingleton(typeof(WebPubSubServiceClient<THub>), sp =>
            {
                var factory = sp.GetRequiredService<WebPubSubServiceClientFactory>();
                return factory.Create<THub>();
            });
            return services;
        }

        private static IServiceCollection AddWebPubSubCore(this IServiceCollection services)
        {
            services.AddSingleton<ServiceRequestHandlerAdapter>()
                .AddSingleton<WebPubSubMarkerService>()
                .AddSingleton<WebPubSubServiceClientFactory>()
                .AddSingleton<RequestValidator>();

            return services;
        }
    }
}
