// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests
{
    public class ProvidersTests
    {
        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanRegisterAndUnRegisterProvider()
        {
            var resourceManager = CreateResourceManager();
            var providers = resourceManager.Providers.List();
            IProvider provider = providers.FirstOrDefault();
            Assert.NotNull(provider);

            provider = resourceManager.Providers.Unregister(provider.Namespace);
            while (provider.RegistrationState.Equals("Unregistering"))
            {
                Thread.Sleep(5000);
                provider = resourceManager.Providers.GetByName(provider.Namespace);
            }

            provider = resourceManager.Providers.Register(provider.Namespace);
            while (provider.RegistrationState.Equals("Registering"))
            {
                Thread.Sleep(5000);
                provider = resourceManager.Providers.GetByName(provider.Namespace);
            }
            Assert.True(string.Equals(provider.RegistrationState, "Registered"));
            IList<ProviderResourceType> resourceTypes = provider.ResourceTypes;
            Assert.True(resourceTypes.Count > 0);
        }

        private IResourceManager CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            IResourceManager resourceManager = ResourceManager.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}
