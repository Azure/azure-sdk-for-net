// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Authentication options when using Web PubSub service.
    /// </summary>
    public class WebPubSubAuthenticationOptions : IWebPubSubAuthenticationOptions
    {
        /// <summary>
        /// Tenant id
        /// </summary>
        public string TenantId { get; private set; }

        /// <summary>
        /// Instance.
        /// </summary>
        public string Instance { get; set; } = "https://login.microsoftonline.com/";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tenantId"></param>
        public WebPubSubAuthenticationOptions(string tenantId)
        {
            TenantId = tenantId;
        }

        /// <summary>
        /// Configure Azure Ad Auth scheme and policies.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceCollection Configure(IServiceCollection services)
        {
            services.AddAuthentication().AddJwtBearer(Constants.Auth.AzureAd.Scheme, options =>
            {
                options.MetadataAddress = $"{Instance}/{TenantId}/v2.0/.well-known/openid-configuration";
                options.TokenValidationParameters.ValidateIssuer = false;
                options.TokenValidationParameters.ValidateAudience = false; // audience may variant for different hubs.
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Validated: " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(Constants.Auth.AzureAd.Scheme)
                    .Build();
                options.AddPolicy(Constants.Auth.AzureAd.Policy, policy);
            });

            return services;
        }
    }
}
