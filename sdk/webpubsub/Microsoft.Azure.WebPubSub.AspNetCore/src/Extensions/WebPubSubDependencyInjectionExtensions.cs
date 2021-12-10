// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;

using Microsoft.AspNetCore.Authorization;
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

            var options = new WebPubSubOptions();
            configure(options);

            if (options.AuthOptions != null)
            {
                services.AddWebPubSubAuthentication(options.AuthOptions);
            }
            return services.AddWebPubSub();
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
            return services
                .AddSingleton<ServiceRequestHandlerAdapter>()
                .AddSingleton<WebPubSubMarkerService>();
        }

        /// <summary>
        /// Add web pubsub authentication.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="authOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebPubSubAuthentication(this IServiceCollection services,
                                                                    IWebPubSubAuthOptions authOptions)
        {
            var builder = services.AddAuthentication();
            authOptions.Configure(Constants.Auth.AzureAd.DefaultScheme, builder);
            return services.AddWebPubSubAuthPolicy(Constants.Auth.AzureAd.DefaultPolicy, authOptions);
        }

        /// <summary>
        /// Add web pubsub auth policy
        /// </summary>
        /// <param name="services"></param>
        /// <param name="policyName"></param>
        /// <param name="authOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebPubSubAuthPolicy(this IServiceCollection services,
                                                                string policyName,
                                                                IWebPubSubAuthOptions authOptions)
        {
            return services.AddAuthorization(options =>
            {
                var builder = new AuthorizationPolicyBuilder().RequireAuthenticatedUser();
                authOptions.Configure(builder);
                options.AddPolicy(policyName, builder.Build());
            });
        }
    }
}
