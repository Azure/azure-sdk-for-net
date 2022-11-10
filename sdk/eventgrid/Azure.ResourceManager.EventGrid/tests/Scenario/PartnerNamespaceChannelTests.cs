// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public PartnerNamespaceChannelTests(bool isAsync) : base(isAsync)
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
                    AzureSubscriptionId = new Guid(DefaultSubscription.Id),
                    ResourceGroupName = _resourceGroup.Data.Name,
                    Name = "",
                    Source = ""
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

            // Delete
            await channel.Value.DeleteAsync(WaitUntil.Completed);
            flag = await _partnerNamespaceChannelCollection.ExistsAsync(channelName);
            Assert.IsFalse(flag);
        }
    }
}
