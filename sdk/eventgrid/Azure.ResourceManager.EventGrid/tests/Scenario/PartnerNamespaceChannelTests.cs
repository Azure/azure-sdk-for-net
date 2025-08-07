// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    internal class PartnerNamespaceChannelTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PartnerNamespaceChannelCollection _partnerNamespaceChannelCollection;

        public PartnerNamespaceChannelTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var partnerNamespace = await CreatePartnerNamespace(_resourceGroup, Recording.GenerateAssetName("partnerNamespace"));
            _partnerNamespaceChannelCollection = partnerNamespace.GetPartnerNamespaceChannels();
        }

        [Test]
        [Ignore("Could not create a valid external partner source")]
        public async Task PartnerNamespaceChannelE2EOperation()
        {
            // Prerequisites: PartnerConfiguration has been created.

            // Create
            string channelName = Recording.GenerateAssetName("channel");
            var data = new PartnerNamespaceChannelData()
            {
                ChannelType = PartnerNamespaceChannelType.PartnerTopic,
                PartnerTopicInfo = new PartnerTopicInfo()
                {
                    AzureSubscriptionId = new Guid("5b4b650e-28b9-4790-b3ab-ddbd88d727c4"),
                    ResourceGroupName = _resourceGroup.Data.Name,
                    Name = "partner-topic",
                    Source = "Partner Topic Source"
                }
            };
            var channel = await _partnerNamespaceChannelCollection.CreateOrUpdateAsync(WaitUntil.Completed, channelName, data);
            Assert.IsNotNull(channel);

            // Exist
            bool flag = await _partnerNamespaceChannelCollection.ExistsAsync(channelName);
            Assert.IsTrue(flag);

            // Get
            var getResponse = await _partnerNamespaceChannelCollection.GetAsync(channelName);
            Assert.IsNotNull(getResponse);

            // GetAll
            var list = await _partnerNamespaceChannelCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // Get Full URL
            var fullUrlResponse = await getResponse.Value.GetFullUriAsync();
            Assert.IsNotNull(fullUrlResponse);

            // List By Partner Namespace
            var listByNamespace = await _partnerNamespaceChannelCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(listByNamespace);

            var updateData = new PartnerNamespaceChannelPatch()
            {
                PartnerTopicInfo = new PartnerUpdateTopicInfo()
                {
                    EventTypeInfo = new PartnerTopicEventTypeInfo()
                    {
                        Kind = EventDefinitionKind.Inline,
                    }
                }
            };
            var updateResponse = await channel.Value.UpdateAsync(updateData, new System.Threading.CancellationToken());
            Assert.IsNotNull(updateResponse);

            // Delete
            await channel.Value.DeleteAsync(WaitUntil.Completed);
            flag = await _partnerNamespaceChannelCollection.ExistsAsync(channelName);
            Assert.IsFalse(flag);
        }
    }
}
