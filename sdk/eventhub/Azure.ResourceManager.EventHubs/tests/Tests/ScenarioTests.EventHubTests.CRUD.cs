// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Linq;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.EventHubs.Models;
using Azure.ResourceManager.EventHubs.Tests;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.Management.EventHub.Tests
{
    public partial class ScenarioTests : EventHubsManagementClientBase
    {
        public ScenarioTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task EventCreateGetUpdateDelete()
        {
            var location = await GetLocation();
            var resourceGroupName = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            Subscription sub = await ArmClient.GetDefaultSubscriptionAsync();
            ResourceGroup resourceGroup =(await sub.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName, new ResourceGroupData(location))).Value;

            // Prepare Storage Account
            var accountName = Recording.GenerateAssetName("sdktestaccount");
            var storageAccountCreateParameters = new StorageAccountCreateParameters(
                    new ResourceManager.Storage.Models.Sku("Standard_LRS"),
                    Kind.StorageV2,
                    "eastus2"
                    )
            {
                AccessTier = AccessTier.Hot
            };
            StorageAccountCollection storageAccountCollection = resourceGroup.GetStorageAccounts();
            await storageAccountCollection.CreateOrUpdateAsync(accountName, storageAccountCreateParameters);
            // Create NameSpace
            var namespaceName = Recording.GenerateAssetName(Helper.NamespacePrefix);
            var createNamespaceResponse = await NamespacesOperations.StartCreateOrUpdateAsync(resourceGroupName, namespaceName,
                new EHNamespace()
                {
                    Location = location
                }
                );
            var np = (await WaitForCompletionAsync(createNamespaceResponse)).Value;
            Assert.NotNull(createNamespaceResponse);
            Assert.AreEqual(np.Name, namespaceName);
            DelayInTest(5);
            // Create Eventhub
            var eventhubName = Recording.GenerateAssetName(Helper.EventHubPrefix);
            var createEventhubResponse = await EventHubsOperations.CreateOrUpdateAsync(resourceGroupName, namespaceName, eventhubName,
                new Eventhub()
                {
                    MessageRetentionInDays = 4,
                    PartitionCount = 4,
                    Status = EntityStatus.Active,
                    CaptureDescription = new CaptureDescription()
                    {
                        Enabled = true,
                        Encoding = EncodingCaptureDescription.Avro,
                        IntervalInSeconds = 120,
                        SizeLimitInBytes = 10485763,
                        Destination = new Destination()
                        {
                            Name = "EventHubArchive.AzureBlockBlob",
                            BlobContainer = "container",
                            ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
                            StorageAccountResourceId = "/subscriptions/" + SubscriptionId + "/resourcegroups/" + resourceGroupName + "/providers/Microsoft.Storage/storageAccounts/" + accountName
                        },
                        SkipEmptyArchives = true
                    }
                });
            Assert.NotNull(createEventhubResponse);
            Assert.AreEqual(createEventhubResponse.Value.Name, eventhubName);
            Assert.True(createEventhubResponse.Value.CaptureDescription.SkipEmptyArchives);
            //Get the created EventHub
            var getEventHubResponse = await EventHubsOperations.GetAsync(resourceGroupName, namespaceName, eventhubName);
            Assert.NotNull(getEventHubResponse.Value);
            Assert.AreEqual(EntityStatus.Active, getEventHubResponse.Value.Status);
            Assert.AreEqual(getEventHubResponse.Value.Name, eventhubName);
            //Get all Event Hubs for a given NameSpace
            var getListEventHubResponse = EventHubsOperations.ListByNamespaceAsync(resourceGroupName, namespaceName);
            var list = await getListEventHubResponse.ToEnumerableAsync();
            Assert.NotNull(getListEventHubResponse);
            Assert.True(list.Count() >= 1);
            // Update the EventHub
            getEventHubResponse.Value.CaptureDescription.IntervalInSeconds = 130;
            getEventHubResponse.Value.CaptureDescription.SizeLimitInBytes = 10485900;
            getEventHubResponse.Value.MessageRetentionInDays = 5;
            //TODO time exception
            var UpdateEventHubResponse = (await EventHubsOperations.CreateOrUpdateAsync(resourceGroupName, namespaceName, eventhubName, getEventHubResponse.Value)).Value;
            Assert.NotNull(UpdateEventHubResponse);
            // Get the updated EventHub and verify the properties
            var getEventResponse = await EventHubsOperations.GetAsync(resourceGroupName, namespaceName, eventhubName);
            Assert.NotNull(getEventResponse);
            Assert.AreEqual(EntityStatus.Active, getEventResponse.Value.Status);
            Assert.AreEqual(5, getEventResponse.Value.MessageRetentionInDays);
            // Delete the Evnet Hub
            var deleteEventResponse = await EventHubsOperations.DeleteAsync(resourceGroupName, namespaceName, eventhubName);
            // Delete namespace and check for the NotFound exception
            var deleteNamespaceResponse = await WaitForCompletionAsync(await NamespacesOperations.StartDeleteAsync(resourceGroupName, namespaceName));
        }
    }
}
