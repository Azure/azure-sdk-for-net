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

            DedicatedHsmData dedicatedHsmData = new DedicatedHsmData(Location)
            {
                NetworkProfile = new NetworkProfile()
                {
                    SubnetId = subnetID,
                    NetworkInterfaces = {
                        new NetworkInterface() {
                            PrivateIPAddress = "10.0.0.4"
                        },
                        new NetworkInterface() {
                            PrivateIPAddress = "10.0.0.5"
                        }
                    }
                },

                ManagementNetworkProfile = new NetworkProfile()
                {
                    SubnetId = subnetID,
                    NetworkInterfaces = {
                        new NetworkInterface() {
                            PrivateIPAddress = "10.0.0.6"
                        }
                    }
                },
                StampId = "stamp1",
                SkuName = HardwareSecurityModulesSkuName.PayShield10KLMK1CPS60,
                Tags =
                {
                    ["Dept"] = "SDK Testing",
                    ["Env"] = "df",
                }
            };

            DedicatedHsmCollection collection = ResourceGroupResource.GetDedicatedHsms();
            var operation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, dedicatedHsmData);
            DedicatedHsmResource dedicatedHsmResource = operation.Value;

            Assert.IsNotNull(dedicatedHsmResource);
            ValidateDedicatedHsmResource(
                dedicatedHsmResource.Data,
                DefaultSubscription.Data.SubscriptionId,
                ResourceGroupResource.Data.Name,
                resourceName,
                Location.Name,
                HardwareSecurityModulesSkuName.PayShield10KLMK1CPS60.ToString(),
                new Dictionary<string, string>(dedicatedHsmData.Tags));

            var getOperation = await collection.GetAsync(resourceName);
            Assert.IsNotNull(getOperation.Value);
            ValidateDedicatedHsmResource(
                getOperation.Value.Data,
                DefaultSubscription.Data.SubscriptionId,
                ResourceGroupResource.Data.Name,
                resourceName,
                Location.Name,
                HardwareSecurityModulesSkuName.PayShield10KLMK1CPS60.ToString(),
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
            Assert.AreEqual(dedicatedHsmCounter, 1);
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

            Assert.NotNull(dedicatedHsmData);
            Assert.AreEqual(expectedResourceId, dedicatedHsmData.Id.ToString());
            Assert.AreEqual(expectedResourceLocation, dedicatedHsmData.Location.Name);
            Assert.AreEqual(expectedResourceName, dedicatedHsmData.Name);
            Assert.NotNull(dedicatedHsmData.Sku);
            Assert.AreEqual(expectedSkuName, dedicatedHsmData.Sku.Name.ToString());
            Assert.NotNull(dedicatedHsmData.Tags);
            Assert.True(expectedTags.Count == dedicatedHsmData.Tags.Count && !expectedTags.Except(dedicatedHsmData.Tags).Any());
        }
    }
}
