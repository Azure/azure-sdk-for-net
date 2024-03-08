// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MigrationDiscoverySap.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests;

public class MigrationSapDiscoveryTests : MigrationDiscoverySapManagementTestBase
{
    public MigrationSapDiscoveryTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback)
    {
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

        // Get SAP DiscoverySite
        SAPDiscoverySiteResource sapDiscoverySiteResource = await rg.GetSAPDiscoverySiteAsync(discoverySiteName);
        Assert.AreEqual(ProvisioningState.Succeeded, sapDiscoverySiteResource.Data.ProvisioningState);
        string sapDiscoverySiteId = sapDiscoverySiteResource.Id.ToString();

        // Upload Excel to SAP DiscoverySite
        string excelPathToImport = @"TestData\ExcelSDKTesting.xlsx";
        await SapDiscoveryTestsHelpers.PostImportEntities(Client, sapDiscoverySiteResource, excelPathToImport);

        // Get List SAP Instances
        List<SAPInstanceData> listSapInstances = await SapDiscoveryTestsHelpers
            .GetSapInstancesListAsync(sapDiscoverySiteResource);

        Assert.IsNotNull(listSapInstances);

        const string expectedSapInstancesListPath = @"TestData\ExpectedGetSapInstanceList.json";

        List<SAPInstanceData> expectedListSapInstances = SapDiscoveryTestsHelpers.GetExpectedSapInstancesListFromJson(
            sapDiscoverySiteId,
            expectedSapInstancesListPath);

        listSapInstances = listSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();
        expectedListSapInstances = expectedListSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();

        Assert.IsTrue(SapDiscoveryTestsHelpers.AreSapInstancesListEqual(listSapInstances, expectedListSapInstances));

        // Get SapInstance
        ResourceIdentifier sapInstanceId = listSapInstances.First().Id;
        Assert.IsNotNull(sapInstanceId);
        SAPInstanceResource sapInstance = await sapDiscoverySiteResource.GetSAPInstanceAsync(sapInstanceId.Name);

        // Get Server Instances List

        List<ServerInstanceData> serverInstancesList = await SapDiscoveryTestsHelpers.GetServerInstancesList(sapInstance);
        Assert.IsNotNull(serverInstancesList);

        const string expectedServerInstanceListPath = @"TestData\ExpectedGetServerInstancesList.json";

        List<ServerInstanceData> expectedServerInstancesList = SapDiscoveryTestsHelpers
            .GetExpectedServerInstancesListFromJson(sapDiscoverySiteId, expectedServerInstanceListPath);

        serverInstancesList = serverInstancesList.OrderBy(server => server.Name.ToLower()).ToList();
        expectedServerInstancesList = expectedServerInstancesList.OrderBy(server => server.Name.ToLower()).ToList();

        Assert.IsTrue(SapDiscoveryTestsHelpers.AreServerInstancesListEqual(serverInstancesList, expectedServerInstancesList));

        // Get ServerInstance
        ResourceIdentifier serverInstanceId = serverInstancesList.First().Id;
        ServerInstanceResource serverInstance = await sapInstance.GetServerInstanceAsync(serverInstanceId.Name);

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
}
