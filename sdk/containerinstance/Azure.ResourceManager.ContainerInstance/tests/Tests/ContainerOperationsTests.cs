// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerInstance.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerInstance.Tests.Tests
{
    public partial class ContainerOperationsTests : ContainerInstanceManagementClientBase
    {
        public ContainerOperationsTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task ContainersListLogsTest()
        {
            // Create resource group for test
            var location = await GetLocationAsync();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, location, resourceGroup);

            // Create container group for test
            var containerGroupName = Recording.GenerateAssetName(Helper.ContainerGroupPrefix);
            var containerGroupParam = Helper.CreateTestContainerGroup(containerGroupName, location);
            var containerGroup = (await WaitForCompletionAsync(await ContainerGroupsOperations.StartCreateOrUpdateAsync(resourceGroup, containerGroupName, containerGroupParam))).Value;
            // Get logs of contaniner group
            var containerLog = (await ContainersOperations.ListLogsAsync(resourceGroup, containerGroupName, containerGroupParam.Containers.FirstOrDefault().Name)).Value;
            Assert.NotNull(containerLog);
        }

        [Test]
        public async Task ContainersExecuteCommandTest()
        {
            // Create resource group for test
            var location = await GetLocationAsync();
            var resourceGroup = Recording.GenerateAssetName(Helper.ResourceGroupPrefix);
            await Helper.TryRegisterResourceGroupAsync(ResourceGroupsOperations, location, resourceGroup);

            // Create container group for test
            var containerGroupName = Recording.GenerateAssetName(Helper.ContainerGroupPrefix);
            var containerGroupParam = Helper.CreateTestContainerGroup(containerGroupName, location);
            var containerGroup = (await WaitForCompletionAsync(await ContainerGroupsOperations.StartCreateOrUpdateAsync(resourceGroup, containerGroupName, containerGroupParam))).Value;
            // Execute one command in container
            ContainerExecRequest containerExecRequest = new ContainerExecRequest()
            {
                Command = "/bin/bash",
                TerminalSize = new ContainerExecRequestTerminalSize() { Rows = 20, Cols = 80 }
            };
            var containerLog = (await ContainersOperations.ExecuteCommandAsync(resourceGroup, containerGroupName, containerGroupParam.Containers.FirstOrDefault().Name, containerExecRequest)).Value;
            Assert.NotNull(containerLog.WebSocketUri);
            Assert.NotNull(containerLog.Password);
        }
    }
}
