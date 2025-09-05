// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using System.Collections.Generic;
using System;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.StandbyPool.Models;

namespace Azure.ResourceManager.StandbyPool.Tests
{
    public class StandbyContainerGroupPoolTestBase : StandbyPoolManagementTestBase
    {
        protected StandbyContainerGroupPoolTestBase(bool isAsync) : base(isAsync, AzureLocation.CentralIndia)
        {
        }

        protected StandbyContainerGroupPoolTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode, AzureLocation.CentralIndia)
        {
        }

        protected async Task<StandbyContainerGroupPoolResource> CreateContainerGroupPoolResource(ResourceGroupResource resourceGroup, string standbyContainerGroupPoolName, long maxReadyCapacity, AzureLocation location, GenericResource containerGroupProfile, ResourceIdentifier subnetId)
        {
            var ElasticityProfile = new StandbyContainerGroupPoolElasticityProfile()
            {
                MaxReadyCapacity = maxReadyCapacity,
                RefillPolicy = StandbyRefillPolicy.Always,
            };
            var ContainerGroupProperties = new StandbyContainerGroupProperties(new StandbyContainerGroupProfile(containerGroupProfile.Id))
            {
                SubnetIds = {
                        new WritableSubResource()
                        {
                            Id = subnetId,
                        }
                    }
            };
            StandbyContainerGroupPoolProperties properties = new StandbyContainerGroupPoolProperties(ElasticityProfile, ContainerGroupProperties);
            properties.Zones.Add("1");
            StandbyContainerGroupPoolData input = new StandbyContainerGroupPoolData(location)
            {
                Properties = properties
            };
            StandbyContainerGroupPoolCollection collection = resourceGroup.GetStandbyContainerGroupPools();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, standbyContainerGroupPoolName, input);
            return lro.Value;
        }

        protected async Task<GenericResource> CreateContainerGroupProfile(ResourceGroupResource resourceGroup, GenericResourceCollection _genericResourceCollection, AzureLocation location)
        {
            var containerGroupName = Recording.GenerateAssetName("testCG-");
            ResourceIdentifier containerGrouProfileId = new ResourceIdentifier($"{resourceGroup.Id}/providers/Microsoft.ContainerInstance/containerGroupProfiles/{containerGroupName}");
            var containerInstances = new Dictionary<string, object>()
            {
                { "name", "test-instance" },
                { "properties", new Dictionary<string, object>()
                    {
                        { "image", "mcr.microsoft.com/azuredocs/aci-helloworld:latest" },
                        { "ports", new List<Dictionary<string, int>> () { new Dictionary<string, int>() { { "port", 8000 } } } },
                        { "resources", new Dictionary<string, object>()
                            {
                                { "requests", new Dictionary<string, object>()
                                    {
                                        { "cpu", "1" },
                                        { "memoryInGB", "1.5" }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var ipAddress = new Dictionary<string, object>()
            {
                { "type", "Public" },
                { "ports", new List<Dictionary<string, object>>()
                {
                        new Dictionary<string, object>()
                        {
                            { "protocol", "TCP" },
                            { "port", 8000 }
                        }
                    }
                }
            };
            var containerGroupProfile = new GenericResourceData(location)
            {
                Properties = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "sku", "Standard" },
                    { "osType", "Linux" },
                    { "ipAddress", ipAddress },
                    { "containers", new List<Dictionary<string, object>>() { containerInstances } },
                    { "imageRegistryCredentials", new List<Object>() {} }
                })
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerGrouProfileId, containerGroupProfile);
            return operation.Value;
        }
    }
}
