// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class ConsoleTests : NetworkCloudManagementTestBase
    {
        public ConsoleTests (bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public ConsoleTests (bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        [RecordedTest]
        public async Task Console()
        {
            // A console's name will always be set to "default"
            string ConsoleName = "default";
            ResourceIdentifier consoleId = NetworkCloudVirtualMachineConsoleResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterRG, TestEnvironment.VMName, ConsoleName);
            NetworkCloudVirtualMachineConsoleResource console = Client.GetNetworkCloudVirtualMachineConsoleResource(consoleId);

            // retrieve VM for which this console will be created for
            ResourceIdentifier vmId = NetworkCloudVirtualMachineResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterRG, TestEnvironment.VMName);
            NetworkCloudVirtualMachineResource virtualMachine = Client.GetNetworkCloudVirtualMachineResource(vmId);
            virtualMachine = await virtualMachine.GetAsync();

            NetworkCloudVirtualMachineConsoleCollection collection = virtualMachine.GetNetworkCloudVirtualMachineConsoles();

            DateTime expiration = DateTime.Parse(TestEnvironment.ConsoleExpirationDate);

            NetworkCloudVirtualMachineConsoleData data = new NetworkCloudVirtualMachineConsoleData
            (TestEnvironment.Location, new ExtendedLocation(TestEnvironment.ManagerExtendedLocation, "CustomLocation"), ConsoleEnabled.True, new NetworkCloudSshPublicKey("ssh-rsa AAtsE3njSONzDYRIZv/WLjVuMfrUSByHp+jfaaOLHTIIB4fJvo6dQUZxE20w2iDHV3tEkmnTo84eba97VMueQD6OzJPEyWZMRpz8UYWOd0IXeRqiFu1lawNblZhwNT/ojNZfpB3af/YDzwQCZgTcTRyNNhL4o/blKUmug0daSsSXISTRnIDpcf5qytjs1Xo+yYyJMvzLL59mhAyb3p/cD+Y3/s3WhAx+l0XOKpzXnblrv9d3q4c2tWmm/SyFqthaqd0= fake-public-key"))
            {
                ExpireOn = expiration,
                Tags =
                {
                    [ "key1" ] = "value1",
                    [ "key2" ] = "value2",
                },
            };

            // Create
            ArmOperation<NetworkCloudVirtualMachineConsoleResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ConsoleName, data);
            Assert.AreEqual(ConsoleName, createResult.Value.Data.Name);

            // Get
            var getResult = await console.GetAsync();
            Assert.AreEqual(ConsoleName, getResult.Value.Data.Name);

            // List
            var listByVirtualMachine = new List<NetworkCloudVirtualMachineConsoleResource>();
            await foreach (NetworkCloudVirtualMachineConsoleResource item in collection.GetAllAsync())
            {
                listByVirtualMachine.Add(item);
            }
            Assert.IsNotEmpty(listByVirtualMachine);

            // Update
            NetworkCloudVirtualMachineConsolePatch patch = new NetworkCloudVirtualMachineConsolePatch()
            {
                Enabled = ConsoleEnabled.False,
                ExpireOn = expiration,
                KeyData = "ssh-rsa AAtsE3njSONzDYRIZv/WLjVuMfrUSByHp+jfaaOLHTIIB4fJvo6dQUZxE20w2iDHV3tEkmnTo84eba97VMueQD6OzJPEyWZMRpz8UYWOd0IXeRqiFu1lawNblZhwNT/ojNZfpB3af/YDzwQCZgTcTRyNNhL4o/blKUmug0daSsSXISTRnIDpcf5qytjs1Xo+yYyJMvzLL59mhAyb3p/cD+Y3/s3WhAx+l0XOKpzXnblrv9d3q4c2tWmm/SyFqthaqd0= fake-public-key",
                Tags =
                {
                    ["key1"] = "newvalue1",
                    ["key2"] = "newvalue2",
                }
            };
            ArmOperation<NetworkCloudVirtualMachineConsoleResource> updateResult = await console.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // Delete
            var deleteResult = await console.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
