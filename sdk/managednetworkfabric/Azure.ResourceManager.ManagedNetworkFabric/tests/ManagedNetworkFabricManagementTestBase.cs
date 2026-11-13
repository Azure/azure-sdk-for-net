// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
{
    public class ManagedNetworkFabricManagementTestBase : ManagementRecordedTestBase<ManagedNetworkFabricManagementTestEnvironment>
    {
        private const string RecordedApiVersion = "2023-06-15";
        private const string LowercaseSanitizedSubscriptionId = "1234abcd-0a1b-1234-5678-123456abcdef";
        private const string UppercaseSanitizedSubscriptionId = "1234ABCD-0A1B-1234-5678-123456ABCDEF";

        private static readonly ResourceType[] s_recordedResourceTypes =
        {
            NetworkFabricAccessControlListResource.ResourceType,
            NetworkFabricExternalNetworkResource.ResourceType,
            NetworkFabricInternalNetworkResource.ResourceType,
            NetworkFabricInternetGatewayResource.ResourceType,
            NetworkFabricInternetGatewayRuleResource.ResourceType,
            NetworkFabricIPCommunityResource.ResourceType,
            NetworkFabricIPExtendedCommunityResource.ResourceType,
            NetworkFabricIPPrefixResource.ResourceType,
            NetworkFabricL2IsolationDomainResource.ResourceType,
            NetworkFabricL3IsolationDomainResource.ResourceType,
            NetworkFabricNeighborGroupResource.ResourceType,
            NetworkFabricResource.ResourceType,
            NetworkFabricControllerResource.ResourceType,
            NetworkDeviceResource.ResourceType,
            NetworkDeviceInterfaceResource.ResourceType,
            NetworkPacketBrokerResource.ResourceType,
            NetworkRackResource.ResourceType,
            NetworkTapResource.ResourceType,
            NetworkTapRuleResource.ResourceType,
            NetworkToNetworkInterconnectResource.ResourceType,
            NetworkFabricRoutePolicyResource.ResourceType,
        };

        protected ArmClient Client { get; private set; }
        protected ResourceGroupResource ResourceGroupResource { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected ManagedNetworkFabricManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            AddPlaybackSubscriptionIdSanitizer();
        }

        protected ManagedNetworkFabricManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            AddPlaybackSubscriptionIdSanitizer();
        }

        [SetUp]
        public void SetUp()
        {
            Client = GetArmClient(CreateClientOptions(), GetSubscriptionId());

            var subscriptionId = SubscriptionResource.CreateResourceIdentifier(GetSubscriptionId());
            TestContext.Out.WriteLine($"Provided subscription-Id : {subscriptionId.SubscriptionId}");

            string resourceGroupName = TestEnvironment.ResourceGroupName;

            TestContext.Out.WriteLine($"Provided ResourceGroup: {resourceGroupName}");
            DefaultSubscription = Client.GetSubscriptionResource(subscriptionId);
            var resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(GetSubscriptionId(), TestEnvironment.ResourceGroupName);
            ResourceGroupResource = Client.GetResourceGroupResource(resourceGroupId);
        }

        protected string GetSubscriptionId()
        {
            return Mode == RecordedTestMode.Playback ? TestEnvironment.SubscriptionId.ToUpperInvariant() : TestEnvironment.SubscriptionId;
        }

        private void AddPlaybackSubscriptionIdSanitizer()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                LegacyExcludedHeaders.Add("Accept");
                UriRegexSanitizers.Add(new UriRegexSanitizer($"(?<subscriptionId>{LowercaseSanitizedSubscriptionId})")
                {
                    GroupForReplace = "subscriptionId",
                    Value = UppercaseSanitizedSubscriptionId
                });
            }
        }

        private ArmClientOptions CreateClientOptions()
        {
            ArmClientOptions options = new ArmClientOptions();
            if (Mode == RecordedTestMode.Playback)
            {
                foreach (ResourceType resourceType in s_recordedResourceTypes)
                {
                    options.SetApiVersion(resourceType, RecordedApiVersion);
                }
            }

            return options;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
