// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Batch;
using Microsoft.Azure.Management.Fluent.Compute;
using Microsoft.Azure.Management.Fluent.Network;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Fluent.Storage;
using Microsoft.Rest;
using System.Linq;
using Microsoft.Azure.Management.Fluent.KeyVault;

namespace Microsoft.Azure.Management
{
    public class Azure : IAzure
    {
        #region Service Managers

        private IResourceManager resourceManager;
        private IStorageManager storageManager;
        private IComputeManager computeManager;
        private INetworkManager networkManager;
        private IBatchManager batchManager;
        private IKeyVaultManager keyVaultManager;

        #endregion Service Managers

        #region Getters

        public string SubscriptionId
        {
            get; private set;
        }

        public IResourceGroups ResourceGroups
        {
            get
            {
                return resourceManager.ResourceGroups;
            }
        }

        public IStorageAccounts StorageAccounts
        {
            get
            {
                return storageManager.StorageAccounts;
            }
        }

        public IVirtualMachines VirtualMachines
        {
            get
            {
                return computeManager.VirtualMachines;
            }
        }

        public INetworks Networks
        {
            get
            {
                return networkManager.Networks;
            }
        }

        public INetworkSecurityGroups NetworkSecurityGroups
        {
            get
            {
                return networkManager.NetworkSecurityGroups;
            }
        }

        public IPublicIpAddresses PublicIpAddresses
        {
            get
            {
                return networkManager.PublicIpAddresses;
            }
        }

        public INetworkInterfaces NetworkInterfaces
        {
            get
            {
                return networkManager.NetworkInterfaces;
            }
        }

        public ILoadBalancers LoadBalancers
        {
            get
            {
                return networkManager.LoadBalancers;
            }
        }

        public IDeployments Deployments
        {
            get
            {
                return resourceManager.Deployments;
            }
        }

        public IVirtualMachineImages VirtualMachineImages
        {
            get
            {
                return computeManager.VirtualMachineImages;
            }
        }

        public IVirtualMachineExtensionImages VirtualMachineExtensionImages
        {
            get
            {
                return computeManager.VirtualMachineExtensionImages;
            }
        }

        public IAvailabilitySets AvailabilitySets
        {
            get
            {
                return computeManager.AvailabilitySets;
            }
        }

        public IBatchAccounts BatchAccounts
        {
            get
            {
                return batchManager.BatchAccounts;
            }
        }
                
        public IVaults Vaults
        {
            get
            {
                return keyVaultManager.Vaults;
            }
        }

        #endregion Getters

        #region ctrs

        private Azure(RestClient restClient, string subscriptionId, string tenantId)
        {
            resourceManager = ResourceManager2.Authenticate(restClient).WithSubscription(subscriptionId);
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
            computeManager = ComputeManager.Authenticate(restClient, subscriptionId);
            networkManager = NetworkManager.Authenticate(restClient, subscriptionId);
            batchManager = BatchManager.Authenticate(restClient, subscriptionId);
            keyVaultManager = KeyVaultManager.Authenticate(restClient, subscriptionId, tenantId);
            SubscriptionId = subscriptionId;
        }

        #endregion ctrs

        #region Azure builder

        public static IAuthenticated Authenticate(ServiceClientCredentials serviceClientCredentials, string tenantId)
        {
            return new Authenticated(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(serviceClientCredentials)
                    .build(), tenantId
                );
        }

        public static IAuthenticated Authenticate(AzureCredentials azureCredentials)
        {
            return new Authenticated(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(azureCredentials)
                    .build(), azureCredentials.TenantId
                );
        }

        public static IAuthenticated Authenticate(string authFile)
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFile);
            var authenticated = new Authenticated(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(credentials)
                    .build(), credentials.TenantId);
            authenticated.SetDefaultSubscription(credentials.DefaultSubscriptionId);
            return authenticated;
        }

        public static IAuthenticated Authenticate(RestClient restClient, string tenantId)
        {
            return new Authenticated(restClient, tenantId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion Azure builder

        #region IAuthenticated and it's implementation

        public interface IAuthenticated
        {
            ITenants Tenants { get; }

            ISubscriptions Subscriptions { get; }

            IAzure WithSubscription(string subscriptionId);

            IAzure WithDefaultSubscription();
        }

        protected class Authenticated : IAuthenticated
        {
            private RestClient restClient;
            private ResourceManager2.IAuthenticated resourceManagerAuthenticated;
            private string defaultSubscription;
            private string tenantId;

            public ITenants Tenants
            {
                get
                {
                    return resourceManagerAuthenticated.Tenants;
                }
            }

            public ISubscriptions Subscriptions
            {
                get
                {
                    return resourceManagerAuthenticated.Subscriptions;
                }
            }

            public Authenticated(RestClient restClient, string tenantId)
            {
                this.restClient = restClient;
                resourceManagerAuthenticated = ResourceManager2.Authenticate(this.restClient);
                this.tenantId = tenantId;
            }

            public void SetDefaultSubscription(string subscriptionId)
            {
                defaultSubscription = subscriptionId;
            }

            public IAzure WithSubscription(string subscriptionId)
            {
                return new Azure(restClient, subscriptionId, tenantId);
            }

            public IAzure WithDefaultSubscription()
            {
                if (defaultSubscription != null)
                {
                    return WithSubscription(defaultSubscription);
                }
                else
                {
                    ISubscription subscription = Subscriptions.List().FirstOrDefault();
                    if (subscription != null)
                    {
                        return WithSubscription(subscription.SubscriptionId);
                    }
                    else
                    {
                        return WithSubscription(null);
                    }
                }
            }
        }

        #endregion IAuthenticated and it's implementation

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IAuthenticated Authenticate(ServiceClientCredentials serviceClientCredentials, string tenantId);

            IAuthenticated Authenticate(AzureCredentials azureCredentials);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            IAuthenticated IConfigurable.Authenticate(ServiceClientCredentials credentials, string tenantId)
            {
                return new Authenticated(BuildRestClient(credentials), tenantId);
            }

            IAuthenticated IConfigurable.Authenticate(AzureCredentials credentials)
            {
                return new Authenticated(BuildRestClient(credentials), credentials.TenantId);
            }
        }

        #endregion IConfigurable and it's implementation
    }

    public interface IAzure
    {
        string SubscriptionId { get; }

        IResourceGroups ResourceGroups { get; }

        IStorageAccounts StorageAccounts { get; }

        IVirtualMachines VirtualMachines { get; }

        INetworks Networks { get; }

        INetworkSecurityGroups NetworkSecurityGroups { get; }

        IPublicIpAddresses PublicIpAddresses { get; }

        INetworkInterfaces NetworkInterfaces { get; }

        ILoadBalancers LoadBalancers { get; }

        IDeployments Deployments { get; }

        IVirtualMachineImages VirtualMachineImages { get; }

        IVirtualMachineExtensionImages VirtualMachineExtensionImages { get; }

        IAvailabilitySets AvailabilitySets { get; }

        IBatchAccounts BatchAccounts { get; }

        IVaults Vaults { get; }
    }
}
