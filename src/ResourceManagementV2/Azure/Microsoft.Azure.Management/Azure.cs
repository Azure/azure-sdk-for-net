using System;
using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Storage;
using Microsoft.Rest;
using System.Linq;
using Microsoft.Azure.Management.V2.Network;

namespace Microsoft.Azure.Management
{
    public class Azure : IAzure
    {
        #region Service Managers

        private IResourceManager resourceManager;
        private IStorageManager storageManager;
        private IComputeManager computeManager;
        private INetworkManager networkManager;

        #endregion

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

        #endregion

        #region ctrs

        private Azure(RestClient restClient, string subscriptionId)
        {
            resourceManager = ResourceManager2.Authenticate(restClient).WithSubscription(subscriptionId);
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
            computeManager = ComputeManager.Authenticate(restClient, subscriptionId);
            networkManager = NetworkManager.Authenticate(restClient, subscriptionId);
            SubscriptionId = subscriptionId;
        }

        #endregion

        #region Azure builder

        public static IAuthenticated Authenticate(ServiceClientCredentials serviceClientCredentials)
        {
            return new Authenticated(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(serviceClientCredentials)
                    .build()
                );
        }


        public static IAuthenticated Authenticate(string authFile)
        {
            ApplicationTokenCredentails credentils = new ApplicationTokenCredentails(authFile);
            var authenticated = new Authenticated(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(credentils)
                    .build());
            authenticated.SetDefaultSubscription(credentils.DefaultSubscriptionId);
            return authenticated;
        }


        public static IAuthenticated Authenticate(RestClient restClient)
        {
            return new Authenticated(restClient);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion

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

            public Authenticated(RestClient restClient)
            {
                this.restClient = restClient;
                resourceManagerAuthenticated = ResourceManager2.Authenticate(this.restClient);
            }

            public void SetDefaultSubscription(string subscriptionId)
            {
                defaultSubscription = subscriptionId;
            }

            public IAzure WithSubscription(string subscriptionId)
            {
                return new Azure(restClient, subscriptionId);
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
                    } else
                    {
                        return WithSubscription(null);
                    }
                }
            }
        }

        #endregion

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IAuthenticated Authenticate(ServiceClientCredentials serviceClientCredentials);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            IAuthenticated IConfigurable.Authenticate(ServiceClientCredentials credentials)
            {
                return new Authenticated(BuildRestClient(credentials));
            }
        }

        #endregion

    }

    public interface IAzure {
        string SubscriptionId { get; }

        IResourceGroups ResourceGroups { get; }

        IStorageAccounts StorageAccounts { get; }

        IVirtualMachines VirtualMachines { get; }

        INetworks Networks { get; }

        INetworkSecurityGroups NetworkSecurityGroups { get; }

        IPublicIpAddresses PublicIpAddresses { get; }

        INetworkInterfaces NetworkInterfaces { get; }
    }
}
