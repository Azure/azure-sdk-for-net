﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Microsoft.Azure.Management.Trafficmanager.Fluent;
using Microsoft.Azure.Management.AppService.Fluent;
using System;

namespace Microsoft.Azure.Management.Fluent
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
        private ITrafficManager trafficManager;
        private IDnsZoneManager dnsZoneManager;
        private ISqlManager sqlManager;
        private ICdnManager cdnManager;
        private IRedisManager redisManager;
        private IAppServiceManager appServiceManager;

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

        public IVirtualMachineScaleSets VirtualMachineScaleSets
        {
            get
            {
                return computeManager.VirtualMachineScaleSets;
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

        public IApplicationGateways ApplicationGateways
        {
            get
            {
                return networkManager.ApplicationGateways;
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

        public ITrafficManagerProfiles TrafficManagerProfiles
        {
            get
            {
                return trafficManager.Profiles;
            }
        }

        public IDnsZones DnsZones
        {
            get
            {
                return dnsZoneManager.Zones;
            }
        }

        public ISqlServers SqlServers
        {
            get
            {
                return sqlManager.SqlServers;
            }
        }

        public IRedisCaches RedisCaches
        {
            get
            {
                return redisManager.RedisCaches;
            }
        }

        public ICdnProfiles CdnProfiles
        {
            get
            {
                return cdnManager.Profiles;
            }
        }

        public IWebApps WebApps
        {
            get
            {
                return appServiceManager.WebApps;
            }
        }

        public IAppServiceManager AppServices
        {
            get
            {
                return appServiceManager;
            }
        }

        #endregion Getters

        #region ctrs

        private Azure(RestClient restClient, string subscriptionId, string tenantId)
        {
            resourceManager = ResourceManager.Authenticate(restClient).WithSubscription(subscriptionId);
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
            computeManager = ComputeManager.Authenticate(restClient, subscriptionId);
            networkManager = NetworkManager.Authenticate(restClient, subscriptionId);
            batchManager = BatchManager.Authenticate(restClient, subscriptionId);
            keyVaultManager = KeyVaultManager.Authenticate(restClient, subscriptionId, tenantId);
            trafficManager = Trafficmanager.Fluent.TrafficManager.Authenticate(restClient, subscriptionId);
            dnsZoneManager = DnsZoneManager.Authenticate(restClient, subscriptionId);
            sqlManager = SqlManager.Authenticate(restClient, subscriptionId);
            redisManager = RedisManager.Authenticate(restClient, subscriptionId);
            cdnManager = CdnManager.Authenticate(restClient, subscriptionId);
            appServiceManager = AppServiceManager.Authenticate(restClient, subscriptionId, tenantId);
            SubscriptionId = subscriptionId;
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
            private Resource.Fluent.ResourceManager.IAuthenticated resourceManagerAuthenticated;
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
                resourceManagerAuthenticated = Resource.Fluent.ResourceManager.Authenticate(this.restClient);
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
                if (!string.IsNullOrWhiteSpace(defaultSubscription))
                {
                    return WithSubscription(defaultSubscription);
                }
                else
                {
                    var resourceManager = Resource.Fluent.ResourceManager.Authenticate(
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

        IResourceGroups ResourceGroups { get; }

        IStorageAccounts StorageAccounts { get; }

        IVirtualMachines VirtualMachines { get; }

        IVirtualMachineScaleSets VirtualMachineScaleSets { get; }

        INetworks Networks { get; }

        INetworkSecurityGroups NetworkSecurityGroups { get; }

        IPublicIpAddresses PublicIpAddresses { get; }

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
    }
}