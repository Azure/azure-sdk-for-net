// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal class TokenValidatorInternal : TokenValidator
    {
        internal static List<SecurityKey> _cacheKeys = new List<SecurityKey>();
        internal static DateTime? _lastSync;
        internal static TimeSpan _cacheRefresh = new TimeSpan(0, 0, 5, 0);
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        internal override async Task<(bool Valid, Dictionary<string, string> Claims)> GetClaimsAndValidate(HttpRequestMessage request, ConfigurationManager configurationManager)
        {
            if (string.IsNullOrEmpty(configurationManager.TenantId) || string.IsNullOrEmpty(configurationManager.AudienceAppId))
            {
                throw new MissingFieldException(string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Trigger_Required_Attrs, ConfigurationManager.TENANT_ID, ConfigurationManager.AUDIENCE_APPID));
            }

            string accessToken = request.Headers?.Authorization?.Parameter;

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return (false, null);
            }

            string[] authenticationAppIds = configurationManager.AudienceAppId.Split(';');

            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadJwtToken(accessToken);
            SupportedTokenSchemaVersions tokenSchemaVersion = TokenValidatorHelper.ParseSupportedTokenVersion(token.Claims.First(x => x.Type.Equals("ver")).Value);

            if (!ConfigurationManager.GetService(token.Payload[(tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ? ConfigurationManager.TOKEN_V2_VERIFY : ConfigurationManager.TOKEN_V1_VERIFY)].ToString(), out ServiceInfo serviceInfo))
            {
                return (false, null);
            }

            try
            {
                await Task.Run(() =>
                {
                    if (MustCacheRefresh())
                    {
                        try
                        {
                            _cacheKeys.Clear();
                            _semaphore.Wait();

                            using (HttpClient httpClient = new HttpClient())
                            {
                                string openidConfiguration = httpClient.GetStringAsync(new Uri($"{serviceInfo.OpenIdConnectionHost}/common/v2.0/.well-known/openid-configuration", UriKind.Absolute)).Result;

                                AuthenticationEventJsonElement openidConfigurationJson = new AuthenticationEventJsonElement(openidConfiguration);
                                string jwksUri = openidConfigurationJson.GetPropertyValue("jwks_uri");
                                string certs = httpClient.GetStringAsync(new Uri(jwksUri, UriKind.Absolute)).Result;
                                AuthenticationEventJsonElement certsJson = new AuthenticationEventJsonElement(certs);
                                foreach (AuthenticationEventJsonElement key in certsJson.GetPropertyValue<AuthenticationEventJsonElement>("keys").Elements)
                                {
                                    _cacheKeys.Add(new RsaSecurityKey(new RSAParameters { Modulus = FromBase64Url(key.GetPropertyValue("n")), Exponent = FromBase64Url(key.GetPropertyValue("e")) }));
                                }
                            }
                        }
                        finally
                        {
                            _semaphore.Release();
                        }
                        _lastSync = DateTime.Now;
                    }
                }).ConfigureAwait(false);

                var result = handler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = string.Format(CultureInfo.CurrentCulture, tokenSchemaVersion == SupportedTokenSchemaVersions.V2_0 ?
                       serviceInfo.TokenIssuerV2 :
                       serviceInfo.TokenIssuerV1, configurationManager.TenantId),
                    ValidAudiences = authenticationAppIds,
                    IssuerSigningKeys = _cacheKeys
                }, out _);

                //Here we validate the version and for version 1 validate that the appid claim matches the authorization party, if version 2, we validate that the azp claim matches the authorization party.
                return (result.Claims.VerifyClaim("ver", $"{tokenSchemaVersion.GetDescription()}"),
                    result.Claims.ToDictionary(x => x.Type, x => x.Value));
            }
            catch (Exception)
            {
                return (false, null);
            }
        }

        internal static byte[] FromBase64Url(string base64Url)
        {
            string padded = base64Url.Length % 4 == 0
                ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/")
                                    .Replace("-", "+");
            return Convert.FromBase64String(base64);
        }

        internal static bool MustCacheRefresh()
        {
            if (_cacheKeys.Count == 0)
                return true;

            if (!_lastSync.HasValue)
                return true;

            return (_lastSync.Value.Add(_cacheRefresh) < DateTime.Now);
        }
    }
}
