// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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

        public const string MigrateProjectIdFormat =
            "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Migrate/MigrateProjects/{2}";

        [TestCase]
        [RecordedTest]
        public async Task TestDiscoveryOperations()
        {
            AzureLocation targetRegion = AzureLocation.SoutheastAsia;
            string targetSubscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupResource rg = await CreateResourceGroup(
                DefaultSubscription,
                "SdkTest-Net-",
                targetRegion);

            string rgName = rg.Id.Name;
            string migrateProjName = Recording.GenerateAssetName("migrateProj-");
            string migrateProjectId = string.Format(
                MigrateProjectIdFormat,
                targetSubscriptionId,
                rgName,
                migrateProjName);
            string discoverySiteName = Recording.GenerateAssetName("SapDiscoverySite-");

            await CreateMigrateProjectAsync(
                targetRegion,
                migrateProjectId);

            await CreateSapDiscoverySiteAsync(
                targetRegion,
                rg,
                migrateProjectId,
                discoverySiteName);

            // Get SAP DiscoverySite
            SAPDiscoverySiteResource sapDiscoverySiteResource =
                await rg.GetSAPDiscoverySiteAsync(discoverySiteName);
            Assert.AreEqual(sapDiscoverySiteResource.Data.ProvisioningState, ProvisioningState.Succeeded);
            string sapDiscoverySiteId = sapDiscoverySiteResource.Id.ToString();

            // Upload Excel to SAP DiscoverySite
            string excelPathToImport = @"TestData\ExcelSDKTesting.xlsx";
            await PostImportEntities(sapDiscoverySiteResource, excelPathToImport);

            // Get List SAP Instances
            List<SAPInstanceData> listSapInstances = await GetSapInstancesListAsync(sapDiscoverySiteResource);
            Assert.IsNotNull(listSapInstances);

            const string expectedSapInstancesListPath = @"TestData\ExpectedGetSapInstanceList.json";
            List<SAPInstanceData> expectedListSapInstances = GetExpectedSapInstancesListFromJson(
                sapDiscoverySiteId,
                expectedSapInstancesListPath);

            listSapInstances = listSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();
            expectedListSapInstances = expectedListSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();

            Assert.IsTrue(AreSapInstancesListEqual(listSapInstances, expectedListSapInstances));

            // Get SapInstance
            ResourceIdentifier sapInstanceId = listSapInstances.First().Id;
            Assert.IsNotNull(sapInstanceId);
            SAPInstanceResource sapInstance = Client.GetSAPInstanceResource(sapInstanceId);

            // Get Server Instances List
            List<ServerInstanceData> serverInstancesList = await GetServerInstancesList(sapInstance);
            Assert.IsNotNull(serverInstancesList);

            const string expectedServerInstanceListPath = @"TestData\ExpectedGetServerInstancesList.json";
            List<ServerInstanceData> expectedServerInstancesList = GetExpectedServerInstancesListFromJson(
                sapDiscoverySiteId,
                expectedServerInstanceListPath);

            serverInstancesList = serverInstancesList.OrderBy(server => server.Name.ToLower()).ToList();
            expectedServerInstancesList = expectedServerInstancesList.OrderBy(server => server.Name.ToLower()).ToList();

            Assert.IsTrue(AreServerInstancesListEqual(serverInstancesList, expectedServerInstancesList));

            // Get ServerInstance
            ResourceIdentifier serverInstanceId = serverInstancesList.First().Id;
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

        private static async Task<List<ServerInstanceData>> GetServerInstancesList(SAPInstanceResource sapInstance)
        {
            ServerInstanceCollection serverCollection = sapInstance.GetServerInstances();

            var serverInstancesList = new List<ServerInstanceData>();
            await foreach (ServerInstanceResource serverInstances in serverCollection.GetAllAsync())
            {
                serverInstancesList.Add(serverInstances.Data);
            }

            return serverInstancesList;
        }

        private static async Task<List<SAPInstanceData>> GetSapInstancesListAsync(SAPDiscoverySiteResource sapDiscoverySiteResource)
        {
            SAPInstanceCollection sapInstancescollection = sapDiscoverySiteResource.GetSAPInstances();

            var listSapInstances = new List<SAPInstanceData>();
            // invoke the operation and iterate over the result
            await foreach (SAPInstanceResource instance in sapInstancescollection.GetAllAsync())
            {
                listSapInstances.Add(instance.Data);
            }

            return listSapInstances;
        }

        private async Task PostImportEntities(SAPDiscoverySiteResource sapDiscoverySiteResource, string excelPathToImport)
        {
            ArmOperation<OperationStatusResult> importEntitiesOp =
                            await sapDiscoverySiteResource.ImportEntitiesAsync(WaitUntil.Completed);

            Assert.IsNotNull(
                await TrackTillConditionReachedForAsyncOperationAsync(
                    new Func<Task<bool>>(async () => await TrackForDiscoveryExcelInputSasUriAsync(
                        importEntitiesOp)), 300),
                "SAS Uri generation failed");

            Response opStatus = await importEntitiesOp.UpdateStatusAsync();
            var operationStatusObj = JObject.Parse(opStatus.Content.ToString());
            var inputExcelSasUri = operationStatusObj?["properties"]?["discoveryExcelSasUri"].ToString();

            //Upload here
            using (FileStream stream = File.OpenRead(excelPathToImport))
            {
                // Construct the blob client with a sas token.
                Storage.Blobs.BlobClient blobClient = GetBlobContentClient(inputExcelSasUri);

                await blobClient.UploadAsync(stream, overwrite: true);
            }

            Assert.IsTrue(
                await TrackTillConditionReachedForAsyncOperationAsync(
                    new Func<Task<bool>>(async () => await ValidateExcelParsingStatusAsync(
                        43,
                        47,
                        importEntitiesOp)), 300),
                "Excel Upload failed.");
        }

        private static List<ServerInstanceData> GetExpectedServerInstancesListFromJson(
            string sapDiscoverySiteId,
            string expectedServerInstanceListPath)
        {
            var serverInstancesJsonString = File.ReadAllText(expectedServerInstanceListPath)
                .Replace("__DiscoverySiteId__", sapDiscoverySiteId);
            JsonElement serverInstancesjson = JsonDocument.Parse(serverInstancesJsonString).RootElement;
            var expectedServerInstancesList = new List<ServerInstanceData>();
            JsonElement.ArrayEnumerator serverInstArray = serverInstancesjson.EnumerateArray();
            for (int i = 0; i < serverInstArray.Count(); i++)
            {
                JsonElement obj = serverInstArray.ElementAt(i);
                expectedServerInstancesList.Add(ServerInstanceData.DeserializeServerInstanceData(obj));
            }

            return expectedServerInstancesList;
        }

        private static List<SAPInstanceData> GetExpectedSapInstancesListFromJson(
            string sapDiscoverySiteId,
            string expectedSapInstancesListPath)
        {
            var expectedSapInstancesString = File.ReadAllText(expectedSapInstancesListPath)
                .Replace("__DiscoverySiteId__", sapDiscoverySiteId);
            JsonElement expectedSapInstancesJson = JsonDocument.Parse(expectedSapInstancesString).RootElement;
            var expectedListSapInstances = new List<SAPInstanceData>();
            using (JsonElement.ArrayEnumerator expectedSapInstancesArray = expectedSapInstancesJson.EnumerateArray())
            {
                for (int i = 0; i < expectedSapInstancesArray.Count(); i++)
                {
                    JsonElement instance = expectedSapInstancesArray.ElementAt(i);
                    expectedListSapInstances.Add(SAPInstanceData.DeserializeSAPInstanceData(instance));
                }
            }

            return expectedListSapInstances;
        }

        private static async Task CreateSapDiscoverySiteAsync(AzureLocation targetRegion, ResourceGroupResource rg, string migrateProjectId, string discoverySiteName)
        {
            // Create discoverySiteData payload
            string createSapDiscoverySitePayloadPath = @"TestData\CreateSapDiscoverySiteData.json";
            JsonElement discoverySiteDataElement = JsonDocument.Parse(
                File.ReadAllText(createSapDiscoverySitePayloadPath)
                    .Replace("__MigrateProjectId__", migrateProjectId)
                    .Replace("__Location__", targetRegion.Name)).RootElement;

            var discoverySiteData = SAPDiscoverySiteData
                .DeserializeSAPDiscoverySiteData(discoverySiteDataElement);

            // Create SAP DiscoverySite
            ArmOperation<SAPDiscoverySiteResource> createDiscoverySiteOperation =
                await rg.GetSAPDiscoverySites().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    discoverySiteName,
                    discoverySiteData);
        }

        private async Task CreateMigrateProjectAsync(AzureLocation targetRegion, string migrateProjectId)
        {
            // Create Migrate Project
            var CreateMigrateProjectPayload = new GenericResourceData(targetRegion)
            {
                Properties = new BinaryData(new Dictionary<string, object>
                {
                    { "registeredTools", new string[] { "ServerAssessment" }}
                })
            };

            await Client.GetGenericResources().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    ResourceIdentifier.Parse(migrateProjectId),
                    CreateMigrateProjectPayload);
        }

        private static bool AreSapInstancesListEqual(
            List<SAPInstanceData> actualListSapInstances,
            List<SAPInstanceData> expectedListSapInstances)
        {
            Assert.AreEqual(expectedListSapInstances.Count, actualListSapInstances.Count);
            for (int i = 0; i < actualListSapInstances.Count; i++)
            {
                if (expectedListSapInstances[i].Location != actualListSapInstances[i].Location ||
                    expectedListSapInstances[i].LandscapeSid != actualListSapInstances[i].LandscapeSid ||
                    expectedListSapInstances[i].Name != actualListSapInstances[i].Name ||
                    expectedListSapInstances[i].SystemSid != actualListSapInstances[i].SystemSid ||
                    expectedListSapInstances[i].ProvisioningState != actualListSapInstances[i].ProvisioningState ||
                    expectedListSapInstances[i].Environment!= actualListSapInstances[i].Environment)
                    return false;
            }
            return true;
        }

        private static bool AreServerInstancesListEqual(
            List<ServerInstanceData> actualServerInstancesList,
            List<ServerInstanceData> expectedServerInstancesList)
        {
            Assert.AreEqual(expectedServerInstancesList.Count, actualServerInstancesList.Count);
            for (int i = 0; i < actualServerInstancesList.Count; i++)
            {
                if (expectedServerInstancesList[i].Name != actualServerInstancesList[i].Name ||
                    expectedServerInstancesList[i].ServerName != actualServerInstancesList[i].ServerName ||
                    expectedServerInstancesList[i].InstanceSid != actualServerInstancesList[i].InstanceSid)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Track for input sas uri for excel upload.
        /// </summary>
        /// <param name="operation">Operation to poll.</param>
        /// <returns>If uri is now available to fetch.</returns>
        protected async Task<bool> TrackForDiscoveryExcelInputSasUriAsync(ArmOperation<OperationStatusResult> operation)
        {
            Response<GenericResource> operationStatus = await Client.GetGenericResources()
                .GetAsync(ResourceIdentifier.Parse(operation.Value.Id));
            JObject operationStatusObj = JObject.Parse(operationStatus?.GetRawResponse()?.Content?.ToString());
            JToken opProperties = operationStatusObj?["properties"];
            Assert.IsNotNull(opProperties);

            JToken status = opProperties?["status"];
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
            Response<GenericResource> operationStatus = await Client.GetGenericResources()
                .GetAsync(ResourceIdentifier.Parse(operation.Value.Id));
            JObject operationStatusObj = JObject.Parse(operationStatus?.GetRawResponse()?.Content?.ToString());
            JToken opProperties = operationStatusObj?["properties"];
            Assert.IsNotNull(opProperties);

            JToken status = opProperties?["status"];
            Assert.IsNotNull(status);
            if (status.ToString() == ImportOperationState.Succeeded.ToString())
            {
                Assert.IsNull(
                    opProperties?["errorExcelSasUri"].ToString(),
                    "Error excel SAS Uri exists for successfull import");
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
                Assert.IsNull(operationStatusObj?["error"], "Error exists for success case.");

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
                Assert.IsNotNull(operationStatusObj?["error"], "Error check.");
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
