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
            ResourceGroupResource rg = await CreateResourceGroup(
                DefaultSubscription,
                "SdkTest-Net-",
                AzureLocation.SoutheastAsia);

            string rgName = rg.Id.Name;
            string migrateProjName = Recording.GenerateAssetName("migrateProj-");
            string migrateProjectId = string.Format(
                MigrateProjectIdFormat,
                DefaultSubscription.Data.SubscriptionId,
                rgName, migrateProjName);
            string discoverySiteName = Recording.GenerateAssetName("SapDiscoverySite-");

            // Create Migrate Project
            var CreateMigrateProjectPayload = new GenericResourceData(AzureLocation.SoutheastAsia)
            {
                Properties = new BinaryData(new Dictionary<string, object>
                {
                    { "registeredTools", new string[] { "ServerAssessment" }}
                })
            };

            ArmOperation<GenericResource> operationStatus = await Client.GetGenericResources()
                .CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    ResourceIdentifier.Parse(migrateProjectId),
                    CreateMigrateProjectPayload);

            // Create Discovery site payload
            var site = new SAPDiscoverySiteData()
            {
                MigrateProjectId = migrateProjectId,
                Location = AzureLocation.SoutheastAsia,
            };

            // Create discovery site
            ArmOperation<SAPDiscoverySiteResource> discoverySiteOp = await rg.GetSAPDiscoverySites()
                .CreateOrUpdateAsync(WaitUntil.Completed, discoverySiteName, site);
            ResourceIdentifier resourceId = discoverySiteOp.Value.Id;

            // Get SAP DiscoverySite
            SAPDiscoverySiteResource sapDiscoverySiteResource = Client.GetSAPDiscoverySiteResource(resourceId);
            Assert.Equals(sapDiscoverySiteResource.Data.ProvisioningState, ProvisioningState.Succeeded);

            // Post import entities
            ArmOperation<OperationStatusResult> importEntitiesOp =
                await sapDiscoverySiteResource.ImportEntitiesAsync(WaitUntil.Completed);

            Assert.IsNotNull(
                await TrackTillConditionReachedForAsyncOperationAsync(
                    new Func<Task<bool>>(async () => await this.TrackForDiscoveryExcelInputSasUriAsync(
                        importEntitiesOp)), 300),
                "SAS Uri generation failed");

            Response opStatus = await importEntitiesOp.UpdateStatusAsync();
            var operationStatusObj = JObject.Parse(opStatus.Content.ToString());
            var inputExcelSasUri = operationStatusObj?["properties"]?["discoveryExcelSasUri"].ToString();

            //Upload here
            using (FileStream stream = File.OpenRead(@"TestData\ExcelSDKTesting.xlsx"))
            {
                // Construct the blob client with a sas token.
                var blobClient = GetBlobContentClient(inputExcelSasUri);

                await blobClient.UploadAsync(stream, overwrite: true);
            }

            Assert.IsTrue(
                await TrackTillConditionReachedForAsyncOperationAsync(
                    new Func<Task<bool>>(async () => await ValidateExcelParsingStatusAsync(
                        43,
                        47,
                        importEntitiesOp)), 300),
                "Excel Upload failed.");

            // Get List SAP Instances
            SAPInstanceCollection sapInstancescollection = sapDiscoverySiteResource.GetSAPInstances();

            var listSapInstances = new List<SAPInstanceData>();
            // invoke the operation and iterate over the result
            await foreach (SAPInstanceResource instance in sapInstancescollection.GetAllAsync())
            {
                listSapInstances.Add(instance.Data);
            }

            Assert.IsNotNull(listSapInstances);

            const string expectedSapInstancesListPath = @"TestData\ExpectedGetSapInstanceList.json";
            const string sapDiscoverySiteJsonPayloadConstant = "__SapDiscoverySIteId__";

            var expectedSapInstancesString = File.ReadAllText(expectedSapInstancesListPath)
                .Replace(sapDiscoverySiteJsonPayloadConstant, sapDiscoverySiteResource.Id.ToString());

            JsonElement expectedSapInstancesJson = JsonDocument.Parse(expectedSapInstancesString).RootElement;
            var expectedList = new List<SAPInstanceData>();
            using (JsonElement.ArrayEnumerator expectedSapInstancesArray = expectedSapInstancesJson.EnumerateArray())
            {
                for (int i = 0; i < expectedSapInstancesArray.Count(); i++)
                {
                    JsonElement instance = expectedSapInstancesArray.ElementAt(i);
                    expectedList.Add(SAPInstanceData.DeserializeSAPInstanceData(instance));
                }
            }

            Assert.AreEqual(expectedList.Count, listSapInstances.Count);

            listSapInstances = listSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();
            expectedList = expectedList.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();
            for (int i = 0; i < listSapInstances.Count; i++)
            {
                Assert.AreEqual(expectedList[i].Location, listSapInstances[i].Location);
                Assert.AreEqual(expectedList[i].LandscapeSid, listSapInstances[i].LandscapeSid);
                Assert.AreEqual(expectedList[i].Name, listSapInstances[i].Name);
                Assert.AreEqual(expectedList[i].SystemSid, listSapInstances[i].SystemSid);
                Assert.AreEqual(expectedList[i].ProvisioningState, listSapInstances[i].ProvisioningState);
                Assert.AreEqual(expectedList[i].Environment, listSapInstances[i].Environment);
            }

            // Get SapInstance
            ResourceIdentifier sapInstanceId = listSapInstances.First().Id;
            Assert.IsNotNull(sapInstanceId);
            SAPInstanceResource sapInstance = Client.GetSAPInstanceResource(sapInstanceId);

            // get the collection of this ServerInstanceResource
            ServerInstanceCollection serverCollection = sapInstance.GetServerInstances();

            var serverInstancesList = new List<ServerInstanceData>();
            await foreach (ServerInstanceResource serverInstances in serverCollection.GetAllAsync())
            {
                serverInstancesList.Add(serverInstances.Data);
            }
            Assert.IsNotNull(serverInstancesList);

            const string expectedServerInstanceListPath = @"TestData\ExpectedGetServerInstancesList.json";

            var serverInstancesJsonString = File.ReadAllText(expectedServerInstanceListPath)
                .Replace(sapDiscoverySiteJsonPayloadConstant, sapDiscoverySiteResource.Id.ToString());
            JsonElement serverInstancesjson = JsonDocument.Parse(serverInstancesJsonString).RootElement;
            var expectedServerInstancesList = new List<ServerInstanceData>();
            JsonElement.ArrayEnumerator serverInstArray = serverInstancesjson.EnumerateArray();
            for (int i = 0; i < serverInstArray.Count(); i++)
            {
                JsonElement obj = serverInstArray.ElementAt(i);
                expectedServerInstancesList.Add(ServerInstanceData.DeserializeServerInstanceData(obj));
            }

            Assert.AreEqual(expectedServerInstancesList.Count(), serverInstancesList.Count());

            serverInstancesList = serverInstancesList.OrderBy(server => server.Name.ToLower()).ToList();
            expectedServerInstancesList = expectedServerInstancesList.OrderBy(server => server.Name.ToLower()).ToList();
            for (int i = 0; i < serverInstancesList.Count; i++)
            {
                Assert.AreEqual(expectedServerInstancesList[i].Name, serverInstancesList[i].Name);
                Assert.AreEqual(expectedServerInstancesList[i].ServerName, serverInstancesList[i].ServerName);
                Assert.AreEqual(expectedServerInstancesList[i].InstanceSid, serverInstancesList[i].InstanceSid);
            }

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
