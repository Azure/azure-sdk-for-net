// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication.IntegrationTests.Models;
using Microsoft.Azure.Services.AppAuthentication.TestCommon;
using Newtonsoft.Json;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests
{
    /// <summary>
    /// Used to create service principalls and Azure AD applications to test if AzureServiceTokenProvider can get tokens using these App credentials. 
    /// </summary>
    public class GraphHelper
    {
        private readonly string _directory;
        private readonly AzureServiceTokenProvider _azureServiceTokenProvider;

        public GraphHelper(string directory)
        {
            _directory = directory;
            _azureServiceTokenProvider = new AzureServiceTokenProvider(Constants.AzureCliConnectionString);
        }

        /// <summary>
        /// Create Azure AD application with Password credential. 
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        public async Task<Application> CreateApplicationAsync(string secret)
        {
            Guid guid = Guid.NewGuid();

            Application newApp = new Application
            {
                DisplayName = $"Microsoft.Azure.Services.AppAuthentication.Test{guid}",
                IdentifierUris = new List<string> { $"https://Microsoft.Azure.Services.AppAuthentication/{guid}"},
                ReplyUrls = new List<string> { "https://Microsoft.Azure.Services.AppAuthentication/" },
                OdataType = "Microsoft.DirectoryServices.Application",
                AppRolesODataType = "Collection(Microsoft.DirectoryServices.AppRole)",
                IdentifierUrisODataType = "Collection(Edm.String)",
                ReplyUrlsODdataType = "Collection(Edm.String)",
                PasswordCredentialsODdataType = "Collection(Microsoft.DirectoryServices.PasswordCredential)"
            };

            PasswordCredential keyCredential = new PasswordCredential
            {
                Value = secret,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2)
            };

            newApp.PasswordCredentials = new List<PasswordCredential> {keyCredential};

            return await CreateApplication(newApp).ConfigureAwait(false);

        }

        /// <summary>
        /// Create Azure AD application with cert as the key credential. 
        /// </summary>
        /// <param name="cert"></param>
        /// <returns></returns>
        public async Task<Application> CreateApplicationAsync(X509Certificate2 cert)
        {
            Guid guid = Guid.NewGuid();

            Application newApp = new Application
            {
                DisplayName = $"Microsoft.Azure.Services.AppAuthentication.Test{guid}",
                IdentifierUris = new List<string> { $"https://localhost/demo/{guid}"},
                ReplyUrls = new List<string> { "https://localhost/demo" },
                OdataType = "Microsoft.DirectoryServices.Application",
                AppRolesODataType = "Collection(Microsoft.DirectoryServices.AppRole)",
                IdentifierUrisODataType = "Collection(Edm.String)",
                ReplyUrlsODdataType = "Collection(Edm.String)",
                KeyCredentialsODdataType = "Collection(Microsoft.DirectoryServices.KeyCredential)"
            };

            KeyCredential keyCredential = new KeyCredential
            {
                Type = "AsymmetricX509Cert",
                Usage = "Verify",
                Value = Convert.ToBase64String(cert.Export(X509ContentType.Cert)),
                StartDate = cert.NotBefore,
                EndDate = cert.NotAfter
            };

            newApp.KeyCredentials = new List<KeyCredential> { keyCredential };

            return await CreateApplication(newApp).ConfigureAwait(false);

        }

        /// <summary>
        /// Common method to create Azure AD application and service principal
        /// </summary>
        /// <param name="newApp"></param>
        /// <returns></returns>
        private async Task<Application> CreateApplication(Application newApp)
        {
            AppRole appRole = new AppRole
            {
                Id = Guid.NewGuid().ToString(),
                IsEnabled = true,
                DisplayName = "Something",
                Description = "Anything",
                Value = "policy.write",
                AllowedMemberTypes = new List<string> { "User" },
                AllowedMemberTypesODataType = "Collection(Edm.String)"
            };
            newApp.AppRoles = new List<AppRole> { appRole };

            string content = JsonConvert.SerializeObject(newApp, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            var createdApp = JsonConvert.DeserializeObject<Application>(await SendHttpRequest(HttpMethod.Post,
                $"{Constants.GraphResourceId}{_directory}/applications?api-version=1.6",
                new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false));

            ServicePrincipal newServicePrincipal = new ServicePrincipal
            {
                DisplayName = newApp.DisplayName,
                AccountEnabled = true,
                AppId = createdApp.AppId,
                OdataType = "Microsoft.DirectoryServices.ServicePrincipal"
            };

            var servicePrincipal = JsonConvert.DeserializeObject<ServicePrincipal>(await SendHttpRequest(HttpMethod.Post,
                $"{Constants.GraphResourceId}{_directory}/servicePrincipals?api-version=1.6",
                new StringContent(JsonConvert.SerializeObject(newServicePrincipal), Encoding.UTF8, "application/json")).ConfigureAwait(false));

            createdApp.ServicePrincipal = servicePrincipal;

            return createdApp;
        }

        /// <summary>
        /// Delete application and service principal, once testing is done. 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public async Task DeleteApplicationAsync(Application app)
        {
            await SendHttpRequest(HttpMethod.Delete,
                $"{Constants.GraphResourceId}{_directory}/directoryObjects/{app.ServicePrincipal.ObjectId}?api-version=1.6").ConfigureAwait(false);

            await SendHttpRequest(HttpMethod.Delete,
                    $"{Constants.GraphResourceId}{_directory}/applications/{app.ObjectId}?api-version=1.6").ConfigureAwait(false);
            
        }

        /// <summary>
        /// Generic method to send http requests to Graph API
        /// </summary>
        /// <param name="method"></param>
        /// <param name="requestUrl"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task<string> SendHttpRequest(HttpMethod method, string requestUrl,
            HttpContent content = null)
        {
            HttpClient client = new HttpClient { Timeout = new TimeSpan(0, 0, 20) };

            HttpRequestMessage request = new HttpRequestMessage(method, requestUrl);

            var accessToken = await _azureServiceTokenProvider.GetAccessTokenAsync(Constants.GraphResourceId, _directory).ConfigureAwait(false);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (content != null)
            {
                // HttpContent is disposed, so making a copy of it for use
                var ms = new MemoryStream();

                await content.CopyToAsync(ms).ConfigureAwait(false);
                ms.Position = 0;
                request.Content = new StreamContent(ms);

                // Copy the content headers
                if (content.Headers != null)
                    foreach (var h in content.Headers)
                        request.Content.Headers.Add(h.Key, h.Value);
            }

            HttpResponseMessage response = await client.SendAsync(request);

            string responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return responseString;
            }

            throw new Exception($"{response.StatusCode}{responseString} {response.ReasonPhrase}");
        }

    }
}