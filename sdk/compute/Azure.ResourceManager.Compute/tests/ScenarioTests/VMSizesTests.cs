// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMSizesTests :ComputeClientBase
    {
        public VMSizesTests(bool isAsync)
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
        public async Task TestListVMSizes()
        {
            string location = DefaultLocation.Replace(" ", "");

            var virtualMachineSizeListResponse = await (VirtualMachineSizesOperations.ListAsync(location)).ToEnumerableAsync();
            Helpers.ValidateVirtualMachineSizeListResponse(virtualMachineSizeListResponse);
        }
    }
}
