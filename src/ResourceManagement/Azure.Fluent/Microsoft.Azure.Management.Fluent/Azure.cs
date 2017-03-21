// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Cdn.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Dns.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Redis.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using System.Linq;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using Microsoft.Azure.Management.AppService.Fluent;
using System;

namespace Microsoft.Azure.Management.Fluent
{
    public class Azure : IAzure
    {
        private IAuthenticated authenticated;

        #region Service Managers

        private IResourceManager resourceManager;
        private IStorageManager storageManager;
        private IComputeManager computeManager;
        private INetworkManager networkManager;
        private IBatchManager batchManager;
        private IKeyVaultManager keyVaultManager;
        private ITrafficManager trafficManager;
        private IDnsZoneManager dnsZoneManager;
        private ISqlManager sqlManager;
        private ICdnManager cdnManager;
        private IRedisManager redisManager;
        private IAppServiceManager appServiceManager;

        #endregion Service Managers

        #region Getters

        /// <returns>the currently selected subscription ID this client is authenticated to work with</returns>
        public string SubscriptionId
        {
            get; private set;
        }

        /// <returns>the currently selected subscription this client is authenticated to work with</returns>
        public ISubscription GetCurrentSubscription()
        {
            return Subscriptions.GetById(SubscriptionId);
        }

        /// <returns>entry point to managing resource groups</returns>
        public IResourceGroups ResourceGroups
        {
            get
            {
                return resourceManager.ResourceGroups;
            }
        }

        /// <returns>entry point to managing storage accounts</returns>
        public IStorageAccounts StorageAccounts
        {
            get
            {
                return storageManager.StorageAccounts;
            }
        }

        /// <returns>entry point to managing virtual machines</returns>
        public IVirtualMachines VirtualMachines
        {
            get
            {
                return computeManager.VirtualMachines;
            }
        }

        /// <returns>entry point to managing virtual machine scale sets</returns>
        public IVirtualMachineScaleSets VirtualMachineScaleSets
        {
            get
            {
                return computeManager.VirtualMachineScaleSets;
            }
        }

        /// <returns>entry point to managing virtual networks</returns>
        public INetworks Networks
        {
            get
            {
                return networkManager.Networks;
            }
        }

        /// <returns>entry point to managing network security groups</returns>
        public INetworkSecurityGroups NetworkSecurityGroups
        {
            get
            {
                return networkManager.NetworkSecurityGroups;
            }
        }

        /// <returns>entry point to managing public IP addresses</returns>
        public IPublicIPAddresses PublicIPAddresses
        {
            get
            {
                return networkManager.PublicIPAddresses;
            }
        }

        /// <returns>entry point to managing network interfaces</returns>
        public INetworkInterfaces NetworkInterfaces
        {
            get
            {
                return networkManager.NetworkInterfaces;
            }
        }

        /// <returns>entry point to managing virtual load balancers</returns>
        public ILoadBalancers LoadBalancers
        {
            get
            {
                return networkManager.LoadBalancers;
            }
        }

        /// <returns>entry point to managing application gateways</returns>
        public IApplicationGateways ApplicationGateways
        {
            get
            {
                return networkManager.ApplicationGateways;
            }
        }

        /// <returns>entry point to managing deployments</returns>
        public IDeployments Deployments
        {
            get
            {
                return resourceManager.Deployments;
            }
        }

        /// <returns>entry point to managing virtual machine images</returns>
        public IVirtualMachineImages VirtualMachineImages
        {
            get
            {
                return computeManager.VirtualMachineImages;
            }
        }

        /// <returns>entry point to managing virtual machine extension images</returns>
        public IVirtualMachineExtensionImages VirtualMachineExtensionImages
        {
            get
            {
                return computeManager.VirtualMachineExtensionImages;
            }
        }

        /// <returns>entry point to managing availability sets</returns>
        public IAvailabilitySets AvailabilitySets
        {
            get
            {
                return computeManager.AvailabilitySets;
            }
        }

        /// <returns>entry point to managing Azure Batch accounts</returns>
        public IBatchAccounts BatchAccounts
        {
            get
            {
                return batchManager.BatchAccounts;
            }
        }

        /// <returns>entry point to managing Azure key vaults</returns>
        public IVaults Vaults
        {
            get
            {
                return keyVaultManager.Vaults;
            }
        }

        /// <returns>entry point to managing Traffic Manager profiles</returns>
        public ITrafficManagerProfiles TrafficManagerProfiles
        {
            get
            {
                return trafficManager.Profiles;
            }
        }

        /// <returns>entry point to managing DNS zones</returns>
        public IDnsZones DnsZones
        {
            get
            {
                return dnsZoneManager.Zones;
            }
        }

        /// <returns>entry point to managing SQL servers</returns>
        public ISqlServers SqlServers
        {
            get
            {
                return sqlManager.SqlServers;
            }
        }

        /// <returns>entry point to managing Redis caches</returns>
        public IRedisCaches RedisCaches
        {
            get
            {
                return redisManager.RedisCaches;
            }
        }

        /// <returns>entry point to managing CDN profiles</returns>
        public ICdnProfiles CdnProfiles
        {
            get
            {
                return cdnManager.Profiles;
            }
        }

        /// <returns>entry point to managing web apps</returns>
        public IWebApps WebApps
        {
            get
            {
                return appServiceManager.WebApps;
            }
        }

        /// <returns>entry point to managing app services</returns>
        public IAppServiceManager AppServices
        {
            get
            {
                return appServiceManager;
            }
        }

        /// <returns>subscriptions that this authenticated client has access to</returns>
        public ISubscriptions Subscriptions
        {
            get
            {
                return authenticated.Subscriptions;
            }
        }

        public IVirtualMachineCustomImages VirtualMachineCustomImages
        {
            get
            {
                return computeManager.VirtualMachineCustomImages;
            }
        }

        public IDisks Disks
        {
            get
            {
                return computeManager.Disks;
            }
        }

        public ISnapshots Snapshots
        {
            get
            {
                return computeManager.Snapshots;
            }
        }

        #endregion Getters

        #region ctrs

        private Azure(RestClient restClient, string subscriptionId, string tenantId, IAuthenticated authenticated)
        {
            resourceManager = Management.Resource.Fluent.ResourceManager.Authenticate(restClient).WithSubscription(subscriptionId);
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
            computeManager = ComputeManager.Authenticate(restClient, subscriptionId);
            networkManager = NetworkManager.Authenticate(restClient, subscriptionId);
            batchManager = BatchManager.Authenticate(restClient, subscriptionId);
            keyVaultManager = KeyVaultManager.Authenticate(restClient, subscriptionId, tenantId);
            trafficManager = TrafficManager.Fluent.TrafficManager.Authenticate(restClient, subscriptionId);
            dnsZoneManager = DnsZoneManager.Authenticate(restClient, subscriptionId);
            sqlManager = SqlManager.Authenticate(restClient, subscriptionId);
            redisManager = RedisManager.Authenticate(restClient, subscriptionId);
            cdnManager = CdnManager.Authenticate(restClient, subscriptionId);
            appServiceManager = AppServiceManager.Authenticate(restClient, subscriptionId, tenantId);
            SubscriptionId = subscriptionId;
            this.authenticated = authenticated;
        }

        #endregion ctrs

        #region Azure builder

        private static Authenticated CreateAuthenticated(RestClient restClient, string tenantId)
        {
            return new Authenticated(restClient, tenantId);
        }

        public static IAuthenticated Authenticate(AzureCredentials azureCredentials)
        {
            var authenticated = CreateAuthenticated(RestClient.Configure()
                    .WithEnvironment(azureCredentials.Environment)
                    .WithCredentials(azureCredentials)
                    .Build(), azureCredentials.TenantId);
            authenticated.SetDefaultSubscription(azureCredentials.DefaultSubscriptionId);
            return authenticated;
        }

        public static IAuthenticated Authenticate(string authFile)
        {
            AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(authFile);
            return Authenticate(credentials);
        }

        public static IAuthenticated Authenticate(RestClient restClient, string tenantId)
        {
            return CreateAuthenticated(restClient, tenantId);
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
            private Management.Resource.Fluent.ResourceManager.IAuthenticated resourceManagerAuthenticated;
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
                resourceManagerAuthenticated = Management.Resource.Fluent.ResourceManager.Authenticate(this.restClient);
                this.tenantId = tenantId;
            }

            public void SetDefaultSubscription(string subscriptionId)
            {
                defaultSubscription = subscriptionId;
            }

            public IAzure WithSubscription(string subscriptionId)
            {
                return new Azure(restClient, subscriptionId, tenantId, this);
            }

            public IAzure WithDefaultSubscription()
            {
                if (!string.IsNullOrWhiteSpace(defaultSubscription))
                {
                    return WithSubscription(defaultSubscription);
                }
                else
                {
                    var resourceManager = Management.Resource.Fluent.ResourceManager.Authenticate(
                        RestClient.Configure()
                            .WithBaseUri(restClient.BaseUri)
                            .WithCredentials(restClient.Credentials).Build());
                    var subscription = resourceManager.Subscriptions.List()
                        .FirstOrDefault(s =>
                            StringComparer.OrdinalIgnoreCase.Equals(s.State, "Enabled") ||
                            StringComparer.OrdinalIgnoreCase.Equals(s.State, "Warned"));

                    return WithSubscription(subscription?.SubscriptionId);
                }
            }
        }

        #endregion IAuthenticated and it's implementation

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IAuthenticated Authenticate(AzureCredentials azureCredentials);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            IAuthenticated IConfigurable.Authenticate(AzureCredentials credentials)
            {
                var authenticated = new Authenticated(BuildRestClient(credentials), credentials.TenantId);
                authenticated.SetDefaultSubscription(credentials.DefaultSubscriptionId);
                return authenticated;
            }
        }

        #endregion IConfigurable and it's implementation
    }

    public interface IAzure
    {
        string SubscriptionId { get; }

        ISubscription GetCurrentSubscription();

        ISubscriptions Subscriptions { get; }

        IResourceGroups ResourceGroups { get; }

        IStorageAccounts StorageAccounts { get; }

        IVirtualMachines VirtualMachines { get; }

        IVirtualMachineScaleSets VirtualMachineScaleSets { get; }

        INetworks Networks { get; }

        INetworkSecurityGroups NetworkSecurityGroups { get; }

        IPublicIPAddresses PublicIPAddresses { get; }

        INetworkInterfaces NetworkInterfaces { get; }

        ILoadBalancers LoadBalancers { get; }

        IApplicationGateways ApplicationGateways { get; }

        IDeployments Deployments { get; }

        IVirtualMachineImages VirtualMachineImages { get; }

        IVirtualMachineExtensionImages VirtualMachineExtensionImages { get; }

        IAvailabilitySets AvailabilitySets { get; }

        IBatchAccounts BatchAccounts { get; }

        IVaults Vaults { get; }

        ITrafficManagerProfiles TrafficManagerProfiles { get; }

        IDnsZones DnsZones { get; }

        ISqlServers SqlServers { get; }

        IRedisCaches RedisCaches { get; }

        ICdnProfiles CdnProfiles { get; }

        IWebApps WebApps { get; }

        IAppServiceManager AppServices { get; }

        IVirtualMachineCustomImages VirtualMachineCustomImages { get; }

        IDisks Disks { get; }

        ISnapshots Snapshots { get; }
    }
}