// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests
{
    public class VnetVerifierTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private NetworkManagerResource _networkManager;
        private string _vnetVerifierName;
        private string _analysisRunName;
        private string _analysisIntentName;
        private VerifierWorkspaceResource _vnetVerifier;
        private ReachabilityAnalysisIntentResource _analysisIntent;
        private ReachabilityAnalysisRunResource _analysisRun;
        private readonly AzureLocation _location = AzureLocation.CentralUS;
        private ResourceIdentifier _networkManagerId;

        public VnetVerifierTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            // Get the default subscription
            _subscription = await GlobalClient.GetDefaultSubscriptionAsync();

            // Create a resource group
            string resourceGroupName = SessionRecording.GenerateAssetName("vnetverifier-dotnet-sdk-tests-RG-");
            _resourceGroup = await _subscription.CreateResourceGroupAsync(resourceGroupName, _location);

            // Create a network manager
            string networkManagerName = SessionRecording.GenerateAssetName("networkManager-");
            _networkManager = await _resourceGroup.CreateNetworkManagerAsync(
                networkManagerName,
                _location,
                new List<string> { _subscription.Data.Id },
                new List<NetworkConfigurationDeploymentType> { });

            _networkManagerId = _networkManager.Id;

            _vnetVerifierName = SessionRecording.GenerateAssetName("vnetVerifier-");
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _vnetVerifier = await _resourceGroup.CreateVerifierWorkspaceAsync(_networkManager, _vnetVerifierName, _location);
            _analysisIntentName = SessionRecording.GenerateAssetName("analysisIntent-");
            _analysisIntent = await _vnetVerifier.CreateAnalysisIntentAsync(_analysisIntentName, new ResourceIdentifier("/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/testVM"),
                new ResourceIdentifier ("/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/ipam-test-vm-integration-test"),
                new List<string>() { "10.0.0.1/24" }, new List<string>() { "10.0.8.0/24" }, new List<string>() { "22" }, new List<string>() { "*" }, new List<NetworkProtocol>() { "TCP" });
            _analysisRunName = SessionRecording.GenerateAssetName("analysisRun-");
            _analysisRun = await _vnetVerifier.CreateAnalysisRunAsync(_analysisRunName, "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Network/networkManagers/arjun-test-nm/verifierWorkspaces/arjun-test-nm/reachabilityAnalysisIntents/myAnalysisIntent");
        }

        [TearDown]
        public async Task Teardown()
        {
            if (await _networkManager.GetVerifierWorkspaces().ExistsAsync(_vnetVerifierName))
            {
                await _vnetVerifier.DeleteVnetVerifierAsync(_networkManager);
            }
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            var vnetVerifier = await _networkManager.GetVerifierWorkspaces().GetAsync(_vnetVerifierName);
            Assert.IsNotNull(vnetVerifier.Value.Data);
            Assert.AreEqual(_vnetVerifierName, vnetVerifier.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            List<VerifierWorkspaceResource> vnetVerifierList = await _networkManager.GetVerifierWorkspaces().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, vnetVerifierList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            await _vnetVerifier.DeleteVnetVerifierAsync(_networkManager);
            var vnetVerifierList = await _networkManager.GetVerifierWorkspaces().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, vnetVerifierList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetAnalysisIntent()
        {
            ReachabilityAnalysisIntentResource analysisIntent = await _vnetVerifier.GetReachabilityAnalysisIntents().GetAsync(_analysisIntentName);
            Assert.IsNotNull(analysisIntent.Data);
            Assert.AreEqual(_analysisIntent, analysisIntent.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllAnalysisIntent()
        {
            List<ReachabilityAnalysisIntentResource> analysisIntentList = await _vnetVerifier.GetReachabilityAnalysisIntents().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, analysisIntentList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task DeleteAnalysisIntent()
        {
            string analysisIntentName = SessionRecording.GenerateAssetName("analysisIntent-");
            var analysisIntent = await _vnetVerifier.CreateAnalysisIntentAsync(_analysisIntentName, new ResourceIdentifier("/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/testVM"),
                new ResourceIdentifier("/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Compute/virtualMachines/ipam-test-vm-integration-test"),
                new List<string>() { "10.0.0.1/24" }, new List<string>() { "10.0.8.0/24" }, new List<string>() { "22" }, new List<string>() { "*" }, new List<NetworkProtocol>() { "TCP" });

            Assert.IsNotNull(analysisIntent.Data);
            Assert.AreEqual(analysisIntentName, analysisIntent.Data.Name);

            await _vnetVerifier.DeleteAnalysisIntentAsync(analysisIntent);
            var analysisIntentList = await _vnetVerifier.GetReachabilityAnalysisIntents().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, analysisIntentList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetAnalysisRun()
        {
            ReachabilityAnalysisRunResource analysisRun = await _vnetVerifier.GetReachabilityAnalysisRuns().GetAsync(_analysisRunName);
            Assert.IsNotNull(analysisRun.Data);
            Assert.AreEqual(_analysisRunName, analysisRun.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllAnalysisRun()
        {
            List<ReachabilityAnalysisRunResource> analysisRunList = await _vnetVerifier.GetReachabilityAnalysisRuns().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, analysisRunList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task DeleteAnalysisRun()
        {
            string analysisRunName = SessionRecording.GenerateAssetName("analysisRun-");
            var analysisRun = await _vnetVerifier.CreateAnalysisRunAsync(analysisRunName, "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359/resourceGroups/ipam-test-rg/providers/Microsoft.Network/networkManagers/arjun-test-nm/verifierWorkspaces/arjun-test-nm/reachabilityAnalysisIntents/myAnalysisIntent");
            Assert.IsNotNull(analysisRun.Data);
            Assert.AreEqual(analysisRunName, analysisRun.Data.Name);

            await _vnetVerifier.DeleteAnalysisRunAsync(analysisRun);
            var analysisRunList = await _vnetVerifier.GetReachabilityAnalysisRuns().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, analysisRunList.Count);
        }
    }
}
