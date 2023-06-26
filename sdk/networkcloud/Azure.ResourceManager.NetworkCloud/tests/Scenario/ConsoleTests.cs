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
        public async Task Console()
        {
            // A console's name will always be set to "default"
            string ConsoleName = "default";
            ResourceIdentifier consoleId = ConsoleResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterRG, TestEnvironment.VMName, ConsoleName);
            ConsoleResource console = Client.GetConsoleResource(consoleId);

            // retrieve VM for which this console will be created for
            ResourceIdentifier vmId = VirtualMachineResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterRG, TestEnvironment.VMName);
            VirtualMachineResource virtualMachine = Client.GetVirtualMachineResource(vmId);
            virtualMachine = await virtualMachine.GetAsync();

            ConsoleCollection collection = virtualMachine.GetConsoles();

            DateTime expiration = DateTime.Parse(TestEnvironment.ConsoleExpirationDate);

            ConsoleData data = new ConsoleData
            (TestEnvironment.Location, new ExtendedLocation(TestEnvironment.ManagerExtendedLocation, "CustomLocation"), ConsoleEnabled.True, new SshPublicKey("ssh-rsa AAtsE3njSONzDYRIZv/WLjVuMfrUSByHp+jfaaOLHTIIB4fJvo6dQUZxE20w2iDHV3tEkmnTo84eba97VMueQD6OzJPEyWZMRpz8UYWOd0IXeRqiFu1lawNblZhwNT/ojNZfpB3af/YDzwQCZgTcTRyNNhL4o/blKUmug0daSsSXISTRnIDpcf5qytjs1Xo+yYyJMvzLL59mhAyb3p/cD+Y3/s3WhAx+l0XOKpzXnblrv9d3q4c2tWmm/SyFqthaqd0= fake-public-key"))
            {
                Expiration = expiration,
                Tags =
                {
                    [ "key1" ] = "value1",
                    [ "key2" ] = "value2",
                },
            };

            // Create
            ArmOperation<ConsoleResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ConsoleName, data);
            Assert.AreEqual(ConsoleName, createResult.Value.Data.Name);

            // Get
            var getResult = await console.GetAsync();
            Assert.AreEqual(ConsoleName, getResult.Value.Data.Name);

            // List
            var listByVirtualMachine = new List<ConsoleResource>();
            await foreach (ConsoleResource item in collection.GetAllAsync())
            {
                listByVirtualMachine.Add(item);
            }
            Assert.IsNotEmpty(listByVirtualMachine);

            // Update
            ConsolePatch patch = new ConsolePatch()
            {
                Enabled = ConsoleEnabled.False,
                Expiration = expiration,
                KeyData = "ssh-rsa AAtsE3njSONzDYRIZv/WLjVuMfrUSByHp+jfaaOLHTIIB4fJvo6dQUZxE20w2iDHV3tEkmnTo84eba97VMueQD6OzJPEyWZMRpz8UYWOd0IXeRqiFu1lawNblZhwNT/ojNZfpB3af/YDzwQCZgTcTRyNNhL4o/blKUmug0daSsSXISTRnIDpcf5qytjs1Xo+yYyJMvzLL59mhAyb3p/cD+Y3/s3WhAx+l0XOKpzXnblrv9d3q4c2tWmm/SyFqthaqd0= fake-public-key",
                Tags =
                {
                    ["key1"] = "newvalue1",
                    ["key2"] = "newvalue2",
                }
            };
            ArmOperation<ConsoleResource> updateResult = await console.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // Delete
            var deleteResult = await console.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
