// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    public class RegistryManager : Manager<IContainerRegistryManagementClient>, IRegistryManager
    {
        #region Fluent private collections
        private IRegistries registries;
        private IStorageManager storageManager;
        #endregion

        public RegistryManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new ContainerRegistryManagementClient(
                new Uri(restClient.BaseUri),
                    restClient.Credentials,
                    restClient.RootHttpHandler,
                    restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
            this.storageManager = StorageManager.Authenticate(restClient, subscriptionId);
        }
        
        public static IRegistryManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new RegistryManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId);
        }

        public static IRegistryManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new RegistryManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }
        

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IRegistryManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IRegistryManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new RegistryManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public IRegistries ContainerRegistries
        {
            get
            {
                if (registries == null)
                {
                    registries = new RegistriesImpl(this, this.storageManager);
                }
                return registries;
            }
        }
    }

    public interface IRegistryManager : IManager<IContainerRegistryManagementClient>
    {
       IRegistries ContainerRegistries { get; }
    }
}
