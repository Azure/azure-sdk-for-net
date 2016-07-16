using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.V2.Resource
{
    public class ResourceManager2 : IResourceManager
    {
        #region SDK clients
        private ResourceManager.ResourceManagementClient resourceManagementClient;
        #endregion

        #region Fluent private collections
        private IResourceGroups resourceGroups;
        #endregion

        #region ctrs

        private ResourceManager2(RestClient restClient, string subscriptionId)
        {
            resourceManagementClient = new ResourceManager.ResourceManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            resourceManagementClient.SubscriptionId = subscriptionId;
        }

        #endregion

        #region ResourceManager2 builder

        public static IAuthenticated Authenticate(ServiceClientCredentials serviceClientCredentials)
        {
            return new Authenticated(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(serviceClientCredentials)
                    .build()
                );
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

            IResourceManager WithSubscription(string subscriptionId);
        }

        protected class Authenticated : IAuthenticated
        {
            private RestClient restClient;
            private SubscriptionClient subscriptionClient;

            private ISubscriptions subscriptions;
            private ITenants tenants;

            public Authenticated(RestClient restClient)
            {
                this.restClient = restClient;
                subscriptionClient = new SubscriptionClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            }

            public ISubscriptions Subscriptions
            {
                get
                {
                    if (subscriptions == null)
                    {
                        subscriptions = new SubscriptionsImpl(this.subscriptionClient.Subscriptions);
                    }
                    return subscriptions;
                }
            }

            public ITenants Tenants
            {
                get
                {
                    if (tenants == null)
                    {
                        tenants = new TenantsImpl(this.subscriptionClient.Tenants);
                    }
                    return tenants;
                }
            }

            public IResourceManager WithSubscription(string subscriptionId)
            {
                return new ResourceManager2(this.restClient, subscriptionId);
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

        #region Collections in ResourceManager2

        public IResourceGroups ResourceGroups
        {
            get
            {
                if (resourceGroups == null)
                {
                    resourceGroups = new ResourceGroupsImpl(resourceManagementClient.ResourceGroups);
                }
                return resourceGroups;
            }
        }

        #endregion
    }

    public interface IResourceManager
    {
        IResourceGroups ResourceGroups { get; }
    }
}
