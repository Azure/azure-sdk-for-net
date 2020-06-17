// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class UsageTests : VMTestBase
    {
        public UsageTests(bool isAsync)
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
        public async Task TestListUsages()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            VirtualMachine inputVM;

            try
            {
                // Create Storage Account, so that both the VMs can share it
                var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

                var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, imageRef);
                var vm1 = returnTwoVM.Item1;
                inputVM = returnTwoVM.Item2;
                // List Usages, and do weak validation to assure that some usages were returned.
                var luResponse = await (UsageClient.ListAsync(vm1.Location)).ToEnumerableAsync();

                ValidateListUsageResponse(luResponse);

                await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, inputVM.Name));
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        private void ValidateListUsageResponse(IEnumerable<Usage> luResponse)
        {
            Assert.NotNull(luResponse);
            Assert.True(luResponse.Count() > 0);

            // Can't do any validation on primitive fields, but will make sure strings are populated and non-null as expected.
            foreach (var usage in luResponse)
            {
                Assert.True(usage.Name.LocalizedValue != null);
                Assert.True(usage.Name.Value != null);
            }
        }
    }
}
