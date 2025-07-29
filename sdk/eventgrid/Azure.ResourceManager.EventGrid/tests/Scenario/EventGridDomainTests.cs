// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
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

        private const string OriginalTag1 = "originalTag1";
        private const string OriginalValue1 = "originalValue1";
        private const string OriginalTag2 = "originalTag2";
        private const string OriginalValue2 = "originalValue2";

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
                    {OriginalTag1, OriginalValue1},
                    {OriginalTag2, OriginalValue2}
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
            Assert.IsTrue(getDomainResponse.Data.Tags.Keys.Contains(OriginalTag1));
            Assert.AreEqual(getDomainResponse.Data.Tags[OriginalTag1], OriginalValue1);
            Assert.IsTrue(getDomainResponse.Data.Tags.Keys.Contains(OriginalTag2));
            Assert.AreEqual(getDomainResponse.Data.Tags[OriginalTag2], OriginalValue2);
            // get private link resource
            var linkResource = await getDomainResponse.GetEventGridDomainPrivateLinkResourceAsync("domain");
            Assert.IsNotNull(linkResource);
            // list all private link resources
            System.Collections.Generic.List<EventGridDomainPrivateLinkResource> list = await getDomainResponse.GetEventGridDomainPrivateLinkResources().ToEnumerableAsync();
            Assert.NotNull(list);
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

            // List keys for a domain.
            // List the two keys used to publish to a domain.
            Response<EventGridDomainSharedAccessKeys> keysResponse = await getDomainResponse.GetSharedAccessKeysAsync();

            // Ensure the response is not null
            Assert.IsNotNull(keysResponse, "Failed to list shared access keys");

            // Ensure the keys object is not null
            Assert.IsNotNull(keysResponse.Value, "Shared access keys response is null");

            // Validate that primary and secondary keys exist
            Assert.IsFalse(string.IsNullOrEmpty(keysResponse.Value.Key1), "Primary key is missing");
            Assert.IsFalse(string.IsNullOrEmpty(keysResponse.Value.Key2), "Secondary key is missing");

            // Regemerate key
            var regenerateKeyContent = new EventGridDomainRegenerateKeyContent("key1");
            var response = await getDomainResponse.RegenerateKeyAsync(regenerateKeyContent);

            // Validate response and regenerated keys
            Assert.IsNotNull(response, "Response should not be null");
            Assert.IsNotNull(response.Value, "Shared access keys response is null");
            Assert.IsFalse(string.IsNullOrEmpty(response.Value.Key1), "Primary key is missing after regeneration");
            Assert.IsFalse(string.IsNullOrEmpty(response.Value.Key2), "Secondary key is missing after regeneration");

            // Replace the domain
            domain.Tags.Clear();
            domain.Tags.Add("replacedTag1", "replacedValue1");
            domain.Tags.Add("replacedTag2", "replacedValue2");
            var replaceDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domain)).Value;

            Assert.IsTrue(replaceDomainResponse.Data.Tags.Keys.Contains("replacedTag1"));
            Assert.IsFalse(replaceDomainResponse.Data.Tags.Keys.Contains(OriginalTag1));

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

            // Validate regenerate keys
            var sharedAccessKeys = (await getDomainResponse.GetSharedAccessKeysAsync()).Value;
            var sharedAccessKey1Before = sharedAccessKeys.Key1;
            var sharedAccessKey2Before = sharedAccessKeys.Key2;
            EventGridDomainRegenerateKeyContent domainRegenerateKeyContent = new EventGridDomainRegenerateKeyContent("key1");
            var regenKeysResponse = (await getDomainResponse.RegenerateKeyAsync(domainRegenerateKeyContent)).Value;
            // TODO: Uncomment when the bug is fixed in the service
            // Assert.AreNotEqual(regenKeysResponse.Key1, sharedAccessKey1Before);
            Assert.AreEqual(regenKeysResponse.Key2, sharedAccessKey2Before);

            // Create domain topic manually.
            var domainTopicCollection = updateDomainResponseWithIpFilteringFeature.GetDomainTopics();
            // Ensure domain topics do not exist before creation
            Assert.IsFalse((await domainTopicCollection.ExistsAsync(domainTopicName1)).Value, "Domain topic already exists before creation.");
            Assert.IsFalse((await domainTopicCollection.ExistsAsync(domainTopicName2)).Value, "Domain topic already exists before creation.");
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

        // Enabling NetworkSecurityPerimeterConfigurations for 2025-04-01-preview version
        [Test]
        public async Task DomainNSPTests()
        {
            await SetCollection();

            var domainName = Recording.GenerateAssetName("sdk-Domain-");
            AzureLocation location = new AzureLocation("eastus", "eastus");

            var domain = new EventGridDomainData(location)
            {
                Tags = {
                    {OriginalTag1, OriginalValue1},
                    {OriginalTag2, OriginalValue2}
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
                    {OriginalTag1, OriginalValue1},
                    {OriginalTag2, OriginalValue2}
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
