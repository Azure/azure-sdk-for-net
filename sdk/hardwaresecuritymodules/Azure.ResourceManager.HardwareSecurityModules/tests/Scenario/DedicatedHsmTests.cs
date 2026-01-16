// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network;
using Newtonsoft.Json.Bson;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.HardwareSecurityModules.Models;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.HardwareSecurityModules.Tests.Scenario
{
    internal class DedicatedHsmTests : HardwareSecurityModulesManagementTestBase
    {
        public DedicatedHsmTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUpForTests(isDedicatedHsm: true);
        }

        [Ignore("Exception")]
        [RecordedTest]
        public async Task CreateOrUpdateDedicatedHsmTest()
        {
            string resourceName = Recording.GenerateAssetName("DedicatedHsmTest");
            ResourceIdentifier subnetID;
            VirtualNetworkResource vnetResource = await CreateVnet();
            subnetID = vnetResource.Data.Subnets[0].Id;

            DedicatedHsmSku sku = new DedicatedHsmSku()
            {
                Name = DedicatedHsmSkuName.PayShield10KLmk1Cps60
            };

            DedicatedHsmProperties properties = new DedicatedHsmProperties()
            {
                NetworkProfile = new DedicatedHsmNetworkProfile()
                {
                    SubnetResourceId = subnetID,
                    NetworkInterfaces = {
                        new DedicatedHsmNetworkInterface() {
                            PrivateIPAddress = "10.0.0.4"
                        },
                        new DedicatedHsmNetworkInterface() {
                            PrivateIPAddress = "10.0.0.5"
                        }
                    }
                },

                ManagementNetworkProfile = new DedicatedHsmNetworkProfile()
                {
                    SubnetResourceId = subnetID,
                    NetworkInterfaces = {
                        new DedicatedHsmNetworkInterface() {
                            PrivateIPAddress = "10.0.0.6"
                        }
                    }
                },
                StampId = "stamp1"
            };

            DedicatedHsmData dedicatedHsmData = new DedicatedHsmData(Location, sku, properties)
            {
                Tags =
                {
                    ["Dept"] = "SDK Testing",
                    ["Env"] = "df",
                }
            };

            DedicatedHsmCollection collection = ResourceGroupResource.GetDedicatedHsms();
            var operation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, dedicatedHsmData);
            DedicatedHsmResource dedicatedHsmResource = operation.Value;

            Assert.That(dedicatedHsmResource, Is.Not.Null);
            ValidateDedicatedHsmResource(
                dedicatedHsmResource.Data,
                DefaultSubscription.Data.SubscriptionId,
                ResourceGroupResource.Data.Name,
                resourceName,
                Location.Name,
                DedicatedHsmSkuName.PayShield10KLmk1Cps60.ToString(),
                new Dictionary<string, string>(dedicatedHsmData.Tags));

            var getOperation = await collection.GetAsync(resourceName);
            Assert.That(getOperation.Value, Is.Not.Null);
            ValidateDedicatedHsmResource(
                getOperation.Value.Data,
                DefaultSubscription.Data.SubscriptionId,
                ResourceGroupResource.Data.Name,
                resourceName,
                Location.Name,
                DedicatedHsmSkuName.PayShield10KLmk1Cps60.ToString(),
                new Dictionary<string, string>(getOperation.Value.Data.Tags));

            var getAllOperation = collection.GetAllAsync();
            int dedicatedHsmCounter = 0;

            await foreach (DedicatedHsmResource dhsmResource in getAllOperation)
            {
                if (dhsmResource.Id == dedicatedHsmResource.Id)
                {
                    dedicatedHsmCounter++;
                    break;
                }
            }
            Assert.That(dedicatedHsmCounter, Is.EqualTo(1));
        }

        protected async Task<VirtualNetworkResource> CreateVnet()
        {
            var vnetName = "dhsm-vnet";

            ServiceDelegation delegation = new ServiceDelegation()
            {
                Name = "myDelegation",
                ServiceName = "Microsoft.HardwareSecurityModules/dedicatedHSMs"
            };

            var vnet = new VirtualNetworkData()
            {
                Location = Location,
                Subnets =
                {
                    new SubnetData()
                    {
                        Name = "default",
                        AddressPrefix = "10.0.0.0/24"
                    }
                }
            };

            vnet.AddressPrefixes.Add("10.0.0.0/16");
            vnet.Subnets[0].Delegations.Add(delegation);
            VirtualNetworkResource vnetResource = (await ResourceGroupResource.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet)).Value;
            var subnetCollection = vnetResource.GetSubnets();
            return vnetResource;
        }

        protected void ValidateDedicatedHsmResource(
            DedicatedHsmData dedicatedHsmData,
            string expecrtedSubId,
            string expecrtedRgName,
            string expectedResourceName,
            string expectedResourceLocation,
            string expectedSkuName,
            Dictionary<string, string> expectedTags)
        {
            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.HardwareSecurityModules/dedicatedHSMs/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expecrtedSubId, expecrtedRgName, expectedResourceName);

            Assert.That(dedicatedHsmData, Is.Not.Null);
            Assert.That(dedicatedHsmData.Id.ToString(), Is.EqualTo(expectedResourceId));
            Assert.That(dedicatedHsmData.Location.Name, Is.EqualTo(expectedResourceLocation));
            Assert.That(dedicatedHsmData.Name, Is.EqualTo(expectedResourceName));
            Assert.That(dedicatedHsmData.Sku, Is.Not.Null);
            Assert.That(dedicatedHsmData.Sku.Name.ToString(), Is.EqualTo(expectedSkuName));
            Assert.That(dedicatedHsmData.Tags, Is.Not.Null);
            Assert.That(expectedTags.Count == dedicatedHsmData.Tags.Count && !expectedTags.Except(dedicatedHsmData.Tags).Any(), Is.True);
        }
    }
}
