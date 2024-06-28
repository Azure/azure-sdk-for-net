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
        public static async Task<NetworkManagerCommit> PostNetworkManagerCommitAsync(
            NetworkManagerResource networkManager,
            AzureLocation location,
            List<string> configurationIds,
            NetworkConfigurationDeploymentType configType)
        {
            NetworkManagerCommit networkManagerCommit = new(new string[] { location }, configType);

            foreach (var id in configurationIds)
            {
                networkManagerCommit.ConfigurationIds.Add(id);
            }

            ArmOperation<NetworkManagerCommit> networkManagerCommitLro = await networkManager.PostNetworkManagerCommitAsync(WaitUntil.Completed, networkManagerCommit);
            return networkManagerCommitLro.Value;
        }

        public static async Task DeleteNetworkGroupAsync(
            this NetworkManagerResource networkManager,
            NetworkGroupResource networkGroup)
        {
            await networkGroup.DeleteAsync(WaitUntil.Completed);
            NullableResponse<NetworkGroupResource> networkGroupResponse = await networkManager.GetNetworkGroups().GetIfExistsAsync(networkGroup.Id);
            Assert.AreEqual(false, networkGroupResponse.HasValue);
        }

        public static async Task DeleteAndVerifyResourceAsync<TCollection>(this TCollection collection, string resourceName)
            where TCollection : ArmCollection
        {
            try
            {
                var method = typeof(TCollection).GetMethod("GetIfExistsAsync", new Type[] { typeof(string), typeof(CancellationToken) });
                if (method == null)
                {
                    throw new InvalidOperationException($"The method 'GetIfExistsAsync' was not found on type '{typeof(TCollection).Name}'.");
                }

                var task = (Task)method.Invoke(collection, new object[] { resourceName, CancellationToken.None });
                await task.ConfigureAwait(false);

                var resultProperty = task.GetType().GetProperty("Result");
                var response = resultProperty.GetValue(task);

                if (response != null)
                {
                    var hasValueProperty = response.GetType().GetProperty("HasValue");
                    bool hasValue = (bool)hasValueProperty.GetValue(response);

                    if (hasValue)
                    {
                        var resourceProperty = response.GetType().GetProperty("Value");
                        var resource = resourceProperty.GetValue(response);

                        await resource.DeleteResourceAsync().ConfigureAwait(false);

                        var verifyMethod = typeof(TCollection).GetMethod("GetIfExistsAsync", new Type[] { typeof(string), typeof(CancellationToken) });
                        if (verifyMethod == null)
                        {
                            throw new InvalidOperationException($"The method 'GetIfExistsAsync' was not found on type '{typeof(TCollection).Name}' for verification.");
                        }

                        var verifyTask = (Task)verifyMethod.Invoke(collection, new object[] { resourceName, CancellationToken.None });
                        await verifyTask.ConfigureAwait(false);

                        var verifyResultProperty = verifyTask.GetType().GetProperty("Result");
                        var verifyResponse = verifyResultProperty.GetValue(verifyTask);

                        if (verifyResponse != null)
                        {
                            var verifyHasValueProperty = verifyResponse.GetType().GetProperty("HasValue");
                            bool verifyHasValue = (bool)verifyHasValueProperty.GetValue(verifyResponse);

                            if (verifyHasValue)
                            {
                                Assert.Fail($"Resource {resourceName} was not deleted");
                            }
                            else
                            {
                                Console.WriteLine($"Resource {resourceName} was deleted successfully");
                            }
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
            var deleteMethod = resource.GetType().GetMethod("DeleteAsync", new Type[] { typeof(WaitUntil), typeof(bool?), typeof(CancellationToken) });
            if (deleteMethod == null)
            {
                deleteMethod = resource.GetType().GetMethod("DeleteAsync", new Type[] { typeof(WaitUntil), typeof(CancellationToken) });
                if (deleteMethod == null)
                {
                    throw new InvalidOperationException($"The method 'DeleteAsync' was not found on type '{resource.GetType().Name}'.");
                }
                else
                {
                    var deleteTask = (Task)deleteMethod.Invoke(resource, new object[] { WaitUntil.Completed, CancellationToken.None });
                    await deleteTask.ConfigureAwait(false);
                }
            }
            else
            {
                var deleteTask = (Task)deleteMethod.Invoke(resource, new object[] { WaitUntil.Completed, null, CancellationToken.None });
                await deleteTask.ConfigureAwait(false);
            }
        }

        public static async Task<ResourceGroupResource> CreateResourceGroupAsync(
            this SubscriptionResource subscription,
            string resourceGroupName,
            AzureLocation location)
        {
            ArmOperation<ResourceGroupResource> resourceGroupLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location));
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

            NetworkGroupData networkGroupData = new()
            {
                Description = "My Test Network Group",
                MemberType = networkGroupType,
            };

            ArmOperation<NetworkGroupResource> networkGroupResource = await networkGroupResources.CreateOrUpdateAsync(WaitUntil.Completed, networkGroupName, networkGroupData);

            // await AddStaticMemberToNetworkGroup(networkGroupType);
            return networkGroupResource.Value;
        }

        private static async Task AddSubnetStaticMemberToNetworkGroup(
            NetworkGroupResource networkGroup,
            List<SubnetResource> subnets)
        {
            NetworkGroupStaticMemberCollection collection = networkGroup.GetNetworkGroupStaticMembers();

            foreach (var subnet in subnets)
            {
                string staticMemberName = $"testStaticMember-{subnet.Data.Name}";

                NetworkGroupStaticMemberData data = new()
                {
                    ResourceId = subnet.Id,
                };

                await collection.CreateOrUpdateAsync(WaitUntil.Completed, staticMemberName, data);
            }
        }

        private static async Task AddVnetStaticMemberToNetworkGroup(
            NetworkGroupResource networkGroup,
            List<VirtualNetworkResource> vnets)
        {
            NetworkGroupStaticMemberCollection collection = networkGroup.GetNetworkGroupStaticMembers();

            foreach (var vnet in vnets)
            {
                string staticMemberName = $"testStaticMember-{vnet.Data.Name}";

                NetworkGroupStaticMemberData data = new()
                {
                    ResourceId = vnet.Id,
                };

                await collection.CreateOrUpdateAsync(WaitUntil.Completed, staticMemberName, data);
            }
        }

        public static async Task<(List<VirtualNetworkResource> Vnets, List<SubnetResource> Subnets)> CreateTestVirtualNetworksAsync(
            this ResourceGroupResource resourceGroup,
            AzureLocation location,
            int numResources = 1)
        {
            VirtualNetworkData vnetData = new()
            {
                Location = location,
                AddressSpace = new AddressSpace(),
            };

            SubnetData subnetData = new()
            {
                AddressPrefix = "10.0.0.0/24"
            };

            List<VirtualNetworkResource> vnets = new();
            List<SubnetResource> subnets = new();

            for (int i = 0; i < numResources; i++)
            {
                string vnetName = $"vnet-{i}";
                vnetData.AddressSpace.AddressPrefixes.Add("10.0.0.0/16");
                ArmOperation<VirtualNetworkResource> vnetLro = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData);

                string subnetName = $"subnet-{i}";
                ArmOperation<SubnetResource> subnetLro = await vnetLro.Value.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnetName, subnetData);

                vnets.Add(vnetLro.Value);
                subnets.Add(subnetLro.Value);
            }

            return (vnets, subnets);
        }
    }
}
