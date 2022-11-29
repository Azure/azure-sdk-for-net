// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Orbital.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Orbital.Tests
{
    public class OrbitalManagementTestBase : ManagementRecordedTestBase<OrbitalManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; private set; }

        protected OrbitalManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected OrbitalManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<OrbitalSpacecraftResource> CreateSpacecraftAsync(ResourceGroupResource resourceGroup, string spacecraftName, AzureLocation? location = null)
        {
            var spacecraftData = new OrbitalSpacecraftData(location == null ? resourceGroup.Data.Location : location.Value)
            {
                NoradId = "25544",
                TitleLine = "ISS",
                TleLine1 = "1 25544U 98067A   08264.51782528 -.00002182  00000-0 -11606-4 0  2927",
                TleLine2 = "2 25544  51.6416 247.4627 0006703 130.5360 325.0288 15.72125391563537",
                Links =
                {
                    new OrbitalSpacecraftLink("uplink", 45, 45, OrbitalLinkDirection.Uplink, OrbitalLinkPolarization.Rhcp),
                    new OrbitalSpacecraftLink("downlink", 55, 55, OrbitalLinkDirection.Downlink, OrbitalLinkPolarization.Lhcp),
                }
            };

            var lro = await resourceGroup.GetOrbitalSpacecrafts().CreateOrUpdateAsync(WaitUntil.Completed, spacecraftName, spacecraftData);
            return lro.Value;
        }
    }
}
