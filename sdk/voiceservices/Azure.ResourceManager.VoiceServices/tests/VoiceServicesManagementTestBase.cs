// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.VoiceServices.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.VoiceServices.Tests
{
    public class VoiceServicesManagementTestBase : ManagementRecordedTestBase<VoiceServicesManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ArmClient ArmClient { get; private set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public SubscriptionResource Subscription { get; set; }

        protected static AzureLocation Location = new AzureLocation("centraluseuap", "CentralUSEUAP");

        protected VoiceServicesManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected VoiceServicesManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        protected async Task InitializeClients()
        {
            ArmClient = GetArmClient();
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
            ResourceGroupsOperations = Subscription.GetResourceGroups();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            string rgName = Recording.GenerateAssetName("SDKTest");
            ResourceGroupData data = new ResourceGroupData(Location);
            var lro = await Subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, data);
            return lro.Value;
        }

        protected static VoiceServicesCommunicationsGatewayData GetDefaultCommunicationsGatewayData()
        {
            var gateway = new VoiceServicesCommunicationsGatewayData(Location)
            {
                Connectivity = VoiceServicesCommunicationsGatewayConnectivity.PublicAddress,
                E911Type = VoiceServicesEmergencyCallType.Standard,
            };
            gateway.ServiceLocations.Add(new VoiceServicesServiceRegionProperties("eastus", new VoiceServicesPrimaryRegionProperties(new List<string> { "1.1.1.1" })));
            gateway.ServiceLocations.Add(new VoiceServicesServiceRegionProperties("westus", new VoiceServicesPrimaryRegionProperties(new List<string> { "1.1.1.2" })));
            gateway.Codecs.Add(VoiceServicesTeamsCodec.Pcma);
            gateway.Platforms.Add(VoiceServicesCommunicationsPlatform.OperatorConnect);
            return gateway;
        }

        protected async Task<VoiceServicesCommunicationsGatewayResource> CreateDefaultCommunicationsGateway()
        {
            var rg = await CreateResourceGroup();
            var resourceName = Recording.GenerateAssetName("SDKTest");
            var createOp = await rg.GetVoiceServicesCommunicationsGateways().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, GetDefaultCommunicationsGatewayData());
            return createOp.Value;
        }
    }
}
