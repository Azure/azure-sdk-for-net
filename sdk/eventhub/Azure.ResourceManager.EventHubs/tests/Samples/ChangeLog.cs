// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Snippet:ChangeLog_Sample
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.EventHubs.Models;

#if !SNIPPET
using NUnit.Framework;
using System.Threading.Tasks;
namespace Azure.ResourceManager.EventHubs.Tests.Samples
{
    public class ChangeLog
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ChangelogSample()
        {
#endif
string namespaceName = "myNamespace";
string eventhubName = "myEventhub";
string resourceGroupName = "myResourceGroup";
ArmClient client = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroup resourceGroup = subscription.GetResourceGroups().Get(resourceGroupName);
//create namespace
EventHubNamespaceData parameters = new EventHubNamespaceData(Location.WestUS)
{
    Sku = new Sku(SkuName.Standard)
    {
        Tier = SkuTier.Standard,
    }
};
parameters.Tags.Add("tag1", "value1");
parameters.Tags.Add("tag2", "value2");
EventHubNamespaceCollection eHNamespaceCollection = resourceGroup.GetEventHubNamespaces();
EventHubNamespace eventHubNamespace = eHNamespaceCollection.CreateOrUpdate(namespaceName, parameters).Value;

//create eventhub
EventHubCollection eventHubCollection = eventHubNamespace.GetEventHubs();
EventHubData eventHubData = new EventHubData()
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
        Destination = new EventHubDestination()
        {
            Name = "EventHubArchive.AzureBlockBlob",
            BlobContainer = "Container",
            ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
            StorageAccountResourceId = subscription.Id.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew"
        },
        SkipEmptyArchives = true
    }
};
EventHub eventHub = eventHubCollection.CreateOrUpdate(eventhubName, eventHubData).Value;
            #endregion
        }
    }
}
