// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMRunCommandsTests : ComputeClientBase
    {
        public VMRunCommandsTests(bool isAsync)
        : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task TestListVMRunCommands()
        {
            string location = DefaultLocation.Replace(" ", "");
            string documentId = "RunPowerShellScript";

            // Verify the List of commands
            var runCommandList = VirtualMachineRunCommandsOperations.ListAsync(location);
            var runCommandListResponse = await runCommandList.ToEnumerableAsync();
            Assert.NotNull(runCommandListResponse);
            Assert.True(runCommandListResponse.Count() > 0, "ListRunCommands should return at least 1 command");
            RunCommandDocumentBase documentBase =
                runCommandListResponse.FirstOrDefault(x => string.Equals(x.Id, documentId));
            Assert.NotNull(documentBase);

            // Verify Get a specific RunCommand
            RunCommandDocument document = await VirtualMachineRunCommandsOperations.GetAsync(location, documentId);
            Assert.NotNull(document);
            Assert.NotNull(document.Script);
            Assert.True(document.Script.Count > 0, "Script should contain at least one command.");
            Assert.NotNull(document.Parameters);
            Assert.True(document.Parameters.Count == 2, "Script should have 2 parameters.");
        }
    }
}
