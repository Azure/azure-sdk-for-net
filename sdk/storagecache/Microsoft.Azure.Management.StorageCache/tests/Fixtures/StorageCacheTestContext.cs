// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Authorization.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    /// <summary>
    /// Defines the <see cref="StorageCacheTestContext" />.
    /// </summary>
    public class StorageCacheTestContext : IDisposable
    {
        /// <summary>
        /// Defines the mockContext.
        /// </summary>
        private readonly MockContext mockContext;

        /// <summary>
        /// Defines the serviceClientCache.
        /// </summary>
        private readonly Dictionary<Type, IDisposable> serviceClientCache = new Dictionary<Type, IDisposable>();

        /// <summary>
        /// Defines the disposedValue.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCacheTestContext"/> class.
        /// </summary>
        /// <param name="suiteObject">Class object.</param>
        /// <param name="methodName">Method name of the calling method.</param>
        public StorageCacheTestContext(
            object suiteObject,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = ".ctor")
        {
            this.mockContext = MockContext.Start(suiteObject.GetType().Name, methodName);
            this.RegisterSubscriptionForResource("Microsoft.StorageCache");
        }

        /// <summary>
        /// Get service client.
        /// </summary>
        /// <param name="delegationHandler">HTTP delegation handler.</param>
        /// <typeparam name="TServiceClient">The type of the service client to return.</typeparam>
        /// <returns>A management client, created from the current context (environment variables).</returns>
        public TServiceClient GetClient<TServiceClient>(DelegatingHandler delegationHandler = null)
            where TServiceClient : class, IDisposable
        {
            if (this.serviceClientCache.TryGetValue(typeof(TServiceClient), out IDisposable clientObject))
            {
                return (TServiceClient)clientObject;
            }

            if (delegationHandler == null)
            {
                delegationHandler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };
            }

            TServiceClient client = this.mockContext.GetServiceClient<TServiceClient>(handlers: delegationHandler);
            this.serviceClientCache.Add(typeof(TServiceClient), client);
            return client;
        }

        /// <summary>
        /// Get or create resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <param name="location">Location where resource group is to be created.</param>
        /// <returns>ResourceGroup object.</returns>
        public ResourceGroup GetOrCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceManagementClient resourceClient = this.GetClient<ResourceManagementClient>();
            ResourceGroup resourceGroup = this.GetResourceGroupIfExists(resourceGroupName);

            if (resourceGroup == null)
            {
                resourceGroup = resourceClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = location,
                    Tags = new Dictionary<string, string>() { { resourceGroupName, DateTime.UtcNow.ToString("u") } },
                });
            }

            return resourceGroup;
        }

        /// <summary>
        /// Get or create virtual network.
        /// </summary>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="virtualNetworkName">The name of the virtual network.</param>
        /// <returns>VirtualNetwork object.</returns>
        public VirtualNetwork GetOrCreateVirtualNetwork(ResourceGroup resourceGroup, string virtualNetworkName)
        {
            NetworkManagementClient networkManagementClient = this.GetClient<NetworkManagementClient>();
            VirtualNetwork virtualNetwork = null;
            try
            {
                virtualNetwork = networkManagementClient.VirtualNetworks.Get(resourceGroup.Name, virtualNetworkName);
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code != "ResourceNotFound")
                {
                    throw;
                }
            }

            if (virtualNetwork == null)
            {
                var vnet = new VirtualNetwork()
                {
                    Location = resourceGroup.Location,
                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string> { "10.0.0.0/16" },
                    },
                };
                virtualNetwork = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroup.Name, virtualNetworkName, vnet);
            }

            return virtualNetwork;
        }

        /// <summary>
        /// Get Or create subnet.
        /// </summary>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="virtualNetwork">Object representing a virtual network.</param>
        /// <param name="subnetName">The name of the subnet.</param>
        /// <returns>Subnet object.</returns>
        public Subnet GetOrCreateSubnet(ResourceGroup resourceGroup, VirtualNetwork virtualNetwork, string subnetName)
        {
            NetworkManagementClient networkManagementClient = this.GetClient<NetworkManagementClient>();
            Subnet subNet = null;
            try
            {
                subNet = networkManagementClient.Subnets.Get(resourceGroup.Name, virtualNetwork.Name, subnetName);
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code != "NotFound")
                {
                    throw;
                }
            }

            if (subNet == null)
            {
                var snet = new Subnet()
                {
                    Name = subnetName,
                    AddressPrefix = "10.0.0.0/24",
                };

                subNet = networkManagementClient.Subnets.CreateOrUpdate(resourceGroup.Name, virtualNetwork.Name, subnetName, snet);
            }

            return subNet;
        }

        /// <summary>
        /// Get cache if exists.
        /// </summary>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="cacheName">The name of the cache.</param>
        /// <returns>Cache object if cache exists else null.</returns>
        public Cache GetCacheIfExists(ResourceGroup resourceGroup, string cacheName)
        {
            StorageCacheManagementClient storagecacheManagementClient = this.GetClient<StorageCacheManagementClient>();
            storagecacheManagementClient.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
            try
            {
                return storagecacheManagementClient.Caches.Get(resourceGroup.Name, cacheName);
            }
            catch (CloudErrorException ex)
            {
                if (ex.Body.Error.Code == "ResourceNotFound")
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Get resource group if exists.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group.</param>
        /// <returns>ResourceGroup object if resource group exists else null.</returns>
        public ResourceGroup GetResourceGroupIfExists(string resourceGroupName)
        {
            ResourceManagementClient resourceManagementClient = this.GetClient<ResourceManagementClient>();
            try
            {
                return resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            }
            catch (CloudException ex)
            {
                if (ex.Body.Code == "ResourceGroupNotFound")
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Register subscription for resource.
        /// </summary>
        /// <param name="providerName">Resource provider name.</param>
        public void RegisterSubscriptionForResource(string providerName)
        {
            ResourceManagementClient resourceManagementClient = this.GetClient<ResourceManagementClient>();
            var reg = resourceManagementClient.Providers.Register(providerName);
            StorageCacheTestUtilities.ThrowIfTrue(reg == null, $"Failed to register provider {providerName}");
            var result = resourceManagementClient.Providers.Get(providerName);
            StorageCacheTestUtilities.ThrowIfTrue(result == null, $"Failed to register provier {providerName}");
        }

        /// <summary>
        /// Add role assignment by role name.
        /// </summary>
        /// <param name="context">Object representing a StorageCacheTestContext.</param>
        /// <param name="scope">The scope of the role assignment to create.</param>
        /// <param name="roleName">The role name.</param>
        /// <param name="assignmentName">The name of the role assignment to create.</param>
        public void AddRoleAssignment(StorageCacheTestContext context, string scope, string roleName, string assignmentName)
        {
            AuthorizationManagementClient authorizationManagementClient = context.GetClient<AuthorizationManagementClient>();
            var roleDefinition = authorizationManagementClient.RoleDefinitions
                .List(scope)
                .First(role => role.RoleName.StartsWith(roleName));

            var newRoleAssignment = new RoleAssignmentCreateParameters()
            {
                RoleDefinitionId = roleDefinition.Id,
                PrincipalId = Constants.StorageCacheResourceProviderPrincipalId,

                // The principal ID assigned to the role.
                // This maps to the ID inside the Active Directory.
                // It can point to a user, service principal, or security group.
                CanDelegate = false,
            };

            authorizationManagementClient.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
        }

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Dispose managed state.
        /// </summary>
        /// <param name="disposing">true if we should dispose managed state, otherwise false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose clients
                    foreach (IDisposable client in this.serviceClientCache.Values)
                    {
                        client.Dispose();
                    }

                    // Dispose context
                    this.mockContext.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
