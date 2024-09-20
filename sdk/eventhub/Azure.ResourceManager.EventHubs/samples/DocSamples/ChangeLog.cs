// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:ChangeLog_Sample_Usings
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.EventHubs.Models;
using Azure.Core;
#endregion

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
            #region Snippet:ChangeLog_Sample
            string namespaceName = "myNamespace";
            string eventhubName = "myEventhub";
            string resourceGroupName = "myResourceGroup";
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupResource resourceGroup = subscription.GetResourceGroups().Get(resourceGroupName);
            //create namespace
            EventHubsNamespaceData parameters = new EventHubsNamespaceData(AzureLocation.WestUS)
            {
                Sku = new EventHubsSku(EventHubsSkuName.Standard)
                {
                    Tier = EventHubsSkuTier.Standard,
                }
            };
            parameters.Tags.Add("tag1", "value1");
            parameters.Tags.Add("tag2", "value2");
            EventHubsNamespaceCollection eHNamespaceCollection = resourceGroup.GetEventHubsNamespaces();
            EventHubsNamespaceResource eventHubNamespace = eHNamespaceCollection.CreateOrUpdate(WaitUntil.Completed, namespaceName, parameters).Value;

            //create eventhub
            EventHubCollection eventHubCollection = eventHubNamespace.GetEventHubs();
            EventHubData eventHubData = new EventHubData()
            {
                PartitionCount = 4,
                Status = EventHubEntityStatus.Active,
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
                        StorageAccountResourceId = new ResourceIdentifier(subscription.Id.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew")
                    },
                    SkipEmptyArchives = true
                }
            };
            EventHubResource eventHub = eventHubCollection.CreateOrUpdate(WaitUntil.Completed, eventhubName, eventHubData).Value;
            #endregion
        }
    }
}
