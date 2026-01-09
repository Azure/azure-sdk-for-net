// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
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
            (TestEnvironment.Location, new ExtendedLocation(TestEnvironment.ManagerExtendedLocation, "CustomLocation"), ConsoleEnabled.True, new NetworkCloudSshPublicKey("ssh-rsa REDACTED"))
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
            Assert.That(createResult.Value.Data.Name, Is.EqualTo(ConsoleName));

            // Get
            var getResult = await console.GetAsync();
            Assert.That(getResult.Value.Data.Name, Is.EqualTo(ConsoleName));

            // List
            var listByVirtualMachine = new List<NetworkCloudVirtualMachineConsoleResource>();
            await foreach (NetworkCloudVirtualMachineConsoleResource item in collection.GetAllAsync())
            {
                listByVirtualMachine.Add(item);
            }
            Assert.That(listByVirtualMachine, Is.Not.Empty);

            // Update
            NetworkCloudVirtualMachineConsolePatch patch = new NetworkCloudVirtualMachineConsolePatch()
            {
                Enabled = ConsoleEnabled.False,
                ExpireOn = expiration,
                KeyData = "ssh-rsa REDACTED",
                Tags =
                {
                    ["key1"] = "newvalue1",
                    ["key2"] = "newvalue2",
                }
            };
            ArmOperation<NetworkCloudVirtualMachineConsoleResource> updateResult = await console.UpdateAsync(WaitUntil.Completed, patch);
            Assert.That(updateResult.Value.Data.Tags, Is.EqualTo(patch.Tags));

            // Delete
            var deleteResult = await console.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.That(deleteResult.HasCompleted, Is.True);
        }
    }
}
