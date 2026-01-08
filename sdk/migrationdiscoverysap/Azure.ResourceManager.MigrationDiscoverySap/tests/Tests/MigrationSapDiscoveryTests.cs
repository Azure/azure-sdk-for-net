// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.MigrationDiscoverySap.Models;
using Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests.Enums;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.Storage.Blobs;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests;

public class MigrationSapDiscoveryTests : MigrationDiscoverySapManagementTestBase
{
    public MigrationSapDiscoveryTests(bool isAsync) : base(isAsync)
    {
        BodyKeySanitizers.Add(new BodyKeySanitizer("properties.discoveryExcelSasUri"));
    }

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
        SapDiscoveryTestsHelpers.MigrateProjectIdFormat,
            targetSubscriptionId,
            rgName,
            migrateProjName);
        string discoverySiteName = Recording.GenerateAssetName("SapDiscoverySite-");

        await SapDiscoveryTestsHelpers.CreateMigrateProjectAsync(Client, targetRegion, migrateProjectId);
        await SapDiscoveryTestsHelpers.CreateSapDiscoverySiteAsync(
            targetRegion,
            rg,
            migrateProjectId,
            discoverySiteName);

        // Get Sap DiscoverySite
        SapDiscoverySiteResource sapDiscoverySiteResource = await rg.GetSapDiscoverySiteAsync(discoverySiteName);
        Assert.That(sapDiscoverySiteResource.Data.ProvisioningState, Is.EqualTo(SapDiscoveryProvisioningState.Succeeded));
        string sapDiscoverySiteId = sapDiscoverySiteResource.Id.ToString();

        // Upload Excel to Sap DiscoverySite
        string excelPathToImport = @"TestData/ExcelSDKTesting.xlsx";
        await PostImportEntities(Client, sapDiscoverySiteResource, excelPathToImport);

        // Get List Sap Instances
        List<SapInstanceData> listSapInstances = await SapDiscoveryTestsHelpers
            .GetSapInstancesListAsync(sapDiscoverySiteResource);

        Assert.That(listSapInstances, Is.Not.Null);

        const string expectedSapInstancesListPath = @"TestData/ExpectedGetSapInstanceList.json";

        List<SapInstanceData> expectedListSapInstances = SapDiscoveryTestsHelpers.GetExpectedSapInstancesListFromJson(
            sapDiscoverySiteId,
            expectedSapInstancesListPath);

        listSapInstances = listSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();
        expectedListSapInstances = expectedListSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();

        Assert.That(listSapInstances.SequenceEqual(expectedListSapInstances, new SapInstanceDataComparer()), Is.True);

        // Get SapInstance
        ResourceIdentifier sapInstanceId = listSapInstances.First().Id;
        Assert.That(sapInstanceId, Is.Not.Null);
        SapInstanceResource sapInstance = await sapDiscoverySiteResource.GetSapInstanceAsync(sapInstanceId.Name);

        // Get Server Instances List

        List<SapDiscoveryServerInstanceData> serverInstancesList = await SapDiscoveryTestsHelpers.GetServerInstancesList(sapInstance);
        Assert.That(serverInstancesList, Is.Not.Null);

        const string expectedServerInstanceListPath = @"TestData/ExpectedGetServerInstancesList.json";

        List<SapDiscoveryServerInstanceData> expectedServerInstancesList = SapDiscoveryTestsHelpers
            .GetExpectedServerInstancesListFromJson(sapDiscoverySiteId, expectedServerInstanceListPath);

        serverInstancesList = serverInstancesList.OrderBy(server => server.Name.ToLower()).ToList();
        expectedServerInstancesList = expectedServerInstancesList.OrderBy(server => server.Name.ToLower()).ToList();

        Assert.That(serverInstancesList.SequenceEqual(expectedServerInstancesList, new ServerInstanceDataComparer()), Is.True);

        // Get ServerInstance
        ResourceIdentifier serverInstanceId = serverInstancesList.First().Id;
        SapDiscoveryServerInstanceResource serverInstance = await sapInstance.GetSapDiscoveryServerInstanceAsync(serverInstanceId.Name);

        //Patch Sap DiscoverySite
        var discoverySitePatch = new SapDiscoverySitePatch();
        discoverySitePatch.Tags.Add("Key1", "TestPatchValue");
        sapDiscoverySiteResource = await sapDiscoverySiteResource.UpdateAsync(discoverySitePatch);
        string discoverySitetagValue = string.Empty;
        Assert.Multiple(() =>
        {
            Assert.That(sapDiscoverySiteResource.Data.Tags.TryGetValue("Key1", out discoverySitetagValue), Is.True);
            Assert.That(discoverySitetagValue, Is.EqualTo("TestPatchValue"));
        });

        //Patch Sap Instance
        var sapInstancePatch = new SapInstancePatch();
        sapInstancePatch.Tags.Add("Key1", "TestPatchValue");
        sapInstance = await sapInstance.UpdateAsync(sapInstancePatch);
        string sapInstancetagValue = string.Empty;
        Assert.Multiple(() =>
        {
            Assert.That(sapInstance.Data.Tags.TryGetValue("Key1", out sapInstancetagValue), Is.True);
            Assert.That(sapInstancetagValue, Is.EqualTo("TestPatchValue"));
        });

        // Delete Sap DiscoverySite
        await sapDiscoverySiteResource.DeleteAsync(WaitUntil.Completed);
    }

    public override void GlobalTimeoutTearDown()
    {
        if (Debugger.IsAttached)
        {
            return;
        }
    }

    public async Task PostImportEntities(ArmClient client, SapDiscoverySiteResource sapDiscoverySiteResource, string excelPathToImport)
    {
        ArmOperation<OperationStatusResult> importEntitiesOp =
            await sapDiscoverySiteResource.ImportEntitiesAsync(WaitUntil.Completed);

        Assert.That(await SapDiscoveryTestsHelpers.TrackTillConditionReachedForAsyncOperationAsync(
            new Func<Task<bool>>(async () => await SapDiscoveryTestsHelpers.TrackForDiscoveryExcelInputSasUriAsync(
                client, importEntitiesOp)), 300),
            Is.Not.Null,
            "SAS Uri generation failed");

        // Skipping Upload while TestMode as playback, as
        // Blob client is a data-plane client which can't simply interact with HttpMockServer.
        if (SessionEnvironment.Mode != RecordedTestMode.Playback)
        {
            Response opStatus = await importEntitiesOp.UpdateStatusAsync();
            var operationStatusObj = JObject.Parse(opStatus.Content.ToString());
            var inputExcelSasUri = operationStatusObj?["properties"]?["discoveryExcelSasUri"].ToString();

            //Upload here
            using (FileStream stream = File.OpenRead(excelPathToImport))
            {
                // Construct the blob client with a sas token.
                var blobClient = GetBlobContentClient(inputExcelSasUri);

                await blobClient.UploadAsync(stream, overwrite: true);
            }
        }

        Assert.That(await SapDiscoveryTestsHelpers.TrackTillConditionReachedForAsyncOperationAsync(
            new Func<Task<bool>>(async () => await SapDiscoveryTestsHelpers.ValidateExcelParsingStatusAsync(
                client,
                importEntitiesOp.Value.Id,
                43,
                47)), 300),
            Is.True,
            "Excel Upload failed.");
    }

    /// <summary>
    /// Get Blob Content client with blob uri and SaS token.
    /// </summary>
    /// <param name="sasUri">The SAS Uri of the blob.</param>
    /// <returns>Blob content client.</returns>
    public BlobClient GetBlobContentClient(string sasUri)
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
        var blobClient = InstrumentClient(new BlobClient(
            new Uri(sasUriFragment[0]),
            new AzureSasCredential(sasUriFragment[1])));

        return blobClient;
    }
}
