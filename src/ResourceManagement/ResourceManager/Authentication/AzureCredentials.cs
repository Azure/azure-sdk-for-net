// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    /// <summary>
    /// Credentials used for authenticating a fluent management client to Azure.
    /// </summary>
    public class AzureCredentials : ServiceClientCredentials
    {
        private UserLoginInformation userLoginInformation;
        private ServicePrincipalLoginInformation servicePrincipalLoginInformation;
        private IDictionary<Uri, ServiceClientCredentials> credentialsCache;
#if PORTABLE
        private DeviceCredentialInformation deviceCredentialInformation;
#endif

        public string DefaultSubscriptionId { get; private set; }

        public string TenantId { get; private set; }

        public string ClientId
        {
            get
            {
#if PORTABLE
                if (deviceCredentialInformation != null)
                {
                    return deviceCredentialInformation.ClientId;
                }
#endif

                return userLoginInformation?.ClientId ?? servicePrincipalLoginInformation?.ClientId;
            }
        }

        public AzureEnvironment Environment { get; private set; }

        public AzureCredentials(UserLoginInformation userLoginInformation, string tenantId, AzureEnvironment environment)
            : this(tenantId, environment)
        {
            this.userLoginInformation = userLoginInformation;
        }
        public AzureCredentials(ServicePrincipalLoginInformation servicePrincipalLoginInformation, string tenantId, AzureEnvironment environment)
            : this(tenantId, environment)
        {
            this.servicePrincipalLoginInformation = servicePrincipalLoginInformation;
        }

        private AzureCredentials(string tenantId, AzureEnvironment environment)
        {
            TenantId = tenantId;
            Environment = environment;
            credentialsCache = new Dictionary<Uri, ServiceClientCredentials>();
        }

#if PORTABLE
        public AzureCredentials(DeviceCredentialInformation deviceCredentialInformation, string tenantId, AzureEnvironment environment)
            : this(tenantId, environment)
        {
            this.deviceCredentialInformation = deviceCredentialInformation;

        }
#endif

        public AzureCredentials WithDefaultSubscription(string subscriptionId)
        {
            DefaultSubscriptionId = subscriptionId;
            return this;
        }

        public async override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var adSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(Environment.AuthenticationEndpoint),
                TokenAudience = new Uri(Environment.ManagementEnpoint),
                ValidateAuthority = true
            };
            string url = request.RequestUri.ToString();
            if (url.StartsWith(Environment.GraphEndpoint, StringComparison.OrdinalIgnoreCase))
            {
                adSettings.TokenAudience = new Uri(Environment.GraphEndpoint);
            }

            if (!credentialsCache.ContainsKey(adSettings.TokenAudience))
            {
                if (servicePrincipalLoginInformation != null)
                {
                    if (servicePrincipalLoginInformation.ClientSecret != null)
                    {
                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, servicePrincipalLoginInformation.ClientId, servicePrincipalLoginInformation.ClientSecret, adSettings, TokenCache.DefaultShared);
                    }
#if NET45
                    else if (servicePrincipalLoginInformation.X509Certificate != null)
                    {
                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, new ClientAssertionCertificate(servicePrincipalLoginInformation.ClientId, servicePrincipalLoginInformation.X509Certificate), adSettings, TokenCache.DefaultShared);
                    }
#endif
                    else
                    {
                        credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                            TenantId, servicePrincipalLoginInformation.ClientId, servicePrincipalLoginInformation.Certificate, servicePrincipalLoginInformation.CertificatePassword, TokenCache.DefaultShared);
                    }
                }
#if !PORTABLE
                else if (userLoginInformation != null)
                {
                    credentialsCache[adSettings.TokenAudience] = await UserTokenProvider.LoginSilentAsync(
                        userLoginInformation.ClientId, TenantId, userLoginInformation.UserName,
                        userLoginInformation.Password, adSettings, TokenCache.DefaultShared);
                }
#endif
#if PORTABLE
                else if (deviceCredentialInformation != null)
                {
                    credentialsCache[adSettings.TokenAudience] = await UserTokenProvider.LoginByDeviceCodeAsync(
                        deviceCredentialInformation.ClientId, TenantId, adSettings, TokenCache.DefaultShared, deviceCredentialInformation.DeviceCodeFlowHandler);
                }
#endif
            }
            await credentialsCache[adSettings.TokenAudience].ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}