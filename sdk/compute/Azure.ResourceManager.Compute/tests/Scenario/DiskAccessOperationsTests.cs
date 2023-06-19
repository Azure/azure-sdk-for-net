// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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

        private async Task<DiskAccessResource> CreateDiskAccessAsync(string name)
        {
            var collection = (await CreateResourceGroupAsync()).GetDiskAccesses();
            var input = ResourceDataHelper.GetEmptyDiskAccess(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var name = Recording.GenerateAssetName("testDA-");
            var access = await CreateDiskAccessAsync(name);
            await access.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var name = Recording.GenerateAssetName("testDA-");
            var access1 = await CreateDiskAccessAsync(name);
            DiskAccessResource access2 = await access1.GetAsync();

            ResourceDataHelper.AssertDiskAccess(access1.Data, access2.Data);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("testDA-");
            var diskAccess = await CreateDiskAccessAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            DiskAccessResource updated = await diskAccess.SetTagsAsync(tags);

            Assert.AreEqual(tags, updated.Data.Tags);
        }
    }
}
