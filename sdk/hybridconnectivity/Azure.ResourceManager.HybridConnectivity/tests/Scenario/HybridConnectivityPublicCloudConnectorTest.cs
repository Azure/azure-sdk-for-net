// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HybridConnectivity;
using Azure.ResourceManager.HybridConnectivity.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.HybridConnectivity.Tests.Scenario
{
    // Comment out the following code as it is not used in version 2023-03-01
    //[LiveOnly]
    //public class HybridConnectivityPublicCloudConnectorTest : HybridConnectivityManagementTestBase
    //{
    //    private HybridConnectivityPublicCloudConnectorResource _testConnector;

    //    private ResourceGroupResource _testRG;

    //    public HybridConnectivityPublicCloudConnectorTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
    //    {
    //    }

    //    [SetUp]
    //    public async Task TestSetUp()
    //    {
    //        _testRG = await CreateResourceGroup();
    //        Assert.IsNotNull(_testRG, "Resource Group initialization failed.");

    //        _testConnector = await CreatePublicCloudConnector(_testRG);
    //        Assert.IsNotNull(_testConnector, "Public Cloud Connector initialization failed.");
    //    }

    //    [TearDown]
    //    public async Task TearDown()
    //    {
    //        var deleteResp = await _testConnector.DeleteAsync(WaitUntil.Completed);
    //        Assert.AreEqual(200, deleteResp.GetRawResponse().Status);
    //    }

    //    [RecordedTest]
    //    public async Task TestPublicCloudConnector()
    //    {
    //        var connectorCollection = _testRG.GetHybridConnectivityPublicCloudConnectors();
    //        Assert.IsNotNull(connectorCollection);

    //        await createSolutionConfiguration();

    //        var testPermissionResp = await _testConnector.TestPermissionsAsync(WaitUntil.Completed);
    //        Assert.IsNotNull(testPermissionResp);
    //        Assert.AreEqual(200, testPermissionResp.GetRawResponse().Status);
    //    }

    //    [RecordedTest]
    //    public async Task TestSolutionConfiguration()
    //    {
    //        var sc = await createSolutionConfiguration();

    //        var patchData = new HybridConnectivitySolutionConfigurationPatch();
    //        patchData.Properties = new SolutionConfigurationPropertiesUpdate();
    //        patchData.Properties.SolutionType = "Microsoft.AssetManagement";
    //        patchData.Properties.SolutionSettings.Add("periodicSync", "true");
    //        patchData.Properties.SolutionSettings.Add("periodicSyncTime", "2");

    //        var updateResp = await sc.UpdateAsync(patchData);
    //        Assert.AreEqual(200, updateResp.GetRawResponse().Status);
    //        Assert.AreEqual("2", updateResp.Value.Data.Properties.SolutionSettings["periodicSyncTime"]);

    //        var deleteResp = await sc.DeleteAsync(WaitUntil.Completed);
    //        Assert.AreEqual(200, deleteResp.GetRawResponse().Status);
    //    }

    //    protected async Task<HybridConnectivitySolutionConfigurationResource> createSolutionConfiguration()
    //    {
    //        var scopeId = _testConnector.Id;
    //        var scCollection = ArmClient.GetHybridConnectivitySolutionConfigurations(scopeId);
    //        Assert.IsNotNull(scCollection);

    //        var scProperties = new SolutionConfigurationProperties(AssetManagementType);
    //        scProperties.SolutionSettings.Add("periodicSync", "true");
    //        scProperties.SolutionSettings.Add("periodicSyncTime", "1");
    //        scProperties.SolutionSettings.Add("cloudProviderServiceTypes", "ec2,s3");
    //        scProperties.SolutionSettings.Add("awsGlobalReadOnly", "true");
    //        scProperties.SolutionSettings.Add("cloudProviderRegions", "us-east-1");

    //        var scData = new HybridConnectivitySolutionConfigurationData();
    //        scData.Properties = scProperties;

    //        var scTask = await scCollection.CreateOrUpdateAsync(WaitUntil.Completed, SolutionConfigurationName, scData);
    //        var sc = scTask.Value;
    //        Assert.IsNotNull(sc);
    //        return sc;
    //    }
    //}
}
