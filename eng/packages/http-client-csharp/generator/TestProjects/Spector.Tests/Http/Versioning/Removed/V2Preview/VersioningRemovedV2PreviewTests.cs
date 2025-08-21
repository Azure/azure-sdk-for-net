// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias RemovedV2Preview;
using System.Threading.Tasks;
using NUnit.Framework;
using RemovedV2Preview::Versioning.Removed;

namespace TestProjects.Spector.Tests.Http.Versioning.Removed.V2Preview
{
    public class VersioningRemovedV2PreviewTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Versioning_Removed_V3Model() => Test(async (host) =>
        {
            var model = new ModelV3("123");
            var response = await new RemovedClient(host).ModelV3Async(model);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("123", response.Value.Id);
        });
    }
}
