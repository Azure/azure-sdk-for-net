// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Reflection;
using System.Threading;
using Azure.ResourceManager.Network.Tests.Tests;
using Azure.ResourceManager.Network.Tests.Helpers.Validation;

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
            var networkManagerCommit = new NetworkManagerCommit(new[] { location.ToString() }, configType);
            foreach (var configId in configurationIds)
            {
                networkManagerCommit.ConfigurationIds.Add(configId);
            }

            await networkManager.PostNetworkManagerCommitAsync(WaitUntil.Started, networkManagerCommit).ConfigureAwait(false);
            await Task.Delay(DelayMilliseconds).ConfigureAwait(false);
        }

        public static async Task VerifyRoutingConfigurationAsync(
            this NetworkManagerResource networkManager,
            RoutingConfigurationValidationData expected)
        {
            Response<NetworkManagerRoutingConfigurationResource> fetchedRoutingConfiguration = await networkManager
                .GetNetworkManagerRoutingConfigurations()
                .GetAsync(expected.Name).ConfigureAwait(false);

            Assert.AreEqual(NetworkProvisioningState.Succeeded, fetchedRoutingConfiguration.Value.Data.ProvisioningState);

            ValidationHelper.ValidateRoutingConfigurationData(fetchedRoutingConfiguration.Value, expected);
        }

        public static async Task DeleteNetworkGroupAsync(
            this NetworkManagerResource networkManager,
            NetworkGroupResource networkGroup)
        {
            await networkGroup.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
            var networkGroupResponse = await networkManager.GetNetworkGroups().GetIfExistsAsync(networkGroup.Id).ConfigureAwait(false);
            Assert.IsFalse(networkGroupResponse.HasValue);
        }

        public class RetryOptions
        {
            public int MaxAttempts { get; set; } = 3;

            public int DelayMilliseconds { get; set; } = 1000;
        }

        public static async Task DeleteAndVerifyResourceAsync<TCollection>(this TCollection collection, string resourceName, RetryOptions retryOptions = null)
            where TCollection : ArmCollection
        {
            retryOptions ??= new RetryOptions();

            try
            {
                var response = await GetResourceIfExistsAsync(collection, resourceName).ConfigureAwait(false);
                if (response != null)
                {
                    var hasValueProperty = response.GetType().GetProperty("HasValue");
                    bool hasValue = (bool)hasValueProperty.GetValue(response);

                    if (hasValue)
                    {
                        var resourceProperty = response.GetType().GetProperty("Value");
                        var resource = resourceProperty.GetValue(response);

                        await resource.DeleteResourceAsync().ConfigureAwait(false);

                        for (int attempt = 0; attempt < retryOptions.MaxAttempts; attempt++)
                        {
                            var verifyResponse = await GetResourceIfExistsAsync(collection, resourceName).ConfigureAwait(false);
                            var verifyHasValueProperty = verifyResponse.GetType().GetProperty("HasValue");
                            bool verifyHasValue = (bool)verifyHasValueProperty.GetValue(verifyResponse);

                            if (!verifyHasValue)
                            {
                                return;
                            }

                            await Task.Delay(retryOptions.DelayMilliseconds).ConfigureAwait(false);
                        }

                        Assert.Fail($"Resource {resourceName} was not deleted after {retryOptions.MaxAttempts} attempts.");
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

        private static async Task<object> GetResourceIfExistsAsync(ArmCollection collection, string resourceName)
        {
            var method = collection.GetType().GetMethod("GetIfExistsAsync", new Type[] { typeof(string), typeof(CancellationToken) });
            if (method == null)
            {
                throw new InvalidOperationException($"The method 'GetIfExistsAsync' was not found on type '{collection.GetType().Name}'.");
            }

            var task = (Task)method.Invoke(collection, new object[] { resourceName, CancellationToken.None });
            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");
            return resultProperty.GetValue(task);
        }

        public static async Task DeleteResourceAsync<TResource>(this TResource resource)
        {
            var deleteMethod = resource.GetType().GetMethod("DeleteAsync", new Type[] { typeof(WaitUntil), typeof(bool?), typeof(CancellationToken) })
                             ?? resource.GetType().GetMethod("DeleteAsync", new Type[] { typeof(WaitUntil), typeof(CancellationToken) });

            if (deleteMethod == null)
            {
                throw new InvalidOperationException($"The method 'DeleteAsync' was not found on type '{resource.GetType().Name}'.");
            }

            var deleteTask = (Task)deleteMethod.Invoke(resource, new object[] { WaitUntil.Completed, true, CancellationToken.None });
            await deleteTask.ConfigureAwait(false);
        }

        public static async Task<ResourceGroupResource> CreateResourceGroupAsync(
            this SubscriptionResource subscription,
            string resourceGroupName,
            AzureLocation location)
        {
            var resourceGroupLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location)).ConfigureAwait(false);
            return resourceGroupLro.Value;
        }

        public static async Task<NetworkManagerResource> CreateNetworkManagerAsync(
            this ResourceGroupResource resourceGroup,
            string networkManagerName,
            AzureLocation location,
            List<string> subscriptions,
            List<NetworkConfigurationDeploymentType> scopeAccesses)
        {
            var networkManagerData = new NetworkManagerData
            {
                Description = "SDK Test Network Manager",
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

            var networkManagerResource = await resourceGroup.GetNetworkManagers().CreateOrUpdateAsync(WaitUntil.Completed, networkManagerName, networkManagerData).ConfigureAwait(false);
            return networkManagerResource.Value;
        }

        public static async Task<NetworkGroupResource> CreateNetworkGroupAsync(this NetworkManagerResource networkManager, string networkGroupType)
        {
            var networkGroupData = new NetworkGroupData
            {
                Description = "SDK Test Network Group",
                MemberType = networkGroupType,
            };

            var networkGroupResource = await networkManager.GetNetworkGroups().CreateOrUpdateAsync(WaitUntil.Completed, $"ng-{networkGroupType}", networkGroupData).ConfigureAwait(false);
            return networkGroupResource.Value;
        }

        public static async Task AddSubnetStaticMemberToNetworkGroup(
            this NetworkGroupResource networkGroup,
            List<SubnetResource> subnets)
        {
            var collection = networkGroup.GetNetworkGroupStaticMembers();

            foreach (var subnet in subnets)
            {
                var data = new NetworkGroupStaticMemberData
                {
                    ResourceId = subnet.Id,
                };

                await collection.CreateOrUpdateAsync(WaitUntil.Completed, $"testStaticMember-{subnet.Data.Name}", data).ConfigureAwait(false);
            }
        }

        public static async Task AddVnetStaticMemberToNetworkGroup(
            this NetworkGroupResource networkGroup,
            List<VirtualNetworkResource> vnets)
        {
            var collection = networkGroup.GetNetworkGroupStaticMembers();

            foreach (var vnet in vnets)
            {
                var data = new NetworkGroupStaticMemberData
                {
                    ResourceId = vnet.Id,
                };

                await collection.CreateOrUpdateAsync(WaitUntil.Completed, $"testStaticMember-{vnet.Data.Name}", data).ConfigureAwait(false);
            }
        }

        public static async Task<List<VirtualNetworkResource>> CreateTestVirtualNetworksAsync(
            this ResourceGroupResource resourceGroup,
            AzureLocation location,
            int numVnets = 1,
            int numSubnetsPerVnet = 1)
        {
            var vnets = new List<VirtualNetworkResource>();

            for (int i = 0; i < numVnets; i++)
            {
                var vnetData = new VirtualNetworkData
                {
                    Location = location,
                    AddressSpace = new AddressSpace
                    {
                        AddressPrefixes = { $"10.{i}.0.0/16" } // Define VNet address prefix
                    }
                };

                for (int j = 0; j < numSubnetsPerVnet; j++)
                {
                    var subnetData = new SubnetData
                    {
                        Name = $"subnet-{j}",
                        AddressPrefix = $"10.{i}.{j}.0/24", // Define Subnet address prefix
                        DefaultOutboundAccess = false
                    };

                    vnetData.Subnets.Add(subnetData);
                }

                var vnetLro = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, $"vnet-{i}", vnetData).ConfigureAwait(false);
                vnets.Add(vnetLro.Value);
            }

            return vnets;
        }
    }
}
