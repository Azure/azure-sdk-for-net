// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DiskAccessOperationsTests : ComputeTestBase
    {
        public DiskAccessOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DiskAccess> CreateDiskAccessAsync(string name)
        {
            var collection = (await CreateResourceGroupAsync()).GetDiskAccesses();
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(name, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var name = Recording.GenerateAssetName("testDA-");
            var access = await CreateDiskAccessAsync(name);
            await access.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var name = Recording.GenerateAssetName("testDA-");
            var access1 = await CreateDiskAccessAsync(name);
            DiskAccess access2 = await access1.GetAsync();

            ResourceDataHelper.AssertDiskAccess(access1.Data, access2.Data);
        }
    }
}
