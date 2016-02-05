﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Common.Authentication.Properties;
using System;
using System.Linq;
using System.Security;
using Hyak.Common;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;

namespace Microsoft.Azure.Common.Authentication.Factories
{
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public const string CommonAdTenant = "Common";

        public AuthenticationFactory()
        {
            TokenProvider = new AdalTokenProvider();
        }

        public ITokenProvider TokenProvider { get; set; }

        public IAccessToken Authenticate(
            AzureAccount account,
            AzureEnvironment environment,
            string tenant,
            SecureString password,
            ShowDialog promptBehavior,
            TokenCache tokenCache,
            AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            var configuration = GetAdalConfiguration(environment, tenant, resourceId, tokenCache);

            TracingAdapter.Information(Resources.AdalAuthConfigurationTrace, configuration.AdDomain, configuration.AdEndpoint,
                configuration.ClientId, configuration.ClientRedirectUri, configuration.ResourceClientUri, configuration.ValidateAuthority);
            IAccessToken token;
            if (account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
            {
                var thumbprint = account.GetProperty(AzureAccount.Property.CertificateThumbprint);
                token = TokenProvider.GetAccessTokenWithCertificate(configuration, account.Id, thumbprint, account.Type);
            }
            else
            {

                token = TokenProvider.GetAccessToken(configuration, promptBehavior, account.Id, password, account.Type);
            }

            account.Id = token.UserId;
            return token;
        }

        public IAccessToken Authenticate(
            AzureAccount account,
            AzureEnvironment environment,
            string tenant,
            SecureString password,
            ShowDialog promptBehavior,
            AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            return Authenticate(account, environment, tenant, password, promptBehavior, AzureSession.TokenCache, resourceId);
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context)
        {
            return GetSubscriptionCloudCredentials(context, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context, AzureEnvironment.Endpoint targetEndpoint)
        {
            if (context.Subscription == null)
            {
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.InvalidDefaultSubscription
                    : Resources.NoSubscriptionInContext;
                throw new ApplicationException(exceptionMessage);
            }

            if (context.Account == null)
            {
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.AccountNotFound
                    : Resources.ArmAccountNotFound;
                throw new ArgumentException(exceptionMessage);
            }

            if (context.Account.Type == AzureAccount.AccountType.Certificate)
            {
                var certificate = AzureSession.DataStore.GetCertificate(context.Account.Id);
                return new CertificateCloudCredentials(context.Subscription.Id.ToString(), certificate);
            }

            if (context.Account.Type == AzureAccount.AccountType.AccessToken)
            {
                return new TokenCloudCredentials(context.Subscription.Id.ToString(), context.Account.GetProperty(AzureAccount.Property.AccessToken));
            }

            string tenant = null;

            if (context.Subscription != null && context.Account != null)
            {
                tenant = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                      .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                      .FirstOrDefault();
            }

            if (tenant == null && context.Tenant != null && context.Tenant.Id != Guid.Empty)
            {
                tenant = context.Tenant.Id.ToString();
            }

            if (tenant == null)
            {
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.TenantNotFound
                    : Resources.NoTenantInContext;
                throw new ArgumentException(exceptionMessage);
            }

            try
            {
                TracingAdapter.Information(Resources.UPNAuthenticationTrace,
                    context.Account.Id, context.Environment.Name, tenant);
                var tokenCache = AzureSession.TokenCache;
                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    tokenCache = new TokenCache(context.TokenCache);
                }

                var token = Authenticate(context.Account, context.Environment,
                        tenant, null, ShowDialog.Never, tokenCache, context.Environment.GetTokenAudience(targetEndpoint));

                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    context.TokenCache = tokenCache.Serialize();
                }

                TracingAdapter.Information(Resources.UPNAuthenticationTokenTrace,
                    token.LoginType, token.TenantId, token.UserId);
                return new AccessTokenCredential(context.Subscription.Id, token);
            }
            catch (Exception ex)
            {
                TracingAdapter.Information(Resources.AdalAuthException, ex.Message);
                var exceptionMessage = targetEndpoint == AzureEnvironment.Endpoint.ServiceManagement
                    ? Resources.InvalidSubscriptionState
                    : Resources.InvalidArmContext;
                throw new ArgumentException(exceptionMessage, ex);
            }
        }

        public ServiceClientCredentials GetServiceClientCredentials(AzureContext context)
        {
            return GetServiceClientCredentials(context,
                AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);
        }

        public ServiceClientCredentials GetServiceClientCredentials(AzureContext context, AzureEnvironment.Endpoint targetEndpoint)
        {
            if (context.Account == null)
            {
                throw new ArgumentException(Resources.ArmAccountNotFound);
            }

            if (context.Account.Type == AzureAccount.AccountType.Certificate)
            {
                throw new NotSupportedException(AzureAccount.AccountType.Certificate.ToString());
            }

            if (context.Account.Type == AzureAccount.AccountType.AccessToken)
            {
                return new TokenCredentials(context.Account.GetProperty(AzureAccount.Property.AccessToken));
            }

            string tenant = null;

            if (context.Subscription != null && context.Account != null)
            {
                tenant = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                      .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                      .FirstOrDefault();
            }

            if (tenant == null && context.Tenant != null && context.Tenant.Id != Guid.Empty)
            {
                tenant = context.Tenant.Id.ToString();
            }

            if (tenant == null)
            {
                throw new ArgumentException(Resources.NoTenantInContext);
            }

            try
            {
                TracingAdapter.Information(Resources.UPNAuthenticationTrace,
                    context.Account.Id, context.Environment.Name, tenant);

                // TODO: When we will refactor the code, need to add tracing
                /*TracingAdapter.Information(Resources.UPNAuthenticationTokenTrace,
                    token.LoginType, token.TenantId, token.UserId);*/

                var env = new ActiveDirectoryServiceSettings
                {
                    AuthenticationEndpoint = context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ActiveDirectory),
                    TokenAudience = context.Environment.GetEndpointAsUri(context.Environment.GetTokenAudience(targetEndpoint)),
                    ValidateAuthority = !context.Environment.OnPremise
                };

                var tokenCache = AzureSession.TokenCache;

                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    tokenCache = new TokenCache(context.TokenCache);
                }

                ServiceClientCredentials result = null;

                if (context.Account.Type == AzureAccount.AccountType.User)
                {
                    result = Rest.Azure.Authentication.UserTokenProvider.CreateCredentialsFromCache(
                        AdalConfiguration.PowerShellClientId,
                        tenant,
                        context.Account.Id,
                        env,
                        tokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                }
                else if (context.Account.Type == AzureAccount.AccountType.ServicePrincipal)
                {
                    if (context.Account.IsPropertySet(AzureAccount.Property.CertificateThumbprint))
                    {
                        result = ApplicationTokenProvider.LoginSilentAsync(
                            tenant,
                            context.Account.Id,
                            new CertificateApplicationCredentialProvider(
                                context.Account.GetProperty(AzureAccount.Property.CertificateThumbprint)),
                            env,
                            tokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                    else
                    {
                        result = ApplicationTokenProvider.LoginSilentAsync(
                            tenant,
                            context.Account.Id,
                            new KeyStoreApplicationCredentialProvider(tenant),
                            env,
                            tokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
                    }
                }
                else
                {
                    throw new NotSupportedException(context.Account.Type.ToString());
                }

                if (context.TokenCache != null && context.TokenCache.Length > 0)
                {
                    context.TokenCache = tokenCache.Serialize();
                }

                return result;
            }
            catch (Exception ex)
            {
                TracingAdapter.Information(Resources.AdalAuthException, ex.Message);
                throw new ArgumentException(Resources.InvalidArmContext, ex);
            }
        }

        private AdalConfiguration GetAdalConfiguration(AzureEnvironment environment, string tenantId,
            AzureEnvironment.Endpoint resourceId, TokenCache tokenCache)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            var adEndpoint = environment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectory];

            return new AdalConfiguration
            {
                AdEndpoint = adEndpoint,
                ResourceClientUri = environment.Endpoints[resourceId],
                AdDomain = tenantId,
                ValidateAuthority = !environment.OnPremise,
                TokenCache = tokenCache
            };
        }
    }
}
