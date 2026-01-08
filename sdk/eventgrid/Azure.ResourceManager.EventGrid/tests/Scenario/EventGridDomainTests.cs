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

            Assert.Multiple(() =>
            {
                Assert.That(createDomainResponse, Is.Not.Null);
                Assert.That(domainName, Is.EqualTo(createDomainResponse.Data.Name));
            });

            // Get the created domain
            var getDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.That(getDomainResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getDomainResponse.Data.ProvisioningState, Is.EqualTo(EventGridDomainProvisioningState.Succeeded));
                Assert.That(getDomainResponse.Data.Location, Is.EqualTo(location));
                Assert.That(getDomainResponse.Data.Tags.Keys.Contains(OriginalTag1), Is.True);
                Assert.That(getDomainResponse.Data.Tags[OriginalTag1], Is.EqualTo(OriginalValue1));
                Assert.That(getDomainResponse.Data.Tags.Keys.Contains(OriginalTag2), Is.True);
                Assert.That(getDomainResponse.Data.Tags[OriginalTag2], Is.EqualTo(OriginalValue2));
            });
            // get private link resource
            var linkResource = await getDomainResponse.GetEventGridDomainPrivateLinkResourceAsync("domain");
            Assert.That(linkResource, Is.Not.Null);
            // list all private link resources
            System.Collections.Generic.List<EventGridDomainPrivateLinkResource> list = await getDomainResponse.GetEventGridDomainPrivateLinkResources().ToEnumerableAsync();
            Assert.Multiple(() =>
            {
                Assert.That(list, Is.Not.Null);
                //// Diable test as identity is not part of GA Version yet.
                //// Assert.Null(getDomainResponse.Identity);
                Assert.That(getDomainResponse.Data.InboundIPRules.Count, Is.EqualTo(0));
            });

            // Get all domains created within a resourceGroup
            var domainsInResourceGroup = await DomainCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(domainsInResourceGroup, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(domainsInResourceGroup.Count, Is.GreaterThanOrEqualTo(1));
                Assert.That(domainName, Is.EqualTo(domainsInResourceGroup.FirstOrDefault().Data.Name));
            });
            // Get all domains created within the subscription irrespective of the resourceGroup
            var domainsInAzureSubscription = await DefaultSubscription.GetEventGridDomainsAsync().ToEnumerableAsync();
            Assert.That(domainsInAzureSubscription, Is.Not.Null);
            Assert.That(domainsInAzureSubscription.Count, Is.GreaterThanOrEqualTo(1));
            var falseFlag = false;
            foreach (var item in domainsInAzureSubscription)
            {
                if (item.Data.Name == domainName)
                {
                    falseFlag = true;
                    break;
                }
            }
            Assert.That(falseFlag, Is.True);

            // List keys for a domain.
            // List the two keys used to publish to a domain.
            Response<EventGridDomainSharedAccessKeys> keysResponse = await getDomainResponse.GetSharedAccessKeysAsync();

            // Ensure the response is not null
            Assert.That(keysResponse, Is.Not.Null, "Failed to list shared access keys");

            Assert.Multiple(() =>
            {
                // Ensure the keys object is not null
                Assert.That(keysResponse.Value, Is.Not.Null, "Shared access keys response is null");

                // Validate that primary and secondary keys exist
                Assert.That(string.IsNullOrEmpty(keysResponse.Value.Key1), Is.False, "Primary key is missing");
                Assert.That(string.IsNullOrEmpty(keysResponse.Value.Key2), Is.False, "Secondary key is missing");
            });

            // Regemerate key
            var regenerateKeyContent = new EventGridDomainRegenerateKeyContent("key1");
            var response = await getDomainResponse.RegenerateKeyAsync(regenerateKeyContent);

            // Validate response and regenerated keys
            Assert.That(response, Is.Not.Null, "Response should not be null");
            Assert.Multiple(() =>
            {
                Assert.That(response.Value, Is.Not.Null, "Shared access keys response is null");
                Assert.That(string.IsNullOrEmpty(response.Value.Key1), Is.False, "Primary key is missing after regeneration");
                Assert.That(string.IsNullOrEmpty(response.Value.Key2), Is.False, "Secondary key is missing after regeneration");
            });

            // Replace the domain
            domain.Tags.Clear();
            domain.Tags.Add("replacedTag1", "replacedValue1");
            domain.Tags.Add("replacedTag2", "replacedValue2");
            var replaceDomainResponse = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domain)).Value;

            Assert.Multiple(() =>
            {
                Assert.That(replaceDomainResponse.Data.Tags.Keys.Contains("replacedTag1"), Is.True);
                Assert.That(replaceDomainResponse.Data.Tags.Keys.Contains(OriginalTag1), Is.False);
            });

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
            Assert.Multiple(() =>
            {
                Assert.That(updateDomainResponse.Data.Tags.Keys.Contains("updatedTag1"), Is.True);
                Assert.That(updateDomainResponse.Data.Tags.Keys.Contains("replacedTag1"), Is.False);
                Assert.That(updateDomainResponse.Data.PublicNetworkAccess, Is.EqualTo(EventGridPublicNetworkAccess.Enabled));
                Assert.That(updateDomainResponse.Data.InboundIPRules.Count, Is.EqualTo(0));
            });

            // Update the Topic with IP filtering feature
            domain.PublicNetworkAccess = EventGridPublicNetworkAccess.Disabled;
            domain.InboundIPRules.Add(new EventGridInboundIPRule() { Action = EventGridIPActionType.Allow, IPMask = "12.35.67.98" });
            domain.InboundIPRules.Add(new EventGridInboundIPRule() { Action = EventGridIPActionType.Allow, IPMask = "12.35.90.100" });
            var updateDomainResponseWithIpFilteringFeature = (await DomainCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainName, domain)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(updateDomainResponseWithIpFilteringFeature.Data.PublicNetworkAccess == EventGridPublicNetworkAccess.Enabled, Is.False);
                Assert.That(updateDomainResponseWithIpFilteringFeature.Data.InboundIPRules, Has.Count.EqualTo(2));
            });

            // Validate regenerate keys
            var sharedAccessKeys = (await getDomainResponse.GetSharedAccessKeysAsync()).Value;
            var sharedAccessKey1Before = sharedAccessKeys.Key1;
            var sharedAccessKey2Before = sharedAccessKeys.Key2;
            EventGridDomainRegenerateKeyContent domainRegenerateKeyContent = new EventGridDomainRegenerateKeyContent("key1");
            var regenKeysResponse = (await getDomainResponse.RegenerateKeyAsync(domainRegenerateKeyContent)).Value;
            // TODO: Uncomment when the bug is fixed in the service
            // Assert.AreNotEqual(regenKeysResponse.Key1, sharedAccessKey1Before);
            Assert.That(sharedAccessKey2Before, Is.EqualTo(regenKeysResponse.Key2));

            // Create domain topic manually.
            var domainTopicCollection = updateDomainResponseWithIpFilteringFeature.GetDomainTopics();
            Assert.Multiple(async () =>
            {
                // Ensure domain topics do not exist before creation
                Assert.That((await domainTopicCollection.ExistsAsync(domainTopicName1)).Value, Is.False, "Domain topic already exists before creation.");
                Assert.That((await domainTopicCollection.ExistsAsync(domainTopicName2)).Value, Is.False, "Domain topic already exists before creation.");
            });
            var createDomainTopicResponse = (await domainTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainTopicName1)).Value;

            Assert.Multiple(() =>
            {
                Assert.That(createDomainTopicResponse, Is.Not.Null);
                Assert.That(domainTopicName1, Is.EqualTo(createDomainTopicResponse.Data.Name));
            });

            // Get the created domain Topic
            var getDomainTopicResponse1 = (await domainTopicCollection.GetAsync(domainTopicName1)).Value;
            Assert.That(getDomainTopicResponse1, Is.Not.Null);
            Assert.That(getDomainTopicResponse1.Data.ProvisioningState, Is.EqualTo(DomainTopicProvisioningState.Succeeded));

            createDomainTopicResponse = (await domainTopicCollection.CreateOrUpdateAsync(WaitUntil.Completed, domainTopicName2)).Value;

            Assert.Multiple(() =>
            {
                Assert.That(createDomainTopicResponse, Is.Not.Null);
                Assert.That(domainTopicName2, Is.EqualTo(createDomainTopicResponse.Data.Name));
            });

            // Get the created domain Topic
            var getDomainTopicResponse2 = (await domainTopicCollection.GetAsync(domainTopicName2)).Value;
            Assert.That(getDomainTopicResponse2, Is.Not.Null);
            Assert.That(getDomainTopicResponse2.Data.ProvisioningState, Is.EqualTo(DomainTopicProvisioningState.Succeeded));

            // Get all domainTopics created within a resourceGroup
            var domainTopicsInDomainPage = await domainTopicCollection.GetAllAsync().ToEnumerableAsync();

            Assert.That(domainTopicsInDomainPage, Is.Not.Null);
            Assert.That(domainTopicsInDomainPage, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(domainTopicsInDomainPage.FirstOrDefault(x => x.Data.Name.Equals(domainTopicName1)), Is.Not.Null);
                Assert.That(domainTopicsInDomainPage.FirstOrDefault(x => x.Data.Name.Equals(domainTopicName2)), Is.Not.Null);
            });

            // Delete domainTopics
            await getDomainTopicResponse1.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await domainTopicCollection.ExistsAsync(domainTopicName1)).Value;
            Assert.That(falseResult, Is.False);
            await getDomainTopicResponse2.DeleteAsync(WaitUntil.Completed);
            falseResult = (await domainTopicCollection.ExistsAsync(domainTopicName2)).Value;
            Assert.That(falseResult, Is.False);

            // Delete domain
            await updateDomainResponseWithIpFilteringFeature.DeleteAsync(WaitUntil.Completed);
            falseResult = (await DomainCollection.ExistsAsync(domainName)).Value;
            Assert.That(falseResult, Is.False);
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

            Assert.Multiple(() =>
            {
                Assert.That(createDomainResponse, Is.Not.Null);
                Assert.That(domainName, Is.EqualTo(createDomainResponse.Data.Name));
            });

            var NspCollection = createDomainResponse.GetDomainNetworkSecurityPerimeterConfigurations();
            var listNSPConfigs = await NspCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(listNSPConfigs.Count(), Is.EqualTo(0));

            // Delete domain
            await createDomainResponse.DeleteAsync(WaitUntil.Completed);
            var falseResult = (await DomainCollection.ExistsAsync(domainName)).Value;
            Assert.That(falseResult, Is.False);
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
            Assert.Multiple(() =>
            {
                Assert.That(createDomainResponse, Is.Not.Null);
                Assert.That(domainName, Is.EqualTo(createDomainResponse.Data.Name));
            });

            // Get the created domain
            var getDomainResponse = (await DomainCollection.GetAsync(domainName)).Value;
            Assert.That(getDomainResponse, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getDomainResponse.Data.IsLocalAuthDisabled, Is.False);
                Assert.That(getDomainResponse.Data.AutoCreateTopicWithFirstSubscription, Is.False);
                Assert.That(getDomainResponse.Data.AutoDeleteTopicWithLastSubscription, Is.False);
            });
        }
    }
}
