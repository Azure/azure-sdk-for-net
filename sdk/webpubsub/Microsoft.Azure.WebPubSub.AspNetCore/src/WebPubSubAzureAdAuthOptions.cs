// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Authentication options when using Web PubSub service.
    /// </summary>
    public class WebPubSubAzureAdAuthOptions : IWebPubSubAuthOptions
    {
        /// <summary>
        /// ObjectId claim type.
        /// </summary>
        private const string ObjectId = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        /// <summary>
        /// Tenant id
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Instance.
        /// </summary>
        public string Instance { get; set; } = "https://login.microsoftonline.com/";

        /// <summary>
        /// Audience.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// MSI client ids.
        /// </summary>
        public string[] ClientIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        public WebPubSubAzureAdAuthOptions()
        {
        }

        /// <summary>
        /// Configure authentication options.
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public AuthenticationBuilder Configure(string scheme, AuthenticationBuilder builder)
        {
            return builder.AddJwtBearer(scheme, options =>
            {
                if (string.IsNullOrEmpty(TenantId))
                {
                    throw new ArgumentNullException(nameof(TenantId), "TenantId is required to setup AAD Auth");
                }

                options.MetadataAddress = $"{Instance}/{TenantId}/v2.0/.well-known/openid-configuration";
                options.Audience = Audience;
                options.TokenValidationParameters.ValidateIssuer = false;
            });
        }

        /// <summary>
        /// Configure authorization policy.
        /// </summary>
        /// <param name="policyBuilder"></param>
        /// <returns></returns>
        public AuthorizationPolicyBuilder Configure(AuthorizationPolicyBuilder policyBuilder)
        {
            return policyBuilder
                .RequireAuthenticatedUser()
                .AddAuthenticationSchemes(Constants.Auth.AzureAd.DefaultScheme)
                .RequireClaim(ObjectId, ClientIds);
        }
    }
}
