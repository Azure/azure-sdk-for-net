// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public class ProviderRegistrationDelegatingHandler : DelegatingHandlerBase
    {
        private AzureCredentials credentials;
        private JsonSerializerSettings settings;

        public ProviderRegistrationDelegatingHandler(AzureCredentials credentials) 
            : base()
        {
            this.credentials = credentials;
            this.settings = new JsonSerializerSettings();
            settings.Converters.Add(new CloudErrorJsonConverter());
        }

        public ProviderRegistrationDelegatingHandler(AzureCredentials credentials, HttpMessageHandler innerHandler) 
            : base(innerHandler)
        {
            this.credentials = credentials;
        }
        
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode && response.Content != null)
            {
                string content = await response.Content.ReadAsStringAsync();
                string contentType = GetHeader(response.Content.Headers, "Content-Type");
                if (contentType != null && contentType.Contains("application/json"))
                {
                    CloudError cloudError = Rest.Serialization.SafeJsonConvert.DeserializeObject<CloudError>(content, settings);
                    if (cloudError != null && cloudError.Code == "MissingSubscriptionRegistration")
                    {
                        Regex regex = new Regex("/subscriptions/([\\w-]+)/", RegexOptions.IgnoreCase);
                        Match match = regex.Match(request.RequestUri.AbsolutePath);
                        IResourceManager resourceManager = ResourceManager.Authenticate(credentials).WithSubscription(match.Groups[1].Value);
                        regex = new Regex(".*'(.*)'");
                        match = regex.Match(cloudError.Message);
                        IProvider provider = await resourceManager.Providers.RegisterAsync(match.Groups[1].Value);
                        while ("Unregistered".Equals(provider.RegistrationState, StringComparison.OrdinalIgnoreCase)
                            || "Registering".Equals(provider.RegistrationState, StringComparison.OrdinalIgnoreCase))
                        {
                            await SdkContext.DelayProvider.DelayAsync(5000, cancellationToken);
                            provider = await resourceManager.Providers.GetByNameAsync(match.Groups[1].Value);
                        }
                        response = await base.SendAsync(request, cancellationToken);
                    }
                }
                
            }
            return response;
        }
    }
}
