﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class CheckConnectivityTests : NetworkServiceClientTestBase
    {
        public CheckConnectivityTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    await CleanupResourceGroupsAsync();
        //}

        [Test]
        public async Task CheckConnectivityVmToInternetTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));
            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with a template
            await CreateVm(
                resourcesClient: ResourceManagementClient,
                resourceGroupName: resourceGroupName,
                location: location,
                virtualMachineName: virtualMachineName,
                storageAccountName: Recording.GenerateAssetName("azsmnet"),
                networkInterfaceName: networkInterfaceName,
                networkSecurityGroupName: networkSecurityGroupName,
                diagnosticsStorageAccountName: Recording.GenerateAssetName("azsmnet"),
                deploymentName: Recording.GenerateAssetName("azsmnet"),
                adminPassword: Recording.GenerateAlphaNumericId("AzureSDKNetworkTest#")
                );

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);

            //Deploy networkWatcherAgent on VM
            VirtualMachineExtension parameters = new VirtualMachineExtension(location)
            {
                Publisher = "Microsoft.Azure.NetworkWatcher",
                TypeHandlerVersion = "1.4",
                TypePropertiesType = "NetworkWatcherAgentWindows"
            };

            VirtualMachineExtensionsCreateOrUpdateOperation createOrUpdateOperation = await ComputeManagementClient.VirtualMachineExtensions.StartCreateOrUpdateAsync(resourceGroupName, getVm.Value.Name, "NetworkWatcherAgent", parameters);
            await createOrUpdateOperation.WaitForCompletionAsync();;

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await networkWatcherContainer.CreateOrUpdateAsync("NetworkWatcherRG", "NetworkWatcher_westus2", properties);

            ConnectivityParameters connectivityParameters =
                new ConnectivityParameters(new ConnectivitySource(getVm.Value.Id), new ConnectivityDestination { Address = "bing.com", Port = 80 });

            Operation<ConnectivityInformation> connectivityCheckOperation = await GetResourceGroup("NetworkWatcherRG").GetNetworkWatchers().Get("NetworkWatcher_westus2").Value.StartCheckConnectivityAsync(connectivityParameters);
            Response<ConnectivityInformation> connectivityCheck = await connectivityCheckOperation.WaitForCompletionAsync();;

            //Validation
            Assert.AreEqual("Reachable", connectivityCheck.Value.ConnectionStatus.ToString());
            Assert.AreEqual(0, connectivityCheck.Value.ProbesFailed);
            Assert.AreEqual("Source", connectivityCheck.Value.Hops.FirstOrDefault().Type);
            Assert.AreEqual("Internet", connectivityCheck.Value.Hops.LastOrDefault().Type);
        }
    }
}
