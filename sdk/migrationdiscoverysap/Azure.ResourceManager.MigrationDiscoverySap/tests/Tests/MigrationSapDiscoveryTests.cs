// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MigrationDiscoverySap.Models;
using Azure.ResourceManager.Resources;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests.Tests;

public class MigrationSapDiscoveryTests : MigrationDiscoverySapManagementTestBase
{
    public MigrationSapDiscoveryTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
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

        // Get Sap DiscoverySite
        SapDiscoverySiteResource sapDiscoverySiteResource = await rg.GetSapDiscoverySiteAsync(discoverySiteName);
        Assert.AreEqual(SapDiscoveryProvisioningState.Succeeded, sapDiscoverySiteResource.Data.ProvisioningState);
        string sapDiscoverySiteId = sapDiscoverySiteResource.Id.ToString();

        // Upload Excel to Sap DiscoverySite
        string excelPathToImport = @"TestData\ExcelSDKTesting.xlsx";
        await SapDiscoveryTestsHelpers.PostImportEntities(Client, sapDiscoverySiteResource, excelPathToImport);

        // Get List Sap Instances
        List<SapInstanceData> listSapInstances = await SapDiscoveryTestsHelpers
            .GetSapInstancesListAsync(sapDiscoverySiteResource);

        Assert.IsNotNull(listSapInstances);

        const string expectedSapInstancesListPath = @"TestData\ExpectedGetSapInstanceList.json";

        List<SapInstanceData> expectedListSapInstances = SapDiscoveryTestsHelpers.GetExpectedSapInstancesListFromJson(
            sapDiscoverySiteId,
            expectedSapInstancesListPath);

        listSapInstances = listSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();
        expectedListSapInstances = expectedListSapInstances.OrderBy(instance => instance.Id.ToString().ToLower()).ToList();

        Assert.IsTrue(listSapInstances.SequenceEqual(expectedListSapInstances, new SapInstanceDataComparer()));

        // Get SapInstance
        ResourceIdentifier sapInstanceId = listSapInstances.First().Id;
        Assert.IsNotNull(sapInstanceId);
        SapInstanceResource sapInstance = await sapDiscoverySiteResource.GetSapInstanceAsync(sapInstanceId.Name);

        // Get Server Instances List

        List<SapDiscoveryServerInstanceData> serverInstancesList = await SapDiscoveryTestsHelpers.GetServerInstancesList(sapInstance);
        Assert.IsNotNull(serverInstancesList);

        const string expectedServerInstanceListPath = @"TestData\ExpectedGetServerInstancesList.json";

        List<SapDiscoveryServerInstanceData> expectedServerInstancesList = SapDiscoveryTestsHelpers
            .GetExpectedServerInstancesListFromJson(sapDiscoverySiteId, expectedServerInstanceListPath);

        serverInstancesList = serverInstancesList.OrderBy(server => server.Name.ToLower()).ToList();
        expectedServerInstancesList = expectedServerInstancesList.OrderBy(server => server.Name.ToLower()).ToList();

        Assert.IsTrue(serverInstancesList.SequenceEqual(expectedServerInstancesList, new ServerInstanceDataComparer()));

        // Get ServerInstance
        ResourceIdentifier serverInstanceId = serverInstancesList.First().Id;
        SapDiscoveryServerInstanceResource serverInstance = await sapInstance.GetSapDiscoveryServerInstanceAsync(serverInstanceId.Name);

        //Patch Sap DiscoverySite
        var discoverySitePatch = new SapDiscoverySitePatch();
        discoverySitePatch.Tags.Add("Key1", "TestPatchValue");
        sapDiscoverySiteResource = await sapDiscoverySiteResource.UpdateAsync(discoverySitePatch);
        string discoverySitetagValue = string.Empty;
        Assert.IsTrue(sapDiscoverySiteResource.Data.Tags.TryGetValue("Key1", out discoverySitetagValue));
        Assert.AreEqual(discoverySitetagValue, "TestPatchValue");

        //Patch Sap Instance
        var sapInstancePatch = new SapInstancePatch();
        sapInstancePatch.Tags.Add("Key1", "TestPatchValue");
        sapInstance = await sapInstance.UpdateAsync(sapInstancePatch);
        string sapInstancetagValue = string.Empty;
        Assert.IsTrue(sapInstance.Data.Tags.TryGetValue("Key1", out sapInstancetagValue));
        Assert.AreEqual(sapInstancetagValue, "TestPatchValue");

        // Delete Sap DiscoverySite
        await sapDiscoverySiteResource.DeleteAsync(WaitUntil.Completed);
    }
}
