using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
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
            ApplicationTokenCredentials credentials = new ApplicationTokenCredentials(@"C:\my.azureauth");
            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}
