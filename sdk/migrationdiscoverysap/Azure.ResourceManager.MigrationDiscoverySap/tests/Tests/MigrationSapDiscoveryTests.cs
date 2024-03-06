// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.MigrationDiscoverySap.Models;
using Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests.Enums;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests
{
    public class MigrationSapDiscoveryTests : MigrationDiscoverySapManagementTestBase
    {
        public MigrationSapDiscoveryTests(bool isAsync) : base(isAsync)
        {
        }

        public const string migrateProjectIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Migrate/MigrateProjects/{2}";

        [TestCase]
        public async Task TestDiscoveryOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("SdkTest-Net-");
            string migrateProjName = Recording.GenerateAssetName("migrateProj");
            string migrateProjectId = String.Format(migrateProjectIdFormat, subscription.Data.SubscriptionId, rgName, migrateProjName);
            string discoverySiteName = Recording.GenerateAssetName("SapDiscoverySite-");

            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.SoutheastAsia);

            GenericResourceData data = new GenericResourceData(AzureLocation.SoutheastAsia)
            {
                Properties = new BinaryData(new Dictionary<string, object>
                {
                    { "registeredTools", new string[] { "ServerAssessment" }}
                })
            };

            var operationStatus = await Client.GetGenericResources().CreateOrUpdateAsync(
                WaitUntil.Completed, ResourceIdentifier.Parse(migrateProjectId), data);

            // Create Discovery site payload
            SAPDiscoverySiteData site = new SAPDiscoverySiteData();
            site.MigrateProjectId = migrateProjectId;
            site.Location = AzureLocation.SoutheastAsia;

            // Create discovery site
            ArmOperation<SAPDiscoverySiteResource> discoverySiteOp = await rg.GetSAPDiscoverySites().CreateOrUpdateAsync(
                WaitUntil.Completed,
                discoverySiteName,
                site);
            var resourceId = discoverySiteOp.Value.Id;

            // Get SAP DiscoverySite
            SAPDiscoverySiteResource sapDiscoverySiteResource = Client.GetSAPDiscoverySiteResource(resourceId);

            // Post import entities
            var importEntitiesOp = await sapDiscoverySiteResource.ImportEntitiesAsync(WaitUntil.Completed);

            Assert.IsNotNull(
                await TrackTillConditionReachedForAsyncOperationAsync(
                    new Func<Task<bool>>(async () => await this.TrackForDiscoveryExcelInputSasUriAsync(
                        importEntitiesOp)), 300),
                "SAS Uri generation failed");

            var opStatus = await importEntitiesOp.UpdateStatusAsync();
            var map = JObject.Parse(opStatus.Content.ToString());
            var inputExcelSasUri = map?["properties"]?["discoveryExcelSasUri"].ToString();

            //Upload here
            using (var stream = File.OpenRead(@"TestData\ExcelSDKTesting.xlsx"))
            {
                // Construct the blob client with a sas token.
                var blobClient = this.GetBlobContentClient(inputExcelSasUri);

                await blobClient.UploadAsync(stream, overwrite: true);
            }

            Assert.IsTrue(
                await TrackTillConditionReachedForAsyncOperationAsync(
                    new Func<Task<bool>>(async () => await this.ValidateExcelParsingStatusAsync(
                        43,
                        47,
                        importEntitiesOp)), 300),
                "Excel Upload failed.");

            var collection = sapDiscoverySiteResource.GetSAPInstances();

            List<SAPInstanceData> list = new List<SAPInstanceData>();
            // invoke the operation and iterate over the result
            await foreach (SAPInstanceResource item in collection.GetAllAsync())
            {
                list.Add(item.Data);
            }

            Assert.IsNotNull(list);

            var jsonString = File.ReadAllText(@"TestData\ExpectedGetSapInstanceList.json").Replace("__SapDiscoverySIteId__", sapDiscoverySiteResource.Id.ToString());
            var json = JsonDocument.Parse(jsonString).RootElement;
            List<SAPInstanceData> expectedList = new List<SAPInstanceData>();
            var arr = json.EnumerateArray();
            for (int i = 0; i < arr.Count(); i++)
            {
                var obj = arr.ElementAt(i);
                expectedList.Add(SAPInstanceData.DeserializeSAPInstanceData(obj));
            }

            Assert.AreEqual(expectedList.Count(), list.Count());

            list = list.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();
            expectedList = expectedList.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();
            for (int i = 0; i < list.Count() ; i++)
            {
                Assert.AreEqual(expectedList[i].Location, list[i].Location);
                Assert.AreEqual(expectedList[i].LandscapeSid, list[i].LandscapeSid);
                Assert.AreEqual(expectedList[i].Name, list[i].Name);
                Assert.AreEqual(expectedList[i].SystemSid, list[i].SystemSid);
                Assert.AreEqual(expectedList[i].ProvisioningState, list[i].ProvisioningState);
                Assert.AreEqual(expectedList[i].Environment, list[i].Environment);
            }

            // Get SapInstance
            var sapInstanceId = list[0].Id;
            SAPInstanceResource sapInstance = Client.GetSAPInstanceResource(sapInstanceId);

            // get the collection of this ServerInstanceResource
            ServerInstanceCollection serverCollection = sapInstance.GetServerInstances();

            List<ServerInstanceData> serverInstancesList = new List<ServerInstanceData>();
            // invoke the operation and iterate over the result
            await foreach (ServerInstanceResource serverInstances in serverCollection.GetAllAsync())
            {
                serverInstancesList.Add(serverInstances.Data);
            }
            Assert.IsNotNull(serverInstancesList);

            var serverInstancesJsonString = File.ReadAllText(@"TestData\ExpectedGetServerInstancesList.json").Replace("__SapDiscoverySIteId__", sapDiscoverySiteResource.Id.ToString());
            var serverInstancesjson = JsonDocument.Parse(serverInstancesJsonString).RootElement;
            List<ServerInstanceData> expectedServerInstancesList = new List<ServerInstanceData>();
            var serverinstArr = serverInstancesjson.EnumerateArray();
            for (int i = 0; i < serverinstArr.Count(); i++)
            {
                var obj = serverinstArr.ElementAt(i);
                expectedServerInstancesList.Add(ServerInstanceData.DeserializeServerInstanceData(obj));
            }

            Assert.AreEqual(expectedServerInstancesList.Count(), serverInstancesList.Count());

            serverInstancesList = serverInstancesList.OrderBy(server => server.Name.ToLower()).ToList();
            expectedServerInstancesList = expectedServerInstancesList.OrderBy(server => server.Name.ToLower()).ToList();
            for (int i = 0; i < serverInstancesList.Count(); i++)
            {
                Assert.AreEqual(expectedServerInstancesList[i].Name, serverInstancesList[i].Name);
                Assert.AreEqual(expectedServerInstancesList[i].ServerName, serverInstancesList[i].ServerName);
                Assert.AreEqual(expectedServerInstancesList[i].InstanceSid, serverInstancesList[i].InstanceSid);
            }

            // Get ServerInstance
            var serverInstanceId = serverInstancesList[0].Id;
            ServerInstanceResource serverInstance = Client.GetServerInstanceResource(serverInstanceId);

            //Patch SAP DiscoverySite
            var discoverySitePatch = new SAPDiscoverySitePatch();
            discoverySitePatch.Tags.Add("Key1", "TestPatchValue");
            sapDiscoverySiteResource = await sapDiscoverySiteResource.UpdateAsync(discoverySitePatch);
            Assert.AreEqual(discoverySiteName, sapDiscoverySiteResource.Data.Name);

            //Patch SAP Instance
            var sapInstancePatch = new SAPInstancePatch();
            sapInstancePatch.Tags.Add("Key1", "TestPatchValue");
            sapInstance = await sapInstance.UpdateAsync(sapInstancePatch);
            Assert.AreEqual("ANQ_ADP", sapInstance.Id.Name);

            // Delete SAP DiscoverySite
            await sapDiscoverySiteResource.DeleteAsync(WaitUntil.Completed);
        }

        /// <summary>
        /// Get Blob Content client with blob uri and SaS token.
        /// </summary>
        /// <param name="sasUri">The SAS Uri of the blob.</param>
        /// <returns>Blob content client.</returns>
        private Azure.Storage.Blobs.BlobClient GetBlobContentClient(string sasUri)
        {
            // Split the sas uri into blob uri and sas token.
            // https://learn.microsoft.com/en-us/azure/ai-services/translator/document-translation/how-to-guides/create-sas-tokens?tabs=blobs#use-your-sas-url-to-grant-access-to-blob-storage
            var sasUriFragment = sasUri.Split('?');
            // Checks if the sas uri fragments are not-empty, not-null and has 2 elements.
            if (sasUriFragment.Length != 2)
            {
                throw new InvalidDataException(
                    $"Invalid sas uri: {sasUri}. Sas uri should be in the format of <blobUri>?<sasToken>");
            }

            // Construct the blob client with a sas token.
            var blobClient = new Azure.Storage.Blobs.BlobClient(
                new Uri(sasUriFragment[0]),
                new AzureSasCredential(sasUriFragment[1]));

            return blobClient;
        }

        /// <summary>
        /// Tracks till it satisfies the input condition (boolean function).
        /// </summary>
        /// <param name="func">The function describing the condition was achieved or not.</param>
        /// <param name="totalCount">The total count to loop.</param>
        /// <returns>The status on whether the condition was achieved.</returns>
        public static async Task<bool> TrackTillConditionReachedForAsyncOperationAsync(
            Func<Task<bool>> func,
            int totalCount = 100)
        {
            var isConditionReached = false;
            int counter = 0;
            while (counter < totalCount)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                if (await func())
                {
                    isConditionReached = true;
                    break;
                }

                counter++;
            }

            return isConditionReached;
        }

        /// <summary>
        /// Track for input sas uri for excel upload.
        /// </summary>
        /// <param name="operation">Operation to poll.</param>
        /// <returns>If uri is now available to fetch.</returns>
        protected async Task<bool> TrackForDiscoveryExcelInputSasUriAsync(ArmOperation<OperationStatusResult> operation)
        {
            var operationStatus = await Client.GetGenericResources().GetAsync(ResourceIdentifier.Parse(operation.Value.Id));
            var map = JObject.Parse(operationStatus?.GetRawResponse()?.Content?.ToString());
            var opProperties = map?["properties"];
            Assert.IsNotNull(opProperties);

            var status = opProperties?["status"];
            Assert.IsNotNull(status);

            if (status.ToString() == ImportOperationState.AwaitingFile.ToString()
                && !string.IsNullOrEmpty(opProperties?["discoveryExcelSasUri"].ToString()))
            {
                return true;
            }
            else if (status.ToString() == ImportOperationState.Failed.ToString() ||
                status.ToString() == ImportOperationState.Canceled.ToString())
            {
                throw new Exception(
                    "SasUriCreationFailed");
            }

            return false;
        }

        /// <summary>
        /// Validates the excel upload terminal statuses.
        /// </summary>
        /// <param name="expectedRowsImported">Expected imported rows after excel parsed.</param>
        /// <param name="expectedTotalRows">Expected total rows after excel parsed.</param>
        /// <param name="operation">The operation to track.</param>
        /// <returns>If all assertions succeeded.</returns>
        protected async Task<bool> ValidateExcelParsingStatusAsync(
            int expectedRowsImported,
            int expectedTotalRows,
            ArmOperation<OperationStatusResult> operation)
        {
            var operationStatus = await Client.GetGenericResources().GetAsync(ResourceIdentifier.Parse(operation.Value.Id));
            var map = JObject.Parse(operationStatus?.GetRawResponse()?.Content?.ToString());
            var opProperties = map?["properties"];
            Assert.IsNotNull(opProperties);

            var status = opProperties?["status"];
            Assert.IsNotNull(status);
            if (status.ToString() == ImportOperationState.Succeeded.ToString())
            {
                Assert.IsNull(opProperties?["errorExcelSasUri"].ToString(), "Error excel SAS Uri exists for successfull import");
                Assert.AreEqual(
                    expectedRowsImported,
                    (int)opProperties?["rowsImported"],
                    "Imported rows check");
                Assert.AreEqual(
                    expectedTotalRows,
                    (int)opProperties?["totalRows"],
                    "total rows check");
                Assert.AreEqual(
                    (int)opProperties?["rowsImported"],
                    (int)opProperties?["totalRows"],
                    "Total rows are not equal to rows imported for success case.");
                Assert.IsNull(map?["error"], "Error exists for success case.");

                return true;
            }
            else if (status.ToString() == ImportOperationState.PartiallySucceeded.ToString())
            {
                Assert.IsNotNull(
                    opProperties?["errorExcelSasUri"].ToString(),
                    "Error excel SAS Uri does not exists for partial successfull import");
                Assert.AreEqual(
                    expectedRowsImported,
                    (int)opProperties?["rowsImported"],
                    "Imported rows check");
                Assert.AreEqual(
                    expectedTotalRows,
                    (int)opProperties?["totalRows"],
                    "total rows check");
                Assert.IsNotNull(map?["error"], "Error check.");
                return true;
            }
            else if (status.ToString() == ImportOperationState.Failed.ToString() ||
                status.ToString() == ImportOperationState.Canceled.ToString())
            {
                throw new Exception(
                    "ExcelUpload Failed/Cancelled");
            }

            return false;
        }
    }
}
