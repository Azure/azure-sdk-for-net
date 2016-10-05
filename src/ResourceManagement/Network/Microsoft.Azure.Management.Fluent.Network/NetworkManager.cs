﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Network
{
    using Management.Network;
    using Resource.Core;
    using Resource;
    using Rest;
    using System;
    using System.Linq;
    using Resource.Authentication;

    public class NetworkManager : ManagerBase, INetworkManager
    {
        private NetworkManagementClient networkManagementClient;
        private PublicIpAddressesImpl publicIpAddresses;
        private NetworkInterfacesImpl networkInterfaces;
        private NetworkSecurityGroupsImpl networkSecurityGroups;
        private NetworksImpl networks;
        private LoadBalancersImpl loadBalancers;

        private NetworkManager(RestClient restClient, string subscriptionId) : base(restClient, subscriptionId)
        {
            networkManagementClient = new NetworkManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            networkManagementClient.SubscriptionId = subscriptionId;
        }


        /// <summary>
        /// Creates an instance of NetworkManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the NetworkManager</returns>
        public static INetworkManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new NetworkManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId);
        }

        /// <summary>
        /// Creates an instance of NetworkManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the NetworkManager</returns>
        public static INetworkManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new NetworkManager(restClient, subscriptionId);
        }

        /// <summary>
        /// Get a Configurable instance that can be used to create NetworkManager with optional configuration.
        /// </summary>
        /// <returns>the instance allowing configurations</returns>
        public static IConfigurable Configure()
        {
            return new Configurable();
        }


        /// <summary>
        /// The inteface allowing configurations to be set.
        /// </summary>
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            INetworkManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of NetworkManager that exposes storage management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <return>the interface exposing storage management API entry points that work in a subscription</returns>
            public INetworkManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new NetworkManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        /// <summary>
        /// return entry point to virtual network management
        /// </summary>
        public INetworks Networks
        {
            get
            {
                if (networks == null)
                {
                    networks = new NetworksImpl(networkManagementClient, this);
                }

                return networks;
            }
        }

        /// <summary>
        /// return entry point to network security group management
        /// </summary>
        public INetworkSecurityGroups NetworkSecurityGroups
        {
            get
            {
                if (networkSecurityGroups == null)
                {
                    networkSecurityGroups = new NetworkSecurityGroupsImpl(networkManagementClient.NetworkSecurityGroups, this);
                }

                return networkSecurityGroups;
            }
        }

        /// <summary>
        /// return entry point to public IP address management
        /// </summary>
        public IPublicIpAddresses PublicIpAddresses
        {
            get
            {
                if (publicIpAddresses == null)
                {
                    publicIpAddresses = new PublicIpAddressesImpl(networkManagementClient, this);
                }

                return publicIpAddresses;
            }
        }

        /// <summary>
        /// return entry point to network interface management
        /// </summary>
        public INetworkInterfaces NetworkInterfaces
        {
            get
            {
                if (networkInterfaces == null)
                {
                    networkInterfaces = new NetworkInterfacesImpl(networkManagementClient, this);
                }

                return networkInterfaces;
            }
        }

        /// <summary>
        /// return entry point to load balancer management
        /// </summary>
        public ILoadBalancers LoadBalancers
        {
            get
            {
                if (loadBalancers == null)
                {
                    loadBalancers = new LoadBalancersImpl(networkManagementClient, this);
                }

                return loadBalancers;
            }
        }
    }

    public interface INetworkManager : IManagerBase
    {
        /// <summary>
        /// return entry point to virtual network management
        /// </summary>
        INetworks Networks { get; }

        /// <summary>
        /// return entry point to network security group management
        /// </summary>
        INetworkSecurityGroups NetworkSecurityGroups { get; }

        /// <summary>
        /// return entry point to public IP address management
        /// </summary>
        IPublicIpAddresses PublicIpAddresses { get; }

        /// <summary>
        /// return entry point to network interface management
        /// </summary>
        INetworkInterfaces NetworkInterfaces { get; }

        /// <summary>
        /// return entry point to load balancer management
        /// </summary>
        ILoadBalancers LoadBalancers { get; }
    }
}
