// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests.Enums;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.Storage.Blobs;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests;
public static class SapDiscoveryTestsHelpers
{
    public const string MigrateProjectIdFormat =
        "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Migrate/MigrateProjects/{2}";

    public static bool AreSapInstancesListEqual(
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
                expectedListSapInstances[i].Environment != actualListSapInstances[i].Environment)
                return false;
        }
        return true;
    }

    public static bool AreServerInstancesListEqual(
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

    public static async Task<SAPDiscoverySiteResource> CreateSapDiscoverySiteAsync(AzureLocation targetRegion, ResourceGroupResource rg, string migrateProjectId, string discoverySiteName)
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
        return createDiscoverySiteOperation.Value;
    }

    public static List<SAPInstanceData> GetExpectedSapInstancesListFromJson(
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

    public static List<ServerInstanceData> GetExpectedServerInstancesListFromJson(
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

    public static async Task<List<SAPInstanceData>> GetSapInstancesListAsync(SAPDiscoverySiteResource sapDiscoverySiteResource)
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

    public static async Task<List<ServerInstanceData>> GetServerInstancesList(SAPInstanceResource sapInstance)
    {
        ServerInstanceCollection serverCollection = sapInstance.GetServerInstances();

        var serverInstancesList = new List<ServerInstanceData>();
        await foreach (ServerInstanceResource serverInstances in serverCollection.GetAllAsync())
        {
            serverInstancesList.Add(serverInstances.Data);
        }

        return serverInstancesList;
    }

    public static async Task PostImportEntities(SAPDiscoverySiteResource sapDiscoverySiteResource, string excelPathToImport, ArmClient client)
    {
        ArmOperation<OperationStatusResult> importEntitiesOp =
                        await sapDiscoverySiteResource.ImportEntitiesAsync(WaitUntil.Completed);

        Assert.IsNotNull(
            await TrackTillConditionReachedForAsyncOperationAsync(
                new Func<Task<bool>>(async () => await TrackForDiscoveryExcelInputSasUriAsync(
                    importEntitiesOp, client)), 300),
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
                    importEntitiesOp, client)), 300),
            "Excel Upload failed.");
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
    /// Get Blob Content client with blob uri and SaS token.
    /// </summary>
    /// <param name="sasUri">The SAS Uri of the blob.</param>
    /// <returns>Blob content client.</returns>
    public static BlobClient GetBlobContentClient(string sasUri)
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
        var blobClient = new BlobClient(
            new Uri(sasUriFragment[0]),
            new AzureSasCredential(sasUriFragment[1]));

        return blobClient;
    }

    public static async Task CreateMigrateProjectAsync(AzureLocation targetRegion, string migrateProjectId, ArmClient client)
    {
        // Create Migrate Project
        var CreateMigrateProjectPayload = new GenericResourceData(targetRegion)
        {
            Properties = new BinaryData(new Dictionary<string, object>
            {
                { "registeredTools", new string[] { "ServerAssessment" }}
            })
        };

        await client.GetGenericResources().CreateOrUpdateAsync(
            WaitUntil.Completed,
            ResourceIdentifier.Parse(migrateProjectId),
            CreateMigrateProjectPayload);
    }

    /// <summary>
    /// Track for input sas uri for excel upload.
    /// </summary>
    /// <param name="operation">Operation to poll.</param>
    /// <returns>If uri is now available to fetch.</returns>
    public static async Task<bool> TrackForDiscoveryExcelInputSasUriAsync(
        ArmOperation<OperationStatusResult> operation,
        ArmClient client)
    {
        Response<GenericResource> operationStatus = await client.GetGenericResources()
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
    public static async Task<bool> ValidateExcelParsingStatusAsync(
        int expectedRowsImported,
        int expectedTotalRows,
        ArmOperation<OperationStatusResult> operation, ArmClient client)
    {
        Response<GenericResource> operationStatus = await client.GetGenericResources()
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
