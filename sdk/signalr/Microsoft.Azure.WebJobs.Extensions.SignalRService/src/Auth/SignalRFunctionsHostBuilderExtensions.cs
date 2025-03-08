// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    using SignalRConnectionInfoConfigureFunc = Func<SecurityTokenResult, HttpRequest, SignalRConnectionDetail, SignalRConnectionDetail>;

    /// <summary>
    /// Extensions to add security token validator and SignalR connection configuration
    /// </summary>
    public static class SignalRFunctionsHostBuilderExtensions
    {
        /// <summary>
        /// Adds security token validation parameters' configuration and SignalR connection's configuration.
        /// </summary>
        /// <param name="services">The service collections to add default auth.</param>
        /// <param name="configureTokenValidationParameters">Token validation parameters to validate security token</param>
        /// <param name="configurer">SignalR connection configuration to be used in generating Azure SignalR service's access token</param>
        public static IServiceCollection AddDefaultAuth(this IServiceCollection services, Action<TokenValidationParameters> configureTokenValidationParameters, SignalRConnectionInfoConfigureFunc configurer = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configureTokenValidationParameters == null)
            {
                throw new ArgumentNullException(nameof(configureTokenValidationParameters));
            }

            var internalSignalRConnectionInfoConfigurer = new InternalSignalRConnectionInfoConfigurer(configurer);

            if (services.Any(d => d.ServiceType == typeof(ISecurityTokenValidator)))
            {
                throw new NotSupportedException($"{nameof(ISecurityTokenValidator)} already injected.");
            }

            services
                .AddSingleton<ISecurityTokenValidator>(s =>
                    new DefaultSecurityTokenValidator(configureTokenValidationParameters));

            services.
                TryAddSingleton<ISignalRConnectionInfoConfigurer>(s =>
                    internalSignalRConnectionInfoConfigurer);

            return services;
        }

        private class InternalSignalRConnectionInfoConfigurer : ISignalRConnectionInfoConfigurer
        {
            public SignalRConnectionInfoConfigureFunc Configure { get; set; }

            public InternalSignalRConnectionInfoConfigurer(SignalRConnectionInfoConfigureFunc Configure)
            {
                this.Configure = Configure;
            }
        }
    }
}