// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class EventGridDomainTests : EventGridManagementTestBase
    {
        public EventGridDomainTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private EventGridDomainCollection DomainCollection { get; set; }
        private ResourceGroupResource ResourceGroup { get; set; }

        private async Task SetCollection()
        {
            ResourceGroup = await CreateResourceGroupAsync(DefaultSubscription, Recording.GenerateAssetName("sdktest-"), DefaultLocation);
            DomainCollection = ResourceGroup.GetEventGridDomains();
        }

        [Test]
        public async Task DomainCreateGetUpdateDelete()
        {
            await SetCollection();

            var domainName = Recording.GenerateAssetName("sdk-Domain-");
            var domainTopicName1 = Recording.GenerateAssetName("sdk-DomainTopic-");
            var domainTopicName2 = Recording.GenerateAssetName("sdk-DomainTopic-");
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");

            var domain = new EventGridDomainData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                InputSchema = EventGridInputSchema.CloudEventSchemaV1_0,
                InputSchemaMapping = new EventGridJsonInputSchemaMapping()
                {
                    Topic = new JsonField("myTopicField", null)
                }
            };

            var createDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domain)).Value;

            Assert.NotNull(createDomainResponse);
            Assert.AreEqual(createDomainResponse.Data.Name, domainName);

            // Get the created domain
            var getDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.NotNull(getDomainResponse);
            Assert.AreEqual(EventGridDomainProvisioningState.Succeeded, getDomainResponse.Data.ProvisioningState);
            Assert.AreEqual(location, getDomainResponse.Data.Location);
            Assert.IsTrue(getDomainResponse.Data.Tags.Keys.Contains("originalTag1"));
            Assert.AreEqual(getDomainResponse.Data.Tags["originalTag1"], "originalValue1");
            Assert.IsTrue(getDomainResponse.Data.Tags.Keys.Contains("originalTag2"));
            Assert.AreEqual(getDomainResponse.Data.Tags["originalTag2"], "originalValue2");

            //// Diable test as identity is not part of GA Version yet.
            //// Assert.Null(getDomainResponse.Identity);
            Assert.AreEqual(getDomainResponse.Data.InboundIPRules.Count, 0);

            // Get all domains created within a resourceGroup
            var domainsInResourceGroup = await DomainCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(domainsInResourceGroup);
            Assert.GreaterOrEqual(domainsInResourceGroup.Count, 1);
            Assert.AreEqual(domainsInResourceGroup.FirstOrDefault().Data.Name, domainName);

            // Get all domains created within the subscription irrespective of the resourceGroup
            var domainsInAzureSubscription = await DefaultSubscription.GetEventGridDomainsAsync().ToEnumerableAsync();
            Assert.NotNull(domainsInAzureSubscription);
            Assert.GreaterOrEqual(domainsInAzureSubscription.Count, 1);
            var falseFlag = false;
            foreach (var item in domainsInAzureSubscription)
            {
                if (item.Data.Name == domainName)
                {
                    falseFlag = true;
                    break;
                }
            }
            Assert.IsTrue(falseFlag);

            // Replace the domain
            domain.Tags.Clear();
            domain.Tags.Add("replacedTag1", "replacedValue1");
            domain.Tags.Add("replacedTag2", "replacedValue2");
            var replaceDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domain)).Value;

            Assert.IsTrue(replaceDomainResponse.Data.Tags.Keys.Contains("replacedTag1"));
            Assert.IsFalse(replaceDomainResponse.Data.Tags.Keys.Contains("originalTag1"));

            // Update the domain with tags & allow traffic from all ips
            var domainUpdateParameters = new EventGridDomainPatch()
            {
                Tags = {
                        { "updatedTag1", "updatedValue1" },
                        { "updatedTag2", "updatedValue2" }
                    },
                PublicNetworkAccess = EventGridPublicNetworkAccess.Enabled,
            };

            await replaceDomainResponse.UpdateAsync(WaitUntil.Completed, domainUpdateParameters);
            var updateDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.IsTrue(updateDomainResponse.Data.Tags.Keys.Contains("updatedTag1"));
            Assert.IsFalse(updateDomainResponse.Data.Tags.Keys.Contains("replacedTag1"));
            Assert.IsTrue(updateDomainResponse.Data.PublicNetworkAccess == EventGridPublicNetworkAccess.Enabled);
            Assert.AreEqual(updateDomainResponse.Data.InboundIPRules.Count, 0);

            // Update the Topic with IP filtering feature
            domain.PublicNetworkAccess = EventGridPublicNetworkAccess.Disabled;
            domain.InboundIPRules.Add(new EventGridInboundIPRule() { Action = EventGridIPActionType.Allow, IPMask = "12.35.67.98" });
            domain.InboundIPRules.Add(new EventGridInboundIPRule() { Action = EventGridIPActionType.Allow, IPMask = "12.35.90.100" });
            var updateDomainResponseWithIpFilteringFeature = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domain)).Value;
            Assert.IsFalse(updateDomainResponseWithIpFilteringFeature.Data.PublicNetworkAccess == EventGridPublicNetworkAccess.Enabled);
            Assert.AreEqual(updateDomainResponseWithIpFilteringFeature.Data.InboundIPRules.Count, 2);

            // Create domain topic manually.
            var domainTopicCollection = updateDomainResponseWithIpFilteringFeature.GetDomainTopics();
            var createDomainTopicResponse = (await domainTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainTopicName1)).Value;

            Assert.NotNull(createDomainTopicResponse);
            Assert.AreEqual(createDomainTopicResponse.Data.Name, domainTopicName1);

            // Get the created domain Topic
            var getDomainTopicResponse1 = (await domainTopicCollection.GetAsync(domainTopicName1)).Value;
            Assert.NotNull(getDomainTopicResponse1);
            Assert.AreEqual(DomainTopicProvisioningState.Succeeded, getDomainTopicResponse1.Data.ProvisioningState);

            createDomainTopicResponse = (await domainTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainTopicName2)).Value;

            Assert.NotNull(createDomainTopicResponse);
            Assert.AreEqual(createDomainTopicResponse.Data.Name, domainTopicName2);

            // Get the created domain Topic
            var getDomainTopicResponse2 = (await domainTopicCollection.GetAsync(domainTopicName2)).Value;
            Assert.NotNull(getDomainTopicResponse2);
            Assert.AreEqual(DomainTopicProvisioningState.Succeeded, getDomainTopicResponse2.Data.ProvisioningState);

            // Get all domainTopics created within a resourceGroup
            var domainTopicsInDomainPage = await domainTopicCollection.GetAllAsync().ToEnumerableAsync();

            Assert.NotNull(domainTopicsInDomainPage);
            Assert.AreEqual(domainTopicsInDomainPage.Count, 2);
            Assert.NotNull(domainTopicsInDomainPage.FirstOrDefault(x => x.Data.Name.Equals(domainTopicName1)));
            Assert.NotNull(domainTopicsInDomainPage.FirstOrDefault(x => x.Data.Name.Equals(domainTopicName2)));

            // Delete domainTopics
            await getDomainTopicResponse1.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await domainTopicCollection.ExistsAsync(domainTopicName1)).Value;
            Assert.IsFalse(falseResult);
            await getDomainTopicResponse2.DeleteAsync(WaitUntil.Completed);
            falseResult = (await domainTopicCollection.ExistsAsync(domainTopicName2)).Value;
            Assert.IsFalse(falseResult);

            // Delete domain
            await updateDomainResponseWithIpFilteringFeature.DeleteAsync(WaitUntil.Completed);
            falseResult = (await DomainCollection.ExistsAsync(domainName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Test]
        public async Task DomainNSPTests()
        {
            await SetCollection();

            var domainName = Recording.GenerateAssetName("sdk-Domain-");
            AzureLocation location = new AzureLocation("eastus", "eastus");

            var domain = new EventGridDomainData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                InputSchema = EventGridInputSchema.CloudEventSchemaV1_0,
                InputSchemaMapping = new EventGridJsonInputSchemaMapping()
                {
                    Topic = new JsonField("myTopicField", null)
                }
            };

            var createDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domain)).Value;

            Assert.NotNull(createDomainResponse);
            Assert.AreEqual(createDomainResponse.Data.Name, domainName);

            var NspCollection = createDomainResponse.GetDomainNetworkSecurityPerimeterConfigurations();
            var listNSPConfigs = await NspCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, listNSPConfigs.Count());

            // Delete domain
            await createDomainResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await DomainCollection.ExistsAsync(domainName)).Value;
            Assert.IsFalse(falseResult);
        }

        [Test]
        public async Task DomainDisableLocalAuthAndAutoCreateAndAutoDelete()
        {
            await SetCollection();

            var domainName = Recording.GenerateAssetName("sdk-Domain-");
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");

            var domain = new EventGridDomainData(location)
            {
                Tags = {
                    {"originalTag1", "originalValue1"},
                    {"originalTag2", "originalValue2"}
                },
                InputSchema = EventGridInputSchema.CloudEventSchemaV1_0,
                IsLocalAuthDisabled = false,
                AutoCreateTopicWithFirstSubscription = false,
                AutoDeleteTopicWithLastSubscription = false,
                InputSchemaMapping = new EventGridJsonInputSchemaMapping()
                {
                    Topic = new JsonField("myTopicField", null)
                }
            };

            var createDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domain)).Value;
            Assert.NotNull(createDomainResponse);
            Assert.AreEqual(createDomainResponse.Data.Name, domainName);

            // Get the created domain
            var getDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.NotNull(getDomainResponse);
            Assert.IsFalse(getDomainResponse.Data.IsLocalAuthDisabled);
            Assert.IsFalse(getDomainResponse.Data.AutoCreateTopicWithFirstSubscription);
            Assert.IsFalse(getDomainResponse.Data.AutoDeleteTopicWithLastSubscription);
        }
    }
}
