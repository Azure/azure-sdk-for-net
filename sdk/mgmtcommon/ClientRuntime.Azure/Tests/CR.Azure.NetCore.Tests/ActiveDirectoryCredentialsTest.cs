// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;
using Microsoft.Rest.Azure.Authentication.Internal;
using Xunit;
using Xunit.Abstractions;
#if FullNetFx
using System.Configuration;
#endif

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    [Collection("ADAL Test Collection")]
    public class ActiveDirectoryCredentialsTest
    {
        private string _username;
        private string _password;
        private string _applicationId;
        private string _secret;
        private string _domain;
        private string _certificatePassword;

        public ActiveDirectoryCredentialsTest()
        {
            IDictionary<string, string> connectionProperties =
                EnvironmentDependentFactAttribute.ParseConnectionString(Environment.GetEnvironmentVariable("ARM_Connection_String"));

            if (connectionProperties != null)
            {
                connectionProperties.TryGetValue("username", out this._username);
                connectionProperties.TryGetValue("password", out this._password);
                connectionProperties.TryGetValue("applicationid", out this._applicationId);
                connectionProperties.TryGetValue("secret", out this._secret);
                connectionProperties.TryGetValue("domain", out this._domain);
                connectionProperties.TryGetValue("certificatePassword", out this._certificatePassword);
            }
        }

#if FullNetFx
        [EnvironmentDependentFact]
        public void CertificateTokenProviderRefreshWorks()
        {
            var thumbprint = "F064B7C7EACC942D10662A5115E047E94FA18498";
            System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificates;
            Assert.True(TryFindCertificatesInStore(thumbprint, System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine, out certificates));

            var cache = new TestTokenCache();
            byte[] certificate = certificates[0].Export(System.Security.Cryptography.X509Certificates.X509ContentType.Pkcs12, _certificatePassword);
            var credentials = ApplicationTokenProvider.LoginSilentAsync(
                                "1449d5b7-8a83-47db-ae4c-9b03e888bad0", 
                                "20c58db7-4501-44e8-8e76-6febdb400c6b",
                                certificate,
                                _certificatePassword)
                            .GetAwaiter().GetResult();
            cache.ForceTokenExpiry();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                new Uri("https://management.azure.com/subscriptions?api-version=2014-04-01-preview"));
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).Wait();
            Assert.NotNull(request.Headers.Authorization);
            var response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [EnvironmentDependentFact]
        public void UserCredentialsPopsDialog()
        {
            var cache = new TestTokenCache();
            var settings = ActiveDirectoryServiceSettings.Azure;
            var credentials = UserTokenProvider.LoginWithPromptAsync(this._domain, 
                ActiveDirectoryClientSettings.UsePromptOnly("1950a258-227b-4e31-a9cf-717495945fc2", new Uri("urn:ietf:wg:oauth:2.0:oob")), 
                settings, this._username, cache).GetAwaiter().GetResult();
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
                new Uri("https://management.azure.com/subscriptions?api-version=2014-04-01-preview"));
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).Wait();
            Assert.NotNull(request.Headers.Authorization);
            var response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Repeat with PromptBehavior.Never
             credentials = UserTokenProvider.LoginWithPromptAsync(this._domain, 
                 ActiveDirectoryClientSettings.UseCacheOrCookiesOnly("1950a258-227b-4e31-a9cf-717495945fc2",new Uri("urn:ietf:wg:oauth:2.0:oob")), 
                 settings, this._username, cache).GetAwaiter().GetResult();
            request = new HttpRequestMessage(HttpMethod.Get,
                new Uri("https://management.azure.com/subscriptions?api-version=2014-04-01-preview"));
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).Wait();
            Assert.NotNull(request.Headers.Authorization);
            response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Repeat with getting tokens strictly from cache
            credentials = UserTokenProvider.CreateCredentialsFromCache("1950a258-227b-4e31-a9cf-717495945fc2", this._domain, this._username, cache).GetAwaiter().GetResult();
            request = new HttpRequestMessage(HttpMethod.Get,
                new Uri("https://management.azure.com/subscriptions?api-version=2014-04-01-preview"));
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).Wait();
            Assert.NotNull(request.Headers.Authorization);
            response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
      }

        [EnvironmentDependentFact]
        public void OrgIdCredentialWorksWithoutDialog()
        {
            var credentials = 
                UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2",
                this._domain, this._username, this._password).GetAwaiter().GetResult();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                new Uri("https://management.azure.com/subscriptions?api-version=2014-04-01-preview"));
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).Wait();
            Assert.NotNull(request.Headers.Authorization);
            var response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [EnvironmentDependentFact]
        public void OrgIdCredentialsThrowsForInvalidCredentials()
        {
            var exception = Assert.Throws<AuthenticationException>(() => UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2",
                this._domain, "unuseduser@thisdomain.com", "This is not a valid password").GetAwaiter().GetResult());
            Assert.NotNull(exception.InnerException);
            Assert.Equal(typeof(AdalException), exception.InnerException.GetType());
            exception = Assert.Throws<AuthenticationException>(() => UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2",
                this._domain, "bad_user@bad_domain.com", this._password).ConfigureAwait(false).GetAwaiter().GetResult());
            Assert.NotNull(exception.InnerException);
            Assert.Equal(typeof(AdalException), exception.InnerException.GetType());
            exception = Assert.Throws<AuthenticationException>(() => UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2", "not-a-valid-domain", this._username, this._password).ConfigureAwait(false).GetAwaiter().GetResult());
            Assert.NotNull(exception.InnerException);
            Assert.Equal(typeof(AdalServiceException), exception.InnerException.GetType());
            exception = Assert.Throws<AuthenticationException>(() => UserTokenProvider.LoginSilentAsync("not-a-valid-client-id", this._domain, this._username, this._password)
                .ConfigureAwait(false).GetAwaiter().GetResult());
            Assert.NotNull(exception.InnerException);
            Assert.Equal(typeof(AdalServiceException), exception.InnerException.GetType());
        }
#endif
#if FullNetFx
        [EnvironmentDependentFact]
        public void CredentialsConstructorThrowsForInvalidValues()
        {
            TokenCache cache = new TestTokenCache();
            var settings = ActiveDirectoryServiceSettings.Azure;
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => UserTokenProvider.LoginSilentAsync(null,
                "microsoft.onmicrosoft.com", this._username, this._password, cache));
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => UserTokenProvider.LoginWithPromptAsync(
                 "microsoft.onmicrosoft.com", ActiveDirectoryClientSettings.UsePromptOnly(string.Empty, new Uri("urn:ietf:wg:oauth:2.0:oob")), 
                 settings, cache));
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => UserTokenProvider.LoginWithPromptAsync(null, 
                ActiveDirectoryClientSettings.UsePromptOnly("1950a258-227b-4e31-a9cf-717495945fc2", new Uri("urn:ietf:wg:oauth:2.0:oob")), 
                settings, cache));
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => UserTokenProvider.LoginWithPromptAsync(string.Empty, 
                ActiveDirectoryClientSettings.UsePromptOnly("1950a258-227b-4e31-a9cf-717495945fc2", new Uri("urn:ietf:wg:oauth:2.0:oob")), 
                settings, cache));
            Assert.ThrowsAsync<AuthenticationException>(() => UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2", 
                "microsoft.onmicrosoft.com", null, this._password, cache));
            Assert.Throws<AuthenticationException>(() => UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2", 
                "microsoft.onmicrosoft.com", string.Empty, this._password, cache).ConfigureAwait(false).GetAwaiter().GetResult());
            Assert.ThrowsAsync<AuthenticationException>(() =>UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2", 
                "microsoft.onmicrosoft.com", this._username, null, cache));
            Assert.ThrowsAsync<AuthenticationException>(() => UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2", 
                "microsoft.onmicrosoft.com", this._username, string.Empty, cache));
        }


        [EnvironmentDependentFact]
        public void UserTokenProviderRefreshWorks()
        {
            var cache = new TestTokenCache();
            var credentials = UserTokenProvider.LoginSilentAsync("1950a258-227b-4e31-a9cf-717495945fc2", this._domain,
                this._username, this._password, cache).GetAwaiter().GetResult();
            cache.ForceTokenExpiry();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                new Uri("https://management.azure.com/subscriptions?api-version=2014-04-01-preview"));
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).Wait();
            Assert.NotNull(request.Headers.Authorization);
            var response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
#endif
        [EnvironmentDependentFact]
        public void ValidApplicationCredentialsAuthenticateCorrectly()
        {
            var cache = new TestTokenCache();
            var credentials = ApplicationTokenProvider.LoginSilentAsync(this._domain, this._applicationId, this._secret, cache).GetAwaiter().GetResult();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                new Uri("https://management.azure.com/subscriptions?api-version=2014-04-01-preview"));
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).Wait();
            Assert.NotNull(request.Headers.Authorization);
            var response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

#if FullNetFx
        [EnvironmentDependentFact]
        public void ApplicationCredentialsCanBeRenewed()
        {
            var cache = new TestTokenCache();
            var credentials = ApplicationTokenProvider.LoginSilentAsync(this._domain, this._applicationId, 
                new MemoryApplicationAuthenticationProvider(new ClientCredential(this._applicationId, this._secret)),
                 ActiveDirectoryServiceSettings.Azure, cache).GetAwaiter().GetResult();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
                new Uri("https://management.azure.com/subscriptions?api-version=2014-04-01-preview"));
            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).Wait();
            Assert.NotNull(request.Headers.Authorization);
            var response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private static bool TryFindCertificatesInStore(string thumbprint,
                     System.Security.Cryptography.X509Certificates.StoreLocation location, out System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificates)
        {
            System.Security.Cryptography.X509Certificates.X509Store store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreName.My, location);
            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadOnly);
            certificates = store.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindByThumbprint, thumbprint, false);
            store.Close();


            return certificates.Count > 0;
        } 
#endif

        class TestTokenCache : TokenCache
        {
            public void ForceTokenExpiry()
            {
                var expired = DateTimeOffset.UtcNow - TimeSpan.FromMinutes(5);
                var dictionaryProperty = typeof (TokenCache).GetField("tokenCacheDictionary", BindingFlags.NonPublic | BindingFlags.Instance);
                IDictionary dictionary = dictionaryProperty.GetValue(this) as IDictionary;
                foreach (var authValue in dictionary.Values)
                {
                    var authResult = authValue.GetType().GetProperty("Result").GetValue(authValue) as AuthenticationResult;
                    var expiresOnProperty = typeof (AuthenticationResult).GetProperty("ExpiresOn");
                    expiresOnProperty.SetValue(authResult, expired);
                }
            }
        }
    }
    public class EnvironmentDependentFactAttribute : FactAttribute
    {
        public EnvironmentDependentFactAttribute(params string[] scenarios)
        {
            IDictionary<string, string> connectionProperties =
                ParseConnectionString(Environment.GetEnvironmentVariable("ARM_Connection_String"));

            if (connectionProperties == null ||
                (!(connectionProperties.ContainsKey("username") && 
                   connectionProperties.ContainsKey("password") &&
                   connectionProperties.ContainsKey("applicationid") && 
                   connectionProperties.ContainsKey("secret") && 
                   connectionProperties.ContainsKey("domain") &&
                   connectionProperties.ContainsKey("certificatePassword"))))
            {
                Skip = "An environment variable: ARM_Connection_String=username=<username>;password=<password>;applicationid=<applicationId>;secret=<secret>;domain=<domain>;certificatePassword=<certificatePassword> is required to run this test";
            }

        }

        internal static IDictionary<string, string> ParseConnectionString(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return null;
            }
            Dictionary<string, string> result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var pairString in connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var pair = pairString.Split(new[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                result[pair[0]] = pair[1];
            }

            return result;
        }
    }
}
