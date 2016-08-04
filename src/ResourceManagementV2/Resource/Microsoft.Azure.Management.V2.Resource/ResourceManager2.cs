using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.V2.Resource
{
    public class ResourceManager2 : ManagerBase, IResourceManager
    {
        #region SDK clients
        private ResourceManagementClient resourceManagementClient;
        private FeatureClient featureClient;
        #endregion

        #region ctrs

        private ResourceManager2(RestClient restClient, string subscriptionId) : base(null, subscriptionId)
        {
            resourceManagementClient = new ResourceManager.ResourceManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            resourceManagementClient.SubscriptionId = subscriptionId;
            featureClient = new FeatureClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            featureClient.SubscriptionId = subscriptionId;
            ResourceManager = this;
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

        /// <summary>
        ///  The interface exposing resource management API entry points that work across subscriptions.
        /// </summary>
        public interface IAuthenticated
        {
            /// <summary>
            /// Gets the entry point to tenant management API.
            /// </summary>
            ITenants Tenants { get; }

            /// <summary>
            /// Gets the entry point to subscription management API.
            /// </summary>
            ISubscriptions Subscriptions { get; }

            /// <summary>
            /// Specifies a subscription to expose resource management API entry points that work in a subscription.
            /// </summary>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <returns>The IResourceManager, the entry point that works in a subscription</returns>
            IResourceManager WithSubscription(string subscriptionId);
        }

        protected class Authenticated : IAuthenticated
        {
            private RestClient restClient;
            private SubscriptionClient subscriptionClient;

            public Authenticated(RestClient restClient)
            {
                this.restClient = restClient;
                subscriptionClient = new SubscriptionClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            }

            #region Implementaiton of IAuthenticated interface

            private ISubscriptions subscriptions;
            private ITenants tenants;

            public ISubscriptions Subscriptions
            {
                get
                {
                    if (subscriptions == null)
                    {
                        subscriptions = new SubscriptionsImpl(subscriptionClient.Subscriptions);
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
                        tenants = new TenantsImpl(subscriptionClient.Tenants);
                    }
                    return tenants;
                }
            }

            public IResourceManager WithSubscription(string subscriptionId)
            {
                return new ResourceManager2(restClient, subscriptionId);
            }

            #endregion
        }
        #endregion

        #region IConfigurable and it's implementation

        /// <summary>
        /// The inteface allowing configurations to be set.
        /// </summary>
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            /// <summary>
            /// Creates an IAuthentciated implementaition exposing resource managment API entry point that work across subscriptions
            /// </summary>
            /// <param name="serviceClientCredentials">The credentials to use</param>
            /// <returns>IAuthentciated, the inteface exposing resource managment API entry point that work across subscriptions</returns>
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

        #region Implementation of IResourceManager interface

        #region Subscription based fluent collections in Azure resource service.

        private IResourceGroups resourceGroups;
        private IGenericResources genericResources;
        private IDeployments deployments;
        private IFeatures features;
        private IProviders providers;

        #endregion

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

        public IGenericResources GenericResources
        {
            get
            {
                if (genericResources == null)
                {
                    genericResources = new GenericResourcesImpl(resourceManagementClient, this);

                }
                return genericResources;
            }
        }

        public IDeployments Deployments
        {
            get
            {
                if (deployments == null)
                {
                    deployments = new DeploymentsImpl(resourceManagementClient.Deployments,
                        resourceManagementClient.DeploymentOperations,
                        this);
                }
                return deployments;
            }
        }

        public IFeatures Features
        {
            get
            {
                if (features == null)
                {
                    features = new FeaturesImpl(featureClient.Features);
                }
                return features;
            }
        }

        public IProviders Providers
        {
            get
            {
                if (providers == null)
                {
                    providers = new ProvidersImpl(resourceManagementClient.Providers);
                }
                return providers;
            }
        }

        #endregion
    }

    /// <summary>
    /// Entry point to Azure resource management.
    /// </summary>
    public interface IResourceManager : IManagerBase
    {
        /// <summary>
        /// Gets the resource group management API entry point.
        /// </summary>
        IResourceGroups ResourceGroups { get; }

        /// <summary>
        /// Gets the generic resource management API entry point.
        /// </summary>
        IGenericResources GenericResources { get; }

        /// <summary>
        /// Gets the deployment management API entry point.
        /// </summary>
        IDeployments Deployments { get; }

        /// <summary>
        /// Gets the feature management API entry point.
        /// </summary>
        IFeatures Features { get; }

        /// <summary>
        /// Gets the provider management API entry point.
        /// </summary>
        IProviders Providers { get; }
    }
}
