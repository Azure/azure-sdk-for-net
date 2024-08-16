// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;
using System;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading;
using Azure.ResourceManager.Models;
using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static partial class NetworkManagerHelperExtensions
    {
        private const int DelayMilliseconds = 10000;

        public static async Task PostNetworkManagerCommitAsync(
            this NetworkManagerResource networkManager,
            AzureLocation location,
            List<string> configurationIds,
            NetworkConfigurationDeploymentType configType)
        {
            var locations = new[] { location.ToString() };
            var networkManagerCommit = new NetworkManagerCommit(locations, configType);

            foreach (var configId in configurationIds)
            {
                networkManagerCommit.ConfigurationIds.Add(configId);
            }

            await networkManager.PostNetworkManagerCommitAsync(WaitUntil.Started, networkManagerCommit).ConfigureAwait(false);

            await Task.Delay(DelayMilliseconds).ConfigureAwait(false);
        }

        public static async Task DeleteNetworkGroupAsync(
            this NetworkManagerResource networkManager,
            NetworkGroupResource networkGroup)
        {
            await networkGroup.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
            NullableResponse<NetworkGroupResource> networkGroupResponse = await networkManager.GetNetworkGroups().GetIfExistsAsync(networkGroup.Id).ConfigureAwait(false);
            Assert.AreEqual(false, networkGroupResponse.HasValue);
        }

        public static async Task DeleteAndVerifyResourceAsync<TCollection>(this TCollection collection, string resourceName)
            where TCollection : ArmCollection
        {
            try
            {
                MethodInfo method = typeof(TCollection).GetMethod("GetIfExistsAsync", new Type[] { typeof(string), typeof(CancellationToken) });
                if (method == null)
                {
                    throw new InvalidOperationException($"The method 'GetIfExistsAsync' was not found on type '{typeof(TCollection).Name}'.");
                }

                var task = (Task)method.Invoke(collection, new object[] { resourceName, CancellationToken.None });
                await task.ConfigureAwait(false);

                PropertyInfo resultProperty = task.GetType().GetProperty("Result");
                var response = resultProperty.GetValue(task);

                if (response != null)
                {
                    PropertyInfo hasValueProperty = response.GetType().GetProperty("HasValue");
                    bool hasValue = (bool)hasValueProperty.GetValue(response);

                    if (hasValue)
                    {
                        PropertyInfo resourceProperty = response.GetType().GetProperty("Value");
                        var resource = resourceProperty.GetValue(response);

                        await resource.DeleteResourceAsync().ConfigureAwait(false);

                        MethodInfo verifyMethod = typeof(TCollection).GetMethod("GetIfExistsAsync", new Type[] { typeof(string), typeof(CancellationToken) });
                        if (verifyMethod == null)
                        {
                            throw new InvalidOperationException($"The method 'GetIfExistsAsync' was not found on type '{typeof(TCollection).Name}' for verification.");
                        }

                        var verifyTask = (Task)verifyMethod.Invoke(collection, new object[] { resourceName, CancellationToken.None });
                        await verifyTask.ConfigureAwait(false);

                        PropertyInfo verifyResultProperty = verifyTask.GetType().GetProperty("Result");
                        var verifyResponse = verifyResultProperty.GetValue(verifyTask);
                        if (verifyResponse != null)
                        {
                            PropertyInfo verifyHasValueProperty = verifyResponse.GetType().GetProperty("HasValue");
                            bool verifyHasValue = (bool)verifyHasValueProperty.GetValue(verifyResponse);
                            // Assert.IsTrue(verifyHasValue == false);
                        }
                    }
                }
            }
            catch (TargetInvocationException ex) when (ex.InnerException is RequestFailedException requestFailedException && requestFailedException.Status == 404)
            {
                Console.WriteLine("Resource was deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calling delete on resource {resourceName}: {ex.Message}");
                throw;
            }
        }

        public static async Task DeleteResourceAsync<TResource>(this TResource resource)
        {
            MethodInfo deleteMethod = resource.GetType().GetMethod("DeleteAsync", new Type[] { typeof(WaitUntil), typeof(bool?), typeof(CancellationToken) });
            if (deleteMethod == null)
            {
                deleteMethod = resource.GetType().GetMethod("DeleteAsync", new Type[] { typeof(WaitUntil), typeof(CancellationToken) });
                if (deleteMethod == null)
                {
                    throw new InvalidOperationException($"The method 'DeleteAsync' was not found on type '{resource.GetType().Name}'.");
                }
                else
                {
                    var deleteTask = (Task)deleteMethod.Invoke(resource, new object[] { WaitUntil.Completed, true, CancellationToken.None });
                    await deleteTask.ConfigureAwait(false);
                }
            }
            else
            {
                var deleteTask = (Task)deleteMethod.Invoke(resource, new object[] { WaitUntil.Completed, true, CancellationToken.None });
                await deleteTask.ConfigureAwait(false);
            }
        }

        public static async Task<ResourceGroupResource> CreateResourceGroupAsync(
            this SubscriptionResource subscription,
            string resourceGroupName,
            AzureLocation location)
        {
            ArmOperation<ResourceGroupResource> resourceGroupLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location)).ConfigureAwait(false);
            return resourceGroupLro.Value;
        }

        public static async Task<NetworkManagerResource> CreateNetworkManagerAsync(
            this ResourceGroupResource resourceGroup,
            string networkManagerName,
            AzureLocation location,
            List<string> subscriptions,
            List<NetworkConfigurationDeploymentType> scopeAccesses)
        {
            NetworkManagerCollection collection = resourceGroup.GetNetworkManagers();

            NetworkManagerData networkManagerData = new()
            {
                Description = "My Test Network Manager",
                Location = location,
            };

            networkManagerData.NetworkManagerScopes = new NetworkManagerPropertiesNetworkManagerScopes();
            foreach (var subscription in subscriptions)
            {
                networkManagerData.NetworkManagerScopes.Subscriptions.Add(subscription);
            }

            foreach (var scopeAccess in scopeAccesses)
            {
                networkManagerData.NetworkManagerScopeAccesses.Add(scopeAccess);
            }

            ArmOperation<NetworkManagerResource> networkManagerResource = await collection.CreateOrUpdateAsync(WaitUntil.Completed, networkManagerName, networkManagerData);
            return networkManagerResource.Value;
        }

        public static async Task<NetworkGroupResource> CreateNetworkGroupAsync(this NetworkManagerResource networkManager, string networkGroupType)
        {
            NetworkGroupCollection networkGroupResources = networkManager.GetNetworkGroups();
            string networkGroupName = $"ng-{networkGroupType}";

            var networkGroupData = new NetworkGroupData
            {
                Description = "My Test Network Group",
            };

            ArmOperation<NetworkGroupResource> networkGroupResource = await networkGroupResources.CreateOrUpdateAsync(WaitUntil.Completed, networkGroupName, networkGroupData).ConfigureAwait(false);
            return networkGroupResource.Value;
        }

        public static async Task AddSubnetStaticMemberToNetworkGroup(
            this NetworkGroupResource networkGroup,
            List<SubnetResource> subnets)
        {
            NetworkGroupStaticMemberCollection collection = networkGroup.GetNetworkGroupStaticMembers();

            foreach (SubnetResource subnet in subnets)
            {
                var staticMemberName = $"testStaticMember-{subnet.Data.Name}";

                var data = new NetworkGroupStaticMemberData
                {
                    ResourceId = subnet.Id,
                };

                await collection.CreateOrUpdateAsync(WaitUntil.Completed, staticMemberName, data).ConfigureAwait(false);
            }
        }

        public static async Task AddVnetStaticMemberToNetworkGroup(
            this NetworkGroupResource networkGroup,
            List<VirtualNetworkResource> vnets)
        {
            NetworkGroupStaticMemberCollection collection = networkGroup.GetNetworkGroupStaticMembers();

            foreach (VirtualNetworkResource vnet in vnets)
            {
                var staticMemberName = $"testStaticMember-{vnet.Data.Name}";

                var data = new NetworkGroupStaticMemberData
                {
                    ResourceId = vnet.Id,
                };

                await collection.CreateOrUpdateAsync(WaitUntil.Completed, staticMemberName, data).ConfigureAwait(false);
            }
        }

        public static async Task<(List<VirtualNetworkResource> Vnets, List<SubnetResource> Subnets)> CreateTestVirtualNetworksAsync(
            this ResourceGroupResource resourceGroup,
            AzureLocation location,
            int numResources = 1)
        {
            var vnetData = new VirtualNetworkData
            {
                Location = location,
                AddressSpace = new AddressSpace
                {
                    AddressPrefixes = { "10.0.0.0/16" }
                }
            };

            var subnetData = new SubnetData
            {
                AddressPrefix = "10.0.0.0/24"
            };

            var vnets = new List<VirtualNetworkResource>();
            var subnets = new List<SubnetResource>();

            for (int i = 0; i < numResources; i++)
            {
                var vnetName = $"vnet-{i}";
                ArmOperation<VirtualNetworkResource> vnetLro = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData).ConfigureAwait(false);

                var subnetName = $"subnet-{i}";
                ArmOperation<SubnetResource> subnetLro = await vnetLro.Value.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnetName, subnetData).ConfigureAwait(false);

                vnets.Add(vnetLro.Value);
                subnets.Add(subnetLro.Value);
            }

            return (vnets, subnets);
        }
    }
}
